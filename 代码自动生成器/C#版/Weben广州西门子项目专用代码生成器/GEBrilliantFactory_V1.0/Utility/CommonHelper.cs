using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// 公共类
    /// </summary>
    public class CommonHelper
    {
        /// <summary>
        /// 获取存储过程名
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        public static ProcName GetProcName(string moduleName)
        {
            string procPrefix = "uspWip_";
            ProcName procName = new ProcName()
            {
                AddProc = procPrefix + "Add" + moduleName,
                UpdateProc = procPrefix + "Update" + moduleName,
                GetSingleProc = procPrefix + "GetSingle" + moduleName,
                ListProc = procPrefix + "Get" + moduleName + "List",
                PageListProc = procPrefix + "Get" + moduleName + "PageList",
            };
            return procName;
        }

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

        /// <summary>
        /// 当前时间字符串
        /// </summary>
        /// <returns></returns>
        public static string GetCurDate()
        {
            return DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day
                            + " "
                            + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TitleToUpper(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            char[] s = str.ToCharArray();
            char c = s[0];

            if ('a' <= c && c <= 'z')
                c = (char)(c & ~0x20);

            s[0] = c;

            return new string(s);
        }
        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TitleToLower(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            char[] s = str.ToCharArray();
            char c = s[0];

            if ('A' <= c && c <= 'Z')
                c = char.ToLower(c);


            s[0] = c;

            return new string(s);
        }

        /// <summary>
        /// 获取数据库连接字符串列表
        /// </summary>
        /// <returns></returns>
        public static List<ListItem> GetDataSources()
        {
            List<ListItem> list = new List<ListItem>();
            ConnectionStringSettingsCollection conn = ConfigurationManager.ConnectionStrings;
            foreach (ConnectionStringSettings item in conn)
            {
                if (item.Name == "LocalSqlServer")
                    continue;
                ListItem listItem = new ListItem()
                {
                    Text = item.Name,
                    Value = item.ConnectionString
                };
                list.Add(listItem);
            }
            return list;
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
        /// 列表页面
        /// </summary>
        CSHTML_List = 6,
        /// <summary>
        /// XML文件
        /// </summary>
        XML = 7,
        /// <summary>
        /// 详情页面
        /// </summary>
        CSHTML_Detail = 8,
        /// <summary>
        /// 存储过程文件
        /// </summary>
        Proc = 9,
        /// <summary>
        /// DAL 文件
        /// </summary>
        DAL = 10,
        /// <summary>
        /// QueryModel
        /// </summary>
        QueryModel = 11,
        /// <summary>
        /// WCF接口文件
        /// </summary>
        WCF_InterFace = 12,
        /// <summary>
        /// WCF接口实现文件
        /// </summary>
        WCF_InterFaceRealize = 13,
        /// <summary>
        /// InsertSQL
        /// </summary>
        SQL_Insert = 14,
        /// <summary>
        /// VUE方法配置
        /// </summary>
        VUE_FunConfig = 15,
        /// <summary>
        /// VUE文件
        /// </summary>
        VUEFile = 16,
        /// <summary>
        /// 新增实体参数类
        /// </summary>
        AddModelParam=17
    }
}
