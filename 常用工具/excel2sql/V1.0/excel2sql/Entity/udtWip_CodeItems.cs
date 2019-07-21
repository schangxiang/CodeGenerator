/*
 * FileName：UdtWip_CodeItems.cs
 * FileDesc：表的中文注解实体类
 * CreateTime：2018-8-24 16:7:36
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2018-8-24 16:7:36 新規作成 (by shaocx)
 */ 
 using System;
using System.Runtime.Serialization; 
                   
namespace Excel2SQL
{
    /// <summary>
    /// 表的中文注解实体类
    /// </summary>
    //[DataContract]
    public class UdtWip_CodeItems 
    {

        public string OrderNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //[DataMember]
        public int id { get; set; }

        /// <summary>
        /// 代码项编码
        /// </summary>
        //[DataMember]
        public string code { get; set; }

        /// <summary>
        /// 代码名称
        /// </summary>
        public string codeName { get; set; }

        /// <summary>
        /// 代码项名称
        /// </summary>
        //[DataMember]
        public string name { get; set; }

        /// <summary>
        /// 代码编码
        /// </summary>
        //[DataMember]
        public string setCode { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        //[DataMember]
        public string note { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        //[DataMember]
        public bool? delFlag { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        //[DataMember]
        public string creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        //[DataMember]
        public DateTime? createTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        //[DataMember]
        public string lastModifier { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        //[DataMember]
        public DateTime? lastModifyTime { get; set; }

    }
}