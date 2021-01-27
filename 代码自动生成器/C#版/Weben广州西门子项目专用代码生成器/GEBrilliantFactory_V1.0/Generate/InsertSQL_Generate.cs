

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
        public static string CreateInsertSQLText(string TableName, string Author, string ChinaComment,
            List<ColumnModel> columnNameList)
        {
            try
            {
                StringBuilder sbText = new StringBuilder();

                sbText.Append(GetInsertSQLStr(TableName, Author,ChinaComment, columnNameList));

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
        private static string GetInsertSQLStr(string TableName, string Author, string ChinaComment, List<ColumnModel> columnNameList)
        {
            var str = TextHelper.ReadText(@"Templete\InitSQL模板.txt");

            str = str.Replace("$TableName$", TableName);//表名
            str = str.Replace("$Author$", Author);//作者
            str = str.Replace("$TableName$", TableName);//表名
            str = str.Replace("$Author$", Author);//作者
            str = str.Replace("$ChinaComment$", ChinaComment);//中文注释

            str = str.Replace("$CurDate$", CommonHelper.GetCurDate());//当前时间


            string str_insert_cols = StructStrHelper.GetColumnsStrNoIDForAdd(columnNameList, "");
            str = str.Replace("$insert_cols$", str_insert_cols);
            str = str.Replace("$insert_cols_values$", StructStrHelper.GetColumnsStrNoIDForInsertSQL(columnNameList));

            return str;
        }

    }
}
