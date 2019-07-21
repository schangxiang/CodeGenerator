
#coding=utf-8

import cx_Oracle
import time

tableName = raw_input("Enter TableName(case-insensitive):") #输入要查询的表名
moduleName = raw_input("Enter ModuleName:") #输入模块名称
filePathName = raw_input("Enter FilePath(eg:XMZB):") #输入模块所在的文件夹（在PM路径下，如XMZB）

#声明变量并赋值
currentTime=time.strftime('%Y-%m-%d %H:%M:%S',time.localtime(time.time()))
entityName = moduleName+"Entity"  #Entity类名 ,替换 $$ENTITYNAME$$
controllerName="PM"+moduleName+"Controller"  #Controller类名 替换 $$CONTROLLERNAME$$
ibllName="I"+moduleName+"BLL"  #IBLL类名 替换 $$IBLLNAME$$
bllName=moduleName+"BLL"  #BLL类名	替换 $$BLLNAME$$
daoName=moduleName+"Dao"  #Dao类名	替换 $$DAONAME$$

getListFunName="Get"+moduleName+"List" #获取列表方法	替换 $$GETLISTFUNNAME$$
insertFunName="Insert"+moduleName #增加方法	替换 $$INSERTFUNNAME$$
updateFunName="Update"+moduleName #更新方法	替换 $$UPDATEFUNNAME$$
deleteFunName="Delete"+moduleName #删除方法	替换 $$DELETEFUNNAME$$
getOneFunName="Get"+moduleName+"ByGUID" #获取单个方法	替换 $$GETONEFUNNAME$$

conn=cx_Oracle.connect('ems/ems@192.168.32.198/orcl')
c=conn.cursor()
# x=c.execute(" select column_name,data_type from user_tab_columns where table_name=UPPER('" + tableName + "') ")
x=c.execute(" select tab.column_name,tab.data_type,col.comments from user_tab_columns tab LEFT JOIN User_col_Comments col ON tab.COLUMN_NAME=col.COLUMN_NAME AND tab.TABLE_NAME=col.TABLE_NAME where tab.table_name=UPPER('" + tableName + "') ")
arr = x.fetchall()



############################################【1】生成Entity 开始##############################################################

fileHeader = '''
/*----------------------------------------------------------------
           // Copyright  2010-2014   ******
           // 版权所有。 
           //
           // 文件名：FileNameStr
           // 文件功能描述: XXXX实体类
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
    /// XXXX实体类
    /// </summary>
    public class $$ENTITYNAME$$
    {
'''
fileFooter = '''    }
}'''
#下面的数组 ['NUMBER','decimal'],如果数据库字段为number类型，那么转换实体类型就是decimal。如果程序报出类型错误，那么可能是数据库中有该数据类型，但在这里数组里没有写出，补上就行。
#['NUMBER','0.0M']  如果数据库字段为number类型，那么在构造函数中赋初值就是0.0M
typeDict = dict((['NUMBER','decimal'],['NVARCHAR2','string'],['VARCHAR2','string'],['DATE','DateTime?'],['CHAR','string']))
valueDict = dict((['NUMBER','0.0M'],['NVARCHAR2','string.Empty'],['VARCHAR2','string.Empty'],['DATE','null'],['CHAR','string.Empty']))



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





fileHeader = fileHeader.replace("$$ENTITYNAME$$",entityName) #实体类名称
fileHeader = fileHeader.replace("NowTimeStr",currentTime) #替换成当前时间
currentFileName=entityName + ".cs" #文件名称
fileHeader = fileHeader.replace("FileNameStr",currentFileName) #替换文件名


fileBody = '''        public $$ENTITYNAME$$()
        {
'''
fileBody = fileBody.replace("$$ENTITYNAME$$",entityName)

for arrItem in arr:
	propertyName =arrItem[0]
	fileBody = fileBody + getColumnValue(propertyName,arrItem[1])

fileBody = fileBody +"        }\n"

for arrItem in arr:
	propertyName =arrItem[0] #字段名称
	propertyComment=arrItem[2] #字段注释
	fileBody = fileBody + getColumnProperty(propertyName,arrItem[1],propertyComment)

wholeFile = fileHeader +fileBody + fileFooter

f = open("d:\\" + currentFileName,"w")
f.write(wholeFile)
f.close()

############################################【1】生成Entity 结束##############################################################

############################################【2】生成SqlXML 开始##############################################################

fileHeader = '''<?xml version="1.0" encoding="utf-8"  ?>
<sqlMap namespace="$$MODULENAME$$" xmlns="http://ibatis.apache.org/mapping"
xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  
  <!--实体-->
  <alias>
    <typeAlias alias="$$ENTITYNAME$$" type="EMS.PM.Models.$$ENTITYNAME$$,EMS.PM.Models"></typeAlias>
  </alias>
  
  <!--映射-->
  <resultMaps>
    <!--查询列（注意：并不一定全是数据库里的字段）-->
    <resultMap id="$$ENTITYNAME$$Map" class="$$ENTITYNAME$$">
		$$RESULTMAPCOLUMNNAME$$
	</resultMap>
  </resultMaps>

   <!--SQL语句-->
  <statements>
	<!--查询XXXX列表,参数：HTGUID合同guid-->
	<select id="$$GETLISTFUNNAME$$" resultMap="$$ENTITYNAME$$Map">
      SELECT 
		 $$GETLISTCOLUMNNAME$$
		 FROM $$TABLENAME$$
    </select>
	<!--插入XXXX列表-->
	<insert id="$$INSERTFUNNAME$$" parameterClass="$$ENTITYNAME$$">
      INSERT INTO $$TABLENAME$$(
			$$INSERCOLUMNNAME$$
		)VALUES(
			$$INSERCOLUMNVALUE$$
		)
	</insert>
	<!--删除一条XXXX实体--> 
    <update id="$$DELETEFUNNAME$$" parameterClass="String">
      DELETE  $$TABLENAME$$ WHERE $$PRIMARYKEY$$=#$$PRIMARYKEY$$#
    </update>

    <!--修改一条XXXX实体-->
    <update id="$$UPDATEFUNNAME$$" parameterClass="$$ENTITYNAME$$Map">
      UPDATE $$TABLENAME$$
      SET
      $$UPDATECOLUMNNAME$$
      WHERE $$PRIMARYKEY$$=#$$PRIMARYKEY$$#
    </update>
	 <!--查询付款审批类型实体 根据ID-->
    <select id="$$GETONEFUNNAME$$" resultMap="$$ENTITYNAME$$Map" parameterClass="string">
	  SELECT 
		 $$GETLISTCOLUMNNAME$$
		 FROM $$TABLENAME$$
      WHERE $$PRIMARYKEY$$=#$$PRIMARYKEY$$#
    </select>
  </statements>
</sqlMap>


<!--
      // Copyright  2010-2014 ******
      // 版权所有。
      //
      // 文件名：FKJH.cs
      // 文件功能描述：有关XXXX的XML
      //
      //
      // 创建标识：shaocx 2014-09-16
      //
      // 修改标识：
      // 修改描述：
      //
      // 修改标识：
      // 修改描述：
-->
      '''


#####################################方法 开始########################################

#getColumnNameForResultMaps方法：获取表中的所有列,放到<resultMaps></resultMaps>里
def getColumnNameForResultMaps(columnName,i,arrLen):
	if i==arrLen:
		valueString = "          <result property=\""+columnName+"\" column=\""+columnName+"\" /><!--注释-->"
	if i==1:
		valueString = "  <result property=\""+columnName+"\" column=\""+columnName+"\" /><!--注释-->\n"
	else:
		valueString = "          <result property=\""+columnName+"\" column=\""+columnName+"\" /><!--注释-->\n"
	return valueString;

#getColumnNameForGetList:构造获取列表的列名集合字符串
def getColumnNameForGetList(columnName,i,arrLen):
	if i==arrLen:
		valueString = "            "+columnName+""
	elif i==1:
		valueString = "   "+columnName+",\n"
	else:
		valueString = "            "+columnName+",\n"
	return valueString;

#getColumnNameForInsertColumnName:构造要插入的列名集合字符串
def getColumnNameForInsertColumnName(columnName,i,arrLen):
	if i==arrLen:
		valueString = "            "+columnName+""
	elif i==1:
		valueString = ""+columnName+",\n"
	else:
		valueString = "            "+columnName+",\n"
	return valueString;

#getColumnNameForInsertColumnValue:构造要插入的列值集合字符串
def getColumnNameForInsertColumnValue(columnName,i,arrLen):
	if i==arrLen:
		valueString = "            #"+columnName+"#"
	elif i==1:
		valueString = "#"+columnName+"#,\n"
	else:
		valueString = "            #"+columnName+"#,\n"
	return valueString;

#getColumnNameForUpdateColumnNamesAndValues:更新SQL需要的列名和列值字符串
def getColumnNameForUpdateColumnNamesAndValues(columnName,i,arrLen):
	if i==arrLen:
		valueString = "            "+columnName+"=#"+columnName+"#"
	elif i==1:
		valueString = "      "+columnName+"=#"+columnName+"#,\n"
	else:
		valueString = "            "+columnName+"=#"+columnName+"#,\n"
	return valueString;

#####################################方法 结束##########################################



#定义遍历表列时构造的字符串变量
str_getColumnNameForResultMaps='''''' #获取表中的所有列,放到<resultMaps></resultMaps>里
str_GetListColumnNames=''''''  #获取列表时SQL需要的列名字符串
str_InsertColumnNames=''''''  #插入SQL需要的列名字符串
str_InsertColumnValues='''''' #插入SQL需要的列值字符串
str_UpdateColumnNamesAndValues='''''' #更新SQL需要的列名和列值字符串
str_PrimaryKey=arr[0][0] #默认第一个字段就是主键

i=0
for arrItem in arr:
	i=i+1
	propertyName = arrItem[0]
	str_getColumnNameForResultMaps=str_getColumnNameForResultMaps+getColumnNameForResultMaps(propertyName,i,len(arr)) ##获取表中的所有列,放到<resultMaps></resultMaps>里
	str_GetListColumnNames=str_GetListColumnNames+getColumnNameForGetList(propertyName,i,len(arr)) #获取列表时SQL需要的列名字符串
	str_InsertColumnNames=str_InsertColumnNames+getColumnNameForInsertColumnName(propertyName,i,len(arr)) #插入SQL需要的列名字符串
	str_InsertColumnValues=str_InsertColumnValues+getColumnNameForInsertColumnValue(propertyName,i,len(arr)) #插入SQL需要的列值字符串
	str_UpdateColumnNamesAndValues=str_UpdateColumnNamesAndValues+getColumnNameForUpdateColumnNamesAndValues(propertyName,i,len(arr)) #更新SQL需要的列名和列值字符串
	



fileHeader = fileHeader.replace("$$GETLISTFUNNAME$$",getListFunName) #替换getListFunName
fileHeader = fileHeader.replace("$$INSERTFUNNAME$$",insertFunName) #替换insertFunName
fileHeader = fileHeader.replace("$$DELETEFUNNAME$$",deleteFunName) #替换deleteFunName
fileHeader = fileHeader.replace("$$UPDATEFUNNAME$$",updateFunName) #替换updateFunName
fileHeader = fileHeader.replace("$$GETONEFUNNAME$$",getOneFunName) #替换getOneFunName
fileHeader = fileHeader.replace("$$MODULENAME$$",moduleName) #替换moduleName
fileHeader = fileHeader.replace("$$ENTITYNAME$$",entityName) #替换entityName
fileHeader = fileHeader.replace("$$TABLENAME$$",tableName) #替换tableName
fileHeader = fileHeader.replace("NowTimeStr",currentTime) #替换成当前时间
fileHeader = fileHeader.replace("$$PRIMARYKEY$$",str_PrimaryKey) #替换主键

fileHeader = fileHeader.replace("$$RESULTMAPCOLUMNNAME$$",str_getColumnNameForResultMaps) #Maps
fileHeader = fileHeader.replace("$$GETLISTCOLUMNNAME$$",str_GetListColumnNames) #GetList
fileHeader = fileHeader.replace("$$INSERCOLUMNNAME$$",str_InsertColumnNames) #InserName
fileHeader = fileHeader.replace("$$INSERCOLUMNVALUE$$",str_InsertColumnValues) #InserValue
fileHeader = fileHeader.replace("$$UPDATECOLUMNNAME$$",str_UpdateColumnNamesAndValues) #Update


currentFileName=moduleName+".xml"
fileHeader = fileHeader.replace("FileNameStr",currentFileName) #替换文件名


f = open("d:\\" + currentFileName,"w")
f.write(fileHeader)
f.close()


############################################【2】生成SqlXML 结束##############################################################

############################################【3】生成Dao 开始##############################################################

fileHeader = '''
/*----------------------------------------------------------------
           // Copyright  2010-2014   ******
           // 版权所有。 
           //
           // 文件名：FileNameStr  (数据访问对象(Data Access Object)类)
           // 文件功能描述: XXXXDao
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
using EMS.PM.Models;



namespace EMS.PM.DataAccess.Dao
{
    /// <summary>
    /// XXXX 数据访问对象类
    /// </summary>
    public class $$DAONAME$$ : PMBaseDao
    {

        #region 获取XXXX列表集合

		/// <summary>
        /// Description：获取XXXX列表集合
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <returns>XXXX实体类集合</returns>
        public IList<$$ENTITYNAME$$> $$GETLISTFUNNAME$$()
        {
            IList<$$ENTITYNAME$$> itemList = null;
            try
            {
                itemList = SqlMap.QueryForList<$$ENTITYNAME$$>("$$GETLISTFUNNAME$$", null);
            }
            catch (Exception ex)
            {
                throw;
            }
            return itemList;
        }

        #endregion

		#region 插入一条XXXX实体

        /// <summary>
        /// Description：插入一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <param name="item">XXXX实体对象</param>
        /// <returns>插入是否成功,true成功，false失败</returns>
        public bool $$INSERTFUNNAME$$($$ENTITYNAME$$ item)
        {
            bool result = false;
            try
            {
                SqlMap.Insert("$$INSERTFUNNAME$$", item);//调用xml的sql语句
                result = true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        #endregion

        #region 删除一条XXXX实体

        /// <summary>
        /// Description：删除一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <param name="itemGUID">XX实体对象的主键GUID</param>
        /// <returns>删除是否成功,true成功，false失败</returns>
        public bool $$DELETEFUNNAME$$(string itemGUID)
        {
            bool result = false;
            try
            {
                SqlMap.Delete("$$DELETEFUNNAME$$", itemGUID);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }

        #endregion

        #region 修改一条XXXX实体

        /// <summary>
        /// Description：修改一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <param name="item">要修改的XXXX实体对象</param>
        /// <returns>修改是否成功。true成功，false失败</returns>
        public bool $$UPDATEFUNNAME$$($$ENTITYNAME$$ item)
        {
            bool result = false;
            try
            {
                SqlMap.Update("$$UPDATEFUNNAME$$", item);
                result = true;
            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            return result;
        }

        #endregion

        #region 获取一条XXXX实体

        /// <summary>
        /// Description：获取一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <param name="itemGUID">要获取的XXXX实体对象的GUID</param>
        /// <returns>获取的XXXX实体对象</returns>
        public IList<$$ENTITYNAME$$> $$GETONEFUNNAME$$(string itemGUID)
        {
            IList<$$ENTITYNAME$$> itemList = null;
            try
            {
                itemList = SqlMap.QueryForList<$$ENTITYNAME$$>("$$GETONEFUNNAME$$", itemGUID);
            }
            catch (Exception ex)
            {
                
                throw;
            }
            return itemList;
        }

        #endregion

'''
fileFooter = '''

    }
}'''



fileHeader = fileHeader.replace("$$GETLISTFUNNAME$$",getListFunName) #替换getListFunName
fileHeader = fileHeader.replace("$$INSERTFUNNAME$$",insertFunName) #替换insertFunName
fileHeader = fileHeader.replace("$$DELETEFUNNAME$$",deleteFunName) #替换deleteFunName
fileHeader = fileHeader.replace("$$UPDATEFUNNAME$$",updateFunName) #替换updateFunName
fileHeader = fileHeader.replace("$$GETONEFUNNAME$$",getOneFunName) #替换getOneFunName

fileHeader = fileHeader.replace("$$ENTITYNAME$$",entityName) #替换entityName
fileHeader = fileHeader.replace("$$DAONAME$$",daoName) #替换daoName
fileHeader = fileHeader.replace("NowTimeStr",currentTime) #替换成当前时间


currentFileName=daoName+".cs"
fileHeader = fileHeader.replace("FileNameStr",currentFileName) #替换文件名


wholeFile = fileHeader + fileFooter
f = open("d:\\" + currentFileName,"w")
f.write(wholeFile)
f.close()


############################################【3】生成Dao 结束##############################################################

############################################【4】生成IBLL 开始##############################################################

fileHeader = '''
/*----------------------------------------------------------------
           // Copyright  2010-2014   ******
           // 版权所有。 
           //
           // 文件名：FileNameStr  （业务逻辑接口类）
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
using EMS.PM.Models;



namespace EMS.PM.IBusiness
{
    /// <summary>
    /// XXXX 业务逻辑接口类
    /// </summary>
    public interface $$IBLLNAME$$
    {

        #region 获取XXXX列表集合

		/// <summary>
        /// Description：获取XXXX列表集合
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <returns>XXXX实体类集合</returns>
        IList<$$ENTITYNAME$$> $$GETLISTFUNNAME$$();

        #endregion

		#region 插入一条XXXX实体

        /// <summary>
        /// Description：插入一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <param name="item">XXXX实体对象</param>
        /// <returns></returns>
        bool $$INSERTFUNNAME$$($$ENTITYNAME$$ item);

        #endregion

        #region 删除一条XXXX实体

        /// <summary>
        /// Description：删除一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <param name="itemGUID">XX实体对象的主键GUID</param>
        /// <returns>删除是否成功,true成功，false失败</returns>
        bool $$DELETEFUNNAME$$(string itemGUID);

        #endregion

        #region 修改一条XXXX实体

        /// <summary>
        /// Description：修改一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <param name="item">要修改的XXXX实体对象</param>
        /// <returns>修改是否成功。true成功，false失败</returns>
        bool $$UPDATEFUNNAME$$($$ENTITYNAME$$ item);

        #endregion

        #region 获取一条XXXX实体

        /// <summary>
        /// Description：获取一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <param name="itemGUID">要获取的XXXX实体对象的GUID</param>
        /// <returns>获取的XXXX实体对象</returns>
        IList<$$ENTITYNAME$$> $$GETONEFUNNAME$$(string itemGUID);

        #endregion

'''
fileFooter = '''

    }
}'''





fileHeader = fileHeader.replace("$$GETLISTFUNNAME$$",getListFunName) #替换getListFunName
fileHeader = fileHeader.replace("$$INSERTFUNNAME$$",insertFunName) #替换insertFunName
fileHeader = fileHeader.replace("$$UPDATEFUNNAME$$",updateFunName) #替换updateFunName
fileHeader = fileHeader.replace("$$DELETEFUNNAME$$",deleteFunName) #替换deleteFunName
fileHeader = fileHeader.replace("$$GETONEFUNNAME$$",getOneFunName) #替换getOneFunName

fileHeader = fileHeader.replace("$$IBLLNAME$$",ibllName) #替换ibllName
fileHeader = fileHeader.replace("$$ENTITYNAME$$",entityName) #替换entityName
fileHeader = fileHeader.replace("NowTimeStr",currentTime) #替换成当前时间


currentFileName=ibllName+".cs"
fileHeader = fileHeader.replace("FileNameStr",currentFileName) #替换文件名


wholeFile = fileHeader + fileFooter
f = open("d:\\" + currentFileName,"w")
f.write(wholeFile)
f.close()

############################################【4】生成IBLL 结束##############################################################

############################################【5】生成BLL 开始##############################################################

fileHeader = '''
/*----------------------------------------------------------------
           // Copyright  2010-2014   ******
           // 版权所有。 
           //
           // 文件名：FileNameStr  （业务逻辑处理类）
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
using EMS.PM.IBusiness;
using EMS.PM.DataAccess.Dao;
using EMS.PM.Models;



namespace EMS.PM.Business
{
    /// <summary>
    /// XXXX 业务逻辑类
    /// </summary>
    public class $$BLLNAME$$:$$IBLLNAME$$
    {
		#region 定义变量

        $$DAONAME$$ dao = new $$DAONAME$$();

        #endregion

        #region 获取XXXX列表集合

		/// <summary>
        /// Description：获取XXXX列表集合
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <returns>XXXX实体类集合</returns>
        public IList<$$ENTITYNAME$$> $$GETLISTFUNNAME$$()
		{
            return dao.$$GETLISTFUNNAME$$();
        }

        #endregion

		#region 插入一条XXXX实体

        /// <summary>
        /// Description：插入一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <param name="item">XXXX实体对象</param>
        /// <returns></returns>
        public bool $$INSERTFUNNAME$$($$ENTITYNAME$$ item)
		{
            return dao.$$INSERTFUNNAME$$(item);
        }

        #endregion

        #region 删除一条XXXX实体

        /// <summary>
        /// Description：删除一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <param name="itemGUID">XX实体对象的主键GUID</param>
        /// <returns>删除是否成功,true成功，false失败</returns>
        public bool $$DELETEFUNNAME$$(string itemGUID)
		{
            return dao.$$DELETEFUNNAME$$(itemGUID);
        }

        #endregion

        #region 修改一条XXXX实体

        /// <summary>
        /// Description：修改一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <param name="item">要修改的XXXX实体对象</param>
        /// <returns>修改是否成功。true成功，false失败</returns>
        public bool $$UPDATEFUNNAME$$($$ENTITYNAME$$ item)
		{
            return dao.$$UPDATEFUNNAME$$(item);
        }

        #endregion

        #region 获取一条XXXX实体

        /// <summary>
        /// Description：获取一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <param name="itemGUID">要获取的XXXX实体对象的GUID</param>
        /// <returns>获取的XXXX实体对象</returns>
        public IList<$$ENTITYNAME$$> $$GETONEFUNNAME$$(string itemGUID)
		{
            return dao.$$GETONEFUNNAME$$(itemGUID);
        }

        #endregion

'''
fileFooter = '''

    }
}'''





fileHeader = fileHeader.replace("$$GETLISTFUNNAME$$",getListFunName) #替换getListFunName
fileHeader = fileHeader.replace("$$INSERTFUNNAME$$",insertFunName) #替换insertFunName
fileHeader = fileHeader.replace("$$UPDATEFUNNAME$$",updateFunName) #替换updateFunName
fileHeader = fileHeader.replace("$$DELETEFUNNAME$$",deleteFunName) #替换deleteFunName
fileHeader = fileHeader.replace("$$GETONEFUNNAME$$",getOneFunName) #替换getOneFunName

fileHeader = fileHeader.replace("$$IBLLNAME$$",ibllName) #替换ibllName
fileHeader = fileHeader.replace("$$BLLNAME$$",bllName) #替换bllName
fileHeader = fileHeader.replace("$$DAONAME$$",daoName) #替换daoName
fileHeader = fileHeader.replace("$$ENTITYNAME$$",entityName) #替换entityName
fileHeader = fileHeader.replace("NowTimeStr",currentTime) #替换成当前时间


currentFileName=bllName+".cs"
fileHeader = fileHeader.replace("FileNameStr",currentFileName) #替换文件名


wholeFile = fileHeader + fileFooter
f = open("d:\\" + currentFileName,"w")
f.write(wholeFile)
f.close()

############################################【5】生成BLL 结束##############################################################

############################################【6】生成Controller 开始##############################################################

fileHeader = '''
/*----------------------------------------------------------------
           // Copyright  2010-2014   ******
           // 版权所有。 
           //
           // 文件名：FileNameStr  （控制器）
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
using EMS.PM.IBusiness;
using System.Web.Mvc;
using EMS.PM.Models;
using System.Collections;
using Newtonsoft.Json;
using SysManager.Common.Utilities;



namespace EMS.PM.Controllers
{
    /// <summary>
    /// XXXX 控制器
    /// </summary>
    public class $$CONTROLLERNAME$$ : PMBaseController 
    {

		#region 定义变量

		/// <summary>
        /// 实例化XXXX业务逻辑接口对象
        /// </summary>
        $$IBLLNAME$$ iBLL = Business.BusinessFactory.Instance.Create$$MODULENAME$$();

        #endregion

		#region 页面显示

        #region 显示XXXX列表页面

        /// <summary>
        /// Description：显示XXXX列表页面
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <returns></returns>
        public ViewResult $$MODULENAME$$LB()
        {
            return View();
        }

        #endregion

        #region 显示XXXX明细页面

        /// <summary>
        /// Description：显示XXXX明细页面
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <returns></returns>
        public ViewResult $$MODULENAME$$MX()
        {
            return View();
        }

        #endregion

        #endregion

        #region 方法

        #region 获取XXXX列表

        public ActionResult $$GETLISTFUNNAME$$()
        {
            IList<$$ENTITYNAME$$> itemList = new List<$$ENTITYNAME$$>();
            try
            {
                itemList = iBLL.$$GETLISTFUNNAME$$();
                
            }
            catch (Exception ex)
            {
                throw;
            }
            return Content(JsonConvert.SerializeObject(itemList));
        }

        #endregion

        #region 插入一条XXXX实体

        /// <summary>
        /// Description：插入一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <param name="item"></param>
        /// <returns>是否插入成功JSON字符串</returns>
        public string $$INSERTFUNNAME$$()
        {
			bool result=false;
			try
            {
                $$ENTITYNAME$$ item = ($$ENTITYNAME$$)JsonConvert.DeserializeObject<$$ENTITYNAME$$>(this.Request["$$MODULENAME$$"].ToString());

				//赋值
				//item.$$MODULENAME$$GUID = CommonHelper.GetGuid;//自动生成的GUID唯一标识
			    //item.LRR = UserData.GetUser().UserId;//录入人
                //item.LRSJ = DateTime.Now;//录入时间
            
                result = iBLL.$$INSERTFUNNAME$$(item);
            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            
            return JsonConvert.SerializeObject(result);
        }

        #endregion

        #region 删除一条XXXX实体

        /// <summary>
        /// Description：删除一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <returns>是否删除成功JSON字符串</returns>
        public string $$DELETEFUNNAME$$()
        {
            bool result = false;
            try
            {
                string itemGUID = Request["itemGUID"];//主键
                result = iBLL.$$DELETEFUNNAME$$(itemGUID);
            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            return JsonConvert.SerializeObject(result);
        }

        #endregion

        #region 修改一条XXXX实体

        /// <summary>
        /// Description：修改一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <returns>是否修改成功JSON字符串</returns>
        public string $$UPDATEFUNNAME$$()
        {
            bool result = false;
            try
            {
                $$MODULENAME$$Entity item = ($$MODULENAME$$Entity)JsonConvert.DeserializeObject<$$MODULENAME$$Entity>(this.Request["$$MODULENAME$$"].ToString());
                string itemGUID = this.Request["itemGUID"].ToString();
                //item.$$MODULENAME$$GUID = itemGUID;//GUID唯一标识
                //item.XGR = UserData.GetUser().UserId;//修改人
                //item.XGSJ = DateTime.Now;//修改时间
                result =iBLL.$$UPDATEFUNNAME$$(item);
            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            return JsonConvert.SerializeObject(result);
        }

        #endregion

        #region 获取一条XXXX实体

        /// <summary>
        /// Description：获取一条XXXX实体
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <returns>序列化XXXX对象成JSON对象</returns>
        public string $$GETONEFUNNAME$$()
        {
            IList<$$ENTITYNAME$$> itemList = null;
            try
            {
                string itemGUID=this.Request["itemGUID"].ToString();
                itemList = iBLL.$$GETONEFUNNAME$$(itemGUID);
            }
            catch (Exception ex)
            {
                throw;
            }
            return JsonConvert.SerializeObject(itemList);
        }

        #endregion

        #endregion

'''
fileFooter = '''

    }
}'''

fileHeader = fileHeader.replace("$$MODULENAME$$",moduleName) #替换moduleName
fileHeader = fileHeader.replace("$$GETLISTFUNNAME$$",getListFunName) #替换getListFunName
fileHeader = fileHeader.replace("$$INSERTFUNNAME$$",insertFunName) #替换insertFunName
fileHeader = fileHeader.replace("$$UPDATEFUNNAME$$",updateFunName) #替换updateFunName
fileHeader = fileHeader.replace("$$DELETEFUNNAME$$",deleteFunName) #替换deleteFunName
fileHeader = fileHeader.replace("$$GETONEFUNNAME$$",getOneFunName) #替换getOneFunName

fileHeader = fileHeader.replace("$$CONTROLLERNAME$$",controllerName) #替换controllerName
fileHeader = fileHeader.replace("$$ENTITYNAME$$",entityName) #替换entityName
fileHeader = fileHeader.replace("$$IBLLNAME$$",ibllName) #替换ibllName
fileHeader = fileHeader.replace("NowTimeStr",currentTime) #替换成当前时间

currentFileName=controllerName+".cs"
fileHeader = fileHeader.replace("FileNameStr",currentFileName) #替换文件名


wholeFile = fileHeader + fileFooter
f = open("d:\\" + currentFileName,"w")
f.write(wholeFile)
f.close()

############################################【6】生成Controller 结束##############################################################



############################################【7】生成JS 开始##############################################################

fileHeader = '''
/*----------------------------------------------------------------
// Copyright  2010-2014 ******
// 版权所有。
//
// 文件名：FileNameStr
// 文件功能描述：XXXX页面 脚本处理
//
//
// 创建标识：shaocx NowTimeStr
//
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/


//页面加载(主页面和子页面同时引用一个JS，所以在得到视图名称时用switch，case控制)
$(function () {
    var thisAction = getCurrentAction(); //获取视图名称
    switch (thisAction) {
        case "$$MODULENAME$$LB": //主页面
            $$MODULENAME$$.$$MODULENAME$$LB(); //加载列表
            break;
        case "$$MODULENAME$$MX": //某个对象的明细页面
            var editFlag = getQueryString("EditFlag");
            if (editFlag != "ADD") {//编辑 
                $$MODULENAME$$.Get$$MODULENAME$$Info();//获取数据
            } else if (editFlag == "ADD") {//新增 
                //打开新增页面
                easyuiAdapter.setController("form", "vm$$MODULENAME$$");
            }
            break;
    }
});

//主页面对象
var $$MODULENAME$$ = {
    //1、视图模型定义
    vm$$MODULENAME$$: avalon.define("vm$$MODULENAME$$", function (vm) {
'''
fileMiddle = '''
	}),
	  //2、加载列表数据
    $$MODULENAME$$LB: function () {
        $("#$$MODULENAME$$DataGrid").datagrid({//KXMCL.cshtml页面的的table的ID
            url: "../PM$$MODULENAME$$/$$GETLISTFUNNAME$$", //获取款项名称的列表数据
            onDblClickRow: function (rowData) {//双击是触发的事件，弹出窗口
                top.MainFrameJS.openWindow({
                    width: 520, //弹出窗口的宽度
                    height: 370, //弹出窗口的高度
                    minimizable: false, //是否显示最小化按钮,默认为true
                    collapsible: false, //是否显示折叠按钮，默认为true
                    maximized: false, //是否显示最大化按钮，默认为true
                    modal: true, //是否模态窗口，即显示为遮罩效果，默认为false
                    title: "付款审批类型"//显示的标题
                }, "../PM$$MODULENAME$$/$$MODULENAME$$MX?EditFlag=MX&id=" + rowData.$$MODULENAME$$GUID); //双击事件可以跳转到详细页面 ，传递ID，MX传递过去调用隐藏保存按钮（2）
            },
            columns: [[//页面显示的选项，编码，系统预制
                 '''
fileFooter='''
            ]]
        });
    },
    //3、点击【新增】，打开明细页面
    $$MODULENAME$$OpenAdd: function () {//
        var dataGridItem = $("#$$MODULENAME$$DataGrid").datagrid("getSelected"); //获取选中的树行
        if (dataGridItem == null) {
            showTipsMsg("请选择一项付款审批类型！", 4000, "w");
            return;
        }
        //跳转页面
        var url = "../PM$$MODULENAME$$/$$MODULENAME$$MX?EditFlag=ADD";
        top.MainFrameJS.openWindow({//弹出窗口
            width: 540, //弹出窗口的宽度
            height: 410, //弹出窗口的高度
            minimizable: false, //是否显示最小化按钮,默认为true
            collapsible: false, //是否显示折叠按钮，默认为true
            maximized: false, //是否显示最大化按钮，默认为true
            modal: true, //是否模态窗口，即显示为遮罩效果，默认为false
            title: "XXXX-新增", //显示的标题
            onBeforeClose: function () {
                //在关闭窗口之前触发的事件，主页面的Table重新加载显示数据
                $("#$$MODULENAME$$DataGrid").datagrid("reload");
            }
        }, url);
    },

    //点击【保存】按钮
    $$MODULENAME$$Save: function () {
        var editFlag = getQueryString("EditFlag");
        var url = '';

        if (editFlag == "ADD") {//新增 
            url = "../PM$$MODULENAME$$/$$INSERTFUNNAME$$";
        } else {//编辑 
            url = "../PM$$MODULENAME$$/$$UPDATEFUNNAME$$";
        }

        //处理
        if (CheckDataValid('#form')) {//验证表单数据
            var postData = { "$$MODULENAME$$": JSON.stringify($$MODULENAME$$.vm$$MODULENAME$$.data.$model) }; //将data数据为Controller中的款项名称实体类赋值
            getDataAsync(url, "POST", postData, function (result) {
                if (result == true) {
                    showTipsMsg('提交成功！', 4000, 's'); //成功：提示信息
                    top.MainFrameJS.closeWindow(); //跳转到主页面
                }
                else {
                    showTipsMsg('提交失败！', 4000, 'e'); //失败：提示信息
                }
            });
        }
    },
    //点击【删除】按钮，执行删除
    $$MODULENAME$$Del: function (id) {
        getDataAsync("../PM$$MODULENAME$$/Delete$$MODULENAME$$Entity?id=" + id, "POST", "", function (result) {//调用Controller中的删除方法
            if (result == true) {
                showTipsMsg('删除成功！', 4000, 's'); //成功：提示信息
                $("#$$MODULENAME$$DataGrid").datagrid("reload"); //页面重新加载
            }
            else {
                showTipsMsg('删除失败！', 4000, 'e'); //失败：提示信息
            }
        });
    },
    //获取指定Guid的付款审批类型实体数据
    Get$$MODULENAME$$Info: function () {
        //数据表单关联
        easyuiAdapter.setController("form", "vm$$MODULENAME$$");
        var editFlag = getQueryString("EditFlag"); //得到传递过来的标志，编辑 
        var id = getQueryString("id"); //guid
        var url = "../PM$$MODULENAME$$/Get$$MODULENAME$$EntityByID?id=" + id; //根据字典表的ID查询字典表的数据
        if (editFlag == "MX") {//明细页面 
            $("#btnSubmit").hide(); //保存按钮隐藏
        } else {//编辑页面 
            $("#btnSubmit").show(); //保存按钮显示
        }
        getDataAsync(url, "POST", "", function (data) {
            data = eval(data);
            $$MODULENAME$$.vm$$MODULENAME$$.data = data[0]; //将Controller中得到的数据赋值给Data，在视图中显示
            easyuiAdapter.setWatch("form", "$$MODULENAME$$", "vm$$MODULENAME$$");
            if (data[0]["SFXTJ"] == "0") {//SFXTJ:是否系统级
                $("#SFXTJ").attr("checked", 'true'); //是否系统级选项框被选中
            }
        });
    },
    Show$$MODULENAME$$Info: function () {
        var dataGridItem = $("#$$MODULENAME$$DataGrid").datagrid("getSelected");
        //获取到Table中的被选中的项
        var url = "";
        if (dataGridItem != null) {
            if (dataGridItem.SFXTJ == "0") {
                //判断是否系统级是否为0 
                url = "../PM$$MODULENAME$$/$$MODULENAME$$MX?id=" + dataGridItem.$$MODULENAME$$GUID + "&EditFlag=MX";
                //如果为0 则跳转页面传递参数ID，传递EditFlag编辑页面的标志
            }
            else {
                url = "../PM$$MODULENAME$$/$$MODULENAME$$MX?id=" + dataGridItem.$$MODULENAME$$GUID + "&EditFlag=Edit";
            }
            if (dataGridItem != null) {//选中一行
                //显示弹窗
                top.MainFrameJS.openWindow({
                    width: 520, //宽度
                    height: 370, //高度
                    minimizable: false, //是否显示最小化按钮,默认为true
                    collapsible: false, //是否显示折叠按钮，默认为true
                    maximized: false, //是否显示最大化按钮，默认为true
                    modal: true, //是否模态窗口，即显示为遮罩效果，默认为false
                    title: "XXXX-编辑", //标题
                    onBeforeClose: function () {//在关闭弹出窗口之前，重新加载Table
                        $("#$$MODULENAME$$DataGrid").datagrid("reload");
                    }
                }, url);
            }
        }
    }
};

//点击【新增】按钮
function add(){
    $$MODULENAME$$.$$MODULENAME$$OpenAdd();
}

//点击【删除】按钮
function del() {
    var dataGridItem = $("#$$MODULENAME$$DataGrid").datagrid("getSelected");
    //获取Table中的被选中的行
    if (dataGridItem != null) {
        var itemGUID= dataGridItem.$$MODULENAME$$GUID; //$$MODULENAME$$GUID:GUID唯一标识
        $.messager.confirm('提示', '确定删除所选信息?', function (Result) {//弹出提示信息
            if (Result) {
                $$MODULENAME$$.$$MODULENAME$$Del(itemGUID);
            }
        });
    } else {
        showTipsMsg('请选择一项需要删除的信息！', 4000, 'w'); //未选中时显示提示信息
        return null;
    }
}

//点击【编辑】按钮
function edit() {
    var dataGridItem = $("#$$MODULENAME$$DataGrid").datagrid("getSelected");
    if (dataGridItem == null) {
        showTipsMsg("请选择一项需要编辑的信息！", 4000, "w");
        return;
    }
    $$MODULENAME$$.Show$$MODULENAME$$Info();
}
    
'''



#getColumnName方法：获取表中的所有列
def getColumnName(columnName,i,arrLen):
	if i==arrLen:
		valueString = "            '" + columnName +"':''\n"
	else:
		valueString = "            '" + columnName +"':'',\n"
	return valueString;

#getColumnNameForDataGrid:为DataGrid构造列
def getColumnNameForDataGrid(columnName,i,arrLen):
	if i==arrLen:
		valueString = "            {field: \""+columnName+"\", title: \""+columnName+"\", width: 30 }\n"
	else:
		valueString = "            {field:\"'"+columnName+"\", title: \""+columnName+"\", width: 30 },\n"
	return valueString;



#中间生成vmModel
fileBody = '''       vm.data = { 
'''
#中间生成DataGrid列
fileBody_DataGrid = '''       vm.data = { 
'''


i=0
for arrItem in arr:
	i=i+1
	propertyName = arrItem[0]
	fileBody = fileBody + getColumnName(propertyName,i,len(arr))
	fileMiddle = fileMiddle + getColumnNameForDataGrid(propertyName,i,len(arr))

fileBody = fileBody +"        };\n"

wholeFile = fileHeader + fileBody+fileMiddle+fileFooter

wholeFile = wholeFile.replace("$$GETLISTFUNNAME$$",getListFunName) #替换getListFunName
wholeFile = wholeFile.replace("$$INSERTFUNNAME$$",insertFunName) #替换insertFunName
wholeFile = wholeFile.replace("$$DELETEFUNNAME$$",deleteFunName) #替换deleteFunName
wholeFile = wholeFile.replace("$$UPDATEFUNNAME$$",updateFunName) #替换updateFunName
wholeFile = wholeFile.replace("$$GETONEFUNNAME$$",getOneFunName) #替换getOneFunName
wholeFile = wholeFile.replace("$$MODULENAME$$",moduleName) #替换moduleName
wholeFile = wholeFile.replace("NowTimeStr",currentTime) #替换成当前时间


currentFileName=moduleName+".js"
wholeFile = wholeFile.replace("FileNameStr",currentFileName) #替换文件名


f = open("d:\\" + currentFileName,"w")
f.write(wholeFile)
f.close()

############################################【7】生成JS 结束##############################################################

############################################【8】生成LBcshtml 开始##############################################################

fileHeader = '''
@{
    ViewBag.Title = "XXXX";
    Layout = "~/Views/Shared/SingleGridPage.cshtml";
}

@section scripts{
    <script src="../../../../Script/PM/$$MODULENAME$$/$$MODULENAME$$.js" type="text/javascript"></script>
}

@section ButtonTool{
    <td>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-add" plain="true"
            onclick="add()">新增</a>
    </td>
     <td>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-edit" plain="true"
            onclick="edit()">编辑</a>
    </td>
    <td>
        <div class="datagrid-btn-separator">
        </div>
    </td>
    <td>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconcls="icon-remove" plain="true"
            onclick="del()">删除</a>
    </td>
}
@section Grid{
     <table id="$$MODULENAME$$DataGrid" class="easyui-datagrid" toolbar="#toolbar" data-options="fit:true,border:false">
    </table>
}

'''




fileHeader = fileHeader.replace("$$MODULENAME$$",moduleName) #替换moduleName

currentFileName=moduleName+"LB.cshtml"


wholeFile = fileHeader
f = open("d:\\" + currentFileName,"w")
f.write(wholeFile)
f.close()

############################################【8】生成LBcshtml 结束##############################################################

############################################【9】生成MXcshtml 开始##############################################################

fileHeader = '''
@{
    ViewBag.Title = "XXXX明细";
    ViewBag.FormTitleWidth = "120px";
    Layout = "~/Views/Shared/SingleCardPage.cshtml";
}

@section scripts{
    <script src="../../../../Script/avalon/avalon.js" type="text/javascript"></script>
    <script src="../../../../Script/avalon/easyuiAdapter.js" type="text/javascript"></script>
    <script src="../../../../Script/PM/$$FILEPATHNAME$$/$$MODULENAME$$.js" type="text/javascript"></script>
}

@section Form{
    <tr class="empty_row_form">
        <th class="title_form">
        </th>
        <td class="content_form">
        </td>
    </tr>
    <tr>
        <th class="title_form must">
            文本:
        </th>
        <td class="content_form">
            <input style="width: 100%" type="text" id="SJBH" class="txt" readonly="readonly"
                ms-duplex="data.SJBH" />
        </td>
    </tr>
    <tr>
        <th class="title_form must">
            数字：
        </th>
        <td class="content_form">
            <input style="width: 100%" type="text" id="FKSPLXBH" class="txt" datacol="yes" checkexpression="Decimal"
                err="数字" ms-duplex="data.FKSPLXBH" />
        </td>
    </tr>
    <tr>
        <th class="title_form must">
            下拉框：
        </th>
        <td class="content_form">
            <select style="width: 100%" id="Gender" class="select easyui-combobox" name="Gender">
                                    <option selected value="男" jquery18205026150992373262="55">男</option>
                                    <option value="女" jquery18205026150992373262="56">女</option>
            </select>
        </td>
    </tr>
    <tr>
        <th class="title_form ">
            单选框：
        </th>
        <td class="content_form" align="left">
            <input type="checkbox" id="SFXTJ" onclick="{return false;}" />
        </td>
    </tr>
    <tr>
        <th class="title_form">
            多行文本：
        </th>
        <td class="content_form" >
            <textarea id="BZ" style="width: 100%; height: 100px" type="text" ms-duplex="data.BZ"></textarea>
        </td>
    </tr>
}

@section BottomButton{
   <a href="javascript:void(0)" id="btnSubmit" class="easyui-linkbutton" onclick="$$MODULENAME$$.$$MODULENAME$$Save();"
        iconcls="icon-save">保存</a> <a href="javascript:void(0)" class="easyui-linkbutton"
            onclick="top.MainFrameJS.closeWindow();" iconcls="icon-close">关闭</a>
}


'''




fileHeader = fileHeader.replace("$$MODULENAME$$",moduleName) #替换moduleName
fileHeader = fileHeader.replace("$$FILEPATHNAME$$",filePathName) #替换文件路径

currentFileName=moduleName+"MX.cshtml"


wholeFile = fileHeader
f = open("d:\\" + currentFileName,"w")
f.write(wholeFile)
f.close()

############################################【9】生成MXcshtml 结束##############################################################



############################################【10】补充文件 开始##############################################################

fileHeader = '''
/*----------------------------------------------------------------
           // Copyright  2010-2014   ******
           // 版权所有。 
           //
           // 感谢使用Python版代码生成器
           // 功能描述: 房地产PM代码生成
           // 创建标识：shaocx  NowTimeStr	\n

									      _ooOoo_
                                      o8888888o
                                      88" . "88
                                      (| -_- |)
                                      O\ = /O
                                   ____/`---'\____
                                 .' \\| |// `.
                                / \\||| : |||// \
                               / _||||| -:- |||||- \
                               | | \\\ - /// | |
                               | \_| ''\---/'' | |
                               \ .-\__ `-` ___/-. /
                             ___`. .' /--.--\ `. . __
                          ."" '< `.___\_<|>_/___.' >'"".
                         | | : `- \`.;`\ _ /`;.`/ - ` : | |
                         \ \ `-. \_ __\ /__ _/ .-` / /
                    ======`-.____`-.___\_____/___.-`____.-'======
                                       `=---='
                    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
                             佛祖保佑 永无BUG
//----------------------------------------------------------------*/ \n


	下面是在PM项目中添加模块后需要在别的文件中配置的代码:
	
	(1)BusinessFactory.cs文件：
		路径：PM.Business\BusinessFactory.cs
		方式：添加
		代码：
			#region XXXX

			/// <summary>
			/// Description:XXXX
			/// Author：shaocx
			/// Time：NowTimeStr
			/// </summary>
			/// <returns></returns>
			public virtual $$IBLLNAME$$ Create$$MODULENAME$$()
			{
				return new $$BLLNAME$$();
			}

            #endregion

	  (2)PM.Maps.config文件
			路径：DataAccess\PM.DataAccess\Config\PM.Maps.config
			方式:添加(路径按实际情况编写)
			代码：
				<!--XXXX [EditBy shaocx,NowTimeStr]-->
				<sqlMap resource="bin\Maps\PM\$$FILEPATHNAME$$\$$MODULENAME$$.xml" />

	  (3)PMViewEngine.cs文件
			路径：PM.Web/App_Start/MvcEx/PMViewEngine.cs
			方式：添加(路径按实际情况编写)
			代码：
				 "~/Views/PM/$$FILEPATHNAME$$/$$MODULENAME$$/{0}.cshtml",   //XXXX [EditBy shaocx,NowTimeStr]

'''
fileFooter = '''

    }
}'''






fileHeader = fileHeader.replace("$$IBLLNAME$$",ibllName) #替换ibllName
fileHeader = fileHeader.replace("$$BLLNAME$$",bllName) #替换bllName
fileHeader = fileHeader.replace("$$MODULENAME$$",moduleName) #替换moduleName
fileHeader = fileHeader.replace("NowTimeStr",currentTime) #替换成当前时间
fileHeader = fileHeader.replace("$$FILEPATHNAME$$",filePathName) #替换文件路径


currentFileName=moduleName+("使用必读").decode("utf-8").encode("gbk")+".txt"
fileHeader = fileHeader.replace("FileNameStr",currentFileName) #替换文件名


wholeFile = fileHeader
f = open("d:\\" + currentFileName,"w")
f.write(wholeFile)
f.close()


############################################【10】补充文件 结束##############################################################

















