

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// 生成Controller类
    /// </summary>
    public class Controller_Generate
    {
        public static string CreateText(string Modulelogo,
            string ChinaComment, List<ColumnModel> columnNameList, string entityName, string orderByName = "")
        {
            var str_dal = TextHelper.ReadText(@"Templete\Controller模板.txt");

            str_dal = str_dal.Replace("$ChinaComment$", ChinaComment);//中文注释
            str_dal = str_dal.Replace("$EntityName$", entityName);
            str_dal = str_dal.Replace("$Modulelogo$", Modulelogo);//模块简写
            str_dal = str_dal.Replace("$OrderByName$", orderByName == "" ? "Id" : orderByName);//模块简写



            var str = StructStrHelper.GetPageFilterStrForController(columnNameList);
            str_dal = str_dal.Replace("$PageSearchFilter$", str);

            return str_dal;
        }
    }
}
