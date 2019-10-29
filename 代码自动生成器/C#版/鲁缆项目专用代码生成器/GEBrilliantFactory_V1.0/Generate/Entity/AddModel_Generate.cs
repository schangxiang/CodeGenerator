using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCode_GEBrilliantFactory
{
    /// <summary>
    /// 生成新增参数实体类
    /// </summary>
    public class AddModel_Generate
    {
        public static string CreateAddModelLText(string addEntityParam,
            string ChinaComment, List<ColumnModel> columnNameList)
        {
            var str_dal = TextHelper.ReadText(@"Templete\Entity\AddModel模板.txt");

            str_dal = str_dal.Replace("$ChinaComment$", ChinaComment);//中文注释
            str_dal = CommonHelper.RepalceNameSpace(str_dal);
            str_dal = str_dal.Replace("$AddEntityParam$", addEntityParam);

            string attrString = "";

            List<ColumnModel> newColumnNameList = ListHelper.RemoveIdCreatorModifier(columnNameList);
            for (int i = 0; i < newColumnNameList.Count; ++i)
            {
                attrString += StructStrHelper.GenerateAttributeForQueryModel(newColumnNameList[i]);
            }
            str_dal = str_dal.Replace("$AddAttributes$", attrString);

            return str_dal;
        }
    }
}
