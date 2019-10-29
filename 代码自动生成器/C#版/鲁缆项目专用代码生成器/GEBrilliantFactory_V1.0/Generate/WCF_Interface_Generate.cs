
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// 生成WCF的接口文件
    /// </summary>
    public class WCF_Interface_Generate
    {
        public static string CreateText(string Wcf_NameSpacePath, string Modulelogo, string entityName,
            string ChinaComment, string addEntityParam)
        {
            var str = TextHelper.ReadText(@"Templete\WCF接口模板.txt");

            str = str.Replace("$Wcf_NameSpacePath$", Wcf_NameSpacePath);//WCF项目的命名空间
            str = str.Replace("$ChinaComment$", ChinaComment);//中文注释
            str = str.Replace("$EntityName$", entityName);//实体类名
            str = str.Replace("$Modulelogo$", Modulelogo);//模块简写
            str = str.Replace("$AddEntityParam$", addEntityParam);

            str = CommonHelper.RepalceNameSpace(str);

            return str;
        }
    }
}
