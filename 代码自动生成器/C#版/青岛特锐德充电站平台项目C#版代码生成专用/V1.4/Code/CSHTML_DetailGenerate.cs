using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel
{
    /// <summary>
    /// 生成详情页面
    /// </summary>
    public class CSHTML_DetailGenerate
    {
        /// <summary>
        /// 生成详情页面
        /// </summary>
        /// <param name="moduleName">模块名</param>
        /// <param name="chinaComment">模块中文名</param>
        /// <param name="columnList">列集合</param>
        /// <returns></returns>
        public static string GenerateCSHTML_Detail(string moduleName,
            string chinaComment, List<ColumnModel> columnList)
        {
            StringBuilder sbContent = new StringBuilder();

            sbContent.Append(Common.GetSinleEnterStr("@{"));
            sbContent.Append(Common.GetSinleEnterStr("Layout = \"~/Views/Shared/_SingleCardPage.cshtml\";"));
            sbContent.Append(Common.GetSinleEnterStr("ViewBag.CardTitle = \"新增$ChinaComment$\";"));
            sbContent.Append(Common.GetSinleEnterStr("}"));

            sbContent.Append(Common.GetSinleEnterStr("@section Style{}"));


            sbContent.Append(Common.GetSinleEnterStr("@section TopButton "));
            sbContent.Append(Common.GetSinleEnterStr(" {"));
            sbContent.Append(Common.GetSinleEnterStr("<div class=\"well widget-body\"> "));
            sbContent.Append(Common.GetSinleEnterStr(" <button type=\"button\" name=\"btnSave\" class=\"btn btn-primary\" click-text=\"正在保存...\" onclick=\"$ModuleName$.BtnSave();\"><i class=\"fa fa-save\"></i>保存</button>"));
            sbContent.Append(Common.GetSinleEnterStr("<button type=\"button\" name=\"btnBack\" class=\"btn btn-default\"><i class=\"fa fa-reply\"></i>返回</button> "));
            sbContent.Append(Common.GetSinleEnterStr(" </div> "));
            sbContent.Append(Common.GetSinleEnterStr(" }"));

            sbContent.Append(Common.GetSinleEnterStr("@section BottomButton "));
            sbContent.Append(Common.GetSinleEnterStr(" {"));
            sbContent.Append(Common.GetSinleEnterStr("<div class=\"well widget-body\"> "));
            sbContent.Append(Common.GetSinleEnterStr(" <button type=\"button\" name=\"btnSave\" class=\"btn btn-primary\" click-text=\"正在保存...\" onclick=\"$ModuleName$.BtnSave();\"><i class=\"fa fa-save\"></i>保存</button>"));
            sbContent.Append(Common.GetSinleEnterStr("<button type=\"button\" name=\"btnBack\" class=\"btn btn-default\"><i class=\"fa fa-reply\"></i>返回</button> "));
            sbContent.Append(Common.GetSinleEnterStr(" </div> "));
            sbContent.Append(Common.GetSinleEnterStr(" }"));

            sbContent.Append(Common.GetSinleEnterStr("@section SelectCtrlType{}"));
            sbContent.Append(Common.GetSinleEnterStr("@section Modal{}"));

            sbContent.Append(Common.GetSinleEnterStr(" @section Form"));
            sbContent.Append(Common.GetSinleEnterStr("{ "));
            sbContent.Append(Common.GetSinleEnterStr(" <div class=\"well widget-body\"> "));
            sbContent.Append(Common.GetSinleEnterStr(" <div class=\"row\"> "));

            sbContent.Append(GetTableList(columnList));

            sbContent.Append(Common.GetSinleEnterStr("  </div>"));
            sbContent.Append(Common.GetSinleEnterStr("  </div>"));
            sbContent.Append(Common.GetSinleEnterStr(" }"));


            
            sbContent.Append(Common.GetSinleEnterStr("@section scripts "));
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


            int count = 0;
            int remainder = columnList.Count % 3;//取余
            int cycle = (columnList.Count - remainder) / 3;//表示3个一组的次数
            if (cycle == 0)
            {//表示列小于3个 
                column.Append("<div class=\"col-lg-12 col-sm-12 col-xs-12\">\n");
                for (int i = 0; i < columnList.Count; i++)
                {
                    GetDynamicData(ref column, columnList[i]);
                }
                column.Append(" </div>\n");
            }
            else
            {
                for (int n = 1; n <= cycle; n++)
                {
                    column.Append("<div class=\"col-lg-12 col-sm-12 col-xs-12\">\n");

                    GetDynamicData(ref column, columnList[3 * (n - 1)]);
                    GetDynamicData(ref column, columnList[3 * (n - 1) + 1]);
                    GetDynamicData(ref column, columnList[3 * (n - 1) + 2]);

                    column.Append(" </div>\n");
                }
                if (remainder > 0)
                {
                    column.Append("<div class=\"col-lg-12 col-sm-12 col-xs-12\">\n");
                    for (int i = 0; i < remainder; i++)
                    {
                        GetDynamicData(ref column, columnList[3 * (cycle) + i]);
                    }
                    column.Append(" </div>\n");
                }
            }
            return column.ToString();
        }


        /// <summary>
        /// 构造动态编辑项
        /// </summary>
        /// <param name="column"></param>
        /// <param name="columnModel"></param>
        public static void GetDynamicData(ref StringBuilder column, ColumnModel columnModel)
        {
            column.Append(" <div class=\"col-lg-4 col-sm-4 col-xs-12\">\n ");
            column.Append("<div class=\"form-group\">\n ");
            column.Append(" <label class=\"col-sm-4 control-label no-padding-left\">*" + columnModel.ColumnComment + "</label>\n");
            column.Append("  <div class=\"col-sm-8\">\n");
            column.Append("<input type=\"text\" class=\"form-control\" id=\"" + columnModel.ColumnName + "\" name=\"" + columnModel.ColumnName + "\" value=\"@ViewBag.$ModuleName$Entity."
                + columnModel.ColumnName + "\" data-bv-notempty=\"true\" data-bv-notempty-message=\"请输入" + columnModel.ColumnComment + "\" data-bv-stringlength=\"true\" data-bv-stringlength-max=\"64\" data-bv-stringlength-message=\"" + columnModel.ColumnComment
                + "超出长度(不能超过64个字符)\" data-bv-field=\"" + columnModel.ColumnName + "\"> \n");
            column.Append(" </div>\n");
            column.Append(" </div>\n");
            column.Append(" </div>\n");
        }
    }
}
