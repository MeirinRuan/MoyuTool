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
using System.Collections;

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
        private MyAttrCollection _MAC = new MyAttrCollection();

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
        [Category("抽奖规则表"),
            TypeConverter(typeof(OptionConvert)),
            DisplayName("奖励物品表"),
            Description("【必填】奖励物品"),]
        public MyAttrCollection MAC
        {
            get { return _MAC; }
            set { _MAC = value; }
        }



    }

    //物品类
    public class DynaProperty
    {
        private string name = string.Empty;
        private object value = null;
        private string description = string.Empty;
        private string _category = string.Empty;
        object _editor = null;
        TypeConverter converter = null;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public TypeConverter Converter 
        {
            get { return converter; }
            set { converter = value; }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public virtual object Editor
        {
            get { return _editor; }
            set { _editor = value; }
        }
    }

    //物品类
    public class AwardList
    {
        private string _ItemId = "";


        [DisplayName("物品id"),
            Description("【必填】物品id"),]
        public string ItemId
        {
            get { return _ItemId; }
            set { _ItemId = value; }
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

    //string的自定义属性类
    public class OptionConvert : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(String))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(String))
            {
                return "";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    //时间自定义控件
    public class DateConverter : UITypeEditor
    {
        DateTimePicker dateControl = new DateTimePicker();

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService iws = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (iws != null)
            {
                if (value is string)
                {
                    iws.DropDownControl(dateControl);
                    return dateControl.Value.ToString("yyyy-MM-dd HH:mm");
                }
                else if (value is DateTime)
                {
                    iws.DropDownControl(dateControl);
                    return dateControl.Value;
                }
            }
            return value;
        }
    }

    //下拉框自定义控件
    public class ListBoxUCConverter : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService iws = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (iws != null)
            {
                CheckedListBoxUC clb = new CheckedListBoxUC(iws, context);
                iws.DropDownControl(clb);
                return clb.SelectedFields;
            }
            return value;
        }
    }

    //自定义的checkedlistbox控件
    public class CheckedListBoxUC : CheckedListBox
    {
        private IWindowsFormsEditorService m_iws;

        private string m_selectStr = string.Empty;

        /// <summary>
        /// 获取选择的字段，多个字段用"|"隔开
        /// </summary>
        public string SelectedFields
        {
            get
            {
                return "{" + m_selectStr + "}";
            }

        }
        public CheckedListBoxUC(IWindowsFormsEditorService iws, ITypeDescriptorContext context)
        {
            m_iws = iws;
            Visible = true;
            Height = 100;
            BorderStyle = BorderStyle.None;
            //添加事件
            Leave += new EventHandler(CheckedListBoxUC_Leave);

            try
            {
                List<string> strList = new List<string> { "阶段性保底抽奖", "循环类保底抽奖", "十连抽追加抽奖次数" };
                if (context.PropertyDescriptor.DisplayName == "服务器编号")
                {
                    strList = new List<string> { "0", "1", "2", "3", "10" };
                }
                BeginUpdate();
                Items.Clear();
                if (null != strList)
                {
                    for (int i = 0; i < strList.Count; i++)
                    {
                        Items.Add(strList[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EndUpdate();
            }
        }

        void CheckedListBoxUC_Leave(object sender, EventArgs e)
        {
            List<string> lstStrs = new List<string>();
            for (int i = 0; i < Items.Count; i++)
            {
                if (GetItemChecked(i))
                {
                    lstStrs.Add((string)Items[i]);
                }

            }
            m_selectStr = string.Join(",", lstStrs.ToArray());
            //m_iws.CloseDropDown();
        }

    }

    //自定义性质描述类
    public class MyPropertyDescription : PropertyDescriptor
    {

        private DynaProperty dp = null;
        public MyPropertyDescription(DynaProperty newdp, Attribute[] attrs) : base(newdp.Name, attrs)
        {
            dp = newdp;
        }

        public override Type ComponentType
        {
            get{ return GetType(); }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get{ return dp.Value.GetType(); }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override object GetValue(object component)
        {
            return dp.Value;
        }

        public override void ResetValue(object component)
        {
            //不重置，无动作 
        }

        public override void SetValue(object component, object value)
        {
            dp.Value = value;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        public override string Description
        {
            get{ return dp.Description; }
        }

        public override TypeConverter Converter
        {
            get { return dp.Converter; }
        }

        public override object GetEditor(Type editorBaseType)
        {
            return dp.Editor == null ? base.GetEditor(editorBaseType) : dp.Editor;
        }
    }

    //自定义的特殊属性类
    public class MyAttrCollection : Dictionary<String, DynaProperty>, ICustomTypeDescriptor
    {
        //动态添加，重写add方法
        public void Add(DynaProperty value)
        {
            if (!ContainsKey(value.Name))
            {
                Add(value.Name, value);
            }
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return TypeDescriptor.GetProperties(this, true);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            int count = Values.Count;
            PropertyDescriptor[] pds = new PropertyDescriptor[count];
            int index = 0;
            foreach (DynaProperty item in Values)
            {
                pds[index] = new MyPropertyDescription(item, attributes);
                index++;
            }
            return new PropertyDescriptorCollection(pds);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    }
}