using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// 数据类型枚举
    /// </summary>
    public enum DataTypeEnum
    {
        dt_char = 0,
        dt_varchar = 1,
        dt_datetime = 2,
        dt_datetime2 = 3,
        dt_int = 4,
        dt_bigint = 5,
        dt_decimal = 6,
        dt_nvarchar = 7,
        dt_Varchar_Desc = 8,
        dt_Varchar_Ext_Link = 9,
        dt_bit = 10,
        /// <summary>
        /// 唯一类型
        /// uniqueidentifier数据类型可存储16字节的二进制值，其作用与全局唯一标记符(GUID)一样。GUID是唯一的二进制数:世界上的任何两台计算机都不会生成重复的GUID值。GUID主要用于在用于多个节点，多台计算机的网络中，分配必须具有唯一性的标识符。
        /// </summary>
        dt_uniqueidentifier = 11,
        dt_float = 12
    }
}
