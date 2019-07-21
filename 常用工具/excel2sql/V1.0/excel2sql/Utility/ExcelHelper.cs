using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Web;
using NPOI.HPSF;
using System.Net.Http;
using NPOI.XSSF.UserModel;

namespace Excel2SQL
{
    /// <summary>
    /// Excel操作类
    /// </summary>
    public class ExcelHelper
    {

        /// <summary>
        /// 从Excel取数据并记录到List集合里
        /// </summary>
        /// <param name="cellHeard">单元头的值和名称：{ { "UserName", "姓名" }, { "Age", "年龄" } };</param>
        /// <param name="filePath">保存文件绝对路径</param>
        /// <param name="errorMsg">错误信息</param>
        /// <returns>转换后的List对象集合</returns>
        public static List<T> ExcelToEntityListForCreateTable<T>(Dictionary<string, string> cellHeard, string filePath,
            out string tableDesc, out string tableName,
            out StringBuilder errorMsg) where T : new()
        {
            List<T> enlist = new List<T>();
            errorMsg = new StringBuilder();
            try
            {
                enlist = Excel2003ToEntityListForCreateTable<T>(cellHeard, filePath, out tableDesc, out tableName, out errorMsg);
                return enlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从Excel取数据并记录到List集合里
        /// </summary>
        /// <param name="cellHeard">单元头的值和名称：{ { "UserName", "姓名" }, { "Age", "年龄" } };</param>
        /// <param name="filePath">保存文件绝对路径</param>
        /// <param name="errorMsg">错误信息</param>
        /// <returns>转换后的List对象集合</returns>
        public static List<T> ExcelToEntityListForInitCodeItems<T>(Dictionary<string, string> cellHeard, string filePath,
            out StringBuilder errorMsg) where T : new()
        {
            List<T> enlist = new List<T>();
            errorMsg = new StringBuilder();
            try
            {
                enlist = Excel2003ToEntityListForInitCodeItems<T>(cellHeard, filePath, out errorMsg);
                return enlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 从Excel2003取数据并记录到List集合里
        /// </summary>
        /// <param name="cellHeard">单元头的Key和Value：{ { "UserName", "姓名" }, { "Age", "年龄" } };</param>
        /// <param name="filePath">保存文件绝对路径</param>
        /// <param name="errorMsg">错误信息</param>
        /// <returns>转换好的List对象集合</returns>
        private static List<T> Excel2003ToEntityListForCreateTable<T>(Dictionary<string, string> cellHeard,
            string filePath, out string tableDesc, out string tableName, out StringBuilder errorMsg) where T : new()
        {
            errorMsg = new StringBuilder(); // 错误信息,Excel转换到实体对象时，会有格式的错误信息
            List<T> enlist = new List<T>(); // 转换后的集合
            List<string> keys = cellHeard.Keys.ToList(); // 要赋值的实体对象属性名称
            tableDesc = "";
            tableName = "";
            try
            {
                IWorkbook workbook = GetWorkBook(filePath);
                if (workbook == null)
                {
                    errorMsg.Append("没有找到IWorkbook");
                    return null;
                }

                ISheet sheet = (ISheet)workbook.GetSheetAt(0); // 获取此文件第一个Sheet页
                ICell cell = sheet.GetRow(0).GetCell(0);
                tableDesc = cell.StringCellValue;
                cell = sheet.GetRow(1).GetCell(0);
                tableName = cell.StringCellValue;
                for (int i = 3; i <= sheet.LastRowNum; i++) // 从3开始，第0行为表汉字名,第1行是表名，第2行是单元头
                {
                    // 1.判断当前行是否空行，若空行就不在进行读取下一行操作，结束Excel读取操作
                    if (sheet.GetRow(i) == null)
                    {
                        break;
                    }

                    T en = new T();
                    string errStr = ""; // 当前行转换时，是否有错误信息，格式为：第1行数据转换异常：XXX列；
                    for (int j = 0; j < keys.Count; j++)
                    {
                        // 2.若属性头的名称包含'.',就表示是子类里的属性，那么就要遍历子类，eg：UserEn.TrueName
                        if (keys[j].IndexOf(".") >= 0)
                        {
                            // 2.1解析子类属性
                            string[] properotyArray = keys[j].Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                            string subClassName = properotyArray[0]; // '.'前面的为子类的名称
                            string subClassProperotyName = properotyArray[1]; // '.'后面的为子类的属性名称
                            System.Reflection.PropertyInfo subClassInfo = en.GetType().GetProperty(subClassName); // 获取子类的类型
                            if (subClassInfo != null)
                            {
                                // 2.1.1 获取子类的实例
                                var subClassEn = en.GetType().GetProperty(subClassName).GetValue(en, null);
                                // 2.1.2 根据属性名称获取子类里的属性信息
                                System.Reflection.PropertyInfo properotyInfo = subClassInfo.PropertyType.GetProperty(subClassProperotyName);
                                if (properotyInfo != null)
                                {
                                    try
                                    {
                                        // Excel单元格的值转换为对象属性的值，若类型不对，记录出错信息
                                        properotyInfo.SetValue(subClassEn, GetExcelCellToProperty(properotyInfo.PropertyType, sheet.GetRow(i).GetCell(j)), null);
                                    }
                                    catch (Exception e)
                                    {
                                        if (errStr.Length == 0)
                                        {
                                            errStr = "第" + i + "行数据转换异常：";
                                        }
                                        errStr += cellHeard[keys[j]] + "列；";
                                    }

                                }
                            }
                        }
                        else
                        {
                            // 3.给指定的属性赋值
                            System.Reflection.PropertyInfo properotyInfo = en.GetType().GetProperty(keys[j]);
                            if (properotyInfo != null)
                            {
                                try
                                {
                                    // Excel单元格的值转换为对象属性的值，若类型不对，记录出错信息
                                    properotyInfo.SetValue(en, GetExcelCellToProperty(properotyInfo.PropertyType, sheet.GetRow(i).GetCell(j)), null);
                                }
                                catch (Exception e)
                                {
                                    if (errStr.Length == 0)
                                    {
                                        errStr = "第" + i + "行数据转换异常：";
                                    }
                                    errStr += cellHeard[keys[j]] + "列；";
                                }
                            }
                        }
                    }
                    // 若有错误信息，就添加到错误信息里
                    if (errStr.Length > 0)
                    {
                        errorMsg.AppendLine(errStr);
                    }
                    enlist.Add(en);
                }

                return enlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 从Excel2003取数据并记录到List集合里
        /// </summary>
        /// <param name="cellHeard">单元头的Key和Value：{ { "UserName", "姓名" }, { "Age", "年龄" } };</param>
        /// <param name="filePath">保存文件绝对路径</param>
        /// <param name="errorMsg">错误信息</param>
        /// <returns>转换好的List对象集合</returns>
        private static List<T> Excel2003ToEntityListForInitCodeItems<T>(Dictionary<string, string> cellHeard,
            string filePath, out StringBuilder errorMsg) where T : new()
        {
            errorMsg = new StringBuilder(); // 错误信息,Excel转换到实体对象时，会有格式的错误信息
            List<T> enlist = new List<T>(); // 转换后的集合
            List<string> keys = cellHeard.Keys.ToList(); // 要赋值的实体对象属性名称
            try
            {
                IWorkbook workbook = GetWorkBook(filePath);
                if (workbook == null)
                {
                    errorMsg.Append("没有找到IWorkbook");
                    return null;
                }
                ISheet sheet = (ISheet)workbook.GetSheetAt(0); // 获取此文件第一个Sheet页
                for (int i = 1; i <= sheet.LastRowNum; i++) // 从1开始，第0行是单元头
                {
                    // 1.判断当前行是否空行，若空行就不在进行读取下一行操作，结束Excel读取操作
                    if (sheet.GetRow(i) == null)
                    {
                        break;
                    }

                    T en = new T();
                    string errStr = ""; // 当前行转换时，是否有错误信息，格式为：第1行数据转换异常：XXX列；
                    for (int j = 0; j < keys.Count; j++)
                    {
                        // 2.若属性头的名称包含'.',就表示是子类里的属性，那么就要遍历子类，eg：UserEn.TrueName
                        if (keys[j].IndexOf(".") >= 0)
                        {
                            // 2.1解析子类属性
                            string[] properotyArray = keys[j].Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                            string subClassName = properotyArray[0]; // '.'前面的为子类的名称
                            string subClassProperotyName = properotyArray[1]; // '.'后面的为子类的属性名称
                            System.Reflection.PropertyInfo subClassInfo = en.GetType().GetProperty(subClassName); // 获取子类的类型
                            if (subClassInfo != null)
                            {
                                // 2.1.1 获取子类的实例
                                var subClassEn = en.GetType().GetProperty(subClassName).GetValue(en, null);
                                // 2.1.2 根据属性名称获取子类里的属性信息
                                System.Reflection.PropertyInfo properotyInfo = subClassInfo.PropertyType.GetProperty(subClassProperotyName);
                                if (properotyInfo != null)
                                {
                                    try
                                    {
                                        // Excel单元格的值转换为对象属性的值，若类型不对，记录出错信息
                                        properotyInfo.SetValue(subClassEn, GetExcelCellToProperty(properotyInfo.PropertyType, sheet.GetRow(i).GetCell(j)), null);
                                    }
                                    catch (Exception e)
                                    {
                                        if (errStr.Length == 0)
                                        {
                                            errStr = "第" + i + "行数据转换异常：";
                                        }
                                        errStr += cellHeard[keys[j]] + "列；";
                                    }

                                }
                            }
                        }
                        else
                        {
                            // 3.给指定的属性赋值
                            System.Reflection.PropertyInfo properotyInfo = en.GetType().GetProperty(keys[j]);
                            if (properotyInfo != null)
                            {
                                try
                                {
                                    // Excel单元格的值转换为对象属性的值，若类型不对，记录出错信息
                                    properotyInfo.SetValue(en, GetExcelCellToProperty(properotyInfo.PropertyType, sheet.GetRow(i).GetCell(j)), null);
                                }
                                catch (Exception e)
                                {
                                    if (errStr.Length == 0)
                                    {
                                        errStr = "第" + i + "行数据转换异常：";
                                    }
                                    errStr += cellHeard[keys[j]] + "列；";
                                }
                            }
                        }
                    }
                    // 若有错误信息，就添加到错误信息里
                    if (errStr.Length > 0)
                    {
                        errorMsg.AppendLine(errStr);
                    }
                    enlist.Add(en);
                }
                return enlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 从Excel获取值传递到对象的属性里
        /// </summary>
        /// <param name="distanceType">目标对象类型</param>
        /// <param name="sourceCell">对象属性的值</param>
        private static Object GetExcelCellToProperty(Type distanceType, ICell sourceCell)
        {
            object rs = distanceType.IsValueType ? Activator.CreateInstance(distanceType) : null;

            // 1.判断传递的单元格是否为空
            if (sourceCell == null || string.IsNullOrEmpty(sourceCell.ToString()))
            {
                return rs;
            }

            // 2.Excel文本和数字单元格转换，在Excel里文本和数字是不能进行转换，所以这里预先存值
            object sourceValue = null;
            switch (sourceCell.CellType)
            {
                case CellType.Blank:
                    break;

                case CellType.Boolean:
                    break;

                case CellType.Error:
                    break;

                case CellType.Formula:
                    break;

                case CellType.Numeric:
                    sourceValue = sourceCell.NumericCellValue;
                    break;

                case CellType.String:
                    sourceValue = sourceCell.StringCellValue;
                    break;

                case CellType.Unknown:
                    break;

                default:
                    break;
            }

            string valueDataType = distanceType.Name;

            // 在这里进行特定类型的处理
            switch (valueDataType.ToLower()) // 以防出错，全部小写
            {
                case "string":
                    rs = sourceValue.ToString().Trim();//移除空格
                    break;
                case "int":
                case "int16":
                case "int32":
                    rs = (int)Convert.ChangeType(sourceCell.NumericCellValue.ToString(), distanceType);
                    break;
                case "float":
                case "single":
                    rs = (float)Convert.ChangeType(sourceCell.NumericCellValue.ToString(), distanceType);
                    break;
                case "datetime":
                    rs = sourceCell.DateCellValue;
                    break;
                case "guid":
                    rs = (Guid)Convert.ChangeType(sourceCell.NumericCellValue.ToString(), distanceType);
                    return rs;
            }
            return rs;
        }

        /// <summary>
        /// 获取IWorkbook
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static IWorkbook GetWorkBook(string filePath)
        {
            IWorkbook workbook = null;
            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                //获取后缀名
                string extension = filePath.Substring(filePath.LastIndexOf(".")).ToString().ToLower();
                //判断是否是excel文件
                if (extension == ".xlsx" || extension == ".xls")
                {
                    //判断excel的版本
                    if (extension == ".xlsx")
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                }
            }
            return workbook;
        }



        #region 测试用例汇总


        public static List<T> ExcelToEntityListForCSYLHZ<T>(Dictionary<string, string> cellHeard, string filePath,
           out StringBuilder errorMsg) where T : new()
        {
            List<T> enlist = new List<T>();
            errorMsg = new StringBuilder();
            try
            {
                enlist = Excel2003ToEntityListForCSYLHZ<T>(cellHeard, filePath, out errorMsg);
                return enlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<T> Excel2003ToEntityListForCSYLHZ<T>(Dictionary<string, string> cellHeard,
   string filePath, out StringBuilder errorMsg) where T : new()
        {
            errorMsg = new StringBuilder(); // 错误信息,Excel转换到实体对象时，会有格式的错误信息
            List<T> enlist = new List<T>(); // 转换后的集合
            List<string> keys = cellHeard.Keys.ToList(); // 要赋值的实体对象属性名称
            try
            {
                IWorkbook workbook = GetWorkBook(filePath);
                if (workbook == null)
                {
                    errorMsg.Append("没有找到IWorkbook");
                    return null;
                }
                int sheets = workbook.NumberOfSheets;
                for (int pp = 0; pp < sheets-1; pp++)
                {
                    ISheet sheet = (ISheet)workbook.GetSheetAt(pp); // 获取此文件第一个Sheet页
                    for (int i = 6; i <= sheet.LastRowNum; i++) // 从1开始，第0行是单元头
                    {
                        // 1.判断当前行是否空行，若空行就不在进行读取下一行操作，结束Excel读取操作
                        if (sheet.GetRow(i) == null)
                        {
                            break;
                        }

                        T en = new T();
                        string errStr = ""; // 当前行转换时，是否有错误信息，格式为：第1行数据转换异常：XXX列；
                        for (int j = 0; j < keys.Count; j++)
                        {
                            // 2.若属性头的名称包含'.',就表示是子类里的属性，那么就要遍历子类，eg：UserEn.TrueName
                            if (keys[j].IndexOf(".") >= 0)
                            {
                                // 2.1解析子类属性
                                string[] properotyArray = keys[j].Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                                string subClassName = properotyArray[0]; // '.'前面的为子类的名称
                                string subClassProperotyName = properotyArray[1]; // '.'后面的为子类的属性名称
                                System.Reflection.PropertyInfo subClassInfo = en.GetType().GetProperty(subClassName); // 获取子类的类型
                                if (subClassInfo != null)
                                {
                                    // 2.1.1 获取子类的实例
                                    var subClassEn = en.GetType().GetProperty(subClassName).GetValue(en, null);
                                    // 2.1.2 根据属性名称获取子类里的属性信息
                                    System.Reflection.PropertyInfo properotyInfo = subClassInfo.PropertyType.GetProperty(subClassProperotyName);
                                    if (properotyInfo != null)
                                    {
                                        try
                                        {
                                            // Excel单元格的值转换为对象属性的值，若类型不对，记录出错信息
                                            properotyInfo.SetValue(subClassEn, GetExcelCellToProperty(properotyInfo.PropertyType, sheet.GetRow(i).GetCell(j)), null);
                                        }
                                        catch (Exception e)
                                        {
                                            if (errStr.Length == 0)
                                            {
                                                errStr = "第" + i + "行数据转换异常：";
                                            }
                                            errStr += cellHeard[keys[j]] + "列；";
                                        }

                                    }
                                }
                            }
                            else
                            {
                                // 3.给指定的属性赋值
                                System.Reflection.PropertyInfo properotyInfo = en.GetType().GetProperty(keys[j]);
                                if (properotyInfo != null)
                                {
                                    try
                                    {
                                        // Excel单元格的值转换为对象属性的值，若类型不对，记录出错信息
                                        properotyInfo.SetValue(en, GetExcelCellToProperty(properotyInfo.PropertyType, sheet.GetRow(i).GetCell(j)), null);
                                    }
                                    catch (Exception e)
                                    {
                                        if (errStr.Length == 0)
                                        {
                                            errStr = "第" + i + "行数据转换异常：";
                                        }
                                        errStr += cellHeard[keys[j]] + "列；";
                                    }
                                }
                            }
                        }
                        // 若有错误信息，就添加到错误信息里
                        if (errStr.Length > 0)
                        {
                            errorMsg.AppendLine(errStr);
                        }
                        enlist.Add(en);
                    }
                }
                
                return enlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
    }
}