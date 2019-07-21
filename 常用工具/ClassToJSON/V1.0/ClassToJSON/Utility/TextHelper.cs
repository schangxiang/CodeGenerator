using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassToJSON
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
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="textContent"></param>
        public static void CreateFile(string filePath, string fileName, string textContent)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string txtName = filePath + "\\" + fileName;


            using (StreamWriter outfile = new StreamWriter(txtName, false, Encoding.GetEncoding("UTF-8")))
            {
                outfile.Write(textContent);
                outfile.Close();
            }
        }
    }
}
