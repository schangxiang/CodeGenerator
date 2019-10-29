using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
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
        public string DataType { get; set; }

        /// <summary>
        /// 注释
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        public string DataLength { get; set; }

        /// <summary>
        /// 是否可为null
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// 是否是主键
        /// </summary>
        public bool IsPrimaryKey { get; set; }

        public int Precision { get; set; }

        public int Scale { get; set; }
    }
}
