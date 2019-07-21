

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// InsertSQL文件生成
    /// </summary>
    public class InsertSQL_Generate
    {
        /// <summary>
        /// 生成InsertSQL
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Author"></param>
        /// <param name="columnNameList"></param>
        /// <returns></returns>
        public static string CreateInsertSQLText(string TableName, string Author,
            List<ColumnModel> columnNameList)
        {
            try
            {
                StringBuilder sbText = new StringBuilder();

                sbText.Append(GetInsertSQLStr(TableName, Author, columnNameList));

                return sbText.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }



        /// <summary>
        /// 生成InsertSQL
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Author"></param>
        /// <param name="columnNameList"></param>
        /// <returns></returns>
        private static string GetInsertSQLStr(string TableName, string Author, List<ColumnModel> columnNameList)
        {
            var str_proc = TextHelper.ReadText(@"Templete\InserSQL模板.txt");

            str_proc = str_proc.Replace("$TableName$", TableName);//表名
            str_proc = str_proc.Replace("$Author$", Author);//作者


            string str_insert_cols = StructStrHelper.GetColumnsStrNoIDForAdd(columnNameList, "");
            str_proc = str_proc.Replace("$insert_cols$", str_insert_cols);
            str_proc = str_proc.Replace("$insert_cols_values$", StructStrHelper.GetColumnsStrNoIDForInsertSQL(columnNameList));

            return str_proc;
        }

    }
}
