using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace GenerateModel
{
    public partial class Form1 : Form
    {
        public StringBuilder ConnectionString;
        string ds;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDBs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strConn = PrepareSql(ds, cmbDBs.SelectedItem.ToString());
            string strSql = "SELECT * FROM sysobjects where type = 'U' ";
            
            List<string> tbList = new List<string>();
            SqlDataReader sdr = SqlHelper.ExecuteReader(strConn, CommandType.Text, strSql);
            if (sdr.HasRows) {
                while (sdr.Read()) {
                    tbList.Add(sdr.GetString(0));
                }
            } else {
                MessageBox.Show("没有用户数据表!");
                return;
            }

            int itbCount = tbList.Count;
            clbTable.Items.Clear();
            for (int i = 0; i < itbCount; i++) {
                clbTable.Items.Add(tbList[i]);
            }
            clbTable.Visible=true;


        }

        /// <summary>
        /// 鼠标单击下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDBs_MouseClick(object sender, MouseEventArgs e) {
            List<string> dbList = new List<string>();
            StringBuilder sBuffer = new StringBuilder("select name from sysdatabases ");
            ds = txtds.Text;
            if (string.IsNullOrEmpty(ds)) {
                MessageBox.Show("数据源不能为空！");
                return;
            } else {
                string strSql = PrepareSql(ds, "master");
                SqlDataReader sdr = SqlHelper.ExecuteReader(strSql, CommandType.Text, sBuffer.ToString());
                if (sdr.HasRows) {
                    while (sdr.Read()) {
                        dbList.Add(sdr.GetString(0));
                    }
                } else {
                    MessageBox.Show("找不到数据库!");
                    return;
                }
                int itbCount = dbList.Count;

                cmbDBs.Items.Clear();
                for (int i = 0; i < itbCount; i++) {
                    cmbDBs.Items.Add(dbList[i]);
                }
            }
        }

        /// <summary>
        /// 准备字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        private string PrepareSql(string str,string db) {
            ConnectionString = new StringBuilder();
            ConnectionString.Append("DATA SOURCE = ").Append(str).Append(";");
            ConnectionString.Append("INITIAL CATALOG = ").Append(db).Append(" ;");
            ConnectionString.Append("User ID=sa; Password = aaaaaa;");

            return ConnectionString.ToString();
        }

        ///// <summary>
        ///// 全选
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnSelectAll_Click(object sender, EventArgs e) {
        //    if (0 > clbTable.Items.Count) {
        //        return;
        //    } else { 
                
        //    }
        //}

        ///// <summary>
        ///// 反选
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnReverse_Click(object sender, EventArgs e) {

        //}


        /// <summary>
        /// 保存路径对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (DialogResult.OK == fbd.ShowDialog()) {
                tbPath.Text = fbd.SelectedPath;
            }
        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        /// <summary>
        /// 导出文件!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e) {
            //MessageBox.Show(clbTable.GetItemText(clbTable.Items[0]));

            
            int iCount = clbTable.Items.Count;
            for (int i = 0; i < iCount;i++ ) {
                string tableName = clbTable.GetItemText(clbTable.Items[i]);
                if (clbTable.GetItemChecked(i)) {
                    CreateModelFile(tableName);    
                }

            }
            MessageBox.Show("运行成功！");
           
        }

        private void CreateModelFile(string _tableName) {
            string strConn = PrepareSql(ds, cmbDBs.SelectedItem.ToString());
            string strSql = "Select Name FROM SysColumns Where id=Object_Id('" + _tableName + "')";
            SqlDataReader sdr = SqlHelper.ExecuteReader(strConn, CommandType.Text, strSql);
            List<string> strList = new List<string>();
            if (sdr.HasRows) {
                while (sdr.Read()) {
                    strList.Add(sdr.GetString(0));
                }
            } else {
            }

            bool tf = Export2File(tbPath.Text, "Model."+_tableName, ModelGenerate.GenerateModel(_tableName, strList));
        }

        private bool Export2File(string _strPath,string _tableName,string _code) {
            string txtName = _strPath +"\\"+ _tableName + ".cs";
            using (StreamWriter outfile = new StreamWriter(txtName)) {
                outfile.Write(_code);
            }

            return true;
        }

        private void CreateXmlFile(string _tableName) {
            string strConn = PrepareSql(ds, cmbDBs.SelectedItem.ToString());
            string strSql = "Select Name FROM SysColumns Where id=Object_Id('" + _tableName + "')";
            SqlDataReader sdr = SqlHelper.ExecuteReader(strConn, CommandType.Text, strSql);
            List<string> strList = new List<string>();
            if (sdr.HasRows) {
                while (sdr.Read()) {
                    strList.Add(sdr.GetString(0));
                }
            } else {
            }

            bool tf = Export2File(tbPath.Text, "XML."+_tableName, SqlMapGenerate.GenerateXml(_tableName, strList));
        }

        private void btnExportXml_Click(object sender, EventArgs e) {
            int iCount = clbTable.Items.Count;
            for (int i = 0; i < iCount; i++) {
                string tableName = clbTable.GetItemText(clbTable.Items[i]);
                if (clbTable.GetItemChecked(i)) {
                    CreateXmlFile(tableName);
                }

            }
            MessageBox.Show("运行成功！");
        }

        private void CreateDaoClass(string _tableName) {
            string strConn = PrepareSql(ds, cmbDBs.SelectedItem.ToString());
            string strSql = "Select Name FROM SysColumns Where id=Object_Id('" + _tableName + "')";
            SqlDataReader sdr = SqlHelper.ExecuteReader(strConn, CommandType.Text, strSql);
            List<string> strList = new List<string>();
            if (sdr.HasRows) {
                while (sdr.Read()) {
                    strList.Add(sdr.GetString(0));
                }
            } else {
            }

            bool tf = Export2File(tbPath.Text, "DAO."+_tableName, DaoGenerate.GenerateDaoClass(_tableName));
        }

        private void btnExportDao_Click(object sender, EventArgs e) {
            int iCount = clbTable.Items.Count;
            for (int i = 0; i < iCount; i++) {
                string tableName = clbTable.GetItemText(clbTable.Items[i]);
                if (clbTable.GetItemChecked(i)) {
                    CreateDaoClass(tableName);
                }

            }
            MessageBox.Show("运行成功！");
        }

        private void CreateServiceClass(string _tableName) {
            string strConn = PrepareSql(ds, cmbDBs.SelectedItem.ToString());
            string strSql = "Select Name FROM SysColumns Where id=Object_Id('" + _tableName + "')";
            SqlDataReader sdr = SqlHelper.ExecuteReader(strConn, CommandType.Text, strSql);
            List<string> strList = new List<string>();
            if (sdr.HasRows) {
                while (sdr.Read()) {
                    strList.Add(sdr.GetString(0));
                }
            } else {
            }

            bool tf = Export2File(tbPath.Text, "Service."+_tableName, ServiceClassGenerate.GenerateServiceString(_tableName));
        }

        private void btnExportService_Click(object sender, EventArgs e) {
            int iCount = clbTable.Items.Count;
            for (int i = 0; i < iCount; i++) {
                string tableName = clbTable.GetItemText(clbTable.Items[i]);
                if (clbTable.GetItemChecked(i)) {
                    CreateServiceClass(tableName);
                }

            }
            MessageBox.Show("运行成功！");
        }

        private void CreateClientClass(string _tableName) {
            string strConn = PrepareSql(ds, cmbDBs.SelectedItem.ToString());
            string strSql = "Select Name FROM SysColumns Where id=Object_Id('" + _tableName + "')";
            SqlDataReader sdr = SqlHelper.ExecuteReader(strConn, CommandType.Text, strSql);
            List<string> strList = new List<string>();
            if (sdr.HasRows) {
                while (sdr.Read()) {
                    strList.Add(sdr.GetString(0));
                }
            } else {
            }

            bool tf = Export2File(tbPath.Text, "CLIENT."+_tableName, ClientGenerate.GenerateClient(_tableName));
        }

        private void btnExportClient_Click(object sender, EventArgs e) {
            int iCount = clbTable.Items.Count;
            for (int i = 0; i < iCount; i++) {
                string tableName = clbTable.GetItemText(clbTable.Items[i]);
                if (clbTable.GetItemChecked(i)) {
                    CreateClientClass(tableName);
                }

            }
            MessageBox.Show("运行成功！");
        }
        




    }
}
