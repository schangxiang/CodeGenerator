namespace GenerateCode_GEBrilliantFactory
{
    partial class MainForm
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
            this.btnPath = new System.Windows.Forms.Button();
            this.lblds = new System.Windows.Forms.Label();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btn_CreateFile = new System.Windows.Forms.Button();
            this.tb_TableName = new System.Windows.Forms.TextBox();
            this.tb_FileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_WCF_NameSpacePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ChinaComment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_CreatePerson = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Primary = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_EntityProName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_EntityName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_OrderBy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_PrimaryDesc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_Modulelogo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_InsertSql = new System.Windows.Forms.Button();
            this.tb_RoutePrefix = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_DataSource = new System.Windows.Forms.Label();
            this.cmb_DataSource = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(563, 649);
            this.btnPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(129, 29);
            this.btnPath.TabIndex = 1;
            this.btnPath.Text = "选择生成路径";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblds
            // 
            this.lblds.AutoSize = true;
            this.lblds.Location = new System.Drawing.Point(40, 59);
            this.lblds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblds.Name = "lblds";
            this.lblds.Size = new System.Drawing.Size(45, 15);
            this.lblds.TabIndex = 2;
            this.lblds.Text = "表名:";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(141, 651);
            this.tbPath.Margin = new System.Windows.Forms.Padding(4);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(336, 25);
            this.tbPath.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(865, 709);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(228, 84);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btn_CreateFile
            // 
            this.btn_CreateFile.Location = new System.Drawing.Point(141, 709);
            this.btn_CreateFile.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CreateFile.Name = "btn_CreateFile";
            this.btn_CreateFile.Size = new System.Drawing.Size(209, 84);
            this.btn_CreateFile.TabIndex = 14;
            this.btn_CreateFile.Text = "生成文件";
            this.btn_CreateFile.UseVisualStyleBackColor = true;
            this.btn_CreateFile.Click += new System.EventHandler(this.btn_CreateFile_Click);
            // 
            // tb_TableName
            // 
            this.tb_TableName.Location = new System.Drawing.Point(133, 55);
            this.tb_TableName.Margin = new System.Windows.Forms.Padding(4);
            this.tb_TableName.Name = "tb_TableName";
            this.tb_TableName.Size = new System.Drawing.Size(243, 25);
            this.tb_TableName.TabIndex = 15;
            this.tb_TableName.TextChanged += new System.EventHandler(this.tb_TableName_TextChanged);
            // 
            // tb_FileName
            // 
            this.tb_FileName.Location = new System.Drawing.Point(305, 159);
            this.tb_FileName.Margin = new System.Windows.Forms.Padding(4);
            this.tb_FileName.Name = "tb_FileName";
            this.tb_FileName.Size = new System.Drawing.Size(264, 25);
            this.tb_FileName.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "文件名称(用于给各个类名的前缀):";
            // 
            // tb_WCF_NameSpacePath
            // 
            this.tb_WCF_NameSpacePath.Location = new System.Drawing.Point(303, 288);
            this.tb_WCF_NameSpacePath.Margin = new System.Windows.Forms.Padding(4);
            this.tb_WCF_NameSpacePath.Name = "tb_WCF_NameSpacePath";
            this.tb_WCF_NameSpacePath.Size = new System.Drawing.Size(261, 25);
            this.tb_WCF_NameSpacePath.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 288);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "WCF项目命名空间:";
            // 
            // tb_ChinaComment
            // 
            this.tb_ChinaComment.Location = new System.Drawing.Point(303, 345);
            this.tb_ChinaComment.Margin = new System.Windows.Forms.Padding(4);
            this.tb_ChinaComment.Name = "tb_ChinaComment";
            this.tb_ChinaComment.Size = new System.Drawing.Size(261, 25);
            this.tb_ChinaComment.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 345);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "表的中文注解:";
            // 
            // tb_CreatePerson
            // 
            this.tb_CreatePerson.Location = new System.Drawing.Point(303, 402);
            this.tb_CreatePerson.Margin = new System.Windows.Forms.Padding(4);
            this.tb_CreatePerson.Name = "tb_CreatePerson";
            this.tb_CreatePerson.Size = new System.Drawing.Size(264, 25);
            this.tb_CreatePerson.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 414);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "你的名字拼音缩写:";
            // 
            // tb_Primary
            // 
            this.tb_Primary.Location = new System.Drawing.Point(461, 55);
            this.tb_Primary.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Primary.Name = "tb_Primary";
            this.tb_Primary.Size = new System.Drawing.Size(192, 25);
            this.tb_Primary.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "主键:";
            // 
            // tb_EntityProName
            // 
            this.tb_EntityProName.Location = new System.Drawing.Point(665, 104);
            this.tb_EntityProName.Margin = new System.Windows.Forms.Padding(4);
            this.tb_EntityProName.Name = "tb_EntityProName";
            this.tb_EntityProName.Size = new System.Drawing.Size(243, 25);
            this.tb_EntityProName.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(496, 108);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 15);
            this.label7.TabIndex = 30;
            this.label7.Text = "实体类对象名/表别名:";
            // 
            // tb_EntityName
            // 
            this.tb_EntityName.Location = new System.Drawing.Point(133, 104);
            this.tb_EntityName.Margin = new System.Windows.Forms.Padding(4);
            this.tb_EntityName.Name = "tb_EntityName";
            this.tb_EntityName.Size = new System.Drawing.Size(243, 25);
            this.tb_EntityName.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 108);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "实体类名:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(635, 170);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "排序:";
            // 
            // tb_OrderBy
            // 
            this.tb_OrderBy.Location = new System.Drawing.Point(689, 166);
            this.tb_OrderBy.Margin = new System.Windows.Forms.Padding(4);
            this.tb_OrderBy.Name = "tb_OrderBy";
            this.tb_OrderBy.Size = new System.Drawing.Size(192, 25);
            this.tb_OrderBy.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(908, 170);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 15);
            this.label10.TabIndex = 36;
            this.label10.Text = "(默认降序)";
            // 
            // tb_PrimaryDesc
            // 
            this.tb_PrimaryDesc.Location = new System.Drawing.Point(769, 55);
            this.tb_PrimaryDesc.Margin = new System.Windows.Forms.Padding(4);
            this.tb_PrimaryDesc.Name = "tb_PrimaryDesc";
            this.tb_PrimaryDesc.Size = new System.Drawing.Size(192, 25);
            this.tb_PrimaryDesc.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(687, 59);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 15);
            this.label11.TabIndex = 37;
            this.label11.Text = "主键描述:";
            // 
            // tb_Modulelogo
            // 
            this.tb_Modulelogo.Location = new System.Drawing.Point(305, 222);
            this.tb_Modulelogo.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Modulelogo.Name = "tb_Modulelogo";
            this.tb_Modulelogo.Size = new System.Drawing.Size(264, 25);
            this.tb_Modulelogo.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 226);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 15);
            this.label3.TabIndex = 40;
            this.label3.Text = "模块简写(用于给各个方法名):";
            // 
            // btn_InsertSql
            // 
            this.btn_InsertSql.Location = new System.Drawing.Point(513, 709);
            this.btn_InsertSql.Margin = new System.Windows.Forms.Padding(4);
            this.btn_InsertSql.Name = "btn_InsertSql";
            this.btn_InsertSql.Size = new System.Drawing.Size(209, 84);
            this.btn_InsertSql.TabIndex = 42;
            this.btn_InsertSql.Text = "生成InitSQL";
            this.btn_InsertSql.UseVisualStyleBackColor = true;
            this.btn_InsertSql.Visible = false;
            this.btn_InsertSql.Click += new System.EventHandler(this.btn_InsertSql_Click);
            // 
            // tb_RoutePrefix
            // 
            this.tb_RoutePrefix.Location = new System.Drawing.Point(735, 222);
            this.tb_RoutePrefix.Margin = new System.Windows.Forms.Padding(4);
            this.tb_RoutePrefix.Name = "tb_RoutePrefix";
            this.tb_RoutePrefix.Size = new System.Drawing.Size(192, 25);
            this.tb_RoutePrefix.TabIndex = 44;
            this.tb_RoutePrefix.Text = "1111";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(635, 230);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 15);
            this.label13.TabIndex = 43;
            this.label13.Text = "WCF路由前缀:";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_DataSource);
            this.groupBox1.Controls.Add(this.cmb_DataSource);
            this.groupBox1.Location = new System.Drawing.Point(68, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1092, 102);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库配置";
            // 
            // lbl_DataSource
            // 
            this.lbl_DataSource.AutoSize = true;
            this.lbl_DataSource.Location = new System.Drawing.Point(259, 50);
            this.lbl_DataSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DataSource.Name = "lbl_DataSource";
            this.lbl_DataSource.Size = new System.Drawing.Size(112, 15);
            this.lbl_DataSource.TabIndex = 1;
            this.lbl_DataSource.Text = "我是链接字符串";
            // 
            // cmb_DataSource
            // 
            this.cmb_DataSource.FormattingEnabled = true;
            this.cmb_DataSource.Location = new System.Drawing.Point(45, 46);
            this.cmb_DataSource.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_DataSource.Name = "cmb_DataSource";
            this.cmb_DataSource.Size = new System.Drawing.Size(191, 23);
            this.cmb_DataSource.TabIndex = 0;
            this.cmb_DataSource.SelectedIndexChanged += new System.EventHandler(this.cmb_DataSource_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_FileName);
            this.groupBox2.Controls.Add(this.lblds);
            this.groupBox2.Controls.Add(this.tb_RoutePrefix);
            this.groupBox2.Controls.Add(this.tb_TableName);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tb_Modulelogo);
            this.groupBox2.Controls.Add(this.tb_WCF_NameSpacePath);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tb_ChinaComment);
            this.groupBox2.Controls.Add(this.tb_PrimaryDesc);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tb_CreatePerson);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tb_OrderBy);
            this.groupBox2.Controls.Add(this.tb_Primary);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tb_EntityProName);
            this.groupBox2.Controls.Add(this.tb_EntityName);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(68, 139);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1092, 484);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "自定义配置";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 808);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_InsertSql);
            this.Controls.Add(this.btn_CreateFile);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.btnPath);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "广州西门子项目-代码生成器(伟本专用)V1.0";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Label lblds;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btn_CreateFile;
        private System.Windows.Forms.TextBox tb_TableName;
        private System.Windows.Forms.TextBox tb_FileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_WCF_NameSpacePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ChinaComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_CreatePerson;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_Primary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_EntityProName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_EntityName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_OrderBy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_PrimaryDesc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_Modulelogo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_InsertSql;
        private System.Windows.Forms.TextBox tb_RoutePrefix;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_DataSource;
        private System.Windows.Forms.ComboBox cmb_DataSource;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

