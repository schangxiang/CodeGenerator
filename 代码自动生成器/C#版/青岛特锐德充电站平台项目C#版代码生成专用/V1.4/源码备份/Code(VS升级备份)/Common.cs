using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel
{
    /// <summary>
    /// 公共类
    /// </summary>
    public class Common
    {
        /// <summary>
        /// 回车符
        /// </summary>
        public const string enterStr = "\n";

        /// <summary>
        /// 单个回车符的字符串
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetSinleEnterStr(string content)
        {
            return content + enterStr;
        }
        /// <summary>
        /// 两个回车符的字符串
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetDoubleEnterStr(string content)
        {
            return content + enterStr + enterStr;
        }
    }

    /// <summary>
    /// 文件类型
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// 实体类文件
        /// </summary>
        Model = 0,
        /// <summary>
        /// DAO文件
        /// </summary>
        DAO = 1,
        /// <summary>
        /// IBLL文件
        /// </summary>
        IBLL = 2,
        /// <summary>
        /// BLL文件
        /// </summary>
        BLL = 3,
        /// <summary>
        /// Controller文件
        /// </summary>
        Controller = 4,
        /// <summary>
        /// JS文件
        /// </summary>
        JS = 5,
        /// <summary>
        /// CSHTML文件
        /// </summary>
        CSHTML = 6,
        /// <summary>
        /// XML文件
        /// </summary>
        XML = 7
    }
}
