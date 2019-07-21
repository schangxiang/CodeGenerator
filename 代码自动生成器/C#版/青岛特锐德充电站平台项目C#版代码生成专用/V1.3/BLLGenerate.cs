using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel
{
    public class BLLGenerate
    {

        /// <summary>
        /// 生成BLL
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="chinaComment">中文注释</param>
        /// <param name="entityName">实体类名称</param>
        /// <param name="entityProName">实体类对象名称</param>
        /// <param name="nameSpacePath">命名空间</param>
        /// <param name="createPerson">创建人</param>
        /// <returns></returns>
        public static string CreateBLLClass(string moduleName, string chinaComment, string entityName, string entityProName, string nameSpacePath, string createPerson)
        {
            string header = @"/*
 * FileName：" + moduleName + @"BLL
 * FileDesc：" + chinaComment + @"业务逻辑接口实现
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
                + "using $NameSpacePath$.IBusiness;\n"
                + "using $NameSpacePath$.DataAccess;\n"
                + "using SysManager.Common.Kernel;\n"
                + "namespace $NameSpacePath$.Business {\n"
                + "    /// <summary>\n"
                + "    /// " + chinaComment + "业务逻辑接口实现\n"
                + "    /// </summary>\n"
                + "    public class $WarnMeasure$BLL:I$WarnMeasure$BLL {\n\n";
            string footer = "    }\n" + "}";
           

            //生成主体内容
            StringBuilder sbContent = new StringBuilder();

            //初始化数据访问接口
            sbContent.Append("      #region 初始化数据访问接口 \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// $ChinaComment$数据访问接口 \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      I$WarnMeasure$Dao $EntityProName$Dao = DaoFactory<I$WarnMeasure$Dao>.Dao; \n");
            sbContent.Append("      #endregion  \n\n");
            
            //查询
            sbContent.Append("      #region 根据过滤条件查询查询$ChinaComment$ \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 根据过滤条件查询查询$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <param name=\"filter\">过滤条件</param> \n");
            sbContent.Append("      /// <returns>$ChinaComment$数据集</returns> \n");
            sbContent.Append("      public List<$EntityName$> Get$WarnMeasure$ByFilter(string filter) \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              return $EntityProName$Dao.Get$WarnMeasure$ByFilter(filter); \n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch \n");
            sbContent.Append("          { \n");
            sbContent.Append("              throw;\n");
            sbContent.Append("          }\n");
            sbContent.Append("      } \n");
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
            sbContent.Append("      public bool Add$WarnMeasure$($EntityName$ $EntityProName$) \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              $EntityProName$Dao.Add$WarnMeasure$($EntityProName$); \n");
            sbContent.Append("              return true; \n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch \n");
            sbContent.Append("          { \n");
            sbContent.Append("              throw;\n");
            sbContent.Append("          }\n");
            sbContent.Append("      } \n");
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
            sbContent.Append("      public bool Edit$WarnMeasure$($EntityName$ $EntityProName$) \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              int i=$EntityProName$Dao.Edit$WarnMeasure$($EntityProName$); \n");
            sbContent.Append("              if(i>0) return true; \n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch \n");
            sbContent.Append("          { \n");
            sbContent.Append("              throw;\n");
            sbContent.Append("          }\n");
            sbContent.Append("          return false;\n");
            sbContent.Append("      } \n");
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
            sbContent.Append("      public bool Remove$WarnMeasure$(string keyID) \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              int i=$EntityProName$Dao.Remove$WarnMeasure$(keyID); \n");
            sbContent.Append("              if(i>0) return true; \n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch \n");
            sbContent.Append("          { \n");
            sbContent.Append("              throw;\n");
            sbContent.Append("          }\n");
            sbContent.Append("          return false;\n");
            sbContent.Append("      } \n");
            sbContent.Append("      #endregion  \n\n");

            string BLLContent = header + sbContent.ToString() + footer;

            //替换文本
            BLLContent = BLLContent.Replace("$WarnMeasure$", moduleName);//模块名称
            BLLContent = BLLContent.Replace("$NameSpacePath$", nameSpacePath);//实体类路径
            BLLContent = BLLContent.Replace("$ChinaComment$", chinaComment);//中文注释
            BLLContent = BLLContent.Replace("$NowTimeStr$", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);//创建时间
            BLLContent = BLLContent.Replace("$CreatePerson$", createPerson);//创建人
            BLLContent = BLLContent.Replace("$EntityName$", entityName);//实体类名
            BLLContent = BLLContent.Replace("$EntityProName$", entityProName);//实体类对象名

            return BLLContent;
        }


    }
}
