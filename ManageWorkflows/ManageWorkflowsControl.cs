using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Net;
using System.IO;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Client;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;

namespace ManageWorkflows
{
    public partial class ManageWorkflowsControl : PluginControlBase
    {
        private Settings mySettings;

        public ManageWorkflowsControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {            
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetWorkflows);
        }

        private void GetWorkflows()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting workflows",
                Work = (worker, args) =>
                {
                    // Instantiate QueryExpression QEworkflow
                    QueryExpression QEworkflow = new QueryExpression("workflow");

                    // Add columns to QEworkflow.ColumnSet
                    //QEworkflow.ColumnSet.AllColumns = true;
                    QEworkflow.ColumnSet.AddColumns("name", "uniquename", "statecode", "primaryentity", "ownerid", "createdon", "category", "type", "businessprocesstype", "workflowid");
                    QEworkflow.AddOrder("name", OrderType.Ascending);

                    args.Result = Service.RetrieveMultiple(QEworkflow);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    EntityCollection result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        //MessageBox.Show($"Found {result.Entities.Count} workflows");

                        checkedListBox1.DisplayMember = "name";
                        foreach (Entity item in result.Entities)
                        {
                            string type = item.FormattedValues["type"];

                            if (type != "Definition")
                                continue;

                            string name = item["name"].ToString();
                            string category = item.FormattedValues["category"];

                            string businessprocesstype = "";
                            if (item.Contains("businessprocesstype"))
                                businessprocesstype = item.FormattedValues["businessprocesstype"];

                            string workflowid = item["workflowid"].ToString();
                            bool isChecked = item.FormattedValues["statecode"] == "Activated" ? true : false;
                            checkedListBox1.Items.Add(new WorkflowList { FriendlyValue = name, RealValue = workflowid, State = isChecked }, isChecked);
                        }
                        checkedListBox1.DisplayMember = "FriendlyValue";
                        checkedListBox1.ValueMember = "RealValue";
                    }
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void btnBrowseImportFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Select Workflows export Excel file",
                Filter = "Excel Workbook|*.xlsx"
            };

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                txtFilePath.Text = ofd.FileName;
            }
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Hashtable processList;
            if (txtFilePath.Text.Length == 0)
                return;
            if (File.Exists(txtFilePath.Text))
            {
                processList = ReadExcelFile(txtFilePath.Text);

                //checkedListBox1.Items.Clear();
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    WorkflowList item = (WorkflowList)checkedListBox1.Items[i];
                    string guidValue = item.RealValue.ToString();
                    bool statusValue = checkedListBox1.GetItemCheckState(i).ToString() == "Checked" ? true : false;

                    if (processList[guidValue] == null)
                        continue;

                    string excelStatusValue = processList[guidValue].ToString();
                    bool excelStatus = excelStatusValue == "Activated" ? true : false;

                    if (statusValue != excelStatus)
                    {
                        checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(item), excelStatus);
                    }


                }
            }
        }


        private static Hashtable ReadExcelFile(string filePath)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filePath, 0, true);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Excel.Range xlRange = xlWorkSheet.UsedRange;
            int totalRows = xlRange.Rows.Count;
            int totalColumns = xlRange.Columns.Count;

            string nameValue, statusValue, guidValue;

            Hashtable col = new Hashtable();
            for (int colCount = 1; colCount <= totalColumns; colCount++)
            {
                string columnValue = Convert.ToString((xlRange.Cells[1, colCount] as Excel.Range).Text);
                if (columnValue.Length == 0)
                    continue;
                col.Add(columnValue, colCount);
            }

            Hashtable processList = new Hashtable();
            if (col.ContainsKey("Process Name") && col.ContainsKey("Status") && col.ContainsKey("(Do Not Modify) Process"))
            {
                for (int rowCount = 1; rowCount <= totalRows; rowCount++)
                {

                    nameValue = Convert.ToString((xlRange.Cells[rowCount, col["Process Name"]] as Excel.Range).Text);
                    statusValue = Convert.ToString((xlRange.Cells[rowCount, col["Status"]] as Excel.Range).Text);
                    guidValue = Convert.ToString((xlRange.Cells[rowCount, col["(Do Not Modify) Process"]] as Excel.Range).Text);

                    processList.Add(guidValue, statusValue);
                }
            }


            xlWorkBook.Close();
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            //Console.WriteLine("End of the file...");

            return processList;
        }

        private static void SetStateWorkflow(Guid workflowid, string state, IOrganizationService service)
        {
            SetStateRequest stateRequest;
            int statecode, statuscode;

            if (state == "Draft")
            {
                statecode = 0;
                statuscode = 1;

                stateRequest = new SetStateRequest
                {
                    EntityMoniker = new EntityReference("workflow", workflowid),
                    State = new OptionSetValue(statecode),
                    Status = new OptionSetValue(statuscode)
                };
                SetStateResponse stateSet = (SetStateResponse)service.Execute(stateRequest);
            }

            if (state == "Activated")
            {
                statecode = 1;
                statuscode = 2;

                stateRequest = new SetStateRequest
                {
                    EntityMoniker = new EntityReference("workflow", workflowid),
                    State = new OptionSetValue(statecode),
                    Status = new OptionSetValue(statuscode)
                };
                SetStateResponse stateSet = (SetStateResponse)service.Execute(stateRequest);
            }
        }

        private void tsbUpdateWorkflows_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                WorkflowList item = (WorkflowList)checkedListBox1.Items[i];
                Guid wfGuid = new Guid(item.RealValue);
                bool origStatus = item.State;

                bool currentStatus = checkedListBox1.GetItemCheckState(i).ToString() == "Checked" ? true : false;
                string currentStatusValue = currentStatus ? "Activated" : "Draft";

                if (origStatus != currentStatus)
                {
                    item.State = currentStatus;
                    checkedListBox1.Items[i] = item;
                    WorkAsync(new WorkAsyncInfo
                    {
                        Message = "Updating Workflows...",
                        Work = (bw, evt) =>
                        {
                            SetStateWorkflow(wfGuid, currentStatusValue, Service);
                        },
                        PostWorkCallBack = evt =>
                        {
                            if (evt.Error != null)
                            {
                                string errorMessage = CrmExceptionHelper.GetErrorMessage(evt.Error, true);
                                MessageBox.Show(this, errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        },
                        ProgressChanged = evt => { SetWorkingMessage(evt.UserState.ToString()); }
                    });
                    
                }


            }
        }
    }

    public class WorkflowList
    {
        public string FriendlyValue { get; set; }
        public string RealValue { get; set; }

        public bool State { get; set; }
    }
}