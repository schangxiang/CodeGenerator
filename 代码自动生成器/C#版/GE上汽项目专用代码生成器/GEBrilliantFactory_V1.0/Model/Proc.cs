/*
 * CLR Version：4.0.30319.42000
 * NameSpace：GenerateCode_GEBrilliantFactory.Model
 * FileName：Proc
 * CurrentYear：2018
 * CurrentTime：2018/8/31 16:46:26
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2018/8/31 16:46:26 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// 存储过程名
    /// </summary>
    public class ProcName
    {
        /// <summary>
        /// 新增的存储过程名
        /// </summary>
        public string AddProc { get; set; }

        /// <summary>
        /// 编辑的存储过程名
        /// </summary>
        public string UpdateProc { get; set; }

        /// <summary>
        /// 列表的存储过程名
        /// </summary>
        public string ListProc { get; set; }

        /// <summary>
        /// 分页列表的存储过程名
        /// </summary>
        public string PageListProc { get; set; }

        /// <summary>
        /// 得到一个实体的存储过程名
        /// </summary>
        public string GetSingleProc { get; set; }
    }
}
