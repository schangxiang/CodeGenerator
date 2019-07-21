using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WIP_Models;

namespace ClassToJSON
{
    public partial class TaskForm : Form
    {
        public TaskForm()
        {
            InitializeComponent();
            this.tb_CreateCount.Text = "100";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_CreateTask_Click(object sender, EventArgs e)
        {
            try
            {
                int count = Convert.ToInt32(this.tb_CreateCount.Text);

                List<ReceiveTaskModel> list = new List<ReceiveTaskModel>();
                string reschedulingTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//上次排产请求时间
                ReceiveTaskModel item = null;
                var nowTime = DateTime.Now;
                int ecmLine = 1;
                for (int i = 1; i <= count; i++)
                {
                    DateTime productTime = DateTime.Now.AddMinutes(i);//生产时间
                    item = new ReceiveTaskModel()
                    {
                        taskNo = i,
                        line = GetLine(ref ecmLine),
                        partName = "零件名" + i.ToString(),
                        partNumber = "零件号" + i.ToString(),
                        quantity = i * 99,
                        productTime = productTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        downLineTime = productTime.AddHours(3).ToString("yyyy-MM-dd HH:mm:ss"),
                        repairBatchNumber = "返修批次号" + i.ToString(),
                        priorityTask = "优先任务",
                        reschedulingFlag = "0",
                        reschedulingTime = reschedulingTime,
                        scheduleStatus = "0"
                    };
                    list.Add(item);
                }
                string content = JSONHelper.GetJSON<ReceiveTaskModel>(list);

                string createFilePath = @"D:\\C#AutoCreateCodeFile\ClassToJSON";
                TextHelper.CreateFile(createFilePath, "下发排产任务.json", content);
                MessageBox.Show("生成文件成功！");
                //成功之后打开文件夹
                using (System.Diagnostics.Process.Start(createFilePath)) { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误,ex:" + ex.Message);
            }

        }


        /// <summary>
        /// 获取生产线
        /// </summary>
        /// <returns></returns>
        private string GetLine(ref int ecmLine)
        {
            string line = "ECM" + ecmLine.ToString();
            if (ecmLine == 5)
            {
                ecmLine = 1;
            }
            else
            {
                ecmLine++;
            }
            return line;
        }


    }
}
