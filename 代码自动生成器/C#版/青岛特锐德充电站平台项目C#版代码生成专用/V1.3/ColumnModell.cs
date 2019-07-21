using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel
{
    /// <summary>
    /// 列对象
    /// </summary>
    public class ColumnModel
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DateType { get; set; }

        /// <summary>
        /// 注释
        /// </summary>
        public string ColumnComment { get; set; }
    }


    /// <summary>
    /// 数据类型枚举
    /// </summary>
    public enum DataTypeEnum
    { 
        dt_char=0,
        dt_varchar=1,
        dt_datetime=2,
        dt_int=3,
        dt_decimal=4
    }
}
