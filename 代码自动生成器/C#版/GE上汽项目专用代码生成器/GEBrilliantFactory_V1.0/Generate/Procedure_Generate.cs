

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// 存储过程文件生成
    /// </summary>
    public class Procedure_Generate
    {
       /// <summary>
        /// 生成存储过程文件
       /// </summary>
       /// <param name="TableName"></param>
       /// <param name="TableAlias"></param>
       /// <param name="Author"></param>
       /// <param name="ChinaComment"></param>
       /// <param name="PimaryKey"></param>
       /// <param name="filePrefixName"></param>
       /// <param name="orderByName"></param>
       /// <param name="Modulelogo">模块简写</param>
       /// <param name="columnNameList"></param>
       /// <returns></returns>
        public static string CreateProcText(string TableName, string TableAlias, string Author,
            string ChinaComment, string PimaryKey, string filePrefixName, string orderByName, string Modulelogo,
            List<ColumnModel> columnNameList)
        {
            try
            {
                StringBuilder sbText = new StringBuilder();

                var str_query_1 = StructStrHelper.GetQueryColumnsStr(columnNameList);
                var str_query_2 = StructStrHelper.GetQueryColumnsStr(columnNameList, TableAlias);//带前缀

                //1、分页存储过程

                sbText.Append(GetPageProcStr(columnNameList,TableName, TableAlias, Author, ChinaComment, str_query_1, str_query_2, filePrefixName));
                sbText.Append("\n\n");

                //2、列表存储过程

                sbText.Append(GetListProcStr(TableName, TableAlias, Author, ChinaComment, str_query_2, filePrefixName, orderByName));
                sbText.Append("\n\n");

                //2、得到一个实体存储过程
                sbText.Append(GetSingleObjectProcStr(TableName, TableAlias, Author, ChinaComment, str_query_2, PimaryKey, filePrefixName, columnNameList));
                sbText.Append("\n\n");

                //3、增加一条记录存储过程
                sbText.Append(GetAddProcStr(TableName, TableAlias, Author, ChinaComment,filePrefixName, columnNameList));
                sbText.Append("\n\n");

                //4、更新一条记录存储过程
                sbText.Append(GetUpdateProcStr(TableName, TableAlias, Author, ChinaComment, PimaryKey, filePrefixName, columnNameList));
                sbText.Append("\n\n");

                //5、更新一条记录存储过程2
                sbText.Append(GetUpdateProcStr2(TableName, TableAlias, Author, ChinaComment, PimaryKey, filePrefixName, columnNameList));
                sbText.Append("\n\n");


                //存储过程名
                ProcName procName = CommonHelper.GetProcName(Modulelogo);
                sbText = sbText.Replace("$AddProcName$", procName.AddProc);
                sbText = sbText.Replace("$UpdateProcName$", procName.UpdateProc);
                sbText = sbText.Replace("$GetSingleProcName$", procName.GetSingleProc);
                sbText = sbText.Replace("$GetListProcName$", procName.ListProc);
                sbText = sbText.Replace("$GetPageListProcName$", procName.PageListProc);

                return sbText.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 分页存储过程
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="TableAlias"></param>
        /// <param name="Author"></param>
        /// <param name="ChinaComment"></param>
        /// <param name="str_query_1"></param>
        /// <param name="str_query_2"></param>
        /// <returns></returns>
        private static string GetPageProcStr(List<ColumnModel> columnNameList,string TableName, string TableAlias, string Author, string ChinaComment,
            string str_query_1, string str_query_2, string filePrefixName)
        {
            var str_page_proc = TextHelper.ReadText(@"Templete\proc\分页存储过程.txt");

            str_page_proc = str_page_proc.Replace("$ProcName$", filePrefixName + "_GetPageList");//存储过程名
            str_page_proc = str_page_proc.Replace("$TableName$", TableName);//表名
            str_page_proc = str_page_proc.Replace("$TableAlias$", TableAlias);//别名
            str_page_proc = str_page_proc.Replace("$Author$", Author);//作者
            str_page_proc = str_page_proc.Replace("$ChinaComment$", ChinaComment);//中文注释
            str_page_proc = str_page_proc.Replace("$CurDate$", CommonHelper.GetCurDate());//当前时间


            str_page_proc = str_page_proc.Replace("$page_cols_params$", StructStrHelper.GetInputParamColumnsStrForQueryPage(columnNameList));
            str_page_proc = str_page_proc.Replace("$where_cols_params$", StructStrHelper.GetCols_AssignmentStrForWherePage(TableAlias, columnNameList));

            str_page_proc = str_page_proc.Replace("$strQueryCol_1$", str_query_1);
            str_page_proc = str_page_proc.Replace("$strQueryCol_2$", str_query_2);
            return str_page_proc;
        }

        /// <summary>
        /// 列表存储过程(不分页)
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="TableAlias"></param>
        /// <param name="Author"></param>
        /// <param name="ChinaComment"></param>
        /// <param name="str_query"></param>
        /// <returns></returns>
        private static string GetListProcStr(string TableName, string TableAlias, string Author, string ChinaComment,
          string str_query, string filePrefixName, string orderByName)
        {
            var str_list_proc = TextHelper.ReadText(@"Templete\proc\列表存储过程.txt");

            str_list_proc = str_list_proc.Replace("$ProcName$", filePrefixName + "_GetList");//存储过程名
            str_list_proc = str_list_proc.Replace("$TableName$", TableName);//表名
            str_list_proc = str_list_proc.Replace("$TableAlias$", TableAlias);//别名
            str_list_proc = str_list_proc.Replace("$Author$", Author);//作者
            str_list_proc = str_list_proc.Replace("$ChinaComment$", ChinaComment);//中文注释
            str_list_proc = str_list_proc.Replace("$CurDate$", CommonHelper.GetCurDate());//当前时间

            str_list_proc = str_list_proc.Replace("$strQueryCol$", str_query);
            str_list_proc = str_list_proc.Replace("$orderByName$", orderByName);
            return str_list_proc;
        }

        /// <summary>
        /// 得到一个实体存储过程
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="TableAlias"></param>
        /// <param name="Author"></param>
        /// <param name="ChinaComment"></param>
        /// <param name="str_query_2"></param>
        /// <param name="PimaryKey"></param>
        /// <param name="columnNameList"></param>
        /// <returns></returns>
        private static string GetSingleObjectProcStr(string TableName, string TableAlias, string Author, string ChinaComment,
        string str_query_2, string PimaryKey, string filePrefixName, List<ColumnModel> columnNameList)
        {
            try
            {
                var str_single_proc = TextHelper.ReadText(@"Templete\proc\得到一个实体存储过程.txt");

                str_single_proc = str_single_proc.Replace("$ProcName$", filePrefixName + "_GetModel");//存储过程名
                str_single_proc = str_single_proc.Replace("$TableName$", TableName);//表名
                str_single_proc = str_single_proc.Replace("$TableAlias$", TableAlias);//别名
                str_single_proc = str_single_proc.Replace("$Author$", Author);//作者
                str_single_proc = str_single_proc.Replace("$ChinaComment$", ChinaComment);//中文注释
                str_single_proc = str_single_proc.Replace("$CurDate$", CommonHelper.GetCurDate());//当前时间

                str_single_proc = str_single_proc.Replace("$Primary$", PimaryKey);
                str_single_proc = str_single_proc.Replace("$strQueryCol$", str_query_2);
                var columnModel = StructStrHelper.GetColumnModelByName(PimaryKey, columnNameList);
                if (columnModel == null)
                    throw new Exception("没有找到相应的主键值！");
                if (columnModel.DataType.ToUpper() == "INT" || columnModel.DataType.ToUpper() == "BIGINT")
                {
                    str_single_proc = str_single_proc.Replace("$DataType$", columnModel.DataType);
                }
                else
                {
                    str_single_proc = str_single_proc.Replace("$DataType$", columnModel.DataType + "(" + columnModel.DataLength + ")");
                }

                return str_single_proc;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 增加一条记录存储过程
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="TableAlias"></param>
        /// <param name="Author"></param>
        /// <param name="ChinaComment"></param>
        /// <param name="str_query_2"></param>
        /// <param name="PimaryKey"></param>
        /// <param name="columnNameList"></param>
        /// <returns></returns>
        private static string GetAddProcStr(string TableName, string TableAlias, string Author, string ChinaComment,
     string filePrefixName, List<ColumnModel> columnNameList)
        {
            var str_proc = TextHelper.ReadText(@"Templete\proc\增加一条记录存储过程.txt");

            str_proc = str_proc.Replace("$ProcName$", filePrefixName + "_ADD");//存储过程名
            str_proc = str_proc.Replace("$TableName$", TableName);//表名
            str_proc = str_proc.Replace("$TableAlias$", TableAlias);//别名
            str_proc = str_proc.Replace("$Author$", Author);//作者
            str_proc = str_proc.Replace("$ChinaComment$", ChinaComment);//中文注释
            str_proc = str_proc.Replace("$CurDate$", CommonHelper.GetCurDate());//当前时间


            string str_insert_cols = StructStrHelper.GetColumnsStrNoIDForAdd(columnNameList, "");
            str_proc = str_proc.Replace("$insert_cols$", str_insert_cols);
            str_proc = str_proc.Replace("$insert_cols_values$", StructStrHelper.GetColumnsStrNoIDForAdd(columnNameList, "@"));
            str_proc = str_proc.Replace("$insert_cols_params$", StructStrHelper.GetInputParamColumnsStrForAdd(columnNameList));

            return str_proc;
        }

        /// <summary>
        /// 编辑一条记录存储过程
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="TableAlias"></param>
        /// <param name="Author"></param>
        /// <param name="ChinaComment"></param>
        /// <param name="PimaryKey"></param>
        /// <param name="columnNameList"></param>
        /// <returns></returns>
        private static string GetUpdateProcStr(string TableName, string TableAlias, string Author, string ChinaComment,
      string PimaryKey, string filePrefixName, List<ColumnModel> columnNameList)
        {
            var str_proc = TextHelper.ReadText(@"Templete\proc\修改一条记录存储过程.txt");

            str_proc = str_proc.Replace("$ProcName$", filePrefixName + "_Update");//存储过程名
            str_proc = str_proc.Replace("$TableName$", TableName);//表名
            str_proc = str_proc.Replace("$TableAlias$", TableAlias);//别名
            str_proc = str_proc.Replace("$Author$", Author);//作者
            str_proc = str_proc.Replace("$ChinaComment$", ChinaComment);//中文注释
            str_proc = str_proc.Replace("$CurDate$", CommonHelper.GetCurDate());//当前时间

            str_proc = str_proc.Replace("$Primary$", PimaryKey);

            str_proc = str_proc.Replace("$update_cols_params$", StructStrHelper.GetInputParamColumnsStrForUpdate(columnNameList));
            str_proc = str_proc.Replace("$update_cols_assignment$", StructStrHelper.GetCols_AssignmentStrForUpdate(columnNameList));

            return str_proc;
        }

        private static string GetUpdateProcStr2(string TableName, string TableAlias, string Author, string ChinaComment,
    string PimaryKey, string filePrefixName, List<ColumnModel> columnNameList)
        {
            var str_proc = TextHelper.ReadText(@"Templete\proc\修改一条记录存储过程2.txt");

            str_proc = str_proc.Replace("$ProcName$", filePrefixName + "_Update");//存储过程名
            str_proc = str_proc.Replace("$TableName$", TableName);//表名
            str_proc = str_proc.Replace("$TableAlias$", TableAlias);//别名
            str_proc = str_proc.Replace("$Author$", Author);//作者
            str_proc = str_proc.Replace("$ChinaComment$", ChinaComment);//中文注释
            str_proc = str_proc.Replace("$CurDate$", CommonHelper.GetCurDate());//当前时间

            str_proc = str_proc.Replace("$Primary$", PimaryKey);

            str_proc = str_proc.Replace("$update_cols_params$", StructStrHelper.GetInputParamColumnsStrForUpdate(columnNameList));
            str_proc = str_proc.Replace("$update_cols_assignment2$", StructStrHelper.GetCols_AssignmentStrForUpdate2(columnNameList));

            return str_proc;
        }
    }
}
