namespace Excel2SQL
{
    partial class InitCodeItemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_CreateCodeItemFile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_SelectFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_CreateCodeItemFile
            // 
            this.tb_CreateCodeItemFile.Location = new System.Drawing.Point(63, 28);
            this.tb_CreateCodeItemFile.Name = "tb_CreateCodeItemFile";
            this.tb_CreateCodeItemFile.Size = new System.Drawing.Size(609, 21);
            this.tb_CreateCodeItemFile.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(195, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(299, 92);
            this.button1.TabIndex = 1;
            this.button1.Text = "生成码表预制SQL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_SelectFile
            // 
            this.btn_SelectFile.Location = new System.Drawing.Point(701, 28);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectFile.TabIndex = 4;
            this.btn_SelectFile.Text = "选择文件";
            this.btn_SelectFile.UseVisualStyleBackColor = true;
            this.btn_SelectFile.Click += new System.EventHandler(this.btn_SelectFile_Click);
            // 
            // InitCodeItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 338);
            this.Controls.Add(this.btn_SelectFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_CreateCodeItemFile);
            this.Name = "InitCodeItemForm";
            this.Text = "InitCodeItemForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_CreateCodeItemFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_SelectFile;
    }
}