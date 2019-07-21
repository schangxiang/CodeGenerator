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
                + "    public class $ModuleName$Controller:AuthBaseController {\n\n";
            string footer = "    }\n" + "}";


            //生成主体内容
            StringBuilder sbContent = new StringBuilder();

            //初始化数据访问接口
            sbContent.Append("      #region 初始化业务逻辑接口 \n\n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// $ChinaComment$业务逻辑接口 \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      [Dependency] \n");
            sbContent.Append("      public  I$ModuleName$BLL $EntityProName$Bll{ get;set; } \n\n");
            sbContent.Append("      #endregion  \n\n");

            //视图区
            sbContent.Append("      #region 视图区 \n\n");

            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// $ChinaComment$列表 \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      [ButtonFilter] \n");
            sbContent.Append("      [ModuleAuthFilter] \n");
            sbContent.Append("      public ActionResult $ModuleName$()\n");
            sbContent.Append("      {\n");
            sbContent.Append("          return View();\n");
            sbContent.Append("      }\n\n");

            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// $ChinaComment$详情 \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      public ActionResult $ModuleName$Detail()\n");
            sbContent.Append("      {\n");
            sbContent.Append("          string flag = this.Request[\"Flag\"].ToString();\n");
            sbContent.Append("          if (flag == \"EDIT\" || flag == \"VIEW\")\n");
            sbContent.Append("          {\n");
            sbContent.Append("              IDictionary<string, object> dict = new Dictionary<string, object>();\n");
            sbContent.Append("              dict.Add(\"ID\", this.Request[\"ID\"].ToString());\n");
            sbContent.Append("              List<$ModuleName$Entity> list = $EntityProName$Bll.Get$ModuleName$ByFilter(dict);\n");
            sbContent.Append("              if (list != null && list.Count == 1)");
            sbContent.Append("              {\n");
            sbContent.Append("                  ViewBag.$ModuleName$Entity = list[0];\n");
            sbContent.Append("              }\n");
            sbContent.Append("              else");
            sbContent.Append("              {\n");
            sbContent.Append("                  throw new TeldException(\"500\", \"查询$ChinaComment$详情失败，请联系管理员\");\n");
            sbContent.Append("              }\n");
            sbContent.Append("          }\n");
            sbContent.Append("          else \n");
            sbContent.Append("          { \n");
            sbContent.Append("              ViewBag.$ModuleName$Entity = new $ModuleName$Entity();\n");
            sbContent.Append("          }\n");
            sbContent.Append("          return View();\n");
            sbContent.Append("      }\n\n");

            sbContent.Append("      #endregion  \n\n");

            //查询
            sbContent.Append("      #region 根据过滤条件查询查询$ChinaComment$ \n\n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 根据过滤条件查询查询$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <param name=\"filter\">过滤条件</param> \n");
            sbContent.Append("      /// <returns>$ChinaComment$数据集</returns> \n");
            sbContent.Append("      public ActionResult Get$ModuleName$ByFilter() \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              string ID = this.Request[\"ID\"]; \n");
            sbContent.Append("              IDictionary<string, object> filter = new Dictionary<string, object>(); \n");
            sbContent.Append("              filter.Add(\"ID\",ID); \n");
            sbContent.Append("              List<$EntityName$> $EntityProName$List = $EntityProName$Bll.Get$ModuleName$ByFilter(filter); \n");
            sbContent.Append("              //格式化数据");
            sbContent.Append("\n");
            sbContent.Append("              IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();\n");
            sbContent.Append("              timeConverter.DateTimeFormat = \"yyyy'-'MM'-'dd HH:mm:ss\";//时间格式\n");
            sbContent.Append("              return Ok($EntityProName$List, new JsonConverter[] { timeConverter }); \n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch (Exception ex) \n");
            sbContent.Append("          { \n");
            sbContent.Append("              throw new TeldException(\"500\", \"查询$ChinaComment$信息加载失败，请联系管理员\", ex);;\n");
            sbContent.Append("          }\n");
            sbContent.Append("      } \n\n");
            sbContent.Append("      #endregion  \n\n");

            //分页查询
            sbContent.Append("      #region 分页查询$ChinaComment$ \n\n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 分页查询$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      public ActionResult Get$ModuleName$ListForPaging() \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              IDictionary<string, object> filter = new Dictionary<string, object>(); \n");
            sbContent.Append("              if ((Convert.ToString(this.Request[\"filter\"]) + \"\").Length > 0) \n");
            sbContent.Append("                  filter = (IDictionary<string, object>)JsonConvert.DeserializeObject(this.Request[\"filter\"].ToString(), typeof(IDictionary<string, object>)); \n");
            sbContent.Append("              \n");
            sbContent.Append("              IDictionary<string, object> dataList= $EntityProName$Bll.Get$ModuleName$ListForPaging(filter); \n");
            sbContent.Append("              //格式化数据");
            sbContent.Append("\n");
            sbContent.Append("              IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();\n");
            sbContent.Append("              timeConverter.DateTimeFormat = \"yyyy'-'MM'-'dd HH:mm:ss\";//时间格式\n");
            sbContent.Append("              return Ok(dataList, new JsonConverter[] { timeConverter }); \n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch (Exception ex) \n");
            sbContent.Append("          { \n");
            sbContent.Append("              throw new TeldException(\"500\", \"$ChinaComment$信息加载失败，请联系管理员\", ex);;\n");
            sbContent.Append("          }\n");
            sbContent.Append("      } \n\n");
            sbContent.Append("      #endregion  \n\n");


            //新增
            sbContent.Append("      #region 新增$ChinaComment$ \n\n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 新增$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <returns></returns> \n");
            sbContent.Append("      public ActionResult Add$ModuleName$() \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              string formStr = Server.UrlDecode(Request.Form[\"FormData\"]);\n");
            sbContent.Append("              $EntityName$ entity = JsonConvert.DeserializeObject<$EntityName$>(formStr);\n");
            sbContent.Append("              if (entity != null)");
            sbContent.Append("              {\n");
            sbContent.Append("                  SessionUser user = ((SessionUser)(this.SessionExt().Get<SessionUser>()));\n");
            sbContent.Append("                  entity.LastModifier = entity.Creator = user.UserName;\n");
            sbContent.Append("                  if ($EntityProName$Bll.Add$ModuleName$(entity))\n");
            sbContent.Append("                  {\n");
            sbContent.Append("                      return Ok();\n");
            sbContent.Append("                  }\n");
            sbContent.Append("                  else \n");
            sbContent.Append("                  {\n");
            sbContent.Append("                      return Error(\"400\", \"新增$ChinaComment$失败\");\n");
            sbContent.Append("                  }\n");
            sbContent.Append("               }\n");
            sbContent.Append("              else {\n");
            sbContent.Append("              return Error(\"400\", \"新增$ChinaComment$失败,传递数据为空\");}\n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch(Exception ex) \n");
            sbContent.Append("          { \n");
            sbContent.Append("                 throw new TeldException(\"500\", \"新增$ChinaComment$失败，请联系管理员\", ex);\n");
            sbContent.Append("          }\n");
            sbContent.Append("      } \n\n");
            sbContent.Append("      #endregion  \n\n");

            //更新
            sbContent.Append("      #region 更新$ChinaComment$ \n\n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 更新$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <returns></returns> \n");
            sbContent.Append("      public ActionResult Edit$ModuleName$() \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              string formStr = Server.UrlDecode(Request.Form[\"FormData\"]);\n");
            sbContent.Append("              $EntityName$ entity = JsonConvert.DeserializeObject<$EntityName$>(formStr);\n");
            sbContent.Append("              if (entity != null)");
            sbContent.Append("              {\n");
            sbContent.Append("                  SessionUser user = ((SessionUser)(this.SessionExt().Get<SessionUser>()));\n");
            sbContent.Append("                  entity.LastModifier =user.UserName;\n");
            sbContent.Append("                  if ($EntityProName$Bll.Edit$ModuleName$(entity))\n");
            sbContent.Append("                  {\n");
            sbContent.Append("                      return Ok();\n");
            sbContent.Append("                  }\n");
            sbContent.Append("                   else \n");
            sbContent.Append("                   {\n");
            sbContent.Append("                      return Error(\"400\", \"修改$ChinaComment$失败\");\n");
            sbContent.Append("                   }\n");
            sbContent.Append("               }\n");
            sbContent.Append("              else {\n");
            sbContent.Append("              return Error(\"400\", \"修改$ChinaComment$失败,传递数据为空\");}\n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch(Exception ex) \n");
            sbContent.Append("          { \n");
            sbContent.Append("                 throw new TeldException(\"500\", \"修改$ChinaComment$失败，请联系管理员\", ex);\n");
            sbContent.Append("          }\n");
            sbContent.Append("      } \n\n");
            sbContent.Append("      #endregion  \n\n");

            //删除
            sbContent.Append("      #region 删除$ChinaComment$ \n\n");
            sbContent.Append("      /// <summary> \n");
            sbContent.Append("      /// 删除$ChinaComment$ \n");
            sbContent.Append("      /// Author：$CreatePerson$ \n");
            sbContent.Append("      /// Date：$NowTimeStr$ \n");
            sbContent.Append("      /// </summary> \n");
            sbContent.Append("      /// <returns></returns> \n");
            sbContent.Append("      public ActionResult Remove$ModuleName$() \n");
            sbContent.Append("      { \n");
            sbContent.Append("          try \n");
            sbContent.Append("          { \n");
            sbContent.Append("              string ID=this.Request[\"ID\"].ToString();\n");
            sbContent.Append("              if ($EntityProName$Bll.Remove$ModuleName$(ID))\n");
            sbContent.Append("              {\n");
            sbContent.Append("                  return Ok();\n");
            sbContent.Append("              }\n");
            sbContent.Append("              else \n");
            sbContent.Append("              {\n");
            sbContent.Append("                   return Error(\"400\", \"删除$ChinaComment$失败\");\n");
            sbContent.Append("              }\n");
            sbContent.Append("          }\n");
            sbContent.Append("          catch(Exception ex) \n");
            sbContent.Append("          { \n");
            sbContent.Append("                 throw new TeldException(\"500\", \"删除$ChinaComment$失败，请联系管理员\", ex);\n");
            sbContent.Append("          }\n");
            sbContent.Append("      } \n\n");
            sbContent.Append("      #endregion  \n\n");

            string ControllerContent = header + sbContent.ToString() + footer;

            //替换文本
            ControllerContent = ControllerContent.Replace("$ModuleName$", moduleName);//模块名称
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
