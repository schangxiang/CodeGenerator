using GenerateModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel2SQL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.tb_FilePath.Text = @"C:\Users\Administrator\Desktop\新建文件夹\建表模板示例.xlsx";
            this.tb_Author.Text = "shaocx";
            this.tb_PrimaryKey.Text = "id";
            this.tb_MS.Text = "dbo";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 码表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            InitCodeItemForm initCodeItem = new InitCodeItemForm();
            initCodeItem.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
                this.tb_FilePath.Text = file;
            }
        }

        private void btn_CreateTable_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = this.tb_FilePath.Text;
                if (filePath == string.Empty)
                {
                    MessageBox.Show("请选择Excel!");
                    return;
                }
                string author = this.tb_Author.Text;
                //string tableName = this.tb_TableName.Text;
                //string tableChinaName = this.tb_ChinaName.Text;
                string unqiueIndex = this.tb_UniqueIndex.Text;
                string primaryKey = this.tb_PrimaryKey.Text.Trim();
                if (primaryKey == "")
                {
                    primaryKey = "id";
                }


                Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "OrderNo", "序号" },
                    { "ColumnName", "字段名称" },
                    { "ChinaName", "中文名称" },
                    { "DataType", "类型" },
                    { "DataLength", "长度" },
                    { "IsNullAuble", "必录项" },
                };

                // 1.2解析文件，存放到一个List集合里
                StringBuilder errorMsg = new StringBuilder(); // 错误信息
                string tableDesc = "", tableName = "";
                List<ColumnEntity> enlist = ExcelHelper.ExcelToEntityListForCreateTable<ColumnEntity>(cellheader, filePath, out tableDesc, out tableName, out errorMsg);
                if (!string.IsNullOrEmpty(errorMsg.ToString()))
                {
                    MessageBox.Show("错误:" + errorMsg.ToString());
                    return;
                }
                //解析tableName，如果存在逗号，说明是有Schema的
                if (tableName.IndexOf('.') > -1)
                {
                    string[] arr = tableName.Split('.');
                    this.tb_MS.Text = arr[0];
                    this.tb_TableName.Text = arr[1];
                    SystemData.TableNameWithNoSchema = arr[1];
                }
                if (enlist != null && enlist.Count > 0)
                {
                    string text = TextHelper.ReadText(@"Templete\建表模板.txt");
                    text = text.Replace("$TableNameWithNoSchema$",SystemData.TableNameWithNoSchema);
                    text = text.Replace("$Schema$", this.tb_MS.Text);
                    text = text.Replace("$TableName$", tableName);
                    text = text.Replace("$TableChinaDesc$", tableDesc);
                    text = text.Replace("$Author$", author);
                    text = text.Replace("$CreateTime$", Common.GetCurDate());
                    text = text.Replace("$PrimaryKey$", primaryKey);
                    text = text.Replace("$ColumnListStr$", Common.GetStrForColumnListStr(enlist, primaryKey));
                    text = text.Replace("$UniqueIndex$", Common.GetUniqueIndex(tableName, unqiueIndex));
                    text = text.Replace("$ColumnsAnnotation$", Common.GetColumnsAnnotation(tableName, primaryKey, this.tb_MS.Text, enlist));




                    string createFilePath = @"D:\\C#AutoCreateCodeFile\Excel2SQL";
                    TextHelper.CreateFile(createFilePath, tableName + ".sql", text);
                    MessageBox.Show("生成文件成功！");
                    //成功之后打开文件夹
                    using (System.Diagnostics.Process.Start(createFilePath)) { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误:" + ex.Message.ToString());
            }

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 测试用例汇总
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CeShiYongLi_Click(object sender, EventArgs e)
        {
            CSYLHZForm frm = new CSYLHZForm();
            frm.ShowDialog();
        }
    }
}
