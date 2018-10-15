using System.ComponentModel;
using System.Drawing.Design;

namespace MyTool
{
    //十连抽的属性类
    public class TenRollSettings
    {
        private int _LuaType = 0;
        private int _RankType = 0;
        private int _VerType = 0;
        private int _TaskId = 0;
        private int _LimitCount = 9999;
        private int _Ver = 1;
        private int _DrawCount = 10;
        private string _RankName = "幸运榜";
        private string _Titile = "十连抽";
        private int _LogId = 0;
        private int _LogId_XSJ = 0;
        private LeastSettings _LeastSettings = new LeastSettings();
        private LstAwdSettings _LstAwdSettings = new LstAwdSettings();
        private TenCount _TenCount = new TenCount();
        private Option _Option = new Option();
        private string _SelectableTable = "";
        private AwardListCollection _ALC = new AwardListCollection();
        
        [Category("\t基础数据配置表"),
            DisplayName("奖池类型"),
            Description("【必填】奖池对应的cq_lua_data 表的type（存储物品产出量）。"),]
        public int nType
        {
            get { return _LuaType; }
            set { _LuaType = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("幸运榜类型"),
            Description("【必填】十连抽幸运榜对应的cq_lua_data表的type。"),]
        public int nRankType
        {
            get { return _RankType; }
            set { _RankType = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("版本号类型"),
            Description("【必填】版本号对应的cq_lua_data表的type。"),]
        public int nVerType
        {
            get { return _VerType; }
            set { _VerType = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("掩码id"),
            Description("【必填】本次活动抽奖的掩码。"),]
        public int nTaskId
        {
            get { return _TaskId; }
            set { _TaskId = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("每日次数限制"),
            Description("【必填】每日次数限制。"),]
        public int nLimitCount
        {
            get { return _LimitCount; }
            set { _LimitCount = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("版本号"),
            Description("【必填】版本号。（每一次重新启用需要配置和之前不同的版本号，否则第二次启用掩码不会被重置）。"),]
        public int nVer
        {
            get { return _Ver; }
            set { _Ver = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("几连抽配置"),
            Description("【必填】几连抽配置（目前客户端不支持，请配置10）默认10。"),]
        public int nDrawCount
        {
            get { return _DrawCount; }
            set { _DrawCount = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("幸运榜名称"),
            Description("【必填】右侧幸运榜显示的名称。"),]
        public string sRankName
        {
            get { return _RankName; }
            set { _RankName = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("活动标题"),
            Description("【必填】显示在界面上方的活动标题。"),]
        public string sTitle
        {
            get { return _Titile; }
            set { _Titile = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("官方logid"),
            Description("【必填】官方logid。"),]
        public int nLogId
        {
            get { return _LogId; }
            set { _LogId = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("西山居logid"),
            Description("【必填】西山居logid。"),]
        public int nLogId_XSJ
        {
            get { return _LogId_XSJ; }
            set { _LogId_XSJ = value; }
        }

        [Category("抽奖规则表"),
            TypeConverter(typeof(OptionConvert)),
            DisplayName("规则表"),
            Description("【必填】控制作用的规则限制"),]
        public Option tOption
        {
            get { return _Option; }
            set { _Option = value; }
        }

        [Category("抽奖规则表"),
            Editor(typeof(ListBoxUCConverter), typeof(UITypeEditor)),
            DisplayName("可选配置"),
            Description("【选填】可选配置"),]
        public string SelectableTable
        {
            get { return _SelectableTable; }
            set { _SelectableTable = value; }
        }

        [Category("抽奖规则表"),
            TypeConverter(typeof(OptionConvert)),
            DisplayName("阶段性保底抽奖"),
            Browsable(false),
            Description("【选填】阶段性保底抽奖")]
        public LeastSettings tLeast
        {
            get { return _LeastSettings; }
            set { _LeastSettings = value; }
        }
        [Category("抽奖规则表"),
            TypeConverter(typeof(OptionConvert)),
            DisplayName("循环类保底抽奖"),
            Browsable(false),
            Description("【选填】循环类保底抽奖"),]
        public LstAwdSettings tLstAwd
        {
            get { return _LstAwdSettings; }
            set { _LstAwdSettings = value; }
        }
        [Category("抽奖规则表"),
            TypeConverter(typeof(OptionConvert)),
            DisplayName("十连抽追加抽奖次数"),
            Browsable(false),
            Description("【选填】十连抽追加抽奖次数"),]
        public TenCount tTenCount
        {
            get { return _TenCount; }
            set { _TenCount = value; }
        }
        [Category("抽奖规则表"),
            Editor(typeof(MyCollectionEditor),typeof(UITypeEditor)),
            TypeConverter(typeof(OptionConvert)),
            DisplayName("奖励物品表"),
            Description("【必填】奖励物品"),]
        public AwardListCollection tAwardList
        {
            get { return _ALC; }
            set { _ALC = value; }
        }

    }

    //物品类
    public class AwardList
    {
        private string _Name = "";
        private object _Value = null;
        private AwardListItem ali = new AwardListItem();

        [Browsable(false)]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        [Browsable(false)]
        public object Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        [TypeConverter(typeof(OptionConvert))]
        public AwardListItem ALI
        {
            get { return ali; }
            set { ali = value; }
        }
    }

    //奖励物品类
    public class AwardListItem
    {
        private int _ItemId = 0;
        private int _Count = 1;
        private int _Chance = 0;
        private int _Bind = 0;
        private int _IsTenDraw = 0;
        private string _NoticeType = "";
        private string _WndNoticeType = "1";
        private string _AwardLev = "";
        private string _TimePhase = "";
        private string _ServerLimit = "";
        private string _DayLimit = "";
        private string _UStaskId = "";
        private string _USLimit = "";
        private string _USData = "";
        private string _UDtaskId = "";
        private string _UDLimit = "";
        private string _UDData = "";

        [DisplayName("物品id"),
            Description("【必填】物品id"),]
        public int ItemId
        {
            get { return _ItemId; }
            set { _ItemId = value; }
        }
        [DisplayName("数量"),
            Description("【必填】数量（不可叠加的物品请配1, 可叠加的物品不要超过叠加物品上限。装备，请注意写0.否则耐久为0）"),]
        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }
        [DisplayName("是否绑定"),
            Description("【必填】 =1：绑定 =0：非绑"),]
        public int IsBind
        {
            get { return _Bind; }
            set { _Bind = value; }
        }
        [DisplayName("抽奖概率"),
            Description("【必填】抽奖概率"),]
        public int Chance
        {
            get { return _Chance; }
            set { _Chance = value; }
        }
        [DisplayName("是否十连抽才能抽中"),
            Description("【选填】默认0：都能抽中， 1：只有10连抽能抽中。"),]
        public int IsTenDraw
        {
            get { return _IsTenDraw; }
            set { _IsTenDraw = value; }
        }
        [Editor(typeof(ListBoxUCConverter), typeof(UITypeEditor)),
            DisplayName("公告方式"),
            Description("【选填】 1：全服公告，2：全地图公告 3：玩家提示 （和nAwardLev属于同一组。此处有配置，对应的文字描素映射nAwardLev 必填。）"),]
        public string NoticeType
        {
            get { return _NoticeType; }
            set { _NoticeType = value; }
        }
        [DisplayName("客户端右侧排行榜显示"),
            Description("【选填】=1:有tips,=0:无tips "),]
        public string WndNoticeType
        {
            get { return _WndNoticeType; }
            set { _WndNoticeType = value; }
        }
        [DisplayName("奖品等级"),
            Description("【选填】 (此处有配置的话 需要再配置对应等级描述,tTips里面需要配置对应的文字说明) "),]
        public string AwardLev
        {
            get { return _AwardLev; }
            set { _AwardLev = value; }
        }
        [DisplayName("可获得的时间段"),
            Description("【选填】支持2种时间段模式。\n1：sTimePhase = '2017-05-05 07:30 ~ 2017-06-06 07:30',\n2: sTimePhase = '07:00 ~ 08:00' "),]
        public string TimePhase
        {
            get { return _TimePhase; }
            set { _TimePhase = value; }
        }
        [DisplayName("活动区间全服产出上限"),
            Description("【选填】活动区间全服产出上限"),]
        public string ServerLimit
        {
            get { return _ServerLimit; }
            set { _ServerLimit = value; }
        }
        [DisplayName("活动区间单日产出上限"),
            Description("【选填】活动区间单日产出上限 "),]
        public string DayLimit
        {
            get { return _DayLimit; }
            set { _DayLimit = value; }
        }
        [DisplayName("活动区间单人产出掩码"),
            Description("【选填】 （记录单人产出数量，和以下2个属性属于同一组）"),]
        public string UStaskId
        {
            get { return _UStaskId; }
            set { _UStaskId = value; }
        }
        [DisplayName("活动区间单人产出上限"),
            Description("【选填】活动区间单人产出上限"),]
        public string USLimit
        {
            get { return _USLimit; }
            set { _USLimit = value; }
        }
        [DisplayName("对应活动区间单人产出掩码的掩码位"),
            Description("【选填】"),]
        public string USData
        {
            get { return _USData; }
            set { _USData = value; }
        }
        [DisplayName("活动区间单人单日产出掩码"),
            Description("【选填】 （记录单人单日产出数量，和以下2个属于同一组） "),]
        public string UDtaskId
        {
            get { return _UDtaskId; }
            set { _UDtaskId = value; }
        }
        [DisplayName("：活动区间单人单日产出上限"),
            Description("【选填】 "),]
        public string UDLimit
        {
            get { return _UDLimit; }
            set { _UDLimit = value; }
        }
        [DisplayName("对应活动区间单人单日产出掩码的掩码位"),
            Description("【选填】 "),]
        public string UDData
        {
            get { return _UDData; }
            set { _UDData = value; }
        }
    }

    //tOption 控制规则的类
    public class Option
    {
        private int _IsOpen = 1;
        private string _StartTime = "";
        private string _EndTime = "";
        private string _Server = "";
        private Cost _Cost = new Cost();

        [DisplayName("该活动是否开启"),
            Description("【必填】1:该活动开启，0：该活动关闭。"),]
        public int IsOpen
        {
            get { return _IsOpen; }
            set { _IsOpen = value; }
        }
        [Editor(typeof(DateConverter), typeof(UITypeEditor)),
            DisplayName("活动开始时间"),
            Description("【选填】活动开始时间"),]
        public string StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }
        [Editor(typeof(DateConverter), typeof(UITypeEditor)),
            DisplayName("活动结束时间"),
            Description("【选填】活动结束时间"),]
        public string EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }
        [Editor(typeof(ListBoxUCConverter), typeof(UITypeEditor)),
            DisplayName("服务器编号"),
            Description("运用于哪些服务器。【必填】tServer = {0, 1, 2}  (=0官方；=1APP；=2应用宝；3=渠道服；10=西山居西瓜渠道)"),]
        public string Server
        {
            get { return _Server; }
            set { _Server = value; }
        }
        [TypeConverter(typeof(OptionConvert)),
            DisplayName("消耗的筹码币"),
            Description("消耗的筹码币 【必填】"),]
        public Cost Ct
        {
            get { return _Cost; }
            set { _Cost = value; }
        }

    }

    //tCost 消耗的筹码币【必填】
    public class Cost
    {
        private int _ItemId = 0;
        private int _ItemNum = 1;
        private int _ShowId = 0;
        private int _IsBuy = 1;
        private int _CostNum = 0;
        private int _IsBind = 1;

        [DisplayName("物品id"),
            Description("【必填】物品id（购买的道具ID）"),]
        public int ItemId
        {
            get { return _ItemId; }
            set { _ItemId = value; }
        }
        [DisplayName("消耗数量"),
            Description("【必填】消耗数量"),]
        public int ItemNum
        {
            get { return _ItemNum; }
            set { _ItemNum = value; }
        }
        [DisplayName("道具展示形象物品id"),
            Description("【必填】道具展示形象物品id(一般都是筹码币ID)"),]
        public int ShowId
        {
            get { return _ShowId; }
            set { _ShowId = value; }
        }
        [DisplayName("是否开启购买系统"),
            Description("是否开启购买系统。=2：连接魔石商店， =1：开启直接购买，=0：不开启【必填】 （如果开启，魔石价格必填）"),]
        public int IsBuy
        {
            get { return _IsBuy; }
            set { _IsBuy = value; }
        }
        [DisplayName("魔石价格"),
            Description("【必填】魔石价格"),]
        public int CostNum
        {
            get { return _CostNum; }
            set { _CostNum = value; }
        }
        [DisplayName("是否出售绑定"),
            Description("【必填】是否出售绑定(默认为1，绑定)"),]
        public int IsBind
        {
            get { return _IsBind; }
            set { _IsBind = value; }
        }
    }

    //tTenCount 十连抽追加抽奖次数【选填】。
    public class TenCount
    {
        private int _TenCount = 0;
        [DisplayName("十连抽追加抽奖次数"),
            Description("【选填】十连抽追加抽奖次数"),]
        public int TenCounts
        {
            get { return _TenCount; }
            set { _TenCount = value; }
        }
    }

    //tLeast 保底抽奖类(阶段性保底抽奖)
    public class LeastSettings
    {
        private int _LeastCount = 0;
        private int _Count = 1;
        private int _IsBind = 1;
        private int _Notice = 0;
        private int _NoticeType = 1;
        private int _AwardLev = 0;
        private int _LogId = 0;
        private int _LogId_XSJ = 0;

        [DisplayName("触发的次数"),
             Description("【必填】触发的次数"),]
        public int LeastCount
        {
            get { return _LeastCount; }
            set { _LeastCount = value; }
        }
        [DisplayName("数量"),
                     Description("【必填】数量（如果是装备请注意，装备的填写方式，否则会出现耐久为0的情况）"),]
        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }
        [DisplayName("是否绑定"),
            Description("【必填】是否绑定"),]
        public int IsBind
        {
            get { return _IsBind; }
            set { _IsBind = value; }
        }
        [DisplayName("公告方式"),
            Description("【选填】公告方式。1：全服公告，2：全地图公告 3：玩家提示"),]
        public int Notice
        {
            get { return _Notice; }
            set { _Notice = value; }
        }
        [DisplayName("是否有客户端右侧公告"),
            Description("【选填】客户端右侧公告。1:有tips,0:无tips"),]
        public int NoticeType
        {
            get { return _NoticeType; }
            set { _NoticeType = value; }
        }
        [DisplayName("对应的奖品等级及文字描素"),
            Description("对应的奖品等级及文字描素(此处有配置的话 需要再配置对应等级描述,提示配置表里面需要配置对应的文字说明)"),]
        public int AwardLev
        {
            get { return _AwardLev; }
            set { _AwardLev = value; }
        }
        [DisplayName("官方logid"),
            Description("【必填】官方logid"),]
        public int LogId
        {
            get { return _LogId; }
            set { _LogId = value; }
        }
        [DisplayName("西山居logid"),
            Description("【必填】西山居logid"),]
        public int LogId_XSJ
        {
            get { return _LogId_XSJ; }
            set { _LogId_XSJ = value; }
        }
    }

    //tLstAwd 保底抽奖类(循环类保底抽奖)
    public class LstAwdSettings
    {
        private int _LeastCount = 0;
        private int _Count = 1;
        private int _IsBind = 1;
        private int _Notice = 0;
        private int _NoticeType = 1;
        private int _AwardLev = 0;
        private int _LogId = 0;
        private int _LogId_XSJ = 0;

        [DisplayName("触发的次数"),
             Description("【必填】触发的次数"),]
        public int LeastCount
        {
            get { return _LeastCount; }
            set { _LeastCount = value; }
        }
        [DisplayName("数量"),
                             Description("【必填】数量（如果是装备请注意，装备的填写方式，否则会出现耐久为0的情况）"),]
        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }
        [DisplayName("是否绑定"),
            Description("【必填】是否绑定"),]
        public int IsBind
        {
            get { return _IsBind; }
            set { _IsBind = value; }
        }
        [DisplayName("公告方式"),
            Description("【选填】公告方式。1：全服公告，2：全地图公告 3：玩家提示"),]
        public int Notice
        {
            get { return _Notice; }
            set { _Notice = value; }
        }
        [DisplayName("是否有客户端右侧公告"),
            Description("【选填】客户端右侧公告。1:有tips,0:无tips"),]
        public int NoticeType
        {
            get { return _NoticeType; }
            set { _NoticeType = value; }
        }
        [DisplayName("对应的奖品等级及文字描素"),
            Description("对应的奖品等级及文字描素(此处有配置的话 需要再配置对应等级描述,提示配置表里面需要配置对应的文字说明)"),]
        public int AwardLev
        {
            get { return _AwardLev; }
            set { _AwardLev = value; }
        }
        [DisplayName("官方logid"),
            Description("【必填】官方logid"),]
        public int LogId
        {
            get { return _LogId; }
            set { _LogId = value; }
        }
        [DisplayName("西山居logid"),
            Description("【必填】西山居logid"),]
        public int LogId_XSJ
        {
            get { return _LogId_XSJ; }
            set { _LogId_XSJ = value; }
        }
    }

}