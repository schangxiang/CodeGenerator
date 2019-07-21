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
 * CLR Version：4.0.30319.34014
 * NameSpace：$nameSpacePath$.DAO
 * FileName：" + moduleName + @"DAO
 * FileDesc：" + chinaComment + @"数据访问接口
 * CurrentTime：$NowTimeStr$
 * Author：$CreatePerson$
 *
 * <更新记录>
 * ver 1.0.0.0   $NowTimeStr$ 新規作成 (by $CreatePerson$)
 */ ";
            header += "\n\n";
            header += "using System;\n"
                + "using System.Collections; \n"
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
            sbContent.Append("      List<$EntityName$> Get$WarnMeasure$ByFilter(IDictionary<string, object> dictParam); \n");
            sbContent.Append("      #endregion  \n\n");


            //分页查询
            sbContent.Append("      #region 分页查询$ChinaComment$ \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 分页查询$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <param name=\"htParam\">查询过滤条件</param> \n");
            sbContent.Append("      /// <returns>实体集合</returns> \n");
            sbContent.Append("      IList<$EntityName$> Get$WarnMeasure$ListForPaging(IDictionary<string, object> dictParam); \n");
            sbContent.Append("      #endregion  \n\n");

            sbContent.Append("      #region 分页查询$ChinaComment$的总条数 \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 分页查询$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <param name=\"htParam\">查询过滤条件</param> \n");
            sbContent.Append("      /// <returns>实体集合</returns> \n");
            sbContent.Append("      int Get$WarnMeasure$ListForPagingCount(IDictionary<string, object> dictParam); \n");
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
            daoContent = daoContent.Replace("$NowTimeStr$", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day
                            + " "
                            + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);//创建时间
            daoContent = daoContent.Replace("$CreatePerson$", createPerson);//创建人
            daoContent = daoContent.Replace("$EntityName$", entityName);//实体类名
            daoContent = daoContent.Replace("$EntityProName$", entityProName);//实体类对象名

            return daoContent;
        }


    }
}
