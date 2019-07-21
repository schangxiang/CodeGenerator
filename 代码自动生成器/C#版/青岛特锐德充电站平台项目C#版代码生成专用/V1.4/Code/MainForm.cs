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

            this.tb_Primary.Text = "ID";//主键名
            this.tb_OrderBy.Text = "LastModifyTime";//排序字段

            /*
            this.tb_TableName.Text = "Base_Test";//表名
            this.tb_NameSpacePath.Text = "Teld.Base";//实体类命名空间 
            this.tb_moduleName.Text = "Test";//模块名称
            this.tb_ChinaComment.Text = "测试表";//中文注释
            this.tb_CreatePerson.Text = "shaocx";//创建人
            this.tb_EntityName.Text = "TestEntity";//实体类名
            this.tb_EntityProName.Text = "test";//实体类对象名
            this.tb_MapName.Text = "BaseMap";
            //*/

            this.tb_TableName.Text = "Base_Xiangzi";//表名
            this.tb_NameSpacePath.Text = "Teld.OpenInterConnectionBM";//实体类命名空间 
            this.tb_moduleName.Text = "Xiangzi";//模块名称
            this.tb_ChinaComment.Text = "祥子";//中文注释
            this.tb_CreatePerson.Text = "shaocx";//创建人
            this.tb_EntityName.Text = "XiangziEntity";//实体类名
            this.tb_EntityProName.Text = "xiangzi";//实体类对象名
            this.tb_MapName.Text = "BaseMap";
        }

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
                string strConn = ConfigurationManager.ConnectionStrings["ConnString"].ToString();

                string primaryKey = this.tb_Primary.Text.Trim();//主键名
                string tableName = this.tb_TableName.Text.Trim();//表名
                string nameSpacePath = this.tb_NameSpacePath.Text.Trim();//实体类命名空间 
                string moduleName = this.tb_moduleName.Text.Trim();//模块名称
                string chinaComment = this.tb_ChinaComment.Text.Trim();//中文注释
                string createPerson = this.tb_CreatePerson.Text.Trim();//创建人
                string entityName = this.tb_EntityName.Text.Trim();//实体类名
                string entityProName = this.tb_EntityProName.Text.Trim();//实体类对象名
                string mapName = this.tb_MapName.Text.Trim();//Map名称
                string orderByName = this.tb_OrderBy.Text.Trim();//排序字段名称

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
                CreateModelFile(strList, tableName, moduleName, nameSpacePath, createPerson, chinaComment, entityName);

                //2、生成XML
                CreateXmlFile(strList, tableName, primaryKey, moduleName, nameSpacePath, chinaComment, createPerson, entityName, orderByName, entityProName);

                //3、生成IDao
                CreateDaoClass(tableName, moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson);

                //4、生成IBLL
                CreateIBLLClass(tableName, moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson);

                //5、生成BLL
                CreateBLLClass(tableName, moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson, mapName);

                //6、生成Controller
                CreateControllerClass(tableName, moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson);

                //7、生成JS
                CreateJS(tableName, moduleName, chinaComment, entityName, createPerson, primaryKey);

                //8、生成列表页面
                this.CreateCSHTML_List(tableName, moduleName, chinaComment, entityName, strList);

                //9、生成详情页面
                this.CreateCSHTML_Detail(tableName, moduleName, chinaComment, entityName, strList);

            }
            catch (Exception ex)
            {
                MessageBox.Show("生成文件失败！" + ex.Message);
                return;

            }
            MessageBox.Show("生成文件成功！");

            //成功之后打开文件夹
            System.Diagnostics.Process.Start(this.tbPath.Text + "\\" + this.tb_TableName.Text);
        }

        #region 分类文件

        /// <summary>
        /// 生成Model
        /// </summary>
        /// <param name="_tableName"></param>
        private void CreateModelFile(List<ColumnModel> strList, string _tableName, string moduleName, string nameSpacePath, string createPerson, string chinaComment, string entityName)
        {
            bool tf = Export2File(tbPath.Text, _tableName, ModelGenerate.GenerateModel(_tableName, strList, moduleName, nameSpacePath, createPerson, chinaComment, entityName), FileType.Model, moduleName, entityName);
        }

        /// <summary>
        /// 生成XML文件
        /// </summary>
        /// <param name="_tableName"></param>
        private void CreateXmlFile(List<ColumnModel> strList, string _tableName, string primaryKey, string moduleName, string nameSpacePath,
            string chinaComment, string createPerson, string entityName, string orderByName, string tableAlias)
        {

            bool tf = Export2File(tbPath.Text, _tableName, SqlMapGenerate.GenerateXml(_tableName, strList, primaryKey, moduleName,
                nameSpacePath, chinaComment, createPerson, entityName, orderByName, tableAlias), FileType.XML, moduleName, entityName);
        }


        private void CreateDaoClass(string _tableName, string moduleName, string chinaComment, string entityName, string entityProName, string nameSpacePath, string createPerson)
        {
            bool tf = Export2File(tbPath.Text, _tableName, DaoGenerate.GenerateDaoClass(moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson), FileType.DAO, moduleName, entityName);
        }

        private void CreateIBLLClass(string _tableName, string moduleName, string chinaComment, string entityName, string entityProName, string nameSpacePath, string createPerson)
        {
            bool tf = Export2File(tbPath.Text, _tableName, IBLLGenerate.GenerateIBLLClass(moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson), FileType.IBLL, moduleName, entityName);
        }

        private void CreateBLLClass(string _tableName, string moduleName, string chinaComment, string entityName, string entityProName, string nameSpacePath, string createPerson, string mapName)
        {
            bool tf = Export2File(tbPath.Text, _tableName, BLLGenerate.CreateBLLClass(moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson, mapName), FileType.BLL, moduleName, entityName);
        }


        /// <summary>
        /// 生成Controller文件
        /// </summary>
        /// <param name="_tableName"></param>
        /// <param name="moduleName"></param>
        /// <param name="chinaComment"></param>
        /// <param name="entityName"></param>
        /// <param name="entityProName"></param>
        /// <param name="nameSpacePath"></param>
        /// <param name="createPerson"></param>
        private void CreateControllerClass(string _tableName, string moduleName, string chinaComment, string entityName, string entityProName, string nameSpacePath, string createPerson)
        {
            bool tf = Export2File(tbPath.Text, _tableName, ControllerGenerate.CreateControllerClass(moduleName, chinaComment, entityName, entityProName, nameSpacePath, createPerson), FileType.Controller, moduleName, entityName);
        }


        /// <summary>
        /// 生成JS文件
        /// </summary>
        /// <param name="_tableName">表名</param>
        /// <param name="moduleName">模块名</param>
        /// <param name="chinaComment">模块中文名</param>
        /// <param name="entityName">实体类名</param>
        /// <param name="createPerson">创建者</param>
        /// <param name="primaryKey">主键</param>
        private void CreateJS(string _tableName, string moduleName, string chinaComment, string entityName, string createPerson, string primaryKey)
        {
            bool tf = Export2File(tbPath.Text, _tableName, JSGenerate.GenerateJS(primaryKey, moduleName, chinaComment, createPerson), FileType.JS, moduleName, entityName);
        }

        /// <summary>
        /// 生成列表页面
        /// </summary>
        /// <param name="_tableName">表名</param>
        /// <param name="moduleName">模块名</param>
        /// <param name="chinaComment">模块中文名</param>
        /// <param name="entityName">实体类名</param>
        /// <param name="createPerson">创建者</param>
        /// <param name="primaryKey">主键</param>
        private void CreateCSHTML_List(string _tableName, string moduleName, string chinaComment, string entityName, List<ColumnModel> columnList)
        {
            bool tf = Export2File(tbPath.Text, _tableName, CSHTML_ListGenerate.GenerateCSHTML_List(moduleName, chinaComment, columnList), FileType.CSHTML_List, moduleName, entityName);
        }

        /// <summary>
        /// 生成详情页面
        /// </summary>
        /// <param name="_tableName">表名</param>
        /// <param name="moduleName">模块名</param>
        /// <param name="chinaComment">模块中文名</param>
        /// <param name="entityName">实体类名</param>
        /// <param name="createPerson">创建者</param>
        /// <param name="primaryKey">主键</param>
        private void CreateCSHTML_Detail(string _tableName, string moduleName, string chinaComment, string entityName, List<ColumnModel> columnList)
        {
            bool tf = Export2File(tbPath.Text, _tableName, CSHTML_DetailGenerate.GenerateCSHTML_Detail(moduleName, chinaComment, columnList), FileType.CSHTML_Detail, moduleName, entityName);
        }



        #endregion

        private bool Export2File(string _strPath, string _tableName, string _code, FileType fileType, string moduleName, string entityName)
        {
            string fileTypeName = "";
            switch (fileType)
            {
                case FileType.Model:
                    fileTypeName = ".cs";
                    break;
                case FileType.DAO:
                    entityName = "I" + moduleName + "Dao";
                    fileTypeName = ".cs";
                    break;
                case FileType.IBLL:
                    entityName = "I" + moduleName + "BLL";
                    fileTypeName = ".cs";
                    break;
                case FileType.BLL:
                    entityName = moduleName + "BLL";
                    fileTypeName = ".cs";
                    break;
                case FileType.Controller:
                    entityName = moduleName + "Controller";
                    fileTypeName = ".cs";
                    break;
                case FileType.JS:
                    entityName = moduleName;
                    fileTypeName = ".js";
                    break;
                case FileType.CSHTML_List:
                    entityName = moduleName;
                    fileTypeName = ".cshtml";
                    break;
                case FileType.CSHTML_Detail:
                    entityName = moduleName;
                    fileTypeName = "Detail.cshtml";
                    break;
                case FileType.XML:
                    entityName = moduleName;
                    fileTypeName = ".xml";
                    break;
            }
            if (!Directory.Exists(_strPath + "\\" + _tableName))
            {
                Directory.CreateDirectory(_strPath + "\\" + _tableName);
            }
            string txtName = _strPath + "\\" + _tableName + "\\" + entityName + fileTypeName;


            using (StreamWriter outfile = new StreamWriter(txtName,false, Encoding.GetEncoding("UTF-8")))
            {
                outfile.Write(_code);
            }

            return true;
        }

    }
}
