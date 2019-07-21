using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel {
    public class ModelGenerate {


        public static string GenerateModel(string tableName,List<string> columnNameList) {
            string header = "using System;\n"
                        + "using System.Collections.Generic;\n"
                        + "using System.Linq;\n"
                        + "using System.Text;\n"

                        + "namespace Model\n"
                        + "{\n"
                        + "    [Serializable]\n"
                        + "    public class " + tableName + "\n"
                        + "    {\n\n";
            int columnCount = columnNameList.Count;
            string attrString = "";
            for (int i = 0; i < columnCount; ++i) {
                attrString += GenerateAttribute(columnNameList[i]);
            }
            string footer = "    }\n" 
                + "}";

            return header + attrString + footer;

        }


        private static string GenerateAttribute(string columnName) {
            string attr = columnName.Substring(columnName.IndexOf('_') + 1);
            string attrStr = "        public string " + attr + " { get; set; }\n";
            return attrStr;
        }


    }
}
