using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Globalization;
using System.ComponentModel;
using System.Drawing.Design;
using System.ComponentModel.Design;
using System.Reflection;

namespace MyTool
{
    //自定义的collection类
    public class AwardListCollection : List<AwardList>, ICustomTypeDescriptor
    {

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
            return TypeDescriptor.GetComponentName(this, true);
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

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            PropertyDescriptor[] props = new PropertyDescriptor[Count];
            for (int i = 0; i < Count; i++)
            {
                props[i] = new AwardListPropertyDescriptor(this[i], attributes, i+1);
            }
            return new PropertyDescriptorCollection(props);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return TypeDescriptor.GetProperties(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

    }

    //自定义的propertydescriptor类
    public class AwardListPropertyDescriptor : PropertyDescriptor
    {
        AwardListItem ali;

        public AwardListPropertyDescriptor(AwardList prop, Attribute[] attrs, int Count) : base(Count.ToString(), attrs)
        {
            ali = prop.ALI;
            
        }

        public override TypeConverter Converter
        {
            get { return new OptionConvert(); }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override Type ComponentType
        {
            get { return GetType(); }
        }

        public override object GetValue(object component)
        {
            return ali;
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get { return ali.GetType(); }
        }

        public override void ResetValue(object component)
        {
        }

        public override void SetValue(object component, object value)
        {
            //theProp.Value = value;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }

    //collectioneditor的自定义类
    public class MyCollectionEditor : CollectionEditor
    {
        public delegate void ValueChangeHandler();
        public static event ValueChangeHandler OnValueChange;

        public MyCollectionEditor(Type type) : base(type)
        {
            
        }

        protected override CollectionForm CreateCollectionForm()
        {
            //获取属性浏览对象
            CollectionForm frm = base.CreateCollectionForm();
            FieldInfo fieldInfo = frm.GetType().GetField("propertyBrower", BindingFlags.NonPublic | BindingFlags.Instance);
            if(fieldInfo != null)
            {
                PropertyGrid pgrid = fieldInfo.GetValue(frm) as PropertyGrid;
                pgrid.PropertyValueChanged += Pgrid_PropertyValueChanged;
                pgrid.SelectedObjectsChanged += ExtendCollectionEditor_ValueChange;
            }

            #region
            //注册按钮事件
            FieldInfo removeButton = frm.GetType().GetField("removeButton", BindingFlags.NonPublic | BindingFlags.Instance);
            if (removeButton != null)
            {
                (removeButton.GetValue(frm) as Button).Click += ExtendCollectionEditor_RemoveClick;
            }

            FieldInfo cancelButton = frm.GetType().GetField("cancelButton", BindingFlags.NonPublic | BindingFlags.Instance);
            if (cancelButton != null)
            {
                (cancelButton.GetValue(frm) as Button).Click += ExtendCollectionEditor_ValueChange;
            }

            FieldInfo okButton = frm.GetType().GetField("okButton", BindingFlags.NonPublic | BindingFlags.Instance);
            if (okButton != null)
            {

            }

            #endregion
            return frm;
        }

        #region
        protected void ExtendCollectionEditor_RemoveClick(object sender, EventArgs e)
        {
            CollectionForm frm = (sender as Button).Parent.Parent.Parent as CollectionForm;
            FieldInfo listbox = frm.GetType().GetField("listbox", BindingFlags.NonPublic | BindingFlags.Instance);
            ListBox listb = listbox.GetValue(frm) as ListBox;

            PropertyInfo Items = frm.GetType().GetProperty("Items", BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo ListItem = null;

            object[] items = new object[listb.Items.Count];
            for (int i = 0; i < listb.Items.Count; i++)
            {
                if (ListItem == null)
                {
                    ListItem = listb.Items[i].GetType().GetProperty("Value", BindingFlags.Public | BindingFlags.Instance);
                }
                items[i] = ListItem.GetValue(listb.Items[i]);
            }
            
            Items.SetValue(frm, items);
 
            AfterRemove();

        }

        private void ExtendCollectionEditor_ValueChange(object sender, EventArgs e)
        {
              SubmitChange();
        }

        private void Pgrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            SubmitChange();
        }
        #endregion

        protected virtual void AfterRemove()
        {
            SubmitChange();
        }

        private void SubmitChange()
        {
           OnValueChange?.Invoke();
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
}
