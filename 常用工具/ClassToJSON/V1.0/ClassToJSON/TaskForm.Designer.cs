namespace ClassToJSON
{
    partial class TaskForm
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
            this.btn_CreateTask = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_CreateCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_CreateTask
            // 
            this.btn_CreateTask.Location = new System.Drawing.Point(111, 138);
            this.btn_CreateTask.Name = "btn_CreateTask";
            this.btn_CreateTask.Size = new System.Drawing.Size(173, 59);
            this.btn_CreateTask.TabIndex = 0;
            this.btn_CreateTask.Text = "生成任务数据";
            this.btn_CreateTask.UseVisualStyleBackColor = true;
            this.btn_CreateTask.Click += new System.EventHandler(this.btn_CreateTask_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "条数:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tb_CreateCount
            // 
            this.tb_CreateCount.Location = new System.Drawing.Point(145, 52);
            this.tb_CreateCount.Name = "tb_CreateCount";
            this.tb_CreateCount.Size = new System.Drawing.Size(100, 21);
            this.tb_CreateCount.TabIndex = 2;
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 262);
            this.Controls.Add(this.tb_CreateCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_CreateTask);
            this.Name = "TaskForm";
            this.Text = "TaskForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_CreateTask;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_CreateCount;
    }
}