using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;


namespace GenerateCode_GEBrilliantFactory
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.tbPath.Text = "D:\\C#AutoCreateCodeFile";

            this.tb_Primary.Text = "id";//主键名
            this.tb_PrimaryDesc.Text = "主键";
            this.tb_OrderBy.Text = "LastModifyTime";//排序字段

            this.tb_TableName.Text = "Base_Xiangzi";//表名
            this.tb_WCF_NameSpacePath.Text = "WIP_";//WCF项目命名空间 
            this.tb_FileName.Text = "Xiangzi";//文件前缀名
            this.tb_ChinaComment.Text = "表的中文注解";//中文注释
            this.tb_CreatePerson.Text = "shaocx";//创建人
            this.tb_EntityName.Text = "XiangziEntity";//实体类名
            this.tb_EntityProName.Text = "xiangzi";//实体类对象名

            this.cmb_DataSource.DropDownStyle = ComboBoxStyle.DropDownList;
            List<ListItem> itemList = CommonHelper.GetDataSources();
            foreach (var item in itemList)
            {
                this.cmb_DataSource.Items.Add(item);
            }
            this.cmb_DataSource.SelectedIndex = 0;
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

        //一键生成所有文件
        private void btn_CreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                string primaryKey = this.tb_Primary.Text.Trim();//主键名
                string primaryKeyDesc = this.tb_PrimaryDesc.Text.Trim();//主键描述
                string tableName = this.tb_TableName.Text.Trim();//表名
                string wcf_NameSpacePath = this.tb_WCF_NameSpacePath.Text.Trim();//WCF项目命名空间 
                string filePrefixName = this.tb_FileName.Text.Trim();//文件前缀名
                string modulelogo = this.tb_Modulelogo.Text.Trim();//模块简写
                string chinaComment = this.tb_ChinaComment.Text.Trim();//中文注释
                string createPerson = this.tb_CreatePerson.Text.Trim();//创建人
                string entityName = this.tb_EntityName.Text.Trim();//实体类名
                string tableAlias = this.tb_EntityProName.Text.Trim();//实体类对象名/表别名
                string orderByName = this.tb_OrderBy.Text.Trim();//排序字段名称
                string routePrefix = this.tb_RoutePrefix.Text.Trim();//WCF路由前缀
                string connStr = this.lbl_DataSource.Text.Trim();//数据库连接字符串
                if (connStr == "")
                {
                    MessageBox.Show("请选择数据库源！");
                    this.cmb_DataSource.Focus();
                    return;
                }
                if (tableName == "")
                {
                    MessageBox.Show("请输入表名！");
                    this.tb_TableName.Focus();
                    return;
                }
                if (primaryKey == "")
                {
                    MessageBox.Show("请输入主键名！");
                    this.tb_Primary.Focus();
                    return;
                }
                if (routePrefix == "")
                {
                    MessageBox.Show("请输入WCF路由前缀！");
                    this.tb_RoutePrefix.Focus();
                    return;
                }
                List<ColumnModel> columnList = StructStrHelper.GetColumnList(tableName, connStr);
                if (columnList.Count == 0)
                {
                    MessageBox.Show("没有获取到表下面的列集合！");
                    return;
                }

                string addEntityParam = "Add" + modulelogo + "Param";//新增参数类名

                //生成Model
                CreateModelFile(columnList, tableName, filePrefixName, wcf_NameSpacePath, createPerson, chinaComment, entityName, modulelogo);

                //生成存储过程文件
                var str_generate = Procedure_Generate.CreateProcText(tableName, tableAlias, createPerson, chinaComment,
                    primaryKey, filePrefixName, orderByName, modulelogo, columnList);
                bool tf = TextHelper.Export2File(tbPath.Text, tableName, str_generate, FileType.Proc, filePrefixName, entityName, modulelogo);

                //生成DAL文件
                str_generate = DAL_Generate.CreateDALText(filePrefixName, tableName, entityName, createPerson,
                   chinaComment, primaryKey, primaryKeyDesc, modulelogo, tableAlias, columnList);
                tf = TextHelper.Export2File(tbPath.Text, tableName, str_generate, FileType.DAL, filePrefixName, entityName, modulelogo);

                //生成BLL文件
                str_generate = BLL_Generate.CreateBLLText(filePrefixName, tableName, entityName, createPerson,
                   chinaComment, primaryKey, primaryKeyDesc, modulelogo, tableAlias, addEntityParam, columnList);
                tf = TextHelper.Export2File(tbPath.Text, tableName, str_generate, FileType.BLL, filePrefixName, entityName, modulelogo);

                //生成QueryModel文件
                str_generate = QueryModel_Generate.CreateQueryModelLText(modulelogo, chinaComment, columnList);
                tf = TextHelper.Export2File(tbPath.Text, tableName, str_generate, FileType.QueryModel, filePrefixName, entityName, modulelogo);

                //生成AddModel文件
                str_generate = AddModel_Generate.CreateAddModelLText(addEntityParam, chinaComment, columnList);
                tf = TextHelper.Export2File(tbPath.Text, tableName, str_generate, FileType.AddModelParam, filePrefixName, entityName, modulelogo);


                //生成WCF接口文件
                str_generate = WCF_Interface_Generate.CreateText(wcf_NameSpacePath, modulelogo, entityName, chinaComment, addEntityParam);
                tf = TextHelper.Export2File(tbPath.Text, tableName, str_generate, FileType.WCF_InterFace, filePrefixName, entityName, modulelogo);


                //生成WCF接口实现文件
                str_generate = WCF_InterfaceRealize_Generate.CreateText(wcf_NameSpacePath, modulelogo,
                    entityName, chinaComment, filePrefixName, primaryKey, tableAlias, addEntityParam, columnList);
                tf = TextHelper.Export2File(tbPath.Text, tableName, str_generate, FileType.WCF_InterFaceRealize, filePrefixName, entityName, modulelogo);


                //VUE方法配置
                str_generate = VUE_FunConfig_Generate.CreateText(modulelogo, chinaComment, routePrefix);
                tf = TextHelper.Export2File(tbPath.Text, tableName, str_generate, FileType.VUE_FunConfig, filePrefixName, entityName, modulelogo);

                //VUE文件
                str_generate = VUE_Generate.CreateText(tableAlias, modulelogo, primaryKey, columnList);
                tf = TextHelper.Export2File(tbPath.Text, tableName, str_generate, FileType.VUEFile, filePrefixName, entityName, modulelogo);

            }
            catch (Exception ex)
            {
                MessageBox.Show("生成文件失败！" + ex.Message);
                return;
            }
            MessageBox.Show("生成文件成功！");
            //成功之后打开文件夹
            using (System.Diagnostics.Process.Start(this.tbPath.Text + "\\" + this.tb_TableName.Text))
            {

            }
            //*/
        }

        #region 分类文件

        /// <summary>
        /// 生成Model
        /// </summary>
        /// <param name="_tableName"></param>
        private void CreateModelFile(List<ColumnModel> strList, string _tableName, string filePrefixName, string nameSpacePath,
            string createPerson, string chinaComment, string entityName, string modulelogo)
        {
            bool tf = TextHelper.Export2File(tbPath.Text, _tableName,
                Model_Generate.GenerateModel(_tableName, strList, filePrefixName, nameSpacePath, createPerson, chinaComment, entityName),
                FileType.Model, filePrefixName, entityName, modulelogo);
        }


        #endregion

        /// <summary>
        /// 文本改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_TableName_TextChanged(object sender, EventArgs e)
        {
            string tableName = this.tb_TableName.Text.Trim();//表名
            if (tableName != "")
            {
                var str = CommonHelper.TitleToUpper(tableName);
                this.tb_FileName.Text = this.tb_EntityName.Text = str;
                var index = tableName.IndexOf('_');
                if (index > -1)
                {
                    var moule_str = tableName.Substring(index + 1, tableName.Length - index - 1);
                    this.tb_Modulelogo.Text = moule_str;
                    this.tb_EntityProName.Text = CommonHelper.TitleToLower(moule_str);
                }
            }
        }

        private void btn_InsertSql_Click(object sender, EventArgs e)
        {
            string connStr = this.lbl_DataSource.Text.Trim();//数据库连接字符串
            if (connStr == "")
            {
                MessageBox.Show("请选择数据库源！");
                this.cmb_DataSource.Focus();
                return;
            }
            var tableName = this.tb_TableName.Text.Trim();
            if (tableName == string.Empty)
            {
                MessageBox.Show("请输入表名!");
                return;
            }
            List<ColumnModel> columnList = StructStrHelper.GetColumnList(tableName, connStr);
            if (columnList.Count == 0)
            {
                MessageBox.Show("没有获取到表下面的列集合！");
                return;
            }

            string createPerson = this.tb_CreatePerson.Text.Trim();//创建人
            var str_generate = InsertSQL_Generate.CreateInsertSQLText(tableName, createPerson, columnList);
            bool tf = TextHelper.Export2File(tbPath.Text, tableName, str_generate, FileType.SQL_Insert, "", "", "");
            MessageBox.Show("生成文件成功！");
            //成功之后打开文件夹
            using (System.Diagnostics.Process.Start(this.tbPath.Text + "\\" + this.tb_TableName.Text))
            {

            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void cmb_DataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connStr = (this.cmb_DataSource.SelectedItem as ListItem).Value;
            this.lbl_DataSource.Text = connStr;
        }
    }
}
