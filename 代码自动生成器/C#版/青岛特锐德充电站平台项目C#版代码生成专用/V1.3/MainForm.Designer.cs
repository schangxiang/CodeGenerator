namespace GenerateModel
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
            this.tb_moduleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_NameSpacePath = new System.Windows.Forms.TextBox();
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
            this.SuspendLayout();
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(273, 358);
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
            this.lblds.Location = new System.Drawing.Point(52, 11);
            this.lblds.Name = "lblds";
            this.lblds.Size = new System.Drawing.Size(35, 12);
            this.lblds.TabIndex = 2;
            this.lblds.Text = "表名:";
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(14, 358);
            this.tbPath.Name = "tbPath";
            this.tbPath.ReadOnly = true;
            this.tbPath.Size = new System.Drawing.Size(253, 21);
            this.tbPath.TabIndex = 7;
            this.tbPath.TextChanged += new System.EventHandler(this.tbPath_TextChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(262, 420);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btn_CreateFile
            // 
            this.btn_CreateFile.Location = new System.Drawing.Point(80, 420);
            this.btn_CreateFile.Name = "btn_CreateFile";
            this.btn_CreateFile.Size = new System.Drawing.Size(99, 23);
            this.btn_CreateFile.TabIndex = 14;
            this.btn_CreateFile.Text = "生成文件";
            this.btn_CreateFile.UseVisualStyleBackColor = true;
            this.btn_CreateFile.Click += new System.EventHandler(this.btn_CreateFile_Click);
            // 
            // tb_TableName
            // 
            this.tb_TableName.Location = new System.Drawing.Point(122, 8);
            this.tb_TableName.Name = "tb_TableName";
            this.tb_TableName.Size = new System.Drawing.Size(183, 21);
            this.tb_TableName.TabIndex = 15;
            // 
            // tb_moduleName
            // 
            this.tb_moduleName.Location = new System.Drawing.Point(251, 91);
            this.tb_moduleName.Name = "tb_moduleName";
            this.tb_moduleName.Size = new System.Drawing.Size(187, 21);
            this.tb_moduleName.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "模块名称(用于给各个类名的前缀):";
            // 
            // tb_NameSpacePath
            // 
            this.tb_NameSpacePath.Location = new System.Drawing.Point(251, 142);
            this.tb_NameSpacePath.Name = "tb_NameSpacePath";
            this.tb_NameSpacePath.Size = new System.Drawing.Size(187, 21);
            this.tb_NameSpacePath.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "命名空间：";
            // 
            // tb_ChinaComment
            // 
            this.tb_ChinaComment.Location = new System.Drawing.Point(241, 217);
            this.tb_ChinaComment.Name = "tb_ChinaComment";
            this.tb_ChinaComment.Size = new System.Drawing.Size(197, 21);
            this.tb_ChinaComment.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "中文注释:";
            // 
            // tb_CreatePerson
            // 
            this.tb_CreatePerson.Location = new System.Drawing.Point(239, 274);
            this.tb_CreatePerson.Name = "tb_CreatePerson";
            this.tb_CreatePerson.Size = new System.Drawing.Size(199, 21);
            this.tb_CreatePerson.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "你的名字拼音缩写:";
            // 
            // tb_Primary
            // 
            this.tb_Primary.Location = new System.Drawing.Point(483, 8);
            this.tb_Primary.Name = "tb_Primary";
            this.tb_Primary.Size = new System.Drawing.Size(183, 21);
            this.tb_Primary.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(394, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "主键:";
            // 
            // tb_EntityProName
            // 
            this.tb_EntityProName.Location = new System.Drawing.Point(483, 47);
            this.tb_EntityProName.Name = "tb_EntityProName";
            this.tb_EntityProName.Size = new System.Drawing.Size(183, 21);
            this.tb_EntityProName.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(394, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "实体类对象名:";
            // 
            // tb_EntityName
            // 
            this.tb_EntityName.Location = new System.Drawing.Point(122, 47);
            this.tb_EntityName.Name = "tb_EntityName";
            this.tb_EntityName.Size = new System.Drawing.Size(183, 21);
            this.tb_EntityName.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "实体类名:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 577);
            this.Controls.Add(this.tb_EntityProName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_EntityName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_Primary);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_CreatePerson);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_ChinaComment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_NameSpacePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_moduleName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_TableName);
            this.Controls.Add(this.btn_CreateFile);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.lblds);
            this.Controls.Add(this.btnPath);
            this.Name = "MainForm";
            this.Text = "Form1";
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
        private System.Windows.Forms.TextBox tb_moduleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_NameSpacePath;
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
    }
}

