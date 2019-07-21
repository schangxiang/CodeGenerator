using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel
{
    /// <summary>
    /// 生成JS
    /// </summary>
    public class JSGenerate
    {
        /// <summary>
        /// 生成JS
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <param name="moduleName">模块名</param>
        /// <param name="chinaComment">模块中文名</param>
        /// <param name="createPerson">创建人</param>
        /// <returns></returns>
        public static string GenerateJS(string primaryKey, string moduleName,
            string chinaComment, string createPerson)
        {
            StringBuilder sbContent = new StringBuilder();
            sbContent.Append(Common.GetSinleEnterStr("//***********************************************************"));
            sbContent.Append(Common.GetSinleEnterStr("//功能描述：$ChinaComment$脚本"));
            sbContent.Append(Common.GetSinleEnterStr("//创建人：$CreatePerson$"));
            sbContent.Append(Common.GetSinleEnterStr("//创建时间：$NowTimeStr$"));
            sbContent.Append(Common.GetSinleEnterStr("//***********************************************************"));

            #region JS对象

            sbContent.Append(Common.GetSinleEnterStr("var $ModuleName$ = {"));

            //记载数据
            sbContent.Append(Common.GetSinleEnterStr("//加载数据"));
            sbContent.Append(Common.GetSinleEnterStr("LoadData: function () {"));
            sbContent.Append(Common.GetSinleEnterStr("var postData = {"));
            sbContent.Append(Common.GetSinleEnterStr(" \"filter\": {"));
            sbContent.Append(Common.GetSinleEnterStr("\"KeyValue\": $(\"#KeyValue\").val()"));
            sbContent.Append(Common.GetSinleEnterStr("}"));
            sbContent.Append(Common.GetSinleEnterStr(" }"));
            sbContent.Append(Common.GetSinleEnterStr("$(\"#$ModuleName$Table\").datagrid({"));
            sbContent.Append(Common.GetSinleEnterStr("url: \"/$ModuleName$/Get$ModuleName$ListForPaging\","));
            sbContent.Append(Common.GetSinleEnterStr("tableType: \"single\","));
            sbContent.Append(Common.GetSinleEnterStr("hiddenInps: ["));
            sbContent.Append(Common.GetSinleEnterStr("{ inpNm: \"hid$PrimaryKey$\", inpValue: \"$PrimaryKey$\" }"));
            sbContent.Append(Common.GetSinleEnterStr(" ]"));
            sbContent.Append(Common.GetSinleEnterStr("}).data('bs.datagrid').searchByFilter({ searchCond: postData });"));
            sbContent.Append(Common.GetSinleEnterStr("},"));

            #region 绑定按钮事件

            //绑定按钮事件
            sbContent.Append(Common.GetSinleEnterStr("//绑定按钮事件"));
            sbContent.Append(Common.GetSinleEnterStr("BindBtnEvent: function () {"));

            sbContent.Append(Common.GetSinleEnterStr("//新增"));
            sbContent.Append(Common.GetSinleEnterStr("$(\"#btnAdd\").click(function () {"));
            sbContent.Append(Common.GetSinleEnterStr("$.pjax({ url: \"/$ModuleName$/$ModuleName$Detail?flag=ADD\" });"));
            sbContent.Append(Common.GetSinleEnterStr("});"));

            sbContent.Append(Common.GetSinleEnterStr("//修改"));
            sbContent.Append(Common.GetSinleEnterStr("$(\"#btnEdit\").click(function () {"));
            sbContent.Append(Common.GetSinleEnterStr("var selectTr = $(\"#$ModuleName$Table .selected\");"));
            sbContent.Append(Common.GetSinleEnterStr("if (selectTr.length > 0) {"));
            sbContent.Append(Common.GetSinleEnterStr("var id = $(selectTr).find(\"[name=hid$PrimaryKey$]\").val();"));
            sbContent.Append(Common.GetSinleEnterStr("$.pjax({ url: \"/$ModuleName$/$ModuleName$Detail?flag=EDIT&id=\" + id });"));
            sbContent.Append(Common.GetSinleEnterStr("} else {"));
            sbContent.Append(Common.GetSinleEnterStr("NotifyWarning(\"请先选择要修改的$ChinaComment$信息\");"));
            sbContent.Append(Common.GetSinleEnterStr(" }"));
            sbContent.Append(Common.GetSinleEnterStr(" });"));

            sbContent.Append(Common.GetSinleEnterStr("//删除"));
            sbContent.Append(Common.GetSinleEnterStr("$(\"#btnDelete\").click(function () {"));
            sbContent.Append(Common.GetSinleEnterStr(" var selectTr = $(\"#$ModuleName$Table .selected\");"));
            sbContent.Append(Common.GetSinleEnterStr(" if (selectTr.length > 0) {"));
            sbContent.Append(Common.GetSinleEnterStr("bootbox.setDefaults(\"locale\", \"zh_CN\");"));
            sbContent.Append(Common.GetSinleEnterStr(" bootbox.confirm(\"您确定要删除该$ChinaComment$信息吗？\", function (ok) {"));
            sbContent.Append(Common.GetSinleEnterStr("if (ok == true) {"));
            sbContent.Append(Common.GetSinleEnterStr(" var id = $(selectTr).find(\"[name=hid$PrimaryKey$]\").val();"));
            sbContent.Append(Common.GetSinleEnterStr(" var postData = { \"$PrimaryKey$\": id }"));
            sbContent.Append(Common.GetSinleEnterStr("getDataAsync(\"/$ModuleName$/Remove$ModuleName$\", \"post\", postData, function (result) {"));
            sbContent.Append(Common.GetSinleEnterStr("if (result.state == \"1\") {"));
            sbContent.Append(Common.GetSinleEnterStr(" NotifySuccess(\"删除成功\");"));
            sbContent.Append(Common.GetSinleEnterStr(" $ModuleName$.LoadData();"));
            sbContent.Append(Common.GetSinleEnterStr("} else {"));
            sbContent.Append(Common.GetSinleEnterStr(" NotifyError(\"删除失败,请联系管理员\");"));
            sbContent.Append(Common.GetSinleEnterStr(" }"));
            sbContent.Append(Common.GetSinleEnterStr("});"));
            sbContent.Append(Common.GetSinleEnterStr(" }"));
            sbContent.Append(Common.GetSinleEnterStr(" });"));
            sbContent.Append(Common.GetSinleEnterStr(" } else {"));
            sbContent.Append(Common.GetSinleEnterStr("NotifyWarning(\"请先选择要删除的$ChinaComment$信息\");"));
            sbContent.Append(Common.GetSinleEnterStr(" }"));
            sbContent.Append(Common.GetSinleEnterStr(" });"));

            sbContent.Append(Common.GetSinleEnterStr(" //查看"));
            sbContent.Append(Common.GetSinleEnterStr("$(\"#btnView\").click(function () {"));
            sbContent.Append(Common.GetSinleEnterStr(" var selectTr = $(\"#$ModuleName$Table .selected\");"));
            sbContent.Append(Common.GetSinleEnterStr("if (selectTr.length > 0) {"));
            sbContent.Append(Common.GetSinleEnterStr("var id = $(selectTr).find(\"[name=hid$PrimaryKey$]\").val();"));
            sbContent.Append(Common.GetSinleEnterStr("$.pjax({ url: \"/$ModuleName$/$ModuleName$Detail?flag=VIEW&id=\" + id });"));
            sbContent.Append(Common.GetSinleEnterStr(" } else {"));
            sbContent.Append(Common.GetSinleEnterStr("NotifyWarning(\"请先选择要查看的$ChinaComment$信息\");"));
            sbContent.Append(Common.GetSinleEnterStr(" }"));
            sbContent.Append(Common.GetSinleEnterStr(" });"));

            sbContent.Append(Common.GetSinleEnterStr(" //查询 "));
            sbContent.Append(Common.GetSinleEnterStr(" $(\"#btnSearch\").click(function () {"));
            sbContent.Append(Common.GetSinleEnterStr("  //列表加载"));
            sbContent.Append(Common.GetSinleEnterStr("  $ModuleName$.LoadData();"));
            sbContent.Append(Common.GetSinleEnterStr(" }); "));

            sbContent.Append(Common.GetSinleEnterStr("//重置 "));
            sbContent.Append(Common.GetSinleEnterStr(" $(\"#btnReset\").click(function () {"));
            sbContent.Append(Common.GetSinleEnterStr("  $(\"#KeyValue\").val('');"));
            sbContent.Append(Common.GetSinleEnterStr("  $ModuleName$.LoadData();"));
            sbContent.Append(Common.GetSinleEnterStr("}); "));

            sbContent.Append(Common.GetSinleEnterStr(" //回车事件"));
            sbContent.Append(Common.GetSinleEnterStr("  $(\"#KeyValue\").keyup(function (event) {"));
            sbContent.Append(Common.GetSinleEnterStr("  if (event.keyCode == 13) {"));
            sbContent.Append(Common.GetSinleEnterStr(" $(\"#btnSearch\").click();"));
            sbContent.Append(Common.GetSinleEnterStr("   }"));
            sbContent.Append(Common.GetSinleEnterStr("  });"));

            sbContent.Append(Common.GetSinleEnterStr(" },"));

            #endregion

            //详细页面禁用控件
            sbContent.Append(Common.GetSinleEnterStr(" DisabledControlFor$ModuleName$Detail: function () {"));
            sbContent.Append(Common.GetSinleEnterStr(" $(\"[name='btnSave']\").css(\"display\", \"none\");//隐藏保存按钮"));
            sbContent.Append(Common.GetSinleEnterStr("  $(\"input[type=text]\").attr(\"disabled\", \"disabled\");"));
            sbContent.Append(Common.GetSinleEnterStr("$(\"textarea\").attr(\"disabled\", \"disabled\"); "));
            sbContent.Append(Common.GetSinleEnterStr("  $(\"select\").attr(\"disabled\", \"disabled\");"));
            sbContent.Append(Common.GetSinleEnterStr("  },"));

            //保存
            sbContent.Append(Common.GetSinleEnterStr(" //保存"));
            sbContent.Append(Common.GetSinleEnterStr(" BtnSave: function () {"));
            sbContent.Append(Common.GetSinleEnterStr(" var form = $(\"#SingleCardForm\").data('bootstrapValidator').validate();//验证表单"));
            sbContent.Append(Common.GetSinleEnterStr("bool = form.isValid(); "));
            sbContent.Append(Common.GetSinleEnterStr(" if (bool == true) {"));
            sbContent.Append(Common.GetSinleEnterStr(" $(\"[name='btnSave']\").attr(\"disabled\", \"disabled\");"));
            sbContent.Append(Common.GetSinleEnterStr(" $(\"[name='btnSave']\").html(\"<i class='fa fa-save'></i>保存中...\");"));
            sbContent.Append(Common.GetSinleEnterStr(" var postData = { \"FormData\": $(\"#SingleCardForm\").form2json() };"));
            sbContent.Append(Common.GetSinleEnterStr(" var postUrl = '/$ModuleName$/Add$ModuleName$';"));
            sbContent.Append(Common.GetSinleEnterStr(" if (getQueryString(\"flag\") == \"EDIT\")"));
            sbContent.Append(Common.GetSinleEnterStr("       postUrl = '/$ModuleName$/Edit$ModuleName$';"));
            sbContent.Append(Common.GetSinleEnterStr("getDataAsync(postUrl, \"post\", postData, function (result) { "));
            sbContent.Append(Common.GetSinleEnterStr(" $(\"[name='btnSave']\").html(\"<i class='fa fa-save'></i>保存\");"));
            sbContent.Append(Common.GetSinleEnterStr("$(\"[name='btnSave']\").removeAttr(\"disabled\"); "));
            sbContent.Append(Common.GetSinleEnterStr(" if (result.state == \"1\") {"));
            sbContent.Append(Common.GetSinleEnterStr(" NotifySuccess(\"保存成功\");"));
            sbContent.Append(Common.GetSinleEnterStr(" window.history.go(-1);"));
            sbContent.Append(Common.GetSinleEnterStr(" } else {"));
            sbContent.Append(Common.GetSinleEnterStr("  NotifyError(\"保存$ChinaComment$信息失败，请联系管理员\");"));
            sbContent.Append(Common.GetSinleEnterStr("  }"));
            sbContent.Append(Common.GetSinleEnterStr("  });"));
            sbContent.Append(Common.GetSinleEnterStr("  }"));
            sbContent.Append(Common.GetSinleEnterStr(" } "));

            sbContent.Append(Common.GetSinleEnterStr("  }"));

            #endregion

            #region 页面加载

            sbContent.Append(Common.GetSinleEnterStr("//页面加载 "));
            sbContent.Append(Common.GetSinleEnterStr("$(function () { "));
            sbContent.Append(Common.GetSinleEnterStr("var action = getCurrentAction(); "));
            sbContent.Append(Common.GetSinleEnterStr("switch (action) { "));
            sbContent.Append(Common.GetSinleEnterStr("  case \"$ModuleName$\":"));
            sbContent.Append(Common.GetSinleEnterStr(" $ModuleName$.LoadData();//列表加载"));
            sbContent.Append(Common.GetSinleEnterStr("$ModuleName$.BindBtnEvent();//加载按钮事件 "));
            sbContent.Append(Common.GetSinleEnterStr("break; "));
            sbContent.Append(Common.GetSinleEnterStr(" case \"$ModuleName$Detail\": "));
            sbContent.Append(Common.GetSinleEnterStr("var flag = getQueryString(\"flag\"); "));
            sbContent.Append(Common.GetSinleEnterStr("switch (flag) { "));
            sbContent.Append(Common.GetSinleEnterStr("  case \"ADD\":"));
            sbContent.Append(Common.GetSinleEnterStr(" $(\"#SingleCardForm\").bootstrapValidator();//注册验证事件"));
            sbContent.Append(Common.GetSinleEnterStr(" break;"));
            sbContent.Append(Common.GetSinleEnterStr(" case \"EDIT\": "));
            sbContent.Append(Common.GetSinleEnterStr("$(\"#SingleCardForm\").bootstrapValidator();//注册验证事件 "));
            sbContent.Append(Common.GetSinleEnterStr(" break;"));
            sbContent.Append(Common.GetSinleEnterStr(" case \"VIEW\":"));
            sbContent.Append(Common.GetSinleEnterStr("$ModuleName$.DisabledControlFor$ModuleName$Detail(); "));
            sbContent.Append(Common.GetSinleEnterStr("break; "));
            sbContent.Append(Common.GetSinleEnterStr("  };"));
            sbContent.Append(Common.GetSinleEnterStr(" //点击按钮【返回】事件 "));
            sbContent.Append(Common.GetSinleEnterStr("$(\"[name='btnBack']\").click(function () { "));
            sbContent.Append(Common.GetSinleEnterStr(" window.history.go(-1); "));
            sbContent.Append(Common.GetSinleEnterStr("  }); "));
            sbContent.Append(Common.GetSinleEnterStr(" break;"));
            sbContent.Append(Common.GetSinleEnterStr(" }"));
            sbContent.Append(Common.GetSinleEnterStr(" })"));


            #endregion

            sbContent.Replace("$ChinaComment$", chinaComment);
            sbContent.Replace("$ModuleName$", moduleName);//模块名称
            sbContent.Replace("$NowTimeStr$", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);//创建时间
            sbContent.Replace("$CreatePerson$", createPerson);//创建人
            sbContent.Replace("$PrimaryKey$", primaryKey);

            return sbContent.ToString();
        }
    }
}
