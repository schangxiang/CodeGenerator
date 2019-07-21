using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel2SQL
{
    public partial class InitCodeItemForm : Form
    {
        public InitCodeItemForm()
        {
            InitializeComponent();
            this.tb_CreateCodeItemFile.Text = @"C:\Users\Administrator\Desktop\新建文件夹\码表模板示例.xlsx";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = this.tb_CreateCodeItemFile.Text;
            if (filePath == string.Empty)
            {
                MessageBox.Show("请选择Excel!");
                return;
            }

            Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "OrderNo", "序号" },
                    { "setCode", "代码编码" },
                    { "codeName", "代码名称" },
                    { "code", "代码项编码" },
                    { "name", "代码项名称" },
                    { "note", "说明" },
                };

            // 1.2解析文件，存放到一个List集合里
            StringBuilder errorMsg = new StringBuilder(); // 错误信息
            List<UdtWip_CodeItems> enlist = ExcelHelper.ExcelToEntityListForInitCodeItems<UdtWip_CodeItems>(cellheader, filePath,out errorMsg);
            if (!string.IsNullOrEmpty(errorMsg.ToString()))
            {
                MessageBox.Show("错误:" + errorMsg.ToString());
                return;
            }
            string fileStr = Excel2SQL.GetInsertSQLForCodeItems(enlist);


            string createFilePath = @"D:\\C#AutoCreateCodeFile\InitCodeItems";
            TextHelper.CreateFile(createFilePath, "codeItems.sql", fileStr);
            MessageBox.Show("生成文件成功！");
            //成功之后打开文件夹
            using (System.Diagnostics.Process.Start(createFilePath)) { }
        }

        private void btn_SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*xls*)|*.xls*"; //设置要选择的文件的类型
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;//返回文件的完整路径    
                this.tb_CreateCodeItemFile.Text = file;
            }
        }
    }
}
