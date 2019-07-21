using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel
{
    public class DaoGenerate
    {

        /// <summary>
        /// 生成IDao
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="chinaComment">中文注释</param>
        /// <param name="entityName">实体类名称</param>
        /// <param name="entityProName">实体类对象名称</param>
        /// <param name="nameSpacePath">命名空间</param>
        /// <param name="createPerson">创建人</param>
        /// <returns></returns>
        public static string GenerateDaoClass(string moduleName, string chinaComment, string entityName, string entityProName, string nameSpacePath, string createPerson)
        {
            string header = @"/*
 * FileName：I" + moduleName + @"DAO
 * FileDesc：" + chinaComment + @"数据访问接口
 * CurrentTime：" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + @"
 * Author：" + createPerson + @"
 *
 * <更新记录>
 */ ";
            header += "\n\n";
            header += "using System;\n"
                + "using System.Collections.Generic;\n"
                + "using System.ComponentModel;\n"
                + "using System.Text;\n"
                + "using $NameSpacePath$.Models;\n"
                + "namespace $NameSpacePath$.DataAccess {\n"
                + "    /// <summary>\n"
                + "    /// " + chinaComment + "数据访问接口\n"
                + "    /// </summary>\n"
                + "    public interface I$WarnMeasure$Dao {\n\n";
            string footer = "    }\n" + "}";
           

            //生成主体内容
            StringBuilder sbContent = new StringBuilder();

            //查询
            sbContent.Append("      #region 根据过滤条件查询查询$ChinaComment$ \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 根据过滤条件查询查询$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <param name=\"filter\">过滤条件</param> \n");
            sbContent.Append("      /// <returns>$ChinaComment$数据集</returns> \n");
            sbContent.Append("      List<$EntityName$> Get$WarnMeasure$ByFilter(string filter); \n");
            sbContent.Append("      #endregion  \n\n");


            //新增
            sbContent.Append("      #region 新增$ChinaComment$ \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 新增$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <param name=\"$EntityProName$\">$ChinaComment$Model</param> \n");
            sbContent.Append("      /// <returns></returns> \n");
            sbContent.Append("      object Add$WarnMeasure$($EntityName$ $EntityProName$); \n");
            sbContent.Append("      #endregion  \n\n");

            //更新
            sbContent.Append("      #region 更新$ChinaComment$ \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 更新$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <param name=\"$EntityProName$\">$ChinaComment$Model</param> \n");
            sbContent.Append("      /// <returns>影响的记录行数</returns> \n");
            sbContent.Append("      int Edit$WarnMeasure$($EntityName$ $EntityProName$); \n");
            sbContent.Append("      #endregion  \n\n");

            //删除
            sbContent.Append("      #region 删除$ChinaComment$ \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 删除$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <param name=\"keyID\">主键ID</param> \n");
            sbContent.Append("      /// <returns>影响的记录行数</returns> \n");
            sbContent.Append("      int Remove$WarnMeasure$(string keyID); \n");
            sbContent.Append("      #endregion  \n\n");

            string daoContent = header + sbContent.ToString() + footer;

            //替换文本
            daoContent = daoContent.Replace("$WarnMeasure$", moduleName);//模块名称
            daoContent = daoContent.Replace("$NameSpacePath$", nameSpacePath);//实体类路径
            daoContent = daoContent.Replace("$ChinaComment$", chinaComment);//中文注释
            daoContent = daoContent.Replace("$NowTimeStr$", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);//创建时间
            daoContent = daoContent.Replace("$CreatePerson$", createPerson);//创建人
            daoContent = daoContent.Replace("$EntityName$", entityName);//实体类名
            daoContent = daoContent.Replace("$EntityProName$", entityProName);//实体类对象名

            return daoContent;
        }


    }
}
