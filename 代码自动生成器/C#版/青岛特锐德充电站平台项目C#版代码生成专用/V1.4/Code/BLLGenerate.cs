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
        /// <param name="mapName">Map名称</param>
        /// <returns></returns>
        public static string CreateBLLClass(string moduleName, string chinaComment, string entityName, 
            string entityProName, string nameSpacePath, string createPerson,string mapName)
        {
            string header = @"/*
 * CLR Version：4.0.30319.34014
 * NameSpace：$nameSpacePath$.BLL
 * FileName：" + moduleName + @"BLL
 * FileDesc：" + chinaComment + @"业务逻辑接口实现
 * CurrentTime：$NowTimeStr$
 * Author：$CreatePerson$
 *
 * <更新记录>
 * ver 1.0.0.0   $NowTimeStr$ 新規作成 (by $CreatePerson$)
 */ ";
            header += "\n\n";
            header += "using System;\n"
                + "using System.Collections.Generic;\n"
                + "using System.Collections;\n"
                + "using System.ComponentModel;\n"
                + "using System.Text;\n"
                + "using $NameSpacePath$.Models;\n"
                + "using $NameSpacePath$.IBusiness;\n"
                + "using $NameSpacePath$.DataAccess;\n"
                + "using SysManager.Common.Kernel;\n"
                + "using IBatisNet.Common;\n"
                + "using Teld.Core.Database.Service;\n"
                + "namespace $NameSpacePath$.Business {\n"
                + "    /// <summary>\n"
                + "    /// " + chinaComment + "业务逻辑接口实现\n"
                + "    /// </summary>\n"
                + "    public class $ModuleName$BLL:I$ModuleName$BLL {\n\n";
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
            sbContent.Append("      I$ModuleName$Dao $EntityProName$Dao = DaoService.GetInstance(SqlMap.$mapName$).GetDao<I$ModuleName$Dao>(); \n");
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
            sbContent.Append("      public List<$EntityName$> Get$ModuleName$ByFilter(IDictionary<string, object> dictParam) \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              return $EntityProName$Dao.Get$ModuleName$ByFilter(dictParam); \n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch \n");
            sbContent.Append("          { \n");
            sbContent.Append("              throw;\n");
            sbContent.Append("          }\n");
            sbContent.Append("      } \n");
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
            sbContent.Append("      public IDictionary<string, object> Get$ModuleName$ListForPaging(IDictionary<string, object> dictParam)\n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              IDictionary<string, object> retDict= new Dictionary<string, object>(); \n");
            sbContent.Append("              int count = $EntityProName$Dao.Get$ModuleName$ListForPagingCount(dictParam); \n");
            sbContent.Append("              IList<$EntityName$> list = $EntityProName$Dao.Get$ModuleName$ListForPaging(dictParam); \n");
            sbContent.Append("              retDict[\"total\"] = count; //总行数 \n");
            sbContent.Append("              retDict[\"rows\"] = list;//数据集 \n");
            sbContent.Append("              return retDict; \n");
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
            sbContent.Append("      public bool Add$ModuleName$($EntityName$ $EntityProName$) \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              $EntityProName$Dao.Add$ModuleName$($EntityProName$); \n");
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
            sbContent.Append("      public bool Edit$ModuleName$($EntityName$ $EntityProName$) \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              int i=$EntityProName$Dao.Edit$ModuleName$($EntityProName$); \n");
            sbContent.Append("              if (i == 1)\n");
            sbContent.Append("                  return true;\n");
            sbContent.Append("              else if (i == 0){\n");
            sbContent.Append("              return false;}\n");
            sbContent.Append("              else{\n");
            sbContent.Append("              return false;}\n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch \n");
            sbContent.Append("          { \n");
            sbContent.Append("              throw;\n");
            sbContent.Append("          }\n");
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
            sbContent.Append("      public bool Remove$ModuleName$(string keyID) \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              int i=$EntityProName$Dao.Remove$ModuleName$(keyID); \n");
            sbContent.Append("              if (i == 1)\n");
            sbContent.Append("                  return true;\n");
            sbContent.Append("              else if (i == 0){\n");
            sbContent.Append("              return false;}\n");
            sbContent.Append("              else{\n");
            sbContent.Append("              return false;}\n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch \n");
            sbContent.Append("          { \n");
            sbContent.Append("              throw;\n");
            sbContent.Append("          }\n");
            sbContent.Append("      } \n");
            sbContent.Append("      #endregion  \n\n");

            string BLLContent = header + sbContent.ToString() + footer;

            //替换文本
            BLLContent = BLLContent.Replace("$ModuleName$", moduleName);//模块名称
            BLLContent = BLLContent.Replace("$NameSpacePath$", nameSpacePath);//实体类路径
            BLLContent = BLLContent.Replace("$ChinaComment$", chinaComment);//中文注释
            BLLContent = BLLContent.Replace("$NowTimeStr$",DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day
                            + " "
                            + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);//创建时间
            BLLContent = BLLContent.Replace("$CreatePerson$", createPerson);//创建人
            BLLContent = BLLContent.Replace("$EntityName$", entityName);//实体类名
            BLLContent = BLLContent.Replace("$EntityProName$", entityProName);//实体类对象名
            BLLContent = BLLContent.Replace("$mapName$",mapName);//Map名称
            

            return BLLContent;
        }


    }
}
