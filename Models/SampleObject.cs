using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using AxControls.Controls;
using AxControls.Atrributes;
using AxControls.Samples;

namespace AxPropertyGrid.Samples.Models
{
    public class SampleObject : IAxContainCustomEditors
    {
        #region Enum properties
        public enum EnumType {
            [AxEnumValueDisplayText("Value 1")]
            Value1,
            [AxEnumValueDisplayText("Properties.Resources.LocaledEnumValueText")] 
            Value2,
            [AxEnumValueDisplayText("Value 3")]
            Value3
        }

        [AxProperty("Enum1", "Enum Properties", HelpText = "Help text for Enum1")]
        
        public EnumType EnumProperty1 { get; set; }

        [AxProperty("Enum2", "Enum Properties", HelpText = "Help text for Enum2")]
        
        public EnumType EnumProperty2 { get; private set; } = EnumType.Value2;
        
        [AxProperty("Enum3", "Enum Properties", EditorStyle=ValueEditorStyle.Enum_RadioGroup_Horizontal)]
        public EnumType EnumProperty3 { get; set; }
        
        [AxProperty("Enum4", "Enum Properties", EditorStyle=ValueEditorStyle.Enum_RadioGroup_Vertical)]
        public EnumType EnumProperty4 { get; set; } = EnumType.Value3;
        #endregion Enum properties end

        #region double properties
        
        [AxProperty("Double1", "Double Properties", HelpText = "Help text for Double1")]
        //[AxProperty("Properties.Resources.AppTitle", "XXXY.Core.Properties.Resources.AboutCopyrightText", HelpText = "Properties.Resources.SampleLocaledDescriptionText")]
        public double DoubleProperty1 { get; set; } = 0.5;
        
        [AxProperty("Double2", "Double Properties", HelpText = "Help text for Double2")]
        public double DoubleProperty2_ReadOnly { get; private set; } = 15.8;

        [AxProperty("Double3", "Double Properties", HelpText = "Help text for Double3")]
        [AxDecimalEdit(0.0, 1.0, 0.01)]
        public double DoubleProperty3 { get; set; } = 20.06;

        [AxProperty("Double4", "Double Properties", HelpText = "Help text for Double4")]
        [AxDecimalEdit(0.0, 100.0, 1, "", "%")]
        public double DoubleProperty4 { get; set; } = 10.5;


        [AxProperty("Double5", "Double Properties", HelpText = "Help text for Double5")]
        [AxDecimalEdit(-100.0, 100.0, 10, "$")]
        public double DoubleProperty5 { get; set; } = 60.2;
        #endregion double properties

        #region uint properties
        
        [AxProperty("UInt1", "UInt Properties", HelpText = "Help text for UInt1")]
        public uint UIntProperty1 { get; set; } = 3;

        
        [AxProperty("UInt2", "UInt Properties", HelpText = "Help text for UInt2")]
        public uint UIntProperty2_ReadOnly { get; private set; } = 15;

        
        [AxProperty("UInt3", "UInt Properties", HelpText = "Help text for UInt3")]
        [AxUIntegerEdit(1, 10, 1)]
        public uint UIntProperty3 { get; set; }

        
        [AxProperty("UInt4", "UInt Properties", HelpText = "Help text for UInt4")]
        [AxUIntegerEdit(0, 100, 5, "", "%")]
        public uint UIntProperty4 { get; set; }

        
        [AxProperty("UInt5", "UInt Properties", HelpText = "Help text for UInt5")]
        [AxUIntegerEdit(0, 100, 10, "$")]
        public uint UIntProperty5 { get; set; }
        #endregion uint properties

        #region numeric properties
        [AxProperty("float1", "numeric properties", HelpText = "Help text for float1")]
        public float FloatProperty1 { get; set; }

        [AxProperty("decimal1", "numeric properties", HelpText = "Help text for decimal1")]
        public decimal DecimalProperty1 { get; set; }

        [AxProperty("sbyte1", "numeric properties", HelpText = "Help text for sbyte1")]
        public sbyte SByteProperty1 { get; set; }

        [AxProperty("byte1", "numeric properties", HelpText = "Help text for byte1")]
        public byte ByteProperty1 { get; set; }

        [AxProperty("short1", "numeric properties", HelpText = "Help text for short1")]
        public short ShortProperty1 { get; set; }

        [AxProperty("ushort1", "numeric properties", HelpText = "Help text for ushort1")]
        public ushort UShortProperty1 { get; set; }

        [AxProperty("int1", "numeric properties", HelpText = "Help text for int1")]
        public int IntProperty1 { get; set; }

        [AxProperty("long1", "numeric properties", HelpText = "Help text for long1")]
        public long LongProperty1 { get; set; }

        [AxProperty("ulong1", "numeric properties", HelpText = "Help text for ulong1")]
        public ulong ULongProperty1 { get; set; }
        #endregion numeric properties


        #region bool properties
        
        [AxProperty("Bool1", "Bool Properties", HelpText = "Help text for Bool1")]
        public bool BoolProperty1 { get; set; } = true;
        
        [AxProperty("Bool2", "Bool Properties", HelpText = "Help text for Bool2")]
        public bool BoolProperty2 { get; private set; } = true;
        
        [AxProperty("Bool3", "Bool Properties", HelpText = "Help text for Bool3", EditorStyle = ValueEditorStyle.Bool_ToggleSwitch)]
        public bool BoolProperty3 { get; set; } = true;
        
        [AxProperty("Bool4", "Bool Properties", HelpText = "Help text for Bool4", EditorStyle = ValueEditorStyle.Bool_ToggleSwitch)]
        public bool BoolProperty4 { get; private set; } = true;
        
        [AxProperty("Bool5", "Bool Properties", HelpText = "Help text for Bool5", EditorStyle = ValueEditorStyle.Bool_ToggleSwitch)]
        public bool BoolProperty5 { get; private set; } = false;

        #endregion bool properties

        #region string properties

        
        [AxProperty("String1", "String Properties", HelpText = "Help text for String1")]
        public string StringProperty1 { get; set; } = "Sample String 1 The bit rate is expressed in the unit bit per second (symbol: bit/s)";

        
        [AxProperty("String2", "String Properties", HelpText = "Help text for String2", EditorStyle = ValueEditorStyle.String_TextBox_Wrap_MultiLine)]
        public string StringProperty2 { get; set; } = "The bit rate is expressed in the unit bit per second (symbol: bit/s), often in conjunction with an SI prefix such as kilo (1 kbit/s = 1,000 bit/s), mega (1 Mbit/s = 1,000 kbit/s), giga (1 Gbit/s = 1,000 Mbit/s) or tera (1 Tbit/s = 1,000 Gbit/s).[2] The non-standard abbreviation bps is often used to replace the standard symbol bit/s, so that, for example, 1 Mbps is used to mean one million bits per second.";

        
        [AxProperty("String3", "String Properties", HelpText = "Help text for String3")]
        public string StringProperty3 { get; private set; } = "Sample String 3";

        
        [AxProperty("String4", "String Properties", HelpText = "", EditorStyle = ValueEditorStyle.String_TextBox_Wrap_MultiLine)]
        [AxStringEdit(true, 150)]
        public string StringProperty4 { get; set; } = "The bit rate is expressed in the unit bit per second (symbol: bit/s), often in conjunction with an SI prefix such as kilo (1 kbit/s = 1,000 bit/s), mega (1 Mbit/s = 1,000 kbit/s), giga (1 Gbit/s = 1,000 Mbit/s) or tera (1 Tbit/s = 1,000 Gbit/s).[2] The non-standard abbreviation bps is often used to replace the standard symbol bit/s, so that, for example, 1 Mbps is used to mean one million bits per second.";

        #endregion string properties

        #region size properties

        
        [AxProperty("Size1", "Size Properties", HelpText = "Help text for Size1")]
        [AxSizeEdit]
        public System.Windows.Size SizeProperty1 { get; set; } = new System.Windows.Size(100, 200);
        
        [AxProperty("Size2", "Size Properties", HelpText = "Help text for Size2")]
        [AxSizeEdit(1, WidthText = "宽度", HeightText = "高度")]
        public System.Windows.Size SizeProperty2 { get; set; } = new System.Windows.Size(300.3, 400.5);
        
        [AxProperty("尺寸", "Size Properties")]
        [AxSizeEdit(0, MinWidth = 5, MaxWidth = 32)]

        public System.Windows.Size SizeProperty3 { get; set; } = new System.Windows.Size(10, 15);
        #endregion

        #region Point Properties
        
        [AxProperty("Point1", "Point Properties", HelpText = "Help text for Point1")]
        [AxPointEdit]
        public System.Windows.Point PointProperty1 { get; set; } = new Point(100, 200);
        
        [AxProperty("Point2", "Point Properties", HelpText = "Help text for Point2")]
        [AxPointEdit(1)]
        public Point PointProperty2 { get; set; } = new Point(300.3f, 400.5f);
        
        [AxProperty("Point3", "Point Properties", HelpText = "Help text for Point3")]
        [AxPointEdit(0)]
        public Point PointProperty3 { get; private set; } = new Point(10, 15);
        #endregion Point Properties

        #region Color properties
        
        [AxProperty("ColorProperty", "Color Properties")]
        public Color ColorProperty1 { get; set; }
        
        [AxProperty("ColorProperty2-readonly", "Color Properties")]
        public Color ColorProperty2 { get; private set; } = Colors.AliceBlue;
        #endregion Color Properties

        #region Datetime properties
        
        [AxProperty("DateTime", "DateTime Properties", HelpText = "Help text for DateTime1")]
        public DateTime DateTimeProperty1 { get; set; } = DateTime.Now;

        
        [AxProperty("DateOnly", "DateTime Properties", HelpText = "Help text for DateOnly")]
        public DateOnly DateProperty { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        
        [AxProperty("DateTime-readonly", "DateTime Properties", HelpText = "Help text for DateTime1")]
        public DateTime DateTimeProperty2 { get; private set; } = DateTime.Now.AddHours(2);

        
        [AxProperty("DateTime-DateAndTime", "DateTime Properties", HelpText = "Help text for DateTime-Date", EditorStyle = ValueEditorStyle.DateTime_DateAndTime)]
        public DateTime DateProperty2 { get; set; } = DateTime.Now;

        
        [AxProperty("DateTime-Time", "DateTime Properties", HelpText = "Help text for DateTime-Time", EditorStyle = ValueEditorStyle.DateTime_Time)]
        public DateTime TimeProperty { get; set; } = DateTime.Now;

        
        [AxProperty("TimeOnly", "DateTime Properties", HelpText = "Help text for DateTime-Time")]
        public TimeOnly TimeProperty2 { get; set; } = TimeOnly.FromDateTime(DateTime.Now);
        #endregion

        #region uniform width line items
        [AxAutoUniformWidthLineUp("size", 1)]
        public double Width { get; set; } = 100;

        [AxAutoUniformWidthLineUp("angle", 1)]
        public double StartAngle { get; set; } = 20;

        [AxAutoUniformWidthLineUp("size", 2)]
        public double Height { get; set; } = 80;

        [AxAutoUniformWidthLineUp("angle", 2)]
        public double EndAngle { get; set; } = 60;

        #endregion uniform width line items

        #region next to properties
        public double Width0 { get; set; } = 100;

        public double NX { get; set; } = 50.5;

        [AxNextTo("Width0")]
        public double Width1 { get; set; } = 120;

        public double NY { get; set; } = 35.5;

        [AxNextTo("Width1")]
        public double Width2 { get; set; } = 150;
        #endregion next to properties

        #region Customize type editor
        
        public AxLibType LibTypeProperty { get; set; } = new AxLibType();
        /// <summary>
        /// User can:
        /// 1, set a new value to the property
        /// 2, only update the inner properties of the property value.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <param name="propertyOwner"></param>
        /// <returns></returns>
        public FrameworkElement? CreateValueEditor(string propertyName, object propertyValue, object propertyOwner)
        {
            if (propertyName == nameof(LibTypeProperty))
            {
                var editor = new AxLibObjEditor();
                editor.DataContext = propertyValue;
                return editor;
            }
            return null;
        }

        public bool IsCustomEditorAvailable(string propertyName)
        {
            if (propertyName == nameof(LibTypeProperty))
                return true;
            return false;
        }

        #endregion Customize type editor

        #region inner properties
        
        [AxInnerProperty("Property2", "innerProp1", "Inner properties")]
        [AxInnerProperty("InnerProperty.InnerDoubleProperty", "innerProp2", "Inner properties")]
        [AxInnerProperty("InnerProperty.InnerType2.InnerStringProperty", "innerProp3", "Inner properties")]
        [AxDecimalEdit("InnerProperty.InnerDoubleProperty", 0.0, 1.0, 0.01)]
        public AxLibType InnerProperty { get; set; } = new();
        
        #endregion inner properties end

        #region Localization properties (using Properties.Resources)

        // Property name, group name and help text are localized via resource keys.
        // Format: "Properties.Resources.ResourceKey" for resources in the calling assembly.
        // Format: "AssemblyName.Properties.Resources.ResourceKey" for cross-assembly resources.

        [AxProperty("Properties.Resources.LocaledBoolPropName",
            "Properties.Resources.LocaledPropGroupName",
            HelpText = "Properties.Resources.LocaledBoolPropHelp")]
        public bool LocaledBool { get; set; } = true;

        [AxProperty("Properties.Resources.LocaledStringPropName",
            "Properties.Resources.LocaledPropGroupName",
            HelpText = "Properties.Resources.LocaledStringPropHelp")]
        public string LocaledString { get; set; } = "Localized string value";

        [AxProperty("Properties.Resources.LocaledDoublePropName",
            "Properties.Resources.LocaledPropGroupName",
            HelpText = "Properties.Resources.LocaledDoublePropHelp")]
        public double LocaledDouble { get; set; } = 3.14;

        [AxProperty("Properties.Resources.LocaledEnumPropName",
            "Properties.Resources.LocaledPropGroupName",
            HelpText = "Properties.Resources.LocaledEnumPropHelp")]
        public EnumType LocaledEnum { get; set; } = EnumType.Value2;

        [AxProperty("Properties.Resources.LocaledColorPropName",
            "Properties.Resources.LocaledPropGroupName",
            HelpText = "Properties.Resources.LocaledColorPropHelp")]
        public Color LocaledColor { get; set; } = Colors.CornflowerBlue;

        [AxProperty("Properties.Resources.LocaledDatePropName",
            "Properties.Resources.LocaledPropGroupName",
            HelpText = "Properties.Resources.LocaledDatePropHelp")]
        public DateTime LocaledDate { get; set; } = DateTime.Now;

        #endregion Localization properties end
    }
}
