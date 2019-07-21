# encoding: utf-8
import cx_Oracle
import time
fileContent = '''
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

using ERP.EHSBOSS.RTF.FrameworkSPI;
using ERP.EHSBOSS.MODULENAMEHERE.Common;


namespace ERP.EHSBOSS.MODULENAMEHERE.Core
{
    public class CAMELNAMEHEREMgr
    {
        #region 构建单例
        private static CAMELNAMEHEREMgr instance = new CAMELNAMEHEREMgr();
        private CAMELNAMEHEREMgr()
        {
        }

        public static CAMELNAMEHEREMgr GetInstance()
        {
            if (instance == null) instance = new CAMELNAMEHEREMgr();
            return instance;
        }
        #endregion

        #region 对象增删改查

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public List<CAMELNAMEHEREEntity> GetCAMELNAMEHEREList(string filter)
        {
            return CAMELNAMEHEREDAC.GetInstance().GetObjects(new LPFFilter(filter));
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">新增的实体对象</param>
        /// <returns></returns>
        public bool AddCAMELNAMEHERE(CAMELNAMEHEREEntity entity)
        {
            CAMELNAMEHEREDAC.GetInstance().Add(entity);
            return true;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">更新的实体对象</param>
        /// <returns></returns>
        public bool UpdateCAMELNAMEHERE(CAMELNAMEHEREEntity entity)
        {
            CAMELNAMEHEREDAC.GetInstance().SetObject(entity.CAMELNAMEHEREId, entity);
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id">删除的对象主键</param>
        /// <returns></returns>
        public bool DeleteCAMELNAMEHERE(decimal Id)
        {
            CAMELNAMEHEREDAC.GetInstance().Remove(Id);
            return true;
        }
        #endregion


    }
}'''

def translateToCamel(originalName):
	translatedString = originalName.replace("_"," ")
	translatedString = translatedString.title()
	translatedString = translatedString.replace(" ","")
	return translatedString;

tableName = raw_input("Enter TableNAME:")
moduleName = raw_input("Enter Module NAME:")#ERP.EHSBOSS.PUB.Core

camelTableName = translateToCamel(tableName)
fileContent = fileContent.replace("MODULENAMEHERE",moduleName)
fileContent = fileContent.replace("CAMELNAMEHERE",camelTableName)
fileContent = fileContent.replace("NowTimeStr",time.strftime('%Y-%m-%d %H:%M:%S',time.localtime(time.time()))) #替换成当前时间


currentFileName=camelTableName + "Mgr.cs"
fileContent = fileContent.replace("FileNameStr",currentFileName) #替换文件名

f = open("d:\\" + currentFileName,"w")
f.write(fileContent)
f.close()























