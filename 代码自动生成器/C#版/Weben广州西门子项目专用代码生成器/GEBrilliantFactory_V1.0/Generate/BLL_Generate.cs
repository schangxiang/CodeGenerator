
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// 生成BLL
    /// </summary>
    public class BLL_Generate
    {
        public static string CreateBLLText(string filePrefixName, string TableName, string entityName, string Author,
            string ChinaComment, string primaryKey,string primaryKeyDesc,string Modulelogo,string tableAlias,
            string addEntityParam,
            List<ColumnModel> columnNameList)
        {
            var str_bll = TextHelper.ReadText(@"Templete\BLL模板.txt");

            str_bll = str_bll.Replace("$TableName$", TableName);//表名
            str_bll = str_bll.Replace("$Author$", Author);//作者
            str_bll = str_bll.Replace("$ChinaComment$", ChinaComment);//中文注释
            str_bll = str_bll.Replace("$CurDate$", CommonHelper.GetCurDate());//当前时间
            str_bll = str_bll.Replace("$EntityName$", entityName);//实体类名

            str_bll = str_bll.Replace("$FilePrefixName$", filePrefixName);//模块名
            str_bll = str_bll.Replace("$Modulelogo$", Modulelogo);//模块简写
            str_bll = str_bll.Replace("$PrimaryKey$", primaryKey);//主键
            str_bll = str_bll.Replace("$PrimaryKeyDesc$", primaryKeyDesc);//描述
            str_bll = str_bll.Replace("$TableAlias$", tableAlias);//表别名

            str_bll = str_bll.Replace("$AddEntityParam$", addEntityParam);

            str_bll = str_bll.Replace("$ToSingleModel$", StructStrHelper.GetToModelStr(columnNameList));//动态给实体类赋值 
            return str_bll;
        }
    }
}
