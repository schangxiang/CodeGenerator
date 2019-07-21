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
using System.Configuration;

namespace GenerateModel
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.tbPath.Text = "D:\\C#AutoCreateCodeFile";

            this.tb_Primary.Text = "ClassSetCode";//主键名
            this.tb_TableName.Text = "Base_BillPrefixTypeMaps";//表名
            this.tb_NameSpacePath.Text = "Teld.Base";//实体类命名空间 
            this.tb_moduleName.Text = "BillPrefixTypeMaps";//模块名称
            this.tb_ChinaComment.Text = "单据前缀类型关联表";//中文注释
            this.tb_CreatePerson.Text = "shaocx";//创建人
            this.tb_EntityName.Text = "BASE_BillPrefixTypeMapsEntity";//实体类名
            this.tb_EntityProName.Text = "billPrefixTypeMaps";//实体类对象名
        }

       
        ///// <summary>
        ///// 准备字符串
        ///// </summary>
        ///// <param name="str"></param>
        ///// <param name="db"></param>
        ///// <returns></returns>
        //private string PrepareSql(string str, string db,string userId,string Password)
        //{
        //    //ConnectionString = new StringBuilder();
        //    //ConnectionString.Append("DATA SOURCE = ").Append(str).Append(";");
        //    //ConnectionString.Append("INITIAL CATALOG = ").Append(db).Append(" ;");
        //    //ConnectionString.Append("User ID=" + userId + "; Password = " + Password + ";");

        //    return ConnectionString.ToString();
        //}

       

        /// <summary>
        /// 保存路径对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (DialogResult.OK == fbd.ShowDialog())
            {
                tbPath.Text = fbd.SelectedPath;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 导出文件!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(clbTable.GetItemText(clbTable.Items[0]));


            //int iCount = clbTable.Items.Count;
            //for (int i = 0; i < iCount; i++)
            //{
            //    string tableName = clbTable.GetItemText(clbTable.Items[i]);
            //    if (clbTable.GetItemChecked(i))
            //    {
            //        CreateModelFile(tableName);
            //    }

            //}
            MessageBox.Show("运行成功！");

        }

        /// <summary>
        /// 生成Model
        /// </summary>
        /// <param name="_tableName"></param>
        private void CreateModelFile(List<ColumnModel> strList, string _tableName, string moduleName, string nameSpacePath, string createPerson, string chinaComment,string entityName)
        {
            bool tf = Export2File(tbPath.Text, _tableName, ModelGenerate.GenerateModel(_tableName, strList, moduleName, nameSpacePath, createPerson, chinaComment, entityName), "Model", moduleName,entityName);
        }

        private bool Export2File(string _strPath, string _tableName, string _code, string fileType, string moduleName,string entityName)
        {
            string fileTypeName = "";
            switch (fileType) {
                case "Model":
                    fileTypeName = ".cs";
                    break;
                case "DAO":
                    entityName = "I" + moduleName + "Dao";
                    fileTypeName = ".cs";
                    break;
                case "IBLL":
                    entityName = "I" + moduleName + "BLL";
                    fileTypeName = ".cs";
                    break;
                case "BLL":
                    entityName = moduleName + "BLL";
                    fileTypeName = ".cs";
                    break;
                case "Controller":
                    entityName = moduleName + "Controller";
                    fileTypeName = ".cs";
                    break;
                case "JS":
                    fileTypeName = ".js";
                    break;
                case "CSHTML":
                    fileTypeName = ".cshtml";
                    break;
                case "XML":
                    entityName = moduleName;
                    fileTypeName = ".xml";
                    break;
            }
            if (!Directory.Exists(_strPath + "\\" + _tableName))
            {
                Directory.CreateDirectory(_strPath + "\\" + _tableName);
            }
            string txtName = _strPath + "\\" + _tableName + "\\" + entityName + fileTypeName;

            using (StreamWriter outfile = new StreamWriter(txtName))
            {
                outfile.Write(_code);
            }

            return true;
        }

        /// <summary>
        /// 生成XML文件
        /// </summary>
        /// <param name="_tableName"></param>
        private void CreateXmlFile(List<ColumnModel> strList, string _tableName, string primaryKey, string moduleName, string nameSpacePath, string chinaComment, string createPerson, string entityName)
        {

            bool tf = Export2File(tbPath.Text, _tableName, SqlMapGenerate.GenerateXml(_tableName, strList, primaryKey, moduleName, nameSpacePath, chinaComment, createPerson, entityName), "XML", moduleName, entityName);
        }

        private void btnExportXml_Click(object sender, EventArgs e)
        {
            //int iCount = clbTable.Items.Count;
            //for (int i = 0; i < iCount; i++)
            //{
            //    string tableName = clbTable.GetItemText(clbTable.Items[i]);
            //    if (clbTable.GetItemChecked(i))
            //    {
            //        CreateXmlFile(tableName);
            //    }

            //}
            MessageBox.Show("运行成功！");
        }

        private void CreateDaoClass(string _tableName, string moduleName, string chinaComment, string entityName, string entityProName, string nameSpacePath, string createPerson)
        {
            bool tf = Export2File(tbPath.Text, _tableName, DaoGenerate.GenerateDaoClass(moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson), "DAO", moduleName, entityName);
        }

        private void CreateIBLLClass(string _tableName, string moduleName, string chinaComment, string entityName, string entityProName, string nameSpacePath, string createPerson)
        {
            bool tf = Export2File(tbPath.Text, _tableName, IBLLGenerate.GenerateIBLLClass(moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson), "IBLL", moduleName, entityName);
        }

        private void CreateBLLClass(string _tableName, string moduleName, string chinaComment, string entityName, string entityProName, string nameSpacePath, string createPerson)
        {
            bool tf = Export2File(tbPath.Text, _tableName, BLLGenerate.CreateBLLClass(moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson), "BLL", moduleName, entityName);
        }


        private void CreateControllerClass(string _tableName, string moduleName, string chinaComment, string entityName, string entityProName, string nameSpacePath, string createPerson)
        {
            bool tf = Export2File(tbPath.Text, _tableName, ControllerGenerate.CreateControllerClass(moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson), "Controller", moduleName, entityName);
        }

        

        private void btnExportDao_Click(object sender, EventArgs e)
        {
            //int iCount = clbTable.Items.Count;
            //for (int i = 0; i < iCount; i++)
            //{
            //    string tableName = clbTable.GetItemText(clbTable.Items[i]);
            //    if (clbTable.GetItemChecked(i))
            //    {
            //        CreateDaoClass(tableName);
            //    }

            //}
            MessageBox.Show("运行成功！");
        }

        private void CreateServiceClass(string _tableName)
        {
            //string strConn = PrepareSql(ds, cmbDBs.SelectedItem.ToString());
            //string strSql = "Select Name FROM SysColumns Where id=Object_Id('" + _tableName + "')";
            //SqlDataReader sdr = SqlHelper.ExecuteReader(strConn, CommandType.Text, strSql);
            //List<string> strList = new List<string>();
            //if (sdr.HasRows)
            //{
            //    while (sdr.Read())
            //    {
            //        strList.Add(sdr.GetString(0));
            //    }
            //}
            //else
            //{
            //}

            bool tf = Export2File(tbPath.Text, _tableName, ServiceClassGenerate.GenerateServiceString(_tableName), "Service", "", "");
        }

        private void btnExportService_Click(object sender, EventArgs e)
        {
            //int iCount = clbTable.Items.Count;
            //for (int i = 0; i < iCount; i++)
            //{
            //    string tableName = clbTable.GetItemText(clbTable.Items[i]);
            //    if (clbTable.GetItemChecked(i))
            //    {
            //        CreateServiceClass(tableName);
            //    }

            //}
            MessageBox.Show("运行成功！");
        }

        private void CreateClientClass(string _tableName)
        {
            //string strConn = PrepareSql(ds, cmbDBs.SelectedItem.ToString());
            //string strSql = "Select Name FROM SysColumns Where id=Object_Id('" + _tableName + "')";
            //SqlDataReader sdr = SqlHelper.ExecuteReader(strConn, CommandType.Text, strSql);
            //List<string> strList = new List<string>();
            //if (sdr.HasRows)
            //{
            //    while (sdr.Read())
            //    {
            //        strList.Add(sdr.GetString(0));
            //    }
            //}
            //else
            //{
            //}

            bool tf = Export2File(tbPath.Text, _tableName, ClientGenerate.GenerateClient(_tableName), "CLIENT", "", "");
        }

        private void btnExportClient_Click(object sender, EventArgs e)
        {
            //int iCount = clbTable.Items.Count;
            //for (int i = 0; i < iCount; i++)
            //{
            //    string tableName = clbTable.GetItemText(clbTable.Items[i]);
            //    if (clbTable.GetItemChecked(i))
            //    {
            //        CreateClientClass(tableName);
            //    }

            //}
            MessageBox.Show("运行成功！");
        }


        //一键生成所有文件
        private void btn_CreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn =ConfigurationManager.ConnectionStrings["ConnString"].ToString();

                string primaryKey = this.tb_Primary.Text.Trim();//主键名
                string tableName = this.tb_TableName.Text.Trim();//表名
                string nameSpacePath = this.tb_NameSpacePath.Text.Trim();//实体类命名空间 
                string moduleName = this.tb_moduleName.Text.Trim();//模块名称
                string chinaComment = this.tb_ChinaComment.Text.Trim();//中文注释
                string createPerson = this.tb_CreatePerson.Text.Trim();//创建人
                string entityName = this.tb_EntityName.Text.Trim();//实体类名
                string entityProName = this.tb_EntityProName.Text.Trim();//实体类对象名

                string strSql = @"
    SELECT 
Syscolumns.name AS Columnsname,
Systypes.name AS DateType,
isnull(g.[value],'') AS N'ColumnDesc' 
FROM sys.extended_properties as Sysproperties
 RIGHT OUTER JOIN
Sysobjects
 INNER JOIN
Syscolumns ON Sysobjects.id = Syscolumns.id INNER JOIN
Systypes ON Syscolumns.xtype = Systypes.xtype ON
Sysproperties.major_id = Syscolumns.id AND
Sysproperties.minor_id = Syscolumns.colid
left join sys.extended_properties g 
on Syscolumns.id=g.major_id AND Syscolumns.colid = g.minor_id 
WHERE (Sysobjects.xtype = 'u' OR
Sysobjects.xtype = 'v') AND (Systypes.name <> 'Sysname') AND
(Sysobjects.name = '" + tableName + @"')
ORDER BY Syscolumns.id  
";
                SqlDataReader sdr = SqlHelper.ExecuteReader(strConn, CommandType.Text, strSql);
                List<ColumnModel> strList = new List<ColumnModel>();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        strList.Add(new ColumnModel()
                        {
                            ColumnName = sdr.GetString(0),
                            DateType = sdr.GetString(1),
                            ColumnComment = sdr.GetString(2)
                        });
                    }
                }
                else
                {
                }

                //1、生成Model
                CreateModelFile(strList, tableName, moduleName, nameSpacePath, createPerson, chinaComment,entityName);

                //2、生成XML
                CreateXmlFile(strList, tableName, primaryKey, moduleName, nameSpacePath, chinaComment, createPerson,entityName);

                //3、生成IDao
                CreateDaoClass(tableName,moduleName,chinaComment,entityName,entityProName,nameSpacePath,createPerson);

                //4、生成IBLL
                CreateIBLLClass(tableName, moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson);

                //5、生成BLL
                CreateBLLClass(tableName, moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson);

                //6、生成Controller
                CreateControllerClass(tableName, moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson);
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成文件失败！"+ex.Message);
                return;
              
            }
            MessageBox.Show("生成文件成功！");
          
        }

        private void tbPath_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
