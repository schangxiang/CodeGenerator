using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIP_Models;

namespace Excel2SQL
{
    public partial class CSYLHZForm : Form
    {
        public CSYLHZForm()
        {
            InitializeComponent();
            this.tb_CreateCodeItemFile.Text = @"E:\CompanyProject\科致软件\src\wip\测试用例\任务执行管理测试用例\1、数据推送测试用例.xlsx,E:\CompanyProject\科致软件\src\wip\测试用例\任务执行管理测试用例\2、热前入库测试用例.xlsx,E:\CompanyProject\科致软件\src\wip\测试用例\任务执行管理测试用例\3、排产下发任务测试用例.xlsx,E:\CompanyProject\科致软件\src\wip\测试用例\任务执行管理测试用例\4、热前出库-入库测试用例.xlsx";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = this.tb_CreateCodeItemFile.Text;
            if (filePath == string.Empty)
            {
                MessageBox.Show("请选择Excel!");
                return;
            }

            string[] fileArr = filePath.Split(',');

            Dictionary<string, string> cellheader = new Dictionary<string, string> {
                    { "ceshijiaoben", "测试脚本" },
                    { "sysCode", "集成系统" },
                    { "fenlei", "分类" },
                    { "type", "正常/异常" },
                    { "shuru", "输入" },
                    { "guocheng", "过程" },
                    { "shuchu", "输出" },
                    { "jieguo", "结果" },
                };

            // 1.2解析文件，存放到一个List集合里
            StringBuilder errorMsg = new StringBuilder(); // 错误信息
            List<UdtWip_UnitTest> totalList = new List<UdtWip_UnitTest>();
            foreach (var item in fileArr)
            {
                List<UdtWip_UnitTest> enlist = ExcelHelper.ExcelToEntityListForCSYLHZ<UdtWip_UnitTest>(cellheader, item, out errorMsg);
                if (!string.IsNullOrEmpty(errorMsg.ToString()))
                {
                    MessageBox.Show("错误:" + errorMsg.ToString());
                    return;
                }
                totalList.AddRange(enlist);
            }

            string fileStr = Excel2SQL.GetInsertSQLForCSYLHZ(totalList);


            string createFilePath = @"D:\\C#AutoCreateCodeFile\UnitTest";
            TextHelper.CreateFile(createFilePath, "UnitTest.sql", fileStr);
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
                this.tb_CreateCodeItemFile.Text = "";
                for (int fi = 0; fi < fileDialog.FileNames.Length; fi++)
                {
                    if (fi == 0)
                    {
                        this.tb_CreateCodeItemFile.Text += fileDialog.FileNames[fi].ToString();
                    }
                    else
                    {
                        this.tb_CreateCodeItemFile.Text += "," + fileDialog.FileNames[fi].ToString();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
