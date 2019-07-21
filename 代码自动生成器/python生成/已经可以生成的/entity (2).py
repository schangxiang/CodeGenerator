
#coding=utf-8

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
           // 创建标识：shaocx  NowTimeStr
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

namespace EMS.PM.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class THISISCLASSNAME
    {
'''
fileFooter = '''    }
}'''
#下面的数组 ['NUMBER','decimal'],如果数据库字段为number类型，那么转换实体类型就是decimal。如果程序报出类型错误，那么可能是数据库中有该数据类型，但在这里数组里没有写出，补上就行。
#['NUMBER','0.0M']  如果数据库字段为number类型，那么在构造函数中赋初值就是0.0M
typeDict = dict((['NUMBER','decimal'],['NVARCHAR2','string'],['VARCHAR2','string'],['DATE','DateTime?'],['CHAR','string']))
valueDict = dict((['NUMBER','0.0M'],['NVARCHAR2','string.Empty'],['VARCHAR2','string.Empty'],['DATE','null'],['CHAR','string.Empty']))

def translateToCamel(originalName):
	translatedString = originalName.replace("_"," ")
	translatedString = translatedString.title()
	translatedString = translatedString.replace(" ","")
	return translatedString;

def getColumnValue(columnName,columnType):
	valueString = "            " + columnName + " = " + valueDict[columnType] + ";\n"
	return valueString;

def getColumnProperty(columnName,columnType,propertyComment):
	propString="\n"
	propString  = propString+"        /// <summary>\n"
	propString  = propString+"        /// \n"  #此处由于获取的注释中文乱码，所以没有成功使用propertyComment
	propString  = propString+"        /// </summary>\n"
	propString  = propString+"        public " + typeDict[columnType] + " " + columnName + " { get; set; }\n\n"
	return propString;


tableName = raw_input("Enter TableName(case-insensitive):")
entityName = raw_input("Enter EntityName:")


className = entityName  #类名
fileHeader = fileHeader.replace("THISISCLASSNAME",className) #实体类名称
fileHeader = fileHeader.replace("NowTimeStr",time.strftime('%Y-%m-%d %H:%M:%S',time.localtime(time.time()))) #替换成当前时间


currentFileName=className + ".cs"
fileHeader = fileHeader.replace("FileNameStr",currentFileName) #替换文件名

conn=cx_Oracle.connect('oa0019999/cwpass@192.168.1.101/orcl')
c=conn.cursor()
# x=c.execute(" select column_name,data_type from user_tab_columns where table_name=UPPER('" + tableName + "') ")
x=c.execute(" select tab.column_name,tab.data_type,col.comments from user_tab_columns tab LEFT JOIN User_col_Comments col ON tab.COLUMN_NAME=col.COLUMN_NAME AND tab.TABLE_NAME=col.TABLE_NAME where tab.table_name=UPPER('" + tableName + "') ")

fileBody = '''        public THISISCLASSNAME()
        {
'''
fileBody = fileBody.replace("THISISCLASSNAME",className)
arr = x.fetchall()
for arrItem in arr:
	propertyName = translateToCamel(arrItem[0])
	fileBody = fileBody + getColumnValue(propertyName,arrItem[1])

fileBody = fileBody +"        }\n"

for arrItem in arr:
	propertyName = translateToCamel(arrItem[0]) #字段名称
	propertyComment=translateToCamel(arrItem[2]) #字段注释
	fileBody = fileBody + getColumnProperty(propertyName,arrItem[1],propertyComment)

wholeFile = fileHeader +fileBody + fileFooter

f = open("d:\\" + currentFileName,"w")
f.write(wholeFile)
f.close()























