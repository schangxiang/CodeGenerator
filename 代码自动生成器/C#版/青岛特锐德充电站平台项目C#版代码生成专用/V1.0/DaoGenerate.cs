using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel {
    public class DaoGenerate {
        public static string header = "using System;\n"
                    + "using System.Collections.Generic;\n"
                    + "using System.Linq;\n"
                    + "using System.Text;\n"
                    + "using Model;\n"
                    + "namespace DataAccess {\n"
                    + "    public class WarnMeasureDao:BaseDao {\n\n";
        public static string footer = "    }\n" + "}";

        #region 私有方法

        private static string GetAddMethodString(string tableName) {
            string addMethod = "		public static bool AddWarnMeasure(WarnMeasure wm) {\n"
                    + "            try {\n"
                    + "                SqlMap.Insert(\"InsertWarnMeasure\", wm);\n"
                    + "                return true;\n"
                    + "            } catch (Exception) {\n"
                    + "                return false;\n"
                    + "            }\n"
                    + "        }\n\n";
            addMethod = addMethod.Replace("WarnMeasure", tableName);

            return addMethod;
        }
        private static string GetUpdateMethodString(string tableName) {
            string updateMethod = "        public static bool UpdateWarnMeasure(WarnMeasure wm) {\n"
                        + "            try {\n"
                        + "                SqlMap.Update(\"UpdateWarnMeasure\", wm);\n"
                        + "                return true;\n"
                        + "            } catch (Exception) {\n"
                        + "                return false;\n"
                        + "            }\n"
                        + "        }\n\n";
            updateMethod = updateMethod.Replace("WarnMeasure", tableName);

            return updateMethod;
        }


        private static string GetDeleteMethodString(string tableName) {
            string deleteString = "        public static bool DeleteWarnMeasure(WarnMeasure wm) {\n"
                        + "            try {\n"
                        + "                SqlMap.Update(\"DeleteWarnMeasure\", wm);\n"
                        + "                return true;\n"
                        + "            } catch (Exception) {\n"
                        + "                return false;\n"
                        + "            }\n"
                        + "        }\n\n";
            deleteString = deleteString.Replace("WarnMeasure", tableName);

            return deleteString;
        }

        private static string GetListMethodString(string tableName) {
            string getListMethod = "        public static IList<WarnMeasure> GetAllWarnMeasure() {\n"
                    + "            return SqlMap.QueryForList<WarnMeasure>(\"SelectAllWarnMeasure\", null);\n"
                    + "        }\n\n";
            getListMethod = getListMethod.Replace("WarnMeasure", tableName);

            return getListMethod;
        }


        #endregion
        

        public static string GenerateDaoClass(string tableName) {
            string daoHeader = header.Replace("WarnMeasure", tableName);

            return daoHeader + GetAddMethodString(tableName) + GetUpdateMethodString(tableName)
                + GetDeleteMethodString(tableName) + GetListMethodString(tableName) + footer;
        }


    }
}
