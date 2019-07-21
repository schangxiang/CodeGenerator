using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel {
    public class SqlMapGenerate {

        private static string GenerateAttribute(string columnName) {
            string attr = columnName.Substring(columnName.IndexOf('_') + 1);
            string attrStr = "        public string " + attr + " { get; set; }\n";
            return attrStr;
        }

        private static string GenerateProperty(List<string> columnNameList) {
            int columnCount = columnNameList.Count;
            string props = "  <resultMaps>\n"
                + "    <resultMap id=\"WarnMeasureMap\" class=\"WarnMeasure\">\n";
            for (int i = 0; i < columnCount; ++i) {
                string attr = columnNameList[i].Substring(columnNameList[i].IndexOf('_') + 1);
                props += "<result property=\"" + attr + "\" column=\"" + columnNameList[i] + "\"/>\n";
            }
            props += "    </resultMap>\n" + "  </resultMaps>\n\n\n\n<statements>\n\n\n";

            return props;
        }

        public static string GenerateXml(string tableName,List<string> columnList) {
            string header = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n"
                + "<sqlMap namespace=\"WarnMeasure\" xmlns=\"http://ibatis.apache.org/mapping\"\n"
                + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" >\n\n"
                + "  <alias>\n"
                + "    <typeAlias alias=\"WarnMeasure\" type=\"Model.WarnMeasure,Model\" />\n"
                + "  </alias>\n\n\n\n";
            header = header.Replace("WarnMeasure", tableName);
            string props = GenerateProperty(columnList);
            props = props.Replace("WarnMeasure", tableName);
            string footer = "  </statements>\n" + "</sqlMap>";


            return header + props + footer;
        }





    }
}
