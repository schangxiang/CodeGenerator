using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel
{
    /// <summary>
    /// 生成列表页面
    /// </summary>
    public class CSHTML_ListGenerate
    {
        /// <summary>
        /// 生成列表页面
        /// </summary>
        /// <param name="moduleName">模块名</param>
        /// <param name="chinaComment">模块中文名</param>
        /// <param name="columnList">列集合</param>
        /// <returns></returns>
        public static string GenerateCSHTML_List(string moduleName,
            string chinaComment, List<ColumnModel> columnList)
        {
            StringBuilder sbContent = new StringBuilder();

            sbContent.Append(Common.GetSinleEnterStr("@{"));
            sbContent.Append(Common.GetSinleEnterStr("Layout = \"~/Views/Shared/_LayoutSingleList.cshtml\";"));
            sbContent.Append(Common.GetSinleEnterStr("ViewBag.Title = \"$ChinaComment$管理\";"));
            sbContent.Append(Common.GetSinleEnterStr("}"));

            sbContent.Append(Common.GetSinleEnterStr("@section Style{}"));

            sbContent.Append(Common.GetSinleEnterStr("@section TableListSearch"));
            sbContent.Append(Common.GetSinleEnterStr("{"));
            sbContent.Append(Common.GetSinleEnterStr(" <div class=\"btn-group \" style=\"width:210px;\">"));
            sbContent.Append(Common.GetSinleEnterStr("  <input type=\"text\" id=\"KeyValue\" class=\"form-control input-sm\" title=\"$ChinaComment$编号、$ChinaComment$名称\" placeholder=\"$ChinaComment$编号、$ChinaComment$名称\" />"));
            sbContent.Append(Common.GetSinleEnterStr(" </div>"));
            sbContent.Append(Common.GetSinleEnterStr("<div class=\"btn-group \"> "));
            sbContent.Append(Common.GetSinleEnterStr("<button type=\"button\" class=\"btn btn-default\" id=\"btnSearch\"><i class=\"fa fa-search\"></i>查询</button> "));
            sbContent.Append(Common.GetSinleEnterStr(" </div> "));
            sbContent.Append(Common.GetSinleEnterStr(" <div class=\"btn-group \">"));
            sbContent.Append(Common.GetSinleEnterStr(" <button type=\"button\" class=\"btn btn-default\" id=\"btnReset\"><i class=\"fa fa-repeat\"></i>重置</button>"));
            sbContent.Append(Common.GetSinleEnterStr(" </div>"));
            sbContent.Append(Common.GetSinleEnterStr(" }"));

            sbContent.Append(Common.GetSinleEnterStr(" @section TableListBtn"));
            sbContent.Append(Common.GetSinleEnterStr(" {"));
            sbContent.Append(Common.GetSinleEnterStr(" @*@TeldHelper.menuButton(ViewBag.Button, new string[] { \"btnAdd\",\"btnEdit\",\"btnDelete\",\"btnView\" })*@"));
            sbContent.Append(Common.GetSinleEnterStr(" <div class=\"widget-buttons\"> "));
            sbContent.Append(Common.GetSinleEnterStr(" <button id=\"btnAdd\" class=\"btn btn-primary\"><i class=\"fa fa-plus\"></i>新增</button>"));
            sbContent.Append(Common.GetSinleEnterStr(" </div>"));
            sbContent.Append(Common.GetSinleEnterStr(" <div class=\"widget-buttons\">"));
            sbContent.Append(Common.GetSinleEnterStr(" <button id=\"btnEdit\" class=\"btn btn-default\"><i class=\"fa fa-edit\"></i>编辑</button> "));
            sbContent.Append(Common.GetSinleEnterStr(" </div>"));
            sbContent.Append(Common.GetSinleEnterStr("<div class=\"widget-buttons\" style=\"text-align:right;\"> "));
            sbContent.Append(Common.GetSinleEnterStr("<button id=\"btnDelete\" class=\"btn btn-default\"><i class=\"fa fa-times\"></i>删除</button> "));
            sbContent.Append(Common.GetSinleEnterStr(" </div> "));
            sbContent.Append(Common.GetSinleEnterStr(" <div class=\"widget-buttons\" style=\"text-align:right;\">"));
            sbContent.Append(Common.GetSinleEnterStr("<button id=\"btnView\" class=\"btn btn-default\"><i class=\"fa fa-eye\"></i>查看</button> "));
            sbContent.Append(Common.GetSinleEnterStr("</div> "));
            sbContent.Append(Common.GetSinleEnterStr(" }"));

            sbContent.Append(Common.GetSinleEnterStr("@section TableContent "));
            sbContent.Append(Common.GetSinleEnterStr(" {"));
            sbContent.Append(Common.GetSinleEnterStr("<table class=\"table table-striped table-hover table-bordered  max-width-table\" id=\"$ModuleName$Table\"> "));
            sbContent.Append(Common.GetSinleEnterStr("  <thead>"));
            sbContent.Append(Common.GetSinleEnterStr("  <tr role=\"row\">"));
            sbContent.Append(GetTableList(columnList));
            sbContent.Append(Common.GetSinleEnterStr("  </tr>"));
            sbContent.Append(Common.GetSinleEnterStr(" </thead> "));
            sbContent.Append(Common.GetSinleEnterStr(" </table>"));
            sbContent.Append(Common.GetSinleEnterStr(" }"));

            sbContent.Append(Common.GetSinleEnterStr("@section PageScript "));
            sbContent.Append(Common.GetSinleEnterStr(" {"));
            sbContent.Append(Common.GetSinleEnterStr(" <script src=\"~/Content/js/$ModuleName$/$ModuleName$.js?Version=$NowTimeStr$\"></script>"));
            sbContent.Append(Common.GetSinleEnterStr(" }"));



            sbContent.Replace("$ChinaComment$", chinaComment);
            sbContent.Replace("$ModuleName$", moduleName);//模块名称
            sbContent.Replace("$NowTimeStr$", DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00"));//创建时间

            return sbContent.ToString();
        }

        /// <summary>
        /// 根据列名构造列表项
        /// </summary>
        /// <param name="columnList"></param>
        /// <returns></returns>
        public static string GetTableList(List<ColumnModel> columnList)
        {
            StringBuilder column = new StringBuilder();
            column.Append("<th style=\"width: 50px; text-align: center; \">\n");
            column.Append("@*radio*@序号\n");
            column.Append("</th>\n");
            for (int i = 0; i < columnList.Count; i++)
            {
                string attrColumnName = columnList[i].ColumnName;
                column.Append("<th style=\"width: 50px; text-align: center; \" data-field=\"field:" + columnList[i].ColumnName + ",cssClass:text-center,hasTitle:true\">\n");
                column.Append(" @Html.Label(\"" + columnList[i].ColumnComment + "\")\n");
                column.Append("</th>\n");
            }
            return column.ToString();
        }
    }
}
