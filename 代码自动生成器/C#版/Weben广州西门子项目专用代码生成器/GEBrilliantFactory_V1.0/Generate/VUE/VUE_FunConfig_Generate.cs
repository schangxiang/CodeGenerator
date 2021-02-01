
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// VUE方法配置
    /// </summary>
    public class VUE_FunConfig_Generate
    {
        /// <summary>
        /// VUE方法配置
        /// </summary>
        /// <param name="Modulelogo">模块简写</param>
        /// <param name="ChinaComment">中文注释</param>
        /// <param name="routePrefix">WCF路由前缀</param>
        /// <returns></returns>
        public static string CreateText(string Modulelogo,
            string ChinaComment, string routePrefix,string entityName)
        {
            var str = TextHelper.ReadText(@"Templete\VUE\VUE方法配置.txt");

            str = str.Replace("$ChinaComment$", ChinaComment);//中文注释
            str = str.Replace("$Modulelogo$", Modulelogo);//模块简写
            str = str.Replace("$RoutePrefix$", routePrefix);//模块简写
            str = str.Replace("$EntityName$", entityName);//模块简写


            return str;
        }
    }
}
