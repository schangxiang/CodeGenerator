

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    public class Model_Generate
    {

        /// <summary>
        /// 创建实体类
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columnNameList"></param>
        /// <param name="filePrefixName">文件前缀名</param>
        /// <param name="nameSpacePath">类命名空间</param>
        /// <param name="createPerson">创建人</param>
        /// <param name="chinaComment">中文注释</param>
        /// <param name="entityName">实体类名</param>
        /// <returns></returns>
        public static string GenerateModel(string tableName, List<ColumnModel> columnNameList, string filePrefixName, string nameSpacePath,
            string createPerson, string chinaComment, string entityName
            )
        {
            string header = "using System;\n"
                         + "using System.Runtime.Serialization; \n"
                         + "                   \n"
                         + "namespace "+SysData.namespace_model+" \n"
                         + "{\n"
                         + "    /// <summary>\n"
                         + "    /// " + chinaComment + "实体类\n"
                         + "    /// </summary>\n"
                         + "    [DataContract]\n"
                         + "    public class $entityName$ \n"
                         + "    {\n\n";
            int columnCount = columnNameList.Count;
            string attrString = "";
            for (int i = 0; i < columnCount; ++i)
            {
                attrString += StructStrHelper.GenerateAttribute(columnNameList[i]);
            }
            string footer = "    }\n"
                + "}";

            string modelContent = header + attrString + footer;
            modelContent = modelContent.Replace(
                            "$NowTimeStr$", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day
                            + " "
                            + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);//创建时间
            modelContent = modelContent.Replace("$CreatePerson$", createPerson);//创建人
            modelContent = modelContent.Replace("$nameSpacePath$", nameSpacePath);//命名空间
            modelContent = modelContent.Replace("$entityName$", entityName);//实体类名
            return modelContent;

        }




    }
}
