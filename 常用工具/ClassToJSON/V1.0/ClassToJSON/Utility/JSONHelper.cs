using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassToJSON
{
    public class JSONHelper
    {
        public static string GetJSON(Type type, bool isList = false)
        {
            try
            {
                PropertyInfo[] propArr = type.GetProperties();
                StringBuilder sb = new StringBuilder();
                string tab = "", prpoTab = "  ";
                if (isList)
                {
                    sb.Append("[ \n");
                    tab = "  ";
                }
                sb.Append(tab + "{ \n");

                //注意：propArr不能作为传输传递！！！出错
                if (propArr != null && propArr.Length > 0)
                {

                    int i = 0;
                    Type propertyType = null;
                    object defaultVal = null;
                    foreach (var item in propArr)
                    {
                        sb.Append(tab + prpoTab + "\"" + item.Name + "\":");
                        defaultVal = "";
                        i++;
                        propertyType = item.PropertyType;
                        if (propertyType == typeof(DateTime))
                        {
                            defaultVal = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            sb.Append("\"" + defaultVal.ToString() + "\" ");
                        }
                        else if (propertyType == typeof(DateTime?))
                        {
                            defaultVal = "null";
                            sb.Append(defaultVal.ToString());
                        }
                        else if (propertyType == typeof(Int32) || propertyType == typeof(decimal) || propertyType == typeof(long))
                        {
                            defaultVal = 0;
                            sb.Append(defaultVal.ToString());
                        }
                        else if (propertyType == typeof(Int32?) || propertyType == typeof(decimal?) || propertyType == typeof(long?))
                        {
                            defaultVal = "null";
                            sb.Append(defaultVal.ToString());
                        }
                        else if (propertyType == typeof(bool))
                        {
                            defaultVal = false;
                            sb.Append(defaultVal.ToString());
                        }
                        else if (propertyType == typeof(bool?))
                        {
                            defaultVal = "null";
                            sb.Append(defaultVal.ToString());
                        }
                        else
                        {
                            sb.Append("\"" + defaultVal.ToString() + "\" ");
                        }
                        if (i == propArr.Length)
                        {
                            sb.Append(" \n");
                        }
                        else
                        {
                            sb.Append(", \n");
                        }
                    }
                }
                sb.Append(tab + "}\n");
                if (isList)
                {
                    sb.Append("]\n");
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static string GetJSON<T>(List<T> modelList)
        {
            try
            {
                Type type = typeof(T);
                PropertyInfo[] propArr = type.GetProperties();

                StringBuilder sb = new StringBuilder();
                string tab = "", prpoTab = "  ";
                sb.Append("[ \n");
                tab = "  ";
                

                //注意：propArr不能作为传输传递！！！出错
                if (propArr != null && propArr.Length > 0)
                {
                    int zz = 0;
                    foreach (var model in modelList)
                    {
                        zz++;
                        sb.Append(tab + "{ \n");
                        int i = 0;
                        Type propertyType = null;
                        object defaultVal = null;
                        foreach (var item in propArr)
                        {
                            sb.Append(tab + prpoTab + "\"" + item.Name + "\":");
                            defaultVal = item.GetValue(model, null);
                            i++;
                            propertyType = item.PropertyType;
                            if (propertyType == typeof(DateTime))
                            {
                                sb.Append("\"" + defaultVal.ToString() + "\" ");
                            }
                            else if (propertyType == typeof(DateTime?))
                            {
                                sb.Append(defaultVal.ToString());
                            }
                            else if (propertyType == typeof(Int32) || propertyType == typeof(decimal) || propertyType == typeof(long))
                            {
                                sb.Append(defaultVal.ToString());
                            }
                            else if (propertyType == typeof(Int32?) || propertyType == typeof(decimal?) || propertyType == typeof(long?))
                            {
                                sb.Append(defaultVal.ToString());
                            }
                            else if (propertyType == typeof(bool))
                            {
                                sb.Append(defaultVal.ToString());
                            }
                            else if (propertyType == typeof(bool?))
                            {
                                sb.Append(defaultVal.ToString());
                            }
                            else
                            {
                                sb.Append("\"" + defaultVal.ToString() + "\" ");
                            }
                            if (i == propArr.Length)
                            {
                                sb.Append(" \n");
                            }
                            else
                            {
                                sb.Append(", \n");
                            }
                        }
                        if (zz == modelList.Count)
                        {
                            sb.Append(tab + "}\n");
                        }
                        else
                        {
                            sb.Append(tab + "},\n");
                        }
                    }
                }
            
                sb.Append("]\n");
                return sb.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取属性文本
        /// </summary>
        /// <param name="propArr"></param>
        /// <param name="sb"></param>
        private static string GetPropertyText(PropertyInfo[] propArr)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            Type propertyType = null;
            object defaultVal = null;
            foreach (var item in propArr)
            {
                sb.Append("\"" + item.Name + "\":");
                defaultVal = "";
                i++;
                propertyType = item.PropertyType;
                if (propertyType == typeof(DateTime))
                {
                    defaultVal = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    sb.Append("\"" + defaultVal.ToString() + "\" ");
                }
                else if (propertyType == typeof(DateTime?))
                {
                    defaultVal = "null";
                    sb.Append(defaultVal.ToString());
                }
                else if (propertyType == typeof(Int32) || propertyType == typeof(decimal))
                {
                    defaultVal = 0;
                    sb.Append(defaultVal.ToString());
                }
                else if (propertyType == typeof(Int32?) || propertyType == typeof(decimal?))
                {
                    defaultVal = "null";
                    sb.Append(defaultVal.ToString());
                }
                else if (propertyType == typeof(bool))
                {
                    defaultVal = false;
                    sb.Append(defaultVal.ToString());
                }
                else if (propertyType == typeof(bool?))
                {
                    defaultVal = "null";
                    sb.Append(defaultVal.ToString());
                }
                else
                {
                    sb.Append("\"" + defaultVal.ToString() + "\" ");
                }
                if (i == propArr.Length)
                {
                    sb.Append(" \n");
                }
                else
                {
                    sb.Append(", \n");
                }
            }
            return sb.ToString();
        }
    }
}
