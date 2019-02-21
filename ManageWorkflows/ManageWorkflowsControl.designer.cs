﻿namespace ManageWorkflows
{
    partial class ManageWorkflowsControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code generated by the Component Designer

        /// <summary> 
        /// Method required to support the designer - do not modify
        /// the contents of this method with the code editor. 
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageWorkflowsControl));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadWorkflows = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpdateWorkflowsList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUpdateWorkflows = new System.Windows.Forms.ToolStripButton();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseImportFile = new System.Windows.Forms.Button();
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbLoadWorkflows,
            this.toolStripSeparator1,
            this.tsbUpdateWorkflowsList,
            this.toolStripSeparator2,
            this.tsbUpdateWorkflows});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(831, 31);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(28, 28);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click_1);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbLoadWorkflows
            // 
            this.tsbLoadWorkflows.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadWorkflows.Image")));
            this.tsbLoadWorkflows.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbLoadWorkflows.Name = "tsbLoadWorkflows";
            this.tsbLoadWorkflows.Size = new System.Drawing.Size(112, 28);
            this.tsbLoadWorkflows.Text = "Load Workflows";
            this.tsbLoadWorkflows.ToolTipText = "Load Workflows";
            this.tsbLoadWorkflows.Click += new System.EventHandler(this.tsbSample_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbUpdateWorkflowsList
            // 
            this.tsbUpdateWorkflowsList.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdateWorkflowsList.Image")));
            this.tsbUpdateWorkflowsList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbUpdateWorkflowsList.Name = "tsbUpdateWorkflowsList";
            this.tsbUpdateWorkflowsList.Size = new System.Drawing.Size(144, 28);
            this.tsbUpdateWorkflowsList.Text = "Update List from Excel";
            this.tsbUpdateWorkflowsList.ToolTipText = "Update List";
            this.tsbUpdateWorkflowsList.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbUpdateWorkflows
            // 
            this.tsbUpdateWorkflows.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdateWorkflows.Image")));
            this.tsbUpdateWorkflows.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbUpdateWorkflows.Name = "tsbUpdateWorkflows";
            this.tsbUpdateWorkflows.Size = new System.Drawing.Size(189, 28);
            this.tsbUpdateWorkflows.Text = "Activate/Deactivate Workflows";
            this.tsbUpdateWorkflows.ToolTipText = "Update Server";
            this.tsbUpdateWorkflows.Click += new System.EventHandler(this.tsbUpdateWorkflows_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(16, 59);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(714, 454);
            this.checkedListBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(151, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "All Processes export file";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(170, 33);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(568, 20);
            this.txtFilePath.TabIndex = 7;
            // 
            // btnBrowseImportFile
            // 
            this.btnBrowseImportFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseImportFile.Location = new System.Drawing.Point(744, 33);
            this.btnBrowseImportFile.Name = "btnBrowseImportFile";
            this.btnBrowseImportFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseImportFile.TabIndex = 8;
            this.btnBrowseImportFile.Text = "Browse";
            this.btnBrowseImportFile.UseVisualStyleBackColor = true;
            this.btnBrowseImportFile.Click += new System.EventHandler(this.btnBrowseImportFile_Click);
            // 
            // ManageWorkflowsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBrowseImportFile);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "ManageWorkflowsControl";
            this.Size = new System.Drawing.Size(831, 534);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbLoadWorkflows;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowseImportFile;
        private System.Windows.Forms.ToolStripButton tsbUpdateWorkflowsList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbUpdateWorkflows;
        private System.Windows.Forms.ToolStripButton tsbClose;
    }
}
