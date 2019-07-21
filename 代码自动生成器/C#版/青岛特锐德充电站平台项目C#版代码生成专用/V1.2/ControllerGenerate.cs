using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel
{
    public class ControllerGenerate
    {

        /// <summary>
        /// 生成Controller
        /// </summary>
        /// <param name="moduleName">模块名称</param>
        /// <param name="chinaComment">中文注释</param>
        /// <param name="entityName">实体类名称</param>
        /// <param name="entityProName">实体类对象名称</param>
        /// <param name="nameSpacePath">命名空间</param>
        /// <param name="createPerson">创建人</param>
        /// <returns></returns>
        public static string CreateControllerClass(string moduleName, string chinaComment, string entityName, string entityProName, string nameSpacePath, string createPerson)
        {

            string header = @"/*
 * CLR Version：4.0.30319.34014
 * NameSpace：$nameSpacePath$.Controller
 * FileName：" + moduleName + @"Controller
 * FileDesc：" + chinaComment + @"控制器
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
                + "using $NameSpacePath$.IBusiness;\n"
                + "using System.Web.Mvc;\n"
                + "using Newtonsoft.Json;\n"
                + "using Microsoft.Practices.Unity;\n"
                + "using SysManager.Common.Utilities;\n"
                + "using System.Configuration;\n"
                + "using Newtonsoft.Json.Converters;\n"
                + "namespace $NameSpacePath$.Controllers {\n"
                + "    /// <summary>\n"
                + "    /// " + chinaComment + "控制器\n"
                + "    /// </summary>\n"
                + "    public class $WarnMeasure$Controller:Controller {\n\n";
            string footer = "    }\n" + "}";


            //生成主体内容
            StringBuilder sbContent = new StringBuilder();

            //初始化数据访问接口
            sbContent.Append("      #region 初始化业务逻辑接口 \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// $ChinaComment$业务逻辑接口 \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      [Dependency] \n");
            sbContent.Append("      public  I$WarnMeasure$BLL $EntityProName$Bll{ get;set; } \n");
            sbContent.Append("      #endregion  \n\n");

            //分页相关变量
            sbContent.Append("      #region 分页相关变量 \n");
            sbContent.Append("      \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 记录总数 \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      private int rowCount = 0; \n");
            sbContent.Append("      \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 总页数 \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      private int pageCount = 1; \n");
            sbContent.Append("      \n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 每页显示记录数 \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      private int pageSize = 10; \n");
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
            sbContent.Append("      public string Get$WarnMeasure$ByFilter() \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              string Id = this.Request[\"Id\"]; \n");
            sbContent.Append("              string Fiter = \"where ID='\" + Id + \"'\"; \n");
            sbContent.Append("              List<$EntityName$> $EntityProName$List = $EntityProName$Bll.Get$WarnMeasure$ByFilter(Fiter); \n");
            sbContent.Append("              return JsonConvert.SerializeObject($EntityProName$List); \n");
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
            sbContent.Append("      public string Get$WarnMeasure$ListForPaging() \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              IDictionary<string, object> filter = new Dictionary<string, object>(); \n");
            sbContent.Append("              if ((Convert.ToString(this.Request[\"filter\"]) + \"\").Length > 0) \n");
            sbContent.Append("                  filter = (IDictionary<string, object>)JsonConvert.DeserializeObject(this.Request[\"filter\"].ToString(), typeof(IDictionary<string, object>)); \n");
            sbContent.Append("              \n");
            sbContent.Append("              IDictionary<string, object> returnHT= $EntityProName$Bll.Get$WarnMeasure$ListForPaging(filter); \n");
            sbContent.Append("              rowCount = Convert.ToInt32(returnHT[\"total\"]);//总条数 \n");
            sbContent.Append("              pageSize = Convert.ToInt32(filter[\"rows\"]);//每页显示的行数\n");
            sbContent.Append("              pageCount = (rowCount % pageSize == 0 ? rowCount / pageSize : (rowCount / pageSize) + 1); \n");
            sbContent.Append("              IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();\n");
            sbContent.Append("              timeConverter.DateTimeFormat = \"yyyy'-'MM'-'dd HH:mm:ss\";//时间格式\n");
            sbContent.Append("              return JsonConvert.SerializeObject(returnHT, timeConverter); \n");
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
            sbContent.Append("      public string Add$WarnMeasure$() \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              string formStr = Server.UrlDecode(Request.Form[\"FormVal\"]);\n");
            sbContent.Append("              $EntityName$ entity = JsonConvert.DeserializeObject<$EntityName$>(formStr);\n");
            sbContent.Append("              if ($EntityProName$Bll.Add$WarnMeasure$(entity))\n");
            sbContent.Append("              {\n");
            sbContent.Append("                  return ConvertJson.Serialize(\"1\", \"\", \"\", \"\", \"\");\n");
            sbContent.Append("              }\n");
            sbContent.Append("              else \n");
            sbContent.Append("              {\n");
            sbContent.Append("                  return ConvertJson.Serialize(\"0\", \"\", \"新增失败\", \"\", \"\");\n");
            sbContent.Append("              }\n");
            sbContent.Append("              \n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch(Exception ex) \n");
            sbContent.Append("          { \n");
            sbContent.Append("                  return ConvertJson.Serialize(\"0\", \"\", \"新增异常:\"+ex.Message, \"\", \"\");\n");
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
            sbContent.Append("      public string Edit$WarnMeasure$() \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              string formStr = Server.UrlDecode(Request.Form[\"FormVal\"]);\n");
            sbContent.Append("              $EntityName$ entity = JsonConvert.DeserializeObject<$EntityName$>(formStr);\n");
            sbContent.Append("              if ($EntityProName$Bll.Edit$WarnMeasure$(entity))\n");
            sbContent.Append("              {\n");
            sbContent.Append("                  return ConvertJson.Serialize(\"1\", \"\", \"\", \"\", \"\");\n");
            sbContent.Append("              }\n");
            sbContent.Append("              else \n");
            sbContent.Append("              {\n");
            sbContent.Append("                  return ConvertJson.Serialize(\"0\", \"\", \"修改失败\", \"\", \"\");\n");
            sbContent.Append("              }\n");
            sbContent.Append("              \n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch(Exception ex) \n");
            sbContent.Append("          { \n");
            sbContent.Append("                  return ConvertJson.Serialize(\"0\", \"\", \"修改异常:\"+ex.Message, \"\", \"\");\n");
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
            sbContent.Append("      /// <param name=\"$EntityProName$\">$ChinaComment$Model</param> \n");
            sbContent.Append("      /// <returns>true:成功，false:失败</returns> \n");
            sbContent.Append("      public string Remove$WarnMeasure$() \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              string ID=this.Request[\"ID\"].ToString();\n");
            sbContent.Append("              if ($EntityProName$Bll.Remove$WarnMeasure$(ID))\n");
            sbContent.Append("              {\n");
            sbContent.Append("                  return ConvertJson.Serialize(\"1\", \"\", \"\", \"\", \"\");\n");
            sbContent.Append("              }\n");
            sbContent.Append("              else \n");
            sbContent.Append("              {\n");
            sbContent.Append("                  return ConvertJson.Serialize(\"0\", \"\", \"删除失败\", \"\", \"\");\n");
            sbContent.Append("              }\n");
            sbContent.Append("              \n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch(Exception ex) \n");
            sbContent.Append("          { \n");
            sbContent.Append("                  return ConvertJson.Serialize(\"0\", \"\", \"删除异常:\"+ex.Message, \"\", \"\");\n");
            sbContent.Append("          }\n");
            sbContent.Append("      } \n");
            sbContent.Append("      #endregion  \n\n");

            string ControllerContent = header + sbContent.ToString() + footer;

            //替换文本
            ControllerContent = ControllerContent.Replace("$WarnMeasure$", moduleName);//模块名称
            ControllerContent = ControllerContent.Replace("$NameSpacePath$", nameSpacePath);//实体类路径
            ControllerContent = ControllerContent.Replace("$ChinaComment$", chinaComment);//中文注释
            ControllerContent = ControllerContent.Replace("$NowTimeStr$", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day
                            + " "
                            + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);//创建时间
            ControllerContent = ControllerContent.Replace("$CreatePerson$", createPerson);//创建人
            ControllerContent = ControllerContent.Replace("$EntityName$", entityName);//实体类名
            ControllerContent = ControllerContent.Replace("$EntityProName$", entityProName);//实体类对象名

            return ControllerContent;
        }


    }
}
