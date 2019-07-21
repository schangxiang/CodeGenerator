using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel
{
    public class IBLLGenerate
    {

        /// <summary>
        /// 生成IIBLL
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="chinaComment">中文注释</param>
        /// <param name="entityName">实体类名称</param>
        /// <param name="entityProName">实体类对象名称</param>
        /// <param name="nameSpacePath">命名空间</param>
        /// <param name="createPerson">创建人</param>
        /// <returns></returns>
        public static string GenerateIBLLClass(string moduleName, string chinaComment, string entityName, string entityProName, string nameSpacePath, string createPerson)
        {

            string header = @"/*
 * CLR Version：4.0.30319.34014
 * NameSpace：$nameSpacePath$.IBLL
 * FileName：" + moduleName + @"IBLL
 * FileDesc：" + chinaComment + @"业务逻辑接口
 * CurrentTime：$NowTimeStr$
 * Author：$CreatePerson$
 *
 * <更新记录>
 * ver 1.0.0.0   $NowTimeStr$ 新規作成 (by $CreatePerson$)
 */ ";
            header += "\n\n";
            header += "using System;\n"
                + "using System.Collections.Generic;\n"
                + "using System.ComponentModel;\n"
                + "using System.Collections;\n"
                + "using System.Text;\n"
                + "using $NameSpacePath$.Models;\n"
                + "namespace $NameSpacePath$.IBusiness {\n"
                + "    /// <summary>\n"
                + "    /// " + chinaComment + "业务逻辑接口\n"
                + "    /// </summary>\n"
                + "    public interface I$WarnMeasure$BLL {\n\n";
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
            sbContent.Append("      /// <param name=\"dictParam\">查询过滤条件</param> \n");
            sbContent.Append("      /// <returns>字典集合</returns> \n");
            sbContent.Append("      IDictionary<string, object> Get$WarnMeasure$ListForPaging(IDictionary<string, object> dictParam); \n");
            sbContent.Append("      #endregion  \n\n");


            //新增
            sbContent.Append("      #region 新增$ChinaComment$ \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 新增$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <param name=\"$EntityProName$\">$ChinaComment$Model</param> \n");
            sbContent.Append("      /// <returns>true:成功，false:失败</returns> \n");
            sbContent.Append("      bool Add$WarnMeasure$($EntityName$ $EntityProName$); \n");
            sbContent.Append("      #endregion  \n\n");

            //更新
            sbContent.Append("      #region 更新$ChinaComment$ \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 更新$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <param name=\"$EntityProName$\">$ChinaComment$Model</param> \n");
            sbContent.Append("      /// <returns>true:成功，false:失败</returns> \n");
            sbContent.Append("      bool Edit$WarnMeasure$($EntityName$ $EntityProName$); \n");
            sbContent.Append("      #endregion  \n\n");

            //删除
            sbContent.Append("      #region 删除$ChinaComment$ \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 删除$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <param name=\"keyID\">主键ID</param> \n");
            sbContent.Append("      /// <returns>true:成功，false:失败</returns> \n");
            sbContent.Append("      bool Remove$WarnMeasure$(string keyID); \n");
            sbContent.Append("      #endregion  \n\n");

            string IBLLContent = header + sbContent.ToString() + footer;

            //替换文本
            IBLLContent = IBLLContent.Replace("$WarnMeasure$", moduleName);//模块名称
            IBLLContent = IBLLContent.Replace("$NameSpacePath$", nameSpacePath);//实体类路径
            IBLLContent = IBLLContent.Replace("$ChinaComment$", chinaComment);//中文注释
            IBLLContent = IBLLContent.Replace("$NowTimeStr$", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day
                            + " "
                            + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);//创建时间
            IBLLContent = IBLLContent.Replace("$CreatePerson$", createPerson);//创建人
            IBLLContent = IBLLContent.Replace("$EntityName$", entityName);//实体类名
            IBLLContent = IBLLContent.Replace("$EntityProName$", entityProName);//实体类对象名

            return IBLLContent;
        }


    }
}
