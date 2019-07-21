namespace ClassToJSON
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_GetJSON = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ClassName = new System.Windows.Forms.TextBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.chk_IsList = new System.Windows.Forms.CheckBox();
            this.btn_takeOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_GetJSON
            // 
            this.btn_GetJSON.Location = new System.Drawing.Point(36, 267);
            this.btn_GetJSON.Name = "btn_GetJSON";
            this.btn_GetJSON.Size = new System.Drawing.Size(219, 67);
            this.btn_GetJSON.TabIndex = 1;
            this.btn_GetJSON.Text = "获取JSON";
            this.btn_GetJSON.UseVisualStyleBackColor = true;
            this.btn_GetJSON.Click += new System.EventHandler(this.btn_GetJSON_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "参数类名：";
            // 
            // tb_ClassName
            // 
            this.tb_ClassName.Location = new System.Drawing.Point(138, 141);
            this.tb_ClassName.Name = "tb_ClassName";
            this.tb_ClassName.Size = new System.Drawing.Size(176, 21);
            this.tb_ClassName.TabIndex = 5;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(302, 267);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(219, 67);
            this.btn_Exit.TabIndex = 14;
            this.btn_Exit.Text = "退出";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // chk_IsList
            // 
            this.chk_IsList.AutoSize = true;
            this.chk_IsList.Location = new System.Drawing.Point(138, 187);
            this.chk_IsList.Name = "chk_IsList";
            this.chk_IsList.Size = new System.Drawing.Size(72, 16);
            this.chk_IsList.TabIndex = 15;
            this.chk_IsList.Text = "是否List";
            this.chk_IsList.UseVisualStyleBackColor = true;
            // 
            // btn_takeOrder
            // 
            this.btn_takeOrder.Location = new System.Drawing.Point(36, 373);
            this.btn_takeOrder.Name = "btn_takeOrder";
            this.btn_takeOrder.Size = new System.Drawing.Size(219, 67);
            this.btn_takeOrder.TabIndex = 16;
            this.btn_takeOrder.Text = "下发排产任务数据";
            this.btn_takeOrder.UseVisualStyleBackColor = true;
            this.btn_takeOrder.Click += new System.EventHandler(this.btn_takeOrder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 490);
            this.Controls.Add(this.btn_takeOrder);
            this.Controls.Add(this.chk_IsList);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.tb_ClassName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_GetJSON);
            this.Name = "MainForm";
            this.Text = "ClassToJSON";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GetJSON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ClassName;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.CheckBox chk_IsList;
        private System.Windows.Forms.Button btn_takeOrder;
    }
}

