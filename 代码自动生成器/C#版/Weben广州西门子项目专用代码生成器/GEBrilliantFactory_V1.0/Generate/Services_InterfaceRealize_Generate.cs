

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// 生成Services的接口实现文件
    /// </summary>
    public class Services_InterfaceRealize_Generate
    {
        public static string CreateText(string Wcf_NameSpacePath, string Modulelogo, string entityName,
            string ChinaComment,string filePrefixName,string primaryKey,string TableAlias,string addEntityParam,
            List<ColumnModel> columnList)
        {
            var str = TextHelper.ReadText(@"Templete\Services接口实现模板.txt");

            str = str.Replace("$ValidateEmptyStrForPrimaryKey$", StructStrHelper.GetValidateEmptyStrForPrimaryKey(columnList, primaryKey));
            str = str.Replace("$Wcf_NameSpacePath$", Wcf_NameSpacePath);//WCF项目的命名空间
            str = str.Replace("$ChinaComment$", ChinaComment);//中文注释
            str = str.Replace("$EntityName$", entityName);//实体类名
            str = str.Replace("$Modulelogo$", Modulelogo);//模块简写
            str = str.Replace("$FilePrefixName$", filePrefixName);//模块名
            str = str.Replace("$PrimaryKey$", primaryKey);//主键名

            str = str.Replace("$ValidateEmptyForInsert$", StructStrHelper.GetValidateEmptyStr(columnList));
            str = str.Replace("$ValidateEmptyForUpdate$", StructStrHelper.GetValidateEmptyStr(columnList,false));
            str = str.Replace("$WhereQuery$", StructStrHelper.GetStrForWhereQuery(columnList));
            str = str.Replace("$AddEntityParam$", addEntityParam);

            str = str.Replace("$TableAlias$", TableAlias);//表别名

            return str;
        }
    }
}
