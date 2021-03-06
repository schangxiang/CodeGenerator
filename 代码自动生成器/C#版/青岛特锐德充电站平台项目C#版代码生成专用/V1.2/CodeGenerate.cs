﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel {
    public class CodeGenerate {
        
        //头部信息
        private static readonly string strUsing = @"//------------------------------------------------------------------------------\n"
                        + "// <auto-generated>\n"
                        + "//     此代码由工具生成。  \n"
                        + "//     技术支持：罗青(www.cnblogs.com/tsingroo)\n"
                        + "//     对此文件的更改可能会导致不正确的行为\n"
                        + "// </auto-generated>\n"
                        + "//------------------------------------------------------------------------------\n"
                        + "using System;\n"
                        + "using System.Data;\n"
                        + "using System.Data.Common;\n"
                        + "using Liger.Common;\n"
                        + "using Liger.Data;\n"
                        + "namespace Liger.Model\n"
                        + "{\n";


        private static string CreateClassHeader(string _tableName) {
            string strClassHeader = "[Serializable]\n"
                                + "public class " + _tableName + " : Entity \n"
                                + "{ \n"
                                + "	 public " + _tableName + "() \n"
                                + "		: base(\"" + _tableName + "\") \n"
                                + "	{ \n"
                                + "		\n"
                                + "	}\n";

            return strClassHeader;
        }

        private static string CreateAttribute(List<string> _strList) {
            StringBuilder sbAttr = new StringBuilder();
            string strAttr = "		/// <summary>\n"
                            + "		/// \n"
                            + "		/// </summary>\n"
                            + "	public string LoginName\n"
                            + "	{\n"
                            + "		get { return _LoginName; }\n"
                            + "		set\n"
                            + "		{\n"
                            + "			this.OnPropertyValueChange(_.LoginName, _LoginName, value);\n"
                            + "			this._LoginName = value;\n"
                            + "		}\n"
                            + "	}\n";
            int ilistCount = _strList.Count;
            //sbAttr.Append(strAttr);
            for (int i = 0; i < ilistCount; i++) {
                sbAttr.Append(strAttr.Replace("LoginName", _strList[i]));
            }

            return sbAttr.ToString();
        }


        private static string CreateRegionModel(List<string> _strList) {
            StringBuilder sbRegionModel = new StringBuilder("		#region Model\n");
            int ilistCount = _strList.Count;
            for (int i = 0; i < ilistCount; i++) {
                sbRegionModel.Append("		private string _" + _strList[i] + ";\n");
            }
            sbRegionModel.Append(CreateAttribute(_strList));
            sbRegionModel.Append("		#endregion\n\n");

            return sbRegionModel.ToString();

        }


        private static string CreateRegionMethod(List<string> _strList) {
            StringBuilder sbRegionMethod = new StringBuilder("");
            string strMethdoHeader = "		#region Method\n"
                                    + "		public override Field GetIdentityField()\n"
                                    + "		{\n"
                                    + "			return _."+_strList[0]+";\n"
                                    + "		}\n\n"
                                    + "		public override Field[] GetPrimaryKeyFields()\n"
                                    + "		{\n"
                                    + "			return new Field[] {\n"
                                    + "				_." + _strList[0] + " \n			};\n"
                                    + "		}\n";
            strMethdoHeader.Replace("UserID", _strList[0]);
            sbRegionMethod.Append(strMethdoHeader);
            string strGetFileds = "			public override Field[] GetFields()\n"
                                + "			{\n"
                                + "				return new Field[] {\n";
            sbRegionMethod.Append(strGetFileds);
            int ilistCount = _strList.Count;
            for (int i = 0; i < ilistCount; i++) {
                sbRegionMethod.Append("_." + _strList[i] + ",\n");
            }
            sbRegionMethod.Remove(sbRegionMethod.Length-1, 1);
            sbRegionMethod.Append("			};\n		}\n");
            string strGetValues = "			public override object[] GetValues()\n"
                                + "			{\n"
                                + "				return new object[] {\n";
            sbRegionMethod.Append(strGetValues);
            for (int i = 0; i < ilistCount; i++) {
                sbRegionMethod.Append("			_" + _strList[i] + ",\n");
            }
            sbRegionMethod.Remove(sbRegionMethod.Length-1, 1);
            sbRegionMethod.Append("			};\n		}\n");
            string strSetValue = "        public override void SetValue(string fieldName, object value)\n"
                                + "		{\n"
                                + "			switch (fieldName)\n"
                                + "			{\n";
            sbRegionMethod.Append(strSetValue);
            sbRegionMethod.Append("			case \"").Append(_strList[0]).Append("\":\n"); ;
            sbRegionMethod.Append("				this._").Append(_strList[0]).Append(" = DataHelper.ConvertValue<string>(value);\n");
            sbRegionMethod.Append("				break;");
            for (int i = 1; i < ilistCount; i++) {
                sbRegionMethod.Append("			case \"").Append(_strList[i]).Append("\":\n"); ;
                sbRegionMethod.Append("				this._").Append(_strList[i]).Append(" = DataHelper.ConvertValue<string>(value);\n");
                sbRegionMethod.Append("				break;\n");
            }
            sbRegionMethod.Append("			}\n		}\n");
            string strGetValue = "		public override object GetValue(string fieldName)\n"
                                + "		{\n"
                                + "			switch (fieldName)\n"
                                + "			{\n";
            sbRegionMethod.Append(strGetValue);
            for (int i = 0; i < ilistCount; i++) {
                sbRegionMethod.Append("				case \"").Append(_strList[i]).Append("\" : \n");
                sbRegionMethod.Append("					return this._").Append(_strList[i]).Append(";\n");
            }
            sbRegionMethod.Append("				default :\n				return null;\n");
            sbRegionMethod.Append("			}\n 			}\n");
            sbRegionMethod.Append("		#endregion\n");

            return sbRegionMethod.ToString();
        }


        private static string CreateRegionClass(string _tableName, List<string> _strList) {
	        StringBuilder sbRegionClass = new StringBuilder("");
	        sbRegionClass.Append("		#region _").Append(_tableName).Append("\n");
	        sbRegionClass.Append("		public class _ {\n");
	        sbRegionClass.Append("			public readonly static Field ALL ").Append("= new Field(\"*\",\""+_tableName+"\");\n");
	
	        int ilistCount = _strList.Count;
	        for(int i = 0; i < ilistCount; i++) {
		        sbRegionClass.Append("			public readonly static Field ").Append(_strList[i]).Append(" = new Field(\""+_strList[i]+"\",\""+_tableName+"\",\""+_strList[i]+"\");\n");
	        }
	
	        sbRegionClass.Append("}\n").Append("	#endregion\n");
	
	        return sbRegionClass.ToString();
        }


        public static string OutputCode(string _tableName, List<string> _strList) {
            StringBuilder sbCode = new StringBuilder("");
            sbCode.Append(strUsing).Append(CreateClassHeader(_tableName));
            sbCode.Append(CreateRegionModel(_strList));
            sbCode.Append(CreateRegionMethod(_strList));
            sbCode.Append(CreateRegionClass(_tableName,_strList));
            sbCode.Append(" }\n}\n");


            return sbCode.ToString();
        }


    }
}
