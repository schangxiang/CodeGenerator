using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel
{
    public class ModelGenerate
    {

        /// <summary>
        /// 创建实体类
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columnNameList"></param>
        /// <param name="moduleName">模块名称</param>
        /// <param name="nameSpacePath">类命名空间</param>
        /// <param name="createPerson">创建人</param>
        /// <param name="chinaComment">中文注释</param>
        /// <param name="entityName">实体类名</param>
        /// <returns></returns>
        public static string GenerateModel(string tableName, List<ColumnModel> columnNameList, string moduleName, string nameSpacePath, string createPerson, string chinaComment,string entityName)
        {
            string header = @"/*
 * FileName："+tableName+@"Entity
 * FileDesc：" + chinaComment + @"实体类
 * CurrentTime：" +DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day+@"
 * Author："+createPerson+@"
 *
 * <更新记录>
 */ ";
            header += "\n using System;\n"
                        + "using System.Collections.Generic;\n"
                        + "using System.Linq;\n"
                        + "using System.Text;\n"
                        + "using System.ComponentModel;\n"
                        + "using System.Threading.Tasks;\n"
                        +"                   \n"
                        + "namespace " + nameSpacePath + ".Models \n"
                        + "{\n"
                        + "    /// <summary>\n"
                        + "    /// " + chinaComment + "实体类\n"
                        + "    /// </summary>\n"
                        + "    [EditorBrowsable(EditorBrowsableState.Never)]\n"
                        + "    [Serializable]\n"
                        + "    public class " + entityName + "\n"
                        + "    {\n\n";
            int columnCount = columnNameList.Count;
            string attrString = "";
            for (int i = 0; i < columnCount; ++i)
            {
                attrString += GenerateAttribute(columnNameList[i]);
            }
            string footer = "    }\n"
                + "}";

            return header + attrString + footer;

        }


        private static string GenerateAttribute(ColumnModel columnModel)
        {
            string attr = columnModel.ColumnName.ToUpper();
            //获取数据类型
            DataTypeEnum enumDT = (DataTypeEnum)Enum.Parse(typeof(DataTypeEnum), "dt_" + columnModel.DateType.ToString());
            string attrStr = "";
            attrStr += "        /// <summary>\n";
            attrStr += "        /// " + columnModel.ColumnComment + "\n";
            attrStr += "        /// </summary>\n";
            switch (enumDT)
            {
                case DataTypeEnum.dt_char:
                case DataTypeEnum.dt_varchar:
                    attrStr += "        public String " + attr + " { get; set; }\n";
                    break;
                case DataTypeEnum.dt_datetime:
                    attrStr += "        public DateTime " + attr + " { get; set; }\n";
                    break;
                case DataTypeEnum.dt_int:
                    attrStr += "        public int " + attr + " { get; set; }\n";
                    break;
                case DataTypeEnum.dt_decimal:
                    attrStr += "        public decimal " + attr + " { get; set; }\n";
                    break;
            }
            attrStr += "\n";//最后是加一个空格
            return attrStr;
        }


    }
}
