namespace GenerateModel
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtds = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.lblds = new System.Windows.Forms.Label();
            this.cmbDBs = new System.Windows.Forms.ComboBox();
            this.clbTable = new System.Windows.Forms.CheckedListBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExportXml = new System.Windows.Forms.Button();
            this.btnExportDao = new System.Windows.Forms.Button();
            this.btnExportService = new System.Windows.Forms.Button();
            this.btnExportClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtds
            // 
            this.txtds.Location = new System.Drawing.Point(91, 3);
            this.txtds.Name = "txtds";
            this.txtds.Size = new System.Drawing.Size(100, 21);
            this.txtds.TabIndex = 0;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(273, 190);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(88, 23);
            this.btnPath.TabIndex = 1;
            this.btnPath.Text = "选择生成路径";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblds
            // 
            this.lblds.AutoSize = true;
            this.lblds.Location = new System.Drawing.Point(2, 8);
            this.lblds.Name = "lblds";
            this.lblds.Size = new System.Drawing.Size(83, 12);
            this.lblds.TabIndex = 2;
            this.lblds.Text = "Data Source =";
            // 
            // cmbDBs
            // 
            this.cmbDBs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDBs.FormattingEnabled = true;
            this.cmbDBs.Location = new System.Drawing.Point(227, 3);
            this.cmbDBs.Name = "cmbDBs";
            this.cmbDBs.Size = new System.Drawing.Size(121, 20);
            this.cmbDBs.TabIndex = 3;
            this.cmbDBs.SelectedIndexChanged += new System.EventHandler(this.cmbDBs_SelectedIndexChanged);
            this.cmbDBs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbDBs_MouseClick);
            // 
            // clbTable
            // 
            this.clbTable.FormattingEnabled = true;
            this.clbTable.Location = new System.Drawing.Point(4, 39);
            this.clbTable.Name = "clbTable";
            this.clbTable.Size = new System.Drawing.Size(253, 132);
            this.clbTable.TabIndex = 4;
            this.clbTable.Visible = false;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(273, 39);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(273, 68);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(75, 23);
            this.btnReverse.TabIndex = 6;
            this.btnReverse.Text = "反选";
            this.btnReverse.UseVisualStyleBackColor = true;
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(4, 190);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(253, 21);
            this.tbPath.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 227);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(128, 227);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(94, 23);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "导出Model";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExportXml
            // 
            this.btnExportXml.Location = new System.Drawing.Point(262, 227);
            this.btnExportXml.Name = "btnExportXml";
            this.btnExportXml.Size = new System.Drawing.Size(99, 23);
            this.btnExportXml.TabIndex = 10;
            this.btnExportXml.Text = "导出XML";
            this.btnExportXml.UseVisualStyleBackColor = true;
            this.btnExportXml.Click += new System.EventHandler(this.btnExportXml_Click);
            // 
            // btnExportDao
            // 
            this.btnExportDao.Location = new System.Drawing.Point(12, 268);
            this.btnExportDao.Name = "btnExportDao";
            this.btnExportDao.Size = new System.Drawing.Size(94, 23);
            this.btnExportDao.TabIndex = 11;
            this.btnExportDao.Text = "导出Dao";
            this.btnExportDao.UseVisualStyleBackColor = true;
            this.btnExportDao.Click += new System.EventHandler(this.btnExportDao_Click);
            // 
            // btnExportService
            // 
            this.btnExportService.Location = new System.Drawing.Point(123, 268);
            this.btnExportService.Name = "btnExportService";
            this.btnExportService.Size = new System.Drawing.Size(99, 23);
            this.btnExportService.TabIndex = 12;
            this.btnExportService.Text = "导出Service.CS";
            this.btnExportService.UseVisualStyleBackColor = true;
            this.btnExportService.Click += new System.EventHandler(this.btnExportService_Click);
            // 
            // btnExportClient
            // 
            this.btnExportClient.Location = new System.Drawing.Point(262, 268);
            this.btnExportClient.Name = "btnExportClient";
            this.btnExportClient.Size = new System.Drawing.Size(99, 23);
            this.btnExportClient.TabIndex = 13;
            this.btnExportClient.Text = "导出Client";
            this.btnExportClient.UseVisualStyleBackColor = true;
            this.btnExportClient.Click += new System.EventHandler(this.btnExportClient_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 308);
            this.Controls.Add(this.btnExportClient);
            this.Controls.Add(this.btnExportService);
            this.Controls.Add(this.btnExportDao);
            this.Controls.Add(this.btnExportXml);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.clbTable);
            this.Controls.Add(this.cmbDBs);
            this.Controls.Add(this.lblds);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtds);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtds;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Label lblds;
        private System.Windows.Forms.ComboBox cmbDBs;
        private System.Windows.Forms.CheckedListBox clbTable;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExportXml;
        private System.Windows.Forms.Button btnExportDao;
        private System.Windows.Forms.Button btnExportService;
        private System.Windows.Forms.Button btnExportClient;
    }
}

