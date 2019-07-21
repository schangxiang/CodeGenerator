# encoding: utf-8

import cx_Oracle
import time

fileHeader = '''
/*----------------------------------------------------------------
           // Copyright  2010-2014   ******
           // 版权所有。 
           //
           // 文件名：FileNameStr
           // 文件功能描述: 
           //
           // 
           // 创建标识：邵长祥 NowTimeStr
           //
           // 修改标识：
           // 修改描述：
           //
           // 修改标识：
           // 修改描述：
//----------------------------------------------------------------*/ \n
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace NAMESPACEATHERE
{
    
    public class DACNAMEHERE : AbstractDAC<ENTITYNAMEHERE,PKTYPEHERE>
    {

        #region 构建单例
		private static DACNAMEHERE instance = null;
        private DACNAMEHERE() { }

        public static DACNAMEHERE GetInstance()
        {
            if (instance == null)
            {
                instance = new DACNAMEHERE();
            }

            return instance;
        }
        #endregion

        protected override ILPFDatabase GetDatabase()
        {
            return Database.GetDatabase();
        }

        protected override string PrimaryKey
        {
            get { return "PKCOLUMNNAMEHERE"; }
        }
		
		protected override string Table
        {
            get { return "TABLENAMEHERE"; }
        }

        protected override string QueryFields
        {
            get { return "QUERYFIELSHERE"; }
        }

        
'''
fileFooter = '''

    }
}'''
typeDict = dict((['NUMBER','decimal'],['NVARCHAR2','string'],['VARCHAR2','string'],['DATE','DateTime?'],['CHAR','string']))
valueDict = dict((['NUMBER','0.0M'],['NVARCHAR2','string.Empty'],['VARCHAR2','string.Empty'],['DATE','null'],['CHAR','string.Empty']))

def translateToCamel(originalName):
	translatedString = originalName.replace("_"," ")
	translatedString = translatedString.title()
	translatedString = translatedString.replace(" ","")
	return translatedString;


def datarowString(columnName,columnType):
	drString = ''
	if columnType == 'NUMBER':
		drString = '            obj.' + translateToCamel(columnName) + ' = Decimal.Round(Convert.ToDecimal(row["' + columnName + '"]), 2);\n\n'
	elif columnType == 'VARCHAR2':
		drString = "            obj." + translateToCamel(columnName) + ' = Convert.ToString(row["' + columnName + '"]);\n\n'
	elif columnType == 'CHAR':
		drString = "            obj." + translateToCamel(columnName) + ' = Convert.ToString(row["' + columnName + '"]);\n\n'
	elif columnType == 'DATE':
		drString = '''            if (Convert.IsDBNull(row["COLUMNNAMEHERE"]))
            {
                obj.PROPERTYNAMEHERE = null;
            }
            else
            {
                obj.PROPERTYNAMEHERE = Convert.ToDateTime(row["COLUMNNAMEHERE"]);
            }

'''
		drString = drString.replace("PROPERTYNAMEHERE",translateToCamel(columnName))
		drString = drString.replace("COLUMNNAMEHERE",columnName)
	else:
		drString = 'Error: ' + columnName + '字段生成错误！'
	return drString;

tableName = raw_input("Enter TableName:")
fileNamespace = raw_input("Enter NameSpace:")

#ERP.EHSBOSS.PUB.Core
camelTableName = translateToCamel(tableName)
fileHeader = fileHeader.replace("NAMESPACEATHERE",fileNamespace)
fileHeader = fileHeader.replace("DACNAMEHERE",camelTableName + "DAC")
fileHeader = fileHeader.replace("TABLENAMEHERE",tableName)
fileHeader = fileHeader.replace("ENTITYNAMEHERE",camelTableName + "Entity")
fileHeader = fileHeader.replace("NowTimeStr",time.strftime('%Y-%m-%d %H:%M:%S',time.localtime(time.time()))) #替换成当前时间


currentFileName=camelTableName + "DAC.cs"
fileContent = fileContent.replace("FileNameStr",currentFileName) #替换文件名

conn=cx_Oracle.connect('lpapps/luckypai@192.168.1.103/lpapps')
c=conn.cursor()
x=c.execute(" select column_name,data_type from user_tab_columns where table_name='" + tableName + "' ")
arr = x.fetchall()
fileHeader = fileHeader.replace("PKTYPEHERE",typeDict[arr[0][1]])
fileHeader = fileHeader.replace("PKCOLUMNNAMEHERE",arr[0][0]) 


queryColumns = []
objectProperties = []
queryBlockString = '''        #region 查询SQL

        protected override string GetContainsObjectSQL(ENTITYNAMEHERE obj)
        {
            return string.Format("SELECT 1 FROM {0} WHERE {1} = '{2}'", this.Table, this.PrimaryKey, obj.PKNAMEHERE);
        }


        protected override ENTITYNAMEHERE GetObjectByDataRow(DataRow row)
        {
            ENTITYNAMEHERE obj = new ENTITYNAMEHERE();\n'''
queryBlockString = queryBlockString.replace("PKNAMEHERE",translateToCamel(arr[0][0]))
queryBlockString = queryBlockString.replace("ENTITYNAMEHERE",camelTableName+"Entity")
for arrItem in arr:
	queryColumns.append(arrItem[0])
	objectProperties.append("obj."+translateToCamel(arrItem[0]) + ",")
	queryBlockString = queryBlockString + datarowString(arrItem[0], arrItem[1])

fileHeader = fileHeader.replace("QUERYFIELSHERE",",".join(queryColumns))
queryBlockString = queryBlockString+ '''            return obj;
        }

        #endregion\n\n'''

insertBlockString = '''        #region 插入语句

        protected override object[] GetInsertSQLParamDataList(ENTITYNAMEHERE obj)
        {\n            '''
insertBlockString = insertBlockString + "            return new object[] { "
for objProp in objectProperties:
	insertBlockString = insertBlockString + objProp

insertBlockString = insertBlockString + " };\n        }\n\n"
insertBlockString = insertBlockString + '''        protected override string GetInsertSQL(ENTITYNAMEHERE obj)
        {
            StringBuilder sqlBuilder = new StringBuilder();\n'''
insertBlockString = insertBlockString + '            sqlBuilder.AppendLine(" INSERT INTO ' + tableName + ' ");\n'
insertBlockString = insertBlockString + '            sqlBuilder.AppendLine(" ('
for arrItem in arr:
	insertBlockString = insertBlockString + arrItem[0]+","

insertBlockString = insertBlockString + ') ");\n'
insertBlockString = insertBlockString + '            sqlBuilder.AppendLine(" VALUES ('
insertBlockString = insertBlockString + tableName+"_S.nextval,"
for i in range(0,len(arr)-1):
	insertBlockString = insertBlockString + '{' + str(i) + '},'

insertBlockString = insertBlockString + ')");\n\n'
insertBlockString = insertBlockString + '''            return sqlBuilder.ToString();
        }

        #endregion\n\n'''
insertBlockString = insertBlockString.replace("ENTITYNAMEHERE",camelTableName + "Entity")
#
updateBlockString = '''        #region 更新语句

        
        protected override object[] GetUpdateRowSQLParamDataList(ENTITYNAMEHERE obj)
        {
            return new object[] {  '''
for arrItem in arr[1:]:
	updateBlockString = updateBlockString + 'obj.' + translateToCamel(arrItem[0])+","

updateBlockString = updateBlockString + 'obj.' + translateToCamel(arr[0][0]) + '};\n        }\n\n\n'
#
updateBlockString = updateBlockString + '''        protected override string GetUpdateRowSQL(ENTITYNAMEHERE obj)
        {
            StringBuilder sqlBuilder = new StringBuilder();
'''
updateBlockString = updateBlockString + '            sqlBuilder.AppendLine("UPDATE ' + tableName + ' SET ");\n '
updateloop = 0
for arrItem in arr[1:]:
	updateBlockString = updateBlockString + '            sqlBuilder.AppendLine(" ' + arrItem[0] + '={' + str(updateloop) + '},");\n'
	updateloop = updateloop + 1

updateBlockString = updateBlockString + '            sqlBuilder.AppendLine(" WHERE ' + arr[0][0] + '={' + str(updateloop) + '} ");\n'
updateBlockString = updateBlockString + '''
            return sqlBuilder.ToString();
        }

        #endregion'''
updateBlockString = updateBlockString.replace("ENTITYNAMEHERE",camelTableName + "Entity")

wholeFile = fileHeader + queryBlockString + insertBlockString + updateBlockString + fileFooter
f = open("d:\\" + currentFileName,"w")
f.write(wholeFile)
f.close()























