

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// VUE文件
    /// </summary>
    public class VUE_Generate
    {
        public static string CreateText(string TableAlias, string modulelogo, string primaryKey,
            List<ColumnModel> columnNameList, string ChinaComment
            , string emport_templeteFileDownName, string emport_excelCategroy)
        {
            var str = TextHelper.ReadText(@"Templete\VUE\VUE文件模板.txt");


            str = str.Replace("$el-table-column$", StructStrHelper.GetElTableColumnStr(columnNameList));//列表项

            //新增/编辑界面
            str = str.Replace("$el-item$", StructStrHelper.GetElFormItemStr(columnNameList));

            str = str.Replace("$el-form-itemForSearch$", StructStrHelper.GetElFormItemForSearchStr(columnNameList));

            //导出字符串
            str = str.Replace("$VueExportColumnHeaderStr$", StructStrHelper.GetVueExportTHeaderArrayStr(columnNameList));


            //公共查询的列
            var SearchFormInputPlaceholderNameStr = "";
            str = str.Replace("$SearchFormInputPlaceholderStr$", StructStrHelper.GetVueSearchFormInputPlaceholderStr(columnNameList, ref SearchFormInputPlaceholderNameStr));
            str = str.Replace("$SearchFormInputPlaceholderNameStr$", SearchFormInputPlaceholderNameStr);

            //高级查询
            str = str.Replace("$FormOptionsStr$", StructStrHelper.GetVueFormOptionsStr(columnNameList));

            str = str.Replace("$ChinaComment$", ChinaComment);//中文注释


            str = str.Replace("$Modulelogo$", modulelogo);//表别名(他一定要在最后替换)
            str = str.Replace("$TableAlias$", TableAlias);//表别名(他一定要在最后替换)
            str = str.Replace("$PrimaryKey$", primaryKey);//主键

            //替换导入功能
            str = str.Replace("$emport_templeteFileDownName$", emport_templeteFileDownName);
            str = str.Replace("$emport_excelCategroy$", emport_excelCategroy);

            return str;
        }
    }
}
