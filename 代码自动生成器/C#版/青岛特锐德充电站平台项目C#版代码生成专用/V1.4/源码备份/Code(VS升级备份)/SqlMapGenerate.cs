using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel
{
    public class SqlMapGenerate
    {

        /// <summary>
        /// 创建XML文本
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="columnList">列集合</param>
        /// <param name="primaryKey">主键</param>
        /// <param name="moduleName">模块名称</param>
        /// <param name="nameSpacePath">实体类命名空间</param>
        /// <param name="chinaComment">中文注释</param>
        /// <param name="entityName">实体类名称</param>
        /// <param name="orderByName">排序名称</param>
        ///  <param name="tableAlias">表别名</param>
        /// <returns></returns>
        public static string GenerateXml(string tableName, List<ColumnModel> columnList, string primaryKey, string moduleName,
            string nameSpacePath,
            string chinaComment, string createPerson, string entityName,
            string orderByName,
            string tableAlias)
        {

            //头部文件
            string header = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n"
                + "<sqlMap namespace=\"$ModuleName$\" xmlns=\"http://ibatis.apache.org/mapping\""
                + "  xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" >\n"
                + "  <alias>\n"
                + "    <typeAlias alias=\"" + entityName + "\" type=\"$NameSpacePath$.Models." + entityName + ",$NameSpacePath$.Models\" />\n"
                + "  </alias>\n";


            //创建标签resultMaps
            string props = GenerateProperty(columnList);

            //创建标签resultMaps
            props += CreateStatements(columnList, tableName, primaryKey,tableAlias);

            //底部文件
            string footer = "</sqlMap> \n\n";
            footer += @"<!--
		// Copyright  2010-2015 ******
		// 版权所有。
		//
		// 文件功能描述：$ChinaComment$的XML
		//
		//
		// 创建时间：$NowTimeStr$
        // 创建人：$CreatePerson$
		//
		// 修改标识：
		// 修改描述：
		//
		// 修改标识：
		// 修改描述：
-->
";
            string xmlContent = header + props + footer;
            //替换文本
            xmlContent = xmlContent.Replace("$ModuleName$", moduleName);//模块名称
            xmlContent = xmlContent.Replace("$NameSpacePath$", nameSpacePath);//实体类路径
            xmlContent = xmlContent.Replace("$ChinaComment$", chinaComment);//中文注释
            xmlContent = xmlContent.Replace("$NowTimeStr$", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);//创建时间
            xmlContent = xmlContent.Replace("$CreatePerson$", createPerson);//创建人
            xmlContent = xmlContent.Replace("$EntityName$", entityName);//实体类名
            xmlContent = xmlContent.Replace("$OrderBy$", orderByName + " DESC");
            xmlContent = xmlContent.Replace("$TableAlias$", tableAlias);//实体类对象名(表别名)

            return xmlContent;

        }

        /// <summary>
        /// 创建标签resultMaps
        /// </summary>
        /// <param name="columnNameList"></param>
        /// <returns></returns>
        private static string GenerateProperty(List<ColumnModel> columnNameList)
        {
            int columnCount = columnNameList.Count;
            string props = "  <resultMaps>\n"
                + "    <!--$ChinaComment$-->\n"
                + "    <resultMap id=\"$ModuleName$Map\" class=\"$EntityName$\">\n";
            for (int i = 0; i < columnCount; ++i)
            {
                string attrColumnName = columnNameList[i].ColumnName;//转换为大写
                props += "      <!--" + columnNameList[i].ColumnComment + "-->\n";
                props += "      <result property=\"" + attrColumnName + "\" column=\"" + attrColumnName + "\"/>\n";
            }
            props += "    </resultMap>\n";
            props += "  </resultMaps>\n";

            return props;
        }

        /// <summary>
        /// 创建标签statements
        /// </summary>
        /// <param name="columnNameList">列集合</param>
        /// <param name="tableName">表名</param>
        /// <param name="primaryKey">主键名</param>
        /// <param name="tableAlias">表别名</param>
        /// <returns></returns>
        private static string CreateStatements(List<ColumnModel> columnNameList, string tableName, string primaryKey,string tableAlias)
        {
            int columnCount = columnNameList.Count;
            string props = "  <statements>\n\n";

            //1、创建查询语句
            props += getSELECTStr(columnNameList, tableName,tableAlias);
            //2、创建分页查询语句
            props += getSELECTPageStr(columnNameList, tableName,tableAlias);
            //3、创建新增语句
            props += getInsertStr(columnNameList, tableName);
            //4、创建修改语句
            props += getUpdateStr(columnNameList, tableName, primaryKey);
            //5、创建删除语句
            props += getDeleteStr(tableName, primaryKey);

            props += "  </statements>\n";
            return props;
        }

        #region 公共方法

        #region 增删改查

        /// <summary>
        /// 构造条件检索查询SQL
        /// </summary>
        /// <param name="columnNameList">列集合</param>
        /// <param name="tableName">表名</param>
        ///  <param name="tableAlias">表别名</param>
        /// <returns></returns>
        private static string getSELECTStr(List<ColumnModel> columnNameList, string tableName, string tableAlias)
        {
            StringBuilder selectSql = new StringBuilder();

            selectSql.Append("    <!-- ***********************************【条件检索$ChinaComment$】 开始***********************************--> \n");

            selectSql.Append("    <!--条件检索$ChinaComment$需要的条件-->\n");
            //传递的参数是String
            selectSql.Append("    <sql id=\"Get$ModuleName$ByFilterForWhere\">\n");
            selectSql.Append("      <dynamic prepend=\"WHERE\"> \n");
            selectSql.Append("          <isParameterPresent> \n");
            selectSql.Append("              <isNotNull  property=\"ID\"> \n");
            selectSql.Append("                  <isNotEmpty  prepend=\"AND\" property=\"ID\"> \n");
            selectSql.Append("                      "+tableAlias+".ID=#ID#\n");
            selectSql.Append("                   </isNotEmpty>\n");
            selectSql.Append("              </isNotNull> \n");
            selectSql.Append("          </isParameterPresent> \n");
            selectSql.Append("      </dynamic> \n");
            selectSql.Append("    </sql>\n");
            selectSql.Append("    \n");

            selectSql.Append("    <!--查询$ChinaComment$-->\n");
            //传递的参数是String
            selectSql.Append("    <select id=\"Get$ModuleName$ByFilter\" resultMap=\"$ModuleName$Map\" parameterClass=\"System.Collections.IDictionary\">\n");
            selectSql.Append("      SELECT \n");
            selectSql.Append(getColumnNameStrForGetList(columnNameList, tableAlias));
            selectSql.Append("      FROM " + tableName + " AS $TableAlias$ \n");
            selectSql.Append("      <include refid=\"Get$ModuleName$ByFilterForWhere\"></include> \n");
            selectSql.Append("    </select>\n");

            selectSql.Append("    <!-- ***********************************【条件检索$ChinaComment$】 结束***********************************--> \n\n");

            return selectSql.ToString();
        }

        /// <summary>
        /// 构造获取列表的完整SELECT分页语句
        /// </summary>
        /// <param name="columnNameList">列集合</param>
        /// <param name="tableName">表名</param>
        /// <param name="tableAlias">表别名</param>
        /// <returns></returns>
        private static string getSELECTPageStr(List<ColumnModel> columnNameList, string tableName, string tableAlias)
        {
            StringBuilder selectSql = new StringBuilder();

            selectSql.Append("    <!-- ***********************************【分页查询$ChinaComment$】 开始***********************************--> \n");

            selectSql.Append("    <!--分页查询$ChinaComment$需要的条件-->\n");
            //传递的参数是String
            selectSql.Append("    <sql id=\"Get$ModuleName$ForWhere\">\n");
            selectSql.Append("      <dynamic prepend=\"WHERE\"> \n");
            selectSql.Append("          <isParameterPresent> \n");
            selectSql.Append("              <isNotNull  property=\"Name\"> \n");
            selectSql.Append("                  <isNotEmpty  prepend=\"AND\" property=\"Name\"> \n");
            selectSql.Append("                   \n");
            selectSql.Append("                   </isNotEmpty>\n");
            selectSql.Append("              </isNotNull> \n");
            selectSql.Append("          </isParameterPresent> \n");
            selectSql.Append("      </dynamic> \n");
            selectSql.Append("    </sql>\n");
            selectSql.Append("    \n");

            selectSql.Append("    <!--分页查询$ChinaComment$-->\n");
            //传递的参数是String
            selectSql.Append("    <select id=\"Get$ModuleName$ListForPaging\" resultMap=\"$ModuleName$Map\" parameterClass=\"System.Collections.IDictionary\">\n");
            selectSql.Append("      SELECT \n");
            selectSql.Append(getColumnNameStrForGetList(columnNameList));
            selectSql.Append("      <include refid=\"PagePrefix\"></include> \n");
            selectSql.Append("      $OrderBy$ \n");
            selectSql.Append("      <include refid=\"PageInfix\"></include> \n");
            selectSql.Append(getColumnNameStrForGetList(columnNameList, tableAlias));
            selectSql.Append("      FROM " + tableName + " AS $TableAlias$\n");
            selectSql.Append("      <include refid=\"Get$ModuleName$ForWhere\"></include> \n");
            selectSql.Append("      <include refid=\"PageSuffix_sqlserver\"></include> \n");
            selectSql.Append("    </select>\n");
            selectSql.Append("    \n");

            selectSql.Append("    <!--分页查询$ChinaComment$总条数-->\n");
            //传递的参数是String
            selectSql.Append("    <select id=\"Get$ModuleName$ListForPagingCount\" resultClass=\"int\" parameterClass=\"System.Collections.IDictionary\"> \n");
            selectSql.Append("      SELECT  COUNT(1) \n");
            selectSql.Append("      FROM " + tableName + " \n");
            selectSql.Append("      <include refid=\"Get$ModuleName$ForWhere\"></include> \n");
            selectSql.Append("    </select> \n");
            selectSql.Append("    \n");
            selectSql.Append("    <!-- ***********************************【分页查询$ChinaComment$】 结束***********************************--> \n");

            return selectSql.ToString();
        }

        /// <summary>
        /// 构造新增的完整Insert语句
        /// </summary>
        /// <returns>格式：Insert语句</returns>
        private static string getInsertStr(List<ColumnModel> columnNameList, string tableName)
        {
            StringBuilder selectSql = new StringBuilder();
            selectSql.Append("    <!--新增$ChinaComment$-->\n");
            //传递的参数是String
            selectSql.Append("    <insert id=\"Add$ModuleName$\" parameterClass=\"$EntityName$\"> \n");
            selectSql.Append("      INSERT INTO " + tableName + "( \n");

            selectSql.Append(getColumnNameStrForGetList(columnNameList));
            selectSql.Append("      ) \n");
            selectSql.Append("      VALUES( \n");
            selectSql.Append(getColumnNameForInsertColumnValue(columnNameList));
            selectSql.Append("      )\n ");
            selectSql.Append("    </insert>\n");
            return selectSql.ToString();
        }

        /// <summary>
        /// 构造修改的完整Update语句
        /// </summary>
        /// <returns>格式：Update语句</returns>
        private static string getUpdateStr(List<ColumnModel> columnNameList, string tableName, string primaryKey)
        {
            StringBuilder selectSql = new StringBuilder();
            selectSql.Append("    <!--修改$ChinaComment$-->\n");
            //传递的参数是String
            selectSql.Append("    <update id=\"Edit$ModuleName$\" parameterClass=\"$EntityName$\">\n");
            selectSql.Append("      UPDATE " + tableName + " SET  \n");
            selectSql.Append(getColumnNameForUpdateColumnNamesAndValues(columnNameList));
            selectSql.Append("      WHERE " + primaryKey + "=#" + primaryKey + "# \n ");
            selectSql.Append("    </update>\n");
            return selectSql.ToString();
        }

        /// <summary>
        /// 构造删除的完整Delete语句
        /// </summary>
        /// <returns>格式：Delete语句</returns>
        private static string getDeleteStr(string tableName, string primaryKey)
        {
            StringBuilder selectSql = new StringBuilder();
            selectSql.Append("    <!--删除$ChinaComment$-->\n");
            //传递的参数是String
            selectSql.Append("    <delete id=\"Remove$ModuleName$\" parameterClass=\"String\">\n");
            selectSql.Append("      DELETE FROM " + tableName + " WHERE " + primaryKey + "=#" + primaryKey + "# \n");
            selectSql.Append("    </delete>\n");
            return selectSql.ToString();
        }

        #endregion


        #region 构造字符串

        /// <summary>
        /// 构造获取列表的列名集合字符串
        /// </summary>
        /// <param name="columnNameList">列集合</param>
        /// <param name="tableAlias">表别名</param>
        /// <returns></returns>
        private static string getColumnNameStrForGetList(List<ColumnModel> columnNameList, string tableAlias = null)
        {
            StringBuilder selectSql = new StringBuilder();
            tableAlias = tableAlias == null ? "" : (tableAlias + ".");
            for (int i = 0; i < columnNameList.Count; i++)
            {
                string attrColumnName = columnNameList[i].ColumnName;
                if (i == (columnNameList.Count - 1))
                    selectSql.Append("         " + tableAlias + attrColumnName + "\n");
                else
                    selectSql.Append("         " + tableAlias + attrColumnName + ",\n");
            }
            return selectSql.ToString();
        }

        /// <summary>
        /// 构造获取列表的列名集合字符串, 用于插入字符串值
        /// </summary>
        /// <returns>格式：#XX1#,#XX2#,#XX3#</returns>
        private static string getColumnNameForInsertColumnValue(List<ColumnModel> columnNameList)
        {
            StringBuilder selectSql = new StringBuilder();
            for (int i = 0; i < columnNameList.Count; i++)
            {
                string attrColumnName = columnNameList[i].ColumnName;
                if (i == (columnNameList.Count - 1))
                    selectSql.Append("         #" + attrColumnName + "#\n");
                else
                    selectSql.Append("         #" + attrColumnName + "#,\n");
            }
            return selectSql.ToString();
        }

        /// <summary>
        /// 构造获取列表的列名集合字符串
        /// </summary>
        /// <returns>格式：XX1=#XX!#,XX2=#XX2#,XX3=#XX3#</returns>
        private static string getColumnNameForUpdateColumnNamesAndValues(List<ColumnModel> columnNameList)
        {
            StringBuilder selectSql = new StringBuilder();
            for (int i = 0; i < columnNameList.Count; i++)
            {
                string attrColumnName = columnNameList[i].ColumnName;
                if (i == (columnNameList.Count - 1))
                    selectSql.Append("         " + attrColumnName + "=#" + attrColumnName + "#\n");
                else
                    selectSql.Append("         " + attrColumnName + "=#" + attrColumnName + "#,\n");
            }
            return selectSql.ToString();
        }

        #endregion



        #endregion

    }
}
