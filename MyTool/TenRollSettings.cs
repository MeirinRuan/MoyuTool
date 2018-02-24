using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Globalization;
using System.Reflection;
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
        
        [Category("\t基础数据配置表"),
            DisplayName("奖池类型"),
            Description("【必填】奖池对应的cq_lua_data 表的type（存储物品产出量）。"),]
        public int LuaType
        {
            get { return _LuaType; }
            set { _LuaType = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("幸运榜类型"),
            Description("【必填】十连抽幸运榜对应的cq_lua_data表的type。"),]
        public int RankType
        {
            get { return _RankType; }
            set { _RankType = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("版本号类型"),
            Description("【必填】版本号对应的cq_lua_data表的type。"),]
        public int VerType
        {
            get { return _VerType; }
            set { _VerType = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("掩码id"),
            Description("【必填】本次活动抽奖的掩码。"),]
        public int TaskId
        {
            get { return _TaskId; }
            set { _TaskId = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("每日次数限制"),
            Description("【必填】每日次数限制。"),]
        public int LimitCount
        {
            get { return _LimitCount; }
            set { _LimitCount = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("版本号"),
            Description("【必填】版本号。（每一次重新启用需要配置和之前不同的版本号，否则第二次启用掩码不会被重置）。"),]
        public int Ver
        {
            get { return _Ver; }
            set { _Ver = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("几连抽配置"),
            Description("【必填】几连抽配置（目前客户端不支持，请配置10）默认10。"),]
        public int DrawCount
        {
            get { return _DrawCount; }
            set { _DrawCount = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("幸运榜名称"),
            Description("【必填】右侧幸运榜显示的名称。"),]
        public string RankName
        {
            get { return _RankName; }
            set { _RankName = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("活动标题"),
            Description("【必填】显示在界面上方的活动标题。"),]
        public string Title
        {
            get { return _Titile; }
            set { _Titile = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("官方logid"),
            Description("【必填】官方logid。"),]
        public int LogId
        {
            get { return _LogId; }
            set { _LogId = value; }
        }
        [Category("\t基础数据配置表"),
            DisplayName("西山居logid"),
            Description("【必填】西山居logid。"),]
        public int LogId_XSJ
        {
            get { return _LogId_XSJ; }
            set { _LogId_XSJ = value; }
        }

        [Category("抽奖规则表"),
            TypeConverter(typeof(OptionConvert)),
            DisplayName("规则表"),
            Description("【必填】控制作用的规则限制"),]
        public Option Opt
        {
            get { return _Option; }
            set { _Option = value; }
        }

        [Category("抽奖规则表"),
            TypeConverter(typeof(ListBoxConvert)),
            Editor(typeof(CheckBoxConvert), typeof(UITypeEditor)),
            DisplayName("可选配置"),
            Description("【选填】可选配置"),]
        public String SelectableTable
        {
            get { return _SelectableTable; }
            set { _SelectableTable = value; }
        }

        [Category("抽奖规则表"),
            TypeConverter(typeof(OptionConvert)),
            DisplayName("阶段性保底抽奖"),
            Browsable(false),
            Description("【选填】阶段性保底抽奖")]
        public LeastSettings Ls
        {
            get { return _LeastSettings; }
            set { _LeastSettings = value; }
        }
        [Category("抽奖规则表"),
            TypeConverter(typeof(OptionConvert)),
            DisplayName("循环类保底抽奖"),
            Browsable(false),
            Description("【选填】循环类保底抽奖"),]
        public LstAwdSettings LstAwd
        {
            get { return _LstAwdSettings; }
            set { _LstAwdSettings = value; }
        }
        [Category("抽奖规则表"),
            TypeConverter(typeof(OptionConvert)),
            DisplayName("十连抽追加抽奖次数"),
            Browsable(false),
            Description("【选填】十连抽追加抽奖次数"),]
        public TenCount TC
        {
            get { return _TenCount; }
            set { _TenCount = value; }
        }




    }

    //tOption 控制规则的类
    /*
     ------tOption:控制作用的规则限制 【必填】
--------{
----------isOpen: 1:该活动开启，0：该活动关闭。【必填】
----------sStartTime：活动开始时间 【选填】
----------sEndTime: 活动结束时间【选填】
----------tServer: 运用于哪些服务器。【必填】tServer = {0, 1, 2}  (=0官方；=1APP；=2应用宝；3=渠道服；10=西山居西瓜渠道)
----------tCost： 消耗的筹码币 【必填】
------------{
---------------nItemId ：物品id（购买的道具ID） 【必填】
---------------nNum ： 消耗数量 【必填】
---------------nShowId: 道具展示形象物品id(一般都是筹码币ID) 【必填】
---------------isBuy: 是否开启购买系统。=2:连接魔石商店 =1：开启直接购买，=0：不开启【必填】 （如果开启，魔石价格必填）
---------------nCost: 魔石价格【必填】
---------------isBind：是否出售绑定【必填】(默认为1，绑定)
------------}
--------}
         */
    public class Option
    {
        private int _IsOpen = 1;

        [DisplayName("该活动是否开启"),
            Description("【必填】1:该活动开启，0：该活动关闭。"),]
        public int IsOpen
        {
            get { return _IsOpen; }
            set { _IsOpen = value; }
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

    //自定义类型转换类的自定义方法
    public class OptionConvert : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
        {
            if (destinationType == typeof(String))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, System.Type destinationType)
        {
            if (destinationType == typeof(String))
            {
                return "";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    //checkbox属性类的自定义方法
    public class CheckBoxConvert : UITypeEditor
    {
        public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override void PaintValue(PaintValueEventArgs e)
        {
            ControlPaint.DrawCheckBox(e.Graphics, e.Bounds, ButtonState.Normal);
        }

    }

    //下拉框属性类的自定义方法
    public class ListBoxConvert : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new List<String> { "阶段性保底抽奖", "循环类保底抽奖" , "十连抽追加抽奖次数" });
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
