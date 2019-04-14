

namespace MyTool
{
    /// <summary>
    /// 基础配置表
    /// </summary>
    public class ScratchDrawBaseData
    {
        public int nLuaDataType;
        public int nTaskId;
        public int nLogId;
        public int nLogId_XSJ;

        /// <summary>
        /// 输出基础配置
        /// </summary>
        /// <returns></returns>
        public string GetBaseDataStr()
        {
            string str = "tBaseData=" +
                "\r\n{\r\n" +
                "\t" + "nLuaDataType = " + nLuaDataType + ",\r\n" +
                "\t" + "nTaskId = " + nTaskId + ",\r\n" +
                "\t" + "nLimitCount = 999999" + ",\r\n" +
                "\t" + "nLogId = " + nLogId + ",\r\n" +
                "\t" + "nLogId_XSJ = " + nLogId_XSJ + ",\r\n" +
                "\t" + "sTitle = \"琉璃幻境\",\r\n" +
                "},\r\n";

            return str;
        }
    }

    /// <summary>
    /// 规则配置表
    /// </summary>
    public class ScratchDrawOption
    {
        public string sStartTime;
        public string sEndTime;
        public ScratchDrawOptionCost OptionCost;

        /// <summary>
        /// 输出规则配置
        /// </summary>
        /// <returns></returns>
        public string GetOptionStr()
        {
            string str = "tOption=" +
                "\r\n{\r\n" +
                "\t" + "isOpen = 1,\r\n" +
                "\t" + "sStartTime = " + sStartTime + ",\r\n" +
                "\t" + "sEndTime = " + sEndTime + ",\r\n" +
                "\t" + "tServer = {0,1,2,3,10},\r\n" +
                "\t" + OptionCost.GetOptionCostStr() +
                "},\r\n";

            return str;
        }
    }

    /// <summary>
    /// 消耗的筹码币
    /// </summary>
    public class ScratchDrawOptionCost
    {
        public int nItemType;
        public int nItemNum;
        public int nItemMonpoly;

        public string GetOptionCostStr()
        {
            string str = "tCost=" +
                "\r\n\t{\r\n" +
                "\t\t" + "nItemType = " + nItemType + ",\r\n" +
                "\t\t" + "nItemNum = " + nItemNum + ",\r\n" +
                "\t\t" + "nItemMonpoly = " + nItemMonpoly + ",\r\n" +
                "\t},\r\n";

            return str;
        }
    }
}
