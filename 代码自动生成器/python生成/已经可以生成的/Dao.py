# encoding: utf-8

import cx_Oracle
import time

fileHeader = '''
/*----------------------------------------------------------------
           // Copyright  2010-2014   ******
           // 版权所有。 
           //
           // 文件名：FileNameStr  (数据访问对象(Data Access Object)类)
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



namespace EMS.PM.DataAccess.Dao
{
    /// <summary>
    /// XXXX 数据访问对象类
    /// </summary>
    public class DAONAMEHERE : PMBaseDao
    {

        #region 获取XXXX列表集合

		/// <summary>
        /// Description：获取XXXX列表集合
        /// Author：shaocx
        /// Time：NowTimeStr
        /// </summary>
        /// <returns>XXXX实体类集合</returns>
        public IList<ENTITYNAMEHERE> GetENTITYNAMEHEREList()
        {
            IList<ENTITYNAMEHERE> itemList = null;
            try
            {
                itemList = SqlMap.QueryForList<ENTITYNAMEHERE>("GetENTITYNAMEHEREList", null);
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
        /// <returns></returns>
        public bool InsertENTITYNAMEHERE(ENTITYNAMEHERE item)
        {
            bool result = false;
            try
            {
                SqlMap.Insert("InsertENTITYNAMEHERE", item);//调用xml的sql语句
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
        public bool DeleteENTITYNAMEHERE(string itemGUID)
        {
            bool result = false;
            try
            {
                SqlMap.Delete("DeleteENTITYNAMEHERE", itemGUID);
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
        public bool UpdateENTITYNAMEHERE(ENTITYNAMEHERE item)
        {
            bool result = false;
            try
            {
                SqlMap.Update("UpdateENTITYNAMEHERE", item);
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
        public IList<ENTITYNAMEHERE> GetENTITYNAMEHEREByID(string itemGUID)
        {
            IList<ENTITYNAMEHERE> itemList = null;
            try
            {
                itemList = SqlMap.QueryForList<ENTITYNAMEHERE>("GetENTITYNAMEHEREByID", itemGUID);
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



entityName = raw_input("Enter EntityName:")
daoName=raw_input("Enter DaoName:")




fileHeader = fileHeader.replace("DAONAMEHERE",daoName)
fileHeader = fileHeader.replace("ENTITYNAMEHERE",entityName)
fileHeader = fileHeader.replace("NowTimeStr",time.strftime('%Y-%m-%d %H:%M:%S',time.localtime(time.time()))) #替换成当前时间


currentFileName=daoName+".cs"
fileHeader = fileHeader.replace("FileNameStr",currentFileName) #替换文件名


wholeFile = fileHeader + fileFooter
f = open("d:\\" + currentFileName,"w")
f.write(wholeFile)
f.close()























