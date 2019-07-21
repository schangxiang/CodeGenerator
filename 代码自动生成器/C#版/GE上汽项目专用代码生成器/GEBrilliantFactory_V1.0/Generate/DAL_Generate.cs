

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// 生成DAL
    /// </summary>
    public class DAL_Generate
    {
        public static string CreateDALText(string filePrefixName, string TableName, string entityName, string Author,
            string ChinaComment, string primaryKey, string primaryKeyDesc, string Modulelogo,string tableAlias,
            List<ColumnModel> columnNameList)
        {
           
            var str_dal = TextHelper.ReadText(@"Templete\DAL模板.txt");

            //存储过程名
            ProcName procName = CommonHelper.GetProcName(Modulelogo);
            str_dal = str_dal.Replace("$AddProcName$", procName.AddProc);
            str_dal = str_dal.Replace("$UpdateProcName$", procName.UpdateProc);
            str_dal = str_dal.Replace("$GetSingleProcName$", procName.GetSingleProc);
            str_dal = str_dal.Replace("$GetListProcName$", procName.ListProc);
            str_dal = str_dal.Replace("$GetPageListProcName$", procName.PageListProc);



            str_dal = str_dal.Replace("$TableName$", TableName);//表名
            str_dal = str_dal.Replace("$Author$", Author);//作者
            str_dal = str_dal.Replace("$ChinaComment$", ChinaComment);//中文注释
            str_dal = str_dal.Replace("$CurDate$", CommonHelper.GetCurDate());//当前时间
            str_dal = str_dal.Replace("$EntityName$", entityName);//实体类名
            str_dal = str_dal.Replace("$TableAlias$", tableAlias);//表别名

            str_dal = str_dal.Replace("$FilePrefixName$", filePrefixName);//模块名
            str_dal = str_dal.Replace("$Modulelogo$", Modulelogo);//模块简写
            str_dal = str_dal.Replace("$PrimaryKey$", primaryKey);//主键
            str_dal = str_dal.Replace("$PrimaryKeyDesc$", primaryKeyDesc);//主键描述

          

            str_dal = str_dal.Replace("$ToSingleModel$", StructStrHelper.GetToModelStr(columnNameList));//动态给实体类赋值 
            str_dal = str_dal.Replace("$AddSqlParameter$", StructStrHelper.GetParameterForAddDAL(columnNameList));
            str_dal = str_dal.Replace("$UpdateSqlParameter$", StructStrHelper.GetParameterForUpdateDAL(columnNameList));
            str_dal = str_dal.Replace("$QueryPageSqlParameter$", StructStrHelper.GetParameterForQueryPageDAL(columnNameList));
            return str_dal;
        }
    }
}
