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
