using System;
using System.Text;
using System.Collections.Generic;
namespace Excel2SQL
{
    //表列实体
    public class ColumnEntity
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        public string ChinaName { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }


        /// <summary>
        /// 数据长度
        /// </summary>
        public string DataLength { get; set; }

        /// <summary>
        /// 是否允许为空
        /// </summary>
        public string IsNullAuble { get; set; }
    }

    /// <summary>
    /// 数据类型枚举
    /// </summary>
    public enum DataTypeEnum
    {
        dt_nvarchar = 0,
        dt_datetime = 1,
        dt_int = 2,
        dt_bigint = 3,
        dt_decimal = 4,
        dt_bit = 5,
        dt_varchar = 6,
        dt_char = 7
    }
}

