using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode_GEBrilliantFactory
{
    public class ListHelper
    {
        /// <summary>
        /// 获取最新的列List集合(去掉 creator和createTime)
        /// </summary>
        /// <param name="columnNameList"></param>
        /// <returns></returns>
        public static List<ColumnModel> RemoveCreator(List<ColumnModel> columnNameList)
        {
            //构造新的List
            List<ColumnModel> newList = new List<ColumnModel>();
            ColumnModel columnModel = null;
            for (int i = 0; i < columnNameList.Count; i++)
            {//需要去掉 创建人和创建时间
                columnModel = columnNameList[i];
                if (columnModel.ColumnName.ToUpper() == "creator".ToUpper()
                    || columnModel.ColumnName.ToUpper() == "createTime".ToUpper())
                {
                    continue;
                }
                newList.Add(columnModel);
            }
            return newList;
        }


        /// <summary>
        ///  获取最新的列List集合(移除全部)
        /// </summary>
        /// <param name="columnNameList"></param>
        /// <returns></returns>
        public static List<ColumnModel> RemoveAll(List<ColumnModel> columnNameList)
        {
            //构造新的List
            List<ColumnModel> newList = new List<ColumnModel>();
            ColumnModel columnModel = null;
            for (int i = 0; i < columnNameList.Count; i++)
            {//需要去掉 创建人和创建时间
                columnModel = columnNameList[i];
                if (columnModel.ColumnName.ToUpper() == "creator".ToUpper()
                   || columnModel.ColumnName.ToUpper() == "createTime".ToUpper()
                   || columnModel.ColumnName.ToUpper() == "lastModifier".ToUpper()
                   || columnModel.ColumnName.ToUpper() == "lastModifyTime".ToUpper()
                   || columnModel.ColumnName.ToUpper() == "delFlag".ToUpper()
                   || columnModel.ColumnName.ToUpper() == "id".ToUpper()
                   )
                {
                    continue;
                }
                newList.Add(columnModel);
            }
            return newList;
        }

        /// <summary>
        /// 获取最新的列List集合(去掉 delFlag、creator、createTime、lastModifier、lastModifyTime)
        /// </summary>
        /// <param name="columnNameList"></param>
        /// <returns></returns>
        public static List<ColumnModel> RemoveDelFlagCreatorModifier(List<ColumnModel> columnNameList)
        {
            List<ColumnModel> newList = new List<ColumnModel>();
            ColumnModel columnModel = null;
            for (int i = 0; i < columnNameList.Count; i++)
            {
                columnModel = columnNameList[i];
                if (columnModel.ColumnName.ToUpper() == "creator".ToUpper()
                    || columnModel.ColumnName.ToUpper() == "createTime".ToUpper()
                    || columnModel.ColumnName.ToUpper() == "lastModifier".ToUpper()
                    || columnModel.ColumnName.ToUpper() == "lastModifyTime".ToUpper()
                    || columnModel.ColumnName.ToUpper() == "delFlag".ToUpper()
                    )
                {
                    continue;
                }
                newList.Add(columnModel);
            }
            return newList;
        }

        /// <summary>
        /// 获取最新的列List集合(去掉 Id，OperationRemark、CreateId，ModifyId)
        /// </summary>
        /// <param name="columnNameList"></param>
        /// <returns></returns>
        public static List<ColumnModel> RemoveIdOperationRemarkCreateIdModifyId(List<ColumnModel> columnNameList)
        {
            List<ColumnModel> newList = new List<ColumnModel>();
            ColumnModel columnModel = null;
            for (int i = 0; i < columnNameList.Count; i++)
            {
                columnModel = columnNameList[i];
                if (columnModel.ColumnName.ToUpper() == "Id".ToUpper()
                    || columnModel.ColumnName.ToUpper() == "OperationRemark".ToUpper()
                    || columnModel.ColumnName.ToUpper() == "CreateId".ToUpper()
                    || columnModel.ColumnName.ToUpper() == "ModifyId".ToUpper()
                    )
                {
                    continue;
                }
                newList.Add(columnModel);
            }
            return newList;
        }

        /// <summary>
        /// 获取最新的列List集合(只保留 字符串类型的字段)
        /// </summary>
        /// <param name="columnNameList"></param>
        /// <returns></returns>
        public static List<ColumnModel> OnlyStringProValue(List<ColumnModel> columnNameList)
        {
            List<ColumnModel> newList = new List<ColumnModel>();
            ColumnModel columnModel = null;
            for (int i = 0; i < columnNameList.Count; i++)
            {
                columnModel = columnNameList[i];
                //获取数据类型
                DataTypeEnum enumDT = (DataTypeEnum)Enum.Parse(typeof(DataTypeEnum), "dt_" + columnModel.DataType.ToString());
                switch (enumDT)
                {
                    case DataTypeEnum.dt_char:
                    case DataTypeEnum.dt_varchar:
                    case DataTypeEnum.dt_Varchar_Desc:
                    case DataTypeEnum.dt_uniqueidentifier:
                    case DataTypeEnum.dt_Varchar_Ext_Link:
                    case DataTypeEnum.dt_nvarchar:
                        newList.Add(columnModel);
                        break;
                }
            }
            return newList;
        }


        /// <summary>
        /// 获取最新的列List集合(去掉 id、creator、createTime、lastModifier、lastModifyTime)
        /// </summary>
        /// <param name="columnNameList"></param>
        /// <returns></returns>
        public static List<ColumnModel> RemoveIdCreatorModifier(List<ColumnModel> columnNameList)
        {
            List<ColumnModel> newList = new List<ColumnModel>();
            ColumnModel columnModel = null;
            for (int i = 0; i < columnNameList.Count; i++)
            {
                columnModel = columnNameList[i];
                if (columnModel.ColumnName.ToUpper() == "creator".ToUpper()
                    || columnModel.ColumnName.ToUpper() == "createTime".ToUpper()
                    || columnModel.ColumnName.ToUpper() == "lastModifier".ToUpper()
                    || columnModel.ColumnName.ToUpper() == "lastModifyTime".ToUpper()
                    || columnModel.ColumnName.ToUpper() == "id".ToUpper()
                    )
                {
                    continue;
                }
                newList.Add(columnModel);
            }
            return newList;
        }

        /// <summary>
        /// 获取最新的列List集合(去掉 ID)
        /// </summary>
        /// <param name="columnNameList"></param>
        /// <returns></returns>
        public static List<ColumnModel> OnlyRemoveId(List<ColumnModel> columnNameList)
        {
            List<ColumnModel> newList = new List<ColumnModel>();
            ColumnModel columnModel = null;
            for (int i = 0; i < columnNameList.Count; i++)
            {
                columnModel = columnNameList[i];
                if (columnModel.ColumnName.ToUpper() == "id".ToUpper())
                {
                    continue;
                }
                newList.Add(columnModel);
            }
            return newList;
        }

    }
}
