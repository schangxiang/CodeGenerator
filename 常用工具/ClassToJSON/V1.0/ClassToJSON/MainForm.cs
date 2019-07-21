using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassToJSON
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_GetJSON_Click(object sender, EventArgs e)
        {
            string className = this.tb_ClassName.Text.Trim();
            if (className == string.Empty)
            {
                MessageBox.Show("请输入参数类名！");
                return;
            }
            //Assembly ass = Assembly.LoadFrom(@"EntityDLL\WIP_Models.dll");
            Assembly ass = Assembly.LoadFrom(@"E:\CompanyProject\科致软件\src\wip\GEBrilliantFactory\WIP_Models\bin\Debug\WIP_Models.dll");
            Type[] mytypes = ass.GetTypes();
            Type classType = null;
            foreach (Type t in mytypes)
            {
                if (t.Name == className)
                    classType = t;
            }
            if (classType == null)
            {
                MessageBox.Show("没有找到该参数类！");
                return;
            }
            //Object obj = Activator.CreateInstance(classType);
            string content = JSONHelper.GetJSON(classType,this.chk_IsList.Checked);
            string createFilePath = @"D:\\C#AutoCreateCodeFile\ClassToJSON";
            TextHelper.CreateFile(createFilePath, className + ".json", content);
            MessageBox.Show("生成文件成功！");
            //成功之后打开文件夹
            using (System.Diagnostics.Process.Start(createFilePath)) { }
        }

        private void btn_takeOrder_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new TaskForm();
            taskForm.ShowDialog();
        }
    }
}
