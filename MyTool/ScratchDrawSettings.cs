using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace MyTool
{
    /// <summary>
    /// 刮刮卡表
    /// </summary>
    public class ScratchDraw
    {
        public static string rwTable = "rwScratchDraw";
        public int nLuaDataType;
        public ScratchDrawBaseData BaseData;
        public ScratchDrawOption OptionData;
        public ScratchDrawAwardList AwardList;
        public ScratchDrawResetItemRandom RandomList;
        public ScratchDrawBroadCastMsg BroadCast;

        public string GetStr()
        {
            string str = "rwScratchDraw[" + nLuaDataType + "]={\r\n" +
                BaseData.GetBaseDataStr() +
                OptionData.GetOptionStr() +
                AwardList.GetAwardListStr() +
                RandomList.GetResetItemRandomStr() +
                BroadCast.GetBroadCastMsg() +
                "\r\n}";
            return str;
        }

    }
    
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
            string str = "\ttBaseData=" +
                "\r\n\t{\r\n" +
                "\t\t" + "nLuaDataType = " + nLuaDataType + ",\r\n" +
                "\t\t" + "nTaskId = " + nTaskId + ",\r\n" +
                "\t\t" + "nLimitCount = 999999" + ",\r\n" +
                "\t\t" + "nSystemHelp = " + nTaskId + ",\r\n" +
                "\t\t" + "nLogId = " + nLogId + ",\r\n" +
                "\t\t" + "nLogId_XSJ = " + nLogId_XSJ + ",\r\n" +
                "\t\t" + "sTitle = \"琉璃幻境\",\r\n" +
                "\t},\r\n";

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
        public ScratchDrawOptionAward OptionAward;
        public ScratchDrawResetAllDraw ResetAllDraw;
        public ScratchDrawResetItem ResetItem;

        /// <summary>
        /// 输出规则配置
        /// </summary>
        /// <returns></returns>
        public string GetOptionStr()
        {
            string str = "\ttOption=" +
                "\r\n\t{\r\n" +
                "\t\t" + "isOpen = 1,\r\n" +
                "\t\t" + "sStartTime = \"" + sStartTime + "\",\r\n" +
                "\t\t" + "sEndTime = \"" + sEndTime + "\",\r\n" +
                "\t\t" + "tServer = {0,1,2,3,10},\r\n" +
                "\t\t" + OptionCost.GetOptionCostStr() +
                "\t\t" + OptionAward.GetOptionAwardStr() +
                "\t\t" + ResetAllDraw.GetResetAllDrawStr() +
                "\t\t" + ResetItem.GetResetItemStr() +
                "\t},\r\n";

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

        public string GetOptionCostStr()
        {
            string str = "tCost={nItemType=" + nItemType + ",nItemNum=" + nItemNum + ",nItemMonpoly=1,},\r\n";

            return str;
        }
    }

    /// <summary>
    /// 不一致的奖励
    /// </summary>
    public class ScratchDrawOptionAward
    {
        public int nItemType;
        public int nItemNum;
        public int nItemMonpoly;

        public string GetOptionAwardStr()
        {
            string str = "tAward={nItemType=" + nItemType + ",nItemNum=" + nItemNum + ",nItemMonpoly=" + nItemMonpoly + ",},\r\n";

            return str;
        }
    }

    /// <summary>
    /// 重置奖池配置
    /// </summary>
    public class ScratchDrawResetAllDraw
    {
        public int nTaskId;
        public int nItemType;
        public int nItemNum;

        public string GetResetAllDrawStr()
        {
            string str = "tResetAllDraw={\r\n" +
                "\t\t\t" + "nTaskId = " + nTaskId + ",\r\n" +
                "\t\t\t" + "nFreeCount = 1,\r\n" +
                "\t\t\t" + "nLimitCount = 999999,\r\n" +
                "\t\t\t" + "nCurLimitCount = 999999,\r\n" +
                "\t\t\t" + "tCost={nItemType=" + nItemType + ",nItemNum=" + nItemNum + ",nItemMonpoly=1,},\r\n" +
                "\t\t},\r\n";

            return str;
        }
    }

    /// <summary>
    /// 重置物品配置
    /// </summary>
    public class ScratchDrawResetItem
    {
        public List<ScratchDrawResetItemValue> ResetItemValue = new List<ScratchDrawResetItemValue>();


        public string GetResetItemStr()
        {
            string str = "tResetItem={\r\n";
            string strvalues = "";

            for (int i = 0; i < ResetItemValue.Count; i++)
            {
                strvalues = strvalues +
                "\t\t\t" + "[" + (i+1) + "]" + "=" +
                ResetItemValue[i].GetResetItemValueStr();
            }

            str = str + strvalues + "\t\t},\r\n";
            return str;
        }

    }

    /// <summary>
    /// 重置物品数据
    /// </summary>
    public class ScratchDrawResetItemValue
    {
        public int nTaskId;
        public int nItemType;
        public int nItemNum;

        public string GetResetItemValueStr()
        {
            string str = "{\r\n" +
                "\t\t\t\t" + "nTaskId = " + nTaskId + ",\r\n" +
                "\t\t\t\t" + "nFreeCount = 0,\r\n" +
                "\t\t\t\t" + "nLimitCount = 999999,\r\n" +
                "\t\t\t\t" + "nCurLimitCount = 999999,\r\n" +
                "\t\t\t\t" + "tCost={nItemType=" + nItemType + ",nItemNum=" + nItemNum + ",nItemMonpoly=1,},\r\n" +
                "\t\t\t},\r\n";

            return str;
        }
    }

    /// <summary>
    /// 奖励表
    /// </summary>
    public class ScratchDrawAwardList
    {
        public List<ScratchDrawAwardListItem> AwardListItem = new List<ScratchDrawAwardListItem>();

        public List<string> AwardListItemName = new List<string> { "超高价值道具", "高价值道具", "普通价值道具", "填充物1", "填充物2" };


        public string GetAwardListStr()
        {
            string str = "\ttAwardList={\r\n";
            string strvalues = "";

            for (int i = 0; i < AwardListItem.Count; i++)
            {
                strvalues = strvalues +
                "\t\t" + "[" + (i + 1) + "]" + "=" +
                AwardListItem[i].GetAwardListValueStr();
            }

            str = str + strvalues + "\t},\r\n";
            return str;
        }
    }

    /// <summary>
    /// 奖励数据表
    /// </summary>
    public class ScratchDrawAwardListItem
    {

        public int Length;
        public List<ScratchDrawAwardListItemValue> AwardListItemValue = new List<ScratchDrawAwardListItemValue>();



        public string GetAwardListValueStr()
        {
            string str = "{\r\n";
            string strvalues = "";

            for (int i = 0; i < AwardListItemValue.Count; i++)
            {
                strvalues = strvalues + AwardListItemValue[i].GetAwardListItemValueStr();
            }

            str = str + strvalues + "\t\t},\r\n";

            return str;
        }
    }

    /// <summary>
    /// 奖励数据
    /// </summary>
    public class ScratchDrawAwardListItemValue
    {

        public int nChance;
        public int nItemType;
        public int nItemNum;
        public int nItemMonpoly;
        public int nIndex;
        public int nAwardLev;
        public int nServerLimit;
        public ScratchDrawAwardListNotice tNotice;


        public string GetAwardListItemValueStr()
        {
            string ServerStr = "nServerLimit = " + nServerLimit + ",";
            if (nServerLimit == 0)
            {
                ServerStr = "";
            }
            string str = "\t\t\t{" +
                "nChance=" + nChance + "," +
                "nItemType=" + nItemType + "," +
                "nItemNum=" + nItemNum + "," +
                "nItemMonpoly=" + nItemMonpoly + "," +
                "nIndex=" + nIndex + "," +
                tNotice.GetNoticeStr() +
                "nAwardLev=" + nAwardLev + "," +
                ServerStr +
                "},\r\n";

            return str;
        }
    }

    /// <summary>
    /// 奖励广播方式
    /// </summary>
    public class ScratchDrawAwardListNotice
    {
        //=1 全服 =2 地图 =3 玩家
        public List<int> Type = new List<int>();

        public string GetNoticeStr()
        {
            string str = "tNoctice={";
            string strvalues = "";

            if (!Type.Contains(3))
            {
                Type.Add(3);
            }

            for (int i = 0; i < Type.Count; i++)
            {
                strvalues = strvalues + Type[i] + ",";
            }

            str = str + strvalues + "},";

            return str;
        }

    }

    /// <summary>
    /// 刮奖概率
    /// </summary>
    public class ScratchDrawResetItemRandom
    {
        public List<ScratchDrawResetItemValueRandom> ScratchDrawResetItemValueRandom = new List<ScratchDrawResetItemValueRandom>();

        public List<string> RandomListItemName = new List<string> { "刮中奖励1", "刮中奖励2", "刮中奖励3" };


        public string GetResetItemRandomStr()
        {
            string str = "\ttScratchList={\r\n";
            string strvalues = "";

            for (int i = 0; i < ScratchDrawResetItemValueRandom.Count; i++)
            {
                strvalues = strvalues +
                "\t\t" + "[" + (i + 1) + "]" + "=" +
                ScratchDrawResetItemValueRandom[i].GetRandomList();
            }

            str = str + strvalues + "\t},\r\n";
            return str;
        }
    }

    /// <summary>
    /// 刮奖概率数据
    /// </summary>
    public class ScratchDrawResetItemValueRandom
    {
        public List<int> Chance = new List<int>();

        public string GetRandomList()
        {
            string str = "{\r\n";
            string strvalues = "";

            for (int i = 0 ;i < Chance.Count; i++)
            {
                strvalues = strvalues + "\t\t\t[" + (i + 1) + "]=" + Chance[i] + ",\r\n";
            }

            str = str + strvalues + "\t\t},\r\n";

            return str;


        }
    }

    /// <summary>
    /// 广播内容
    /// </summary>
    public class ScratchDrawBroadCastMsg
    {
        public List<string> BroadCastMsg = new List<string>();
        public string DefalutMsg = "%s获得了%s";

        public string GetBroadCastMsg()
        {
            string str = "\ttTips={\r\n";
            string strvalues = "";

            for (int i = 0; i < BroadCastMsg.Count; i++)
            {
                strvalues = strvalues + BroadCastMsg[i];
            }

            str = str + strvalues + "\t},\r\n";

            return str;
        }
    }


}
