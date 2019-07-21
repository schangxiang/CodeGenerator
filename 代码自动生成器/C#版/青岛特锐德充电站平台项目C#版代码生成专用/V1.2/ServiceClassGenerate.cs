using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel {
    public class ServiceClassGenerate {
        static string header = "using System;\n"
                    + "using System.Collections.Generic;\n"
                    + "using System.Linq;\n"
                    + "using System.Web;\n"
                    + "using System.Web.Services;\n"
                    + "using DataAccess;\n"
                    + "using Model;\n\n"
                    + "namespace WebSrv {\n\n"
                    + "    /// <summary>\n"
                    + "    /// Summary description for WarnMeasure\n"
                    + "    /// </summary>\n"
                    + "    [WebService(Namespace = \"http://tempuri.org/\")]\n"
                    + "    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]\n"
                    + "    [System.ComponentModel.ToolboxItem(false)]\n"
                    + "    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. \n"
                    + "    // [System.Web.Script.Services.ScriptService]\n"
                    + "    public class WarnMeasureSrv : System.Web.Services.WebService {\n";

        static string footer = "\n\n    }\n" + "}";



        private static string GetAddMethodString(string tableName) {
            string addMethod = "        [WebMethod]\n"
                    + "        public bool AddWarnMeasure(WarnMeasure c) {\n"
                    + "            return WarnMeasureDao.AddWarnMeasure(c);\n"
                    + "        }\n\n";
            return addMethod.Replace("WarnMeasure", tableName);
        }

        private static string GetUpdateMethodString(string tableName) {
            string updateMethod = "        [WebMethod]\n"
                    + "        public bool UpdateWarnMeasure(WarnMeasure c) {\n"
                    + "            return WarnMeasureDao.UpdateWarnMeasure(c);\n"
                    + "        }\n\n";
            return updateMethod.Replace("WarnMeasure", tableName);
        }

        private static string GetDeleteMethodString(string tableName) {
            string deleteMethod = "        [WebMethod]\n"
                    + "        public bool DeleteWarnMeasure(WarnMeasure c) {\n"
                    + "            return WarnMeasureDao.DeleteWarnMeasure(c);\n"
                    + "        }\n\n";

            return deleteMethod.Replace("WarnMeasure", tableName);
        }

        private static string GetListMethodString(string tableName) {
            string listMethod = "        [WebMethod]\n"
                    + "        public List<WarnMeasure> GetAllWarnMeasure() {\n"
                    + "            return WarnMeasureDao.GetAllWarnMeasure() as List<WarnMeasure>;\n"
                    + "        }\n\n";

            return listMethod.Replace("WarnMeasure", tableName);
        }

        public static string GenerateServiceString(string tableName) {
            string contentString = GetAddMethodString(tableName) + GetUpdateMethodString(tableName)
                + GetDeleteMethodString(tableName) + GetListMethodString(tableName);
            header = header.Replace("WarnMeasure", tableName);

            return header + contentString + footer;
        }


    }
}
