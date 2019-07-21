using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateModel {
    public class ClientGenerate {
        public static string clientString = "using System;\n"
            + "using System.Collections.Generic;\n"
            + "using System.Linq;\n"
            + "using System.Text;\n"
            + "using Client.WarnMeasureSrv;\n"
            + "namespace Client {\n"
            + "    public class WarnMeasureClient : BaseClient {\n\n"
            + "        private static WarnMeasureSrv.WarnMeasureSrv wmsrv;\n"
            + "        public WarnMeasureClient() {\n"
            + "            wmsrv = new WarnMeasureSrv.WarnMeasureSrv();\n"
            + "            SetBaseWebReference(wmsrv);\n"
            + "        }\n\n"
            + "        private static WarnMeasureClient _WarnMeasureClient;\n\n"
            + "        public static WarnMeasureClient Current {\n"
            + "            get {\n"
            + "                if (_WarnMeasureClient == null) {\n"
            + "                    _WarnMeasureClient = new WarnMeasureClient();\n"
            + "                }\n"
            + "                return WarnMeasureClient._WarnMeasureClient;\n"
            + "            }\n"
            + "        }\n"
            + "        public bool AddWarnMeasure(WarnMeasure c) {\n"
            + "            return wmsrv.AddWarnMeasure(c);\n\n"
            + "        }\n\n"
            + "        public bool UpdateWarnMeasure(WarnMeasure c) {\n"
            + "            return wmsrv.UpdateWarnMeasure(c);\n"
            + "        }\n"
            + "        public bool DeleteWarnMeasure(WarnMeasure c) {\n"
            + "            return wmsrv.DeleteWarnMeasure(c);\n"
            + "        }\n\n"
            + "        public List<WarnMeasure> GetAllWarnMeasure() {\n"
            + "            return new List<WarnMeasure>(wmsrv.GetAllWarnMeasure());\n"
            + "        }\n\n"
            + "        public List<WarnMeasure> GetWarnMeasureByDeviceParam(string dpID) {\n"
            + "            return new List<WarnMeasure>(wmsrv.GetWarnMeasureByDeviceParam(dpID));\n"
            + "        }\n\n"
            + "    }\n"
            + "}";

        public static string GenerateClient(string tableName) {

            return clientString.Replace("WarnMeasure", tableName);
        }

    }
}
