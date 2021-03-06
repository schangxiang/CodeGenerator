﻿
using GenerateCode_GEBrilliantFactory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode_GEBrilliantFactory
{
    public class TextHelper
    {
        /// <summary>
        /// 读取text文本内容
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadText(string path)
        {
            try
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                String line;
                StringBuilder sb = new StringBuilder();
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line.ToString() + " \n");
                }
                return sb.ToString();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 生成文件
        /// </summary>
        /// <param name="_strPath">路径</param>
        /// <param name="_tableName">表名</param>
        /// <param name="_code">生成的代码字符串</param>
        /// <param name="fileType">生成的文件类型</param>
        /// <param name="filePrefixName">前缀</param>
        /// <param name="entityName">实体类名</param>
        /// <param name="modulelogo">模块名字</param>
        /// <returns></returns>
        public static bool Export2File(string _strPath, string _tableName, string _code, FileType fileType,
            string filePrefixName, string entityName, string modulelogo)
        {
            string fileTypeName = "";
            switch (fileType)
            {
                case FileType.Model:
                    fileTypeName = ".cs";
                    break;
                case FileType.AddModelParam:
                    entityName = "Add" + modulelogo + "Param";
                    fileTypeName = ".cs";
                    break;
                case FileType.IBLL:
                    entityName = "I" + filePrefixName + "BLL";
                    fileTypeName = ".cs";
                    break;
                case FileType.Controller:
                    entityName = filePrefixName + "Controller";
                    fileTypeName = ".cs";
                    break;
                case FileType.JS:
                    entityName = filePrefixName;
                    fileTypeName = ".js";
                    break;
                case FileType.CSHTML_List:
                    entityName = filePrefixName;
                    fileTypeName = ".cshtml";
                    break;
                case FileType.CSHTML_Detail:
                    entityName = filePrefixName;
                    fileTypeName = "Detail.cshtml";
                    break;
                case FileType.XML:
                    entityName = filePrefixName;
                    fileTypeName = ".xml";
                    break;
                case FileType.Proc:
                    entityName = filePrefixName;
                    fileTypeName = "Proc.sql";
                    break;
                case FileType.DAL:
                    entityName = filePrefixName;
                    fileTypeName = "DAL.cs";
                    break;
                case FileType.BLL:
                    entityName = filePrefixName;
                    fileTypeName = "BLL.cs";
                    break;
                case FileType.QueryModel:
                    entityName = "Query" + modulelogo;
                    fileTypeName = "Param.cs";
                    break;
                case FileType.WCF_InterFace:
                    entityName = "I" + modulelogo + "Service";
                    fileTypeName = ".cs";
                    break;
                case FileType.WCF_InterFaceRealize:
                    entityName = modulelogo + "Service";
                    fileTypeName = ".cs";
                    break;
                case FileType.SQL_Insert:
                    entityName = _tableName + "InsertSQL";
                    fileTypeName = ".txt";
                    break;
                case FileType.VUE_FunConfig:
                    entityName = _tableName + "VUE方法配置";
                    fileTypeName = ".txt";
                    break;
                case FileType.VUEFile:
                    entityName = _tableName;
                    fileTypeName = ".vue";
                    break;
            }
            if (!Directory.Exists(_strPath + "\\" + _tableName))
            {
                Directory.CreateDirectory(_strPath + "\\" + _tableName);
            }
            string filePath = _strPath + "\\" + _tableName + "\\" + entityName + fileTypeName;
            using (StreamWriter outfile = new StreamWriter(filePath, false, Encoding.GetEncoding("UTF-8")))
            {
                outfile.Write(_code);
            }

            return true;
        }
    }
}
