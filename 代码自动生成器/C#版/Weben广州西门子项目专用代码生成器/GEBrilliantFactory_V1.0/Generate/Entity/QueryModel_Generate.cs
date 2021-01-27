

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// 生成查询实体类
    /// </summary>
    public class QueryModel_Generate
    {
        public static string CreateQueryModelLText(string Modulelogo,
            string ChinaComment, List<ColumnModel> columnNameList, string entityName)
        {
            var str_dal = TextHelper.ReadText(@"Templete\Entity\QueryModel模板.txt");

            str_dal = str_dal.Replace("$ChinaComment$", ChinaComment);//中文注释
            str_dal = str_dal.Replace("$EntityName$", entityName);
           
            str_dal = str_dal.Replace("$Modulelogo$", Modulelogo);//模块简写

            string attrString = "";

            List<ColumnModel> newColumnNameList = ListHelper.RemoveIdCreatorModifier(columnNameList);
            for (int i = 0; i < newColumnNameList.Count; ++i)
            {
                attrString += StructStrHelper.GenerateAttributeForQueryModel(newColumnNameList[i]);
            }
            str_dal = str_dal.Replace("$QueryAttributes$", attrString);
           
            return str_dal;
        }
    }
}
