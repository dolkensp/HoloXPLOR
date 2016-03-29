using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "TestArrays")]
    public partial class TestArrays
    {
        [XmlArray(ElementName = "myStringArray")]
        [XmlArrayItem(ElementName = "String", Type=typeof(_String))]
        public _String[] MyStringArray { get; set; }

        [XmlArray(ElementName = "myInt8Array")]
        [XmlArrayItem(ElementName = "Int8", Type=typeof(_SByte))]
        public _SByte[] MyInt8Array { get; set; }

        [XmlArray(ElementName = "myInt16Array")]
        [XmlArrayItem(ElementName = "Int16", Type=typeof(_Int16))]
        public _Int16[] MyInt16Array { get; set; }

        [XmlArray(ElementName = "myInt32Array")]
        [XmlArrayItem(ElementName = "Int32", Type=typeof(_Int32))]
        public _Int32[] MyInt32Array { get; set; }

        [XmlArray(ElementName = "myInt64Array")]
        [XmlArrayItem(ElementName = "Int64", Type=typeof(_Int64))]
        public _Int64[] MyInt64Array { get; set; }

        [XmlArray(ElementName = "myUInt8Array")]
        [XmlArrayItem(ElementName = "UInt8", Type=typeof(_Byte))]
        public _Byte[] MyUInt8Array { get; set; }

        [XmlArray(ElementName = "myUInt16Array")]
        [XmlArrayItem(ElementName = "UInt16", Type=typeof(_UInt16))]
        public _UInt16[] MyUInt16Array { get; set; }

        [XmlArray(ElementName = "myUInt32Array")]
        [XmlArrayItem(ElementName = "UInt32", Type=typeof(_UInt32))]
        public _UInt32[] MyUInt32Array { get; set; }

        [XmlArray(ElementName = "myUInt64Array")]
        [XmlArrayItem(ElementName = "UInt64", Type=typeof(_UInt64))]
        public _UInt64[] MyUInt64Array { get; set; }

        [XmlArray(ElementName = "myBooleanArray")]
        [XmlArrayItem(ElementName = "Boolean", Type=typeof(_Boolean))]
        public _Boolean[] MyBooleanArray { get; set; }

        [XmlArray(ElementName = "myFloatArray")]
        [XmlArrayItem(ElementName = "Single", Type=typeof(_Single))]
        public _Single[] MyFloatArray { get; set; }

        [XmlArray(ElementName = "myDoubleArray")]
        [XmlArrayItem(ElementName = "Double", Type=typeof(_Double))]
        public _Double[] MyDoubleArray { get; set; }

        [XmlArray(ElementName = "myEnumArray")]
        [XmlArrayItem(ElementName = "Enum", Type=typeof(_EMyEnum))]
        public _EMyEnum[] MyEnumArray { get; set; }

        [XmlArray(ElementName = "myStructArray")]
        [XmlArrayItem(Type = typeof(TestAtomics))]
        public TestAtomics[] MyStructArray { get; set; }

        [XmlArray(ElementName = "myWeakPtrArray")]
        [XmlArrayItem(ElementName = "WeakPointer", Type=typeof(_WeakPointer))]
        public _WeakPointer[] MyWeakPtrArray { get; set; }

        [XmlArray(ElementName = "myReferenceArray")]
        [XmlArrayItem(ElementName = "Reference", Type=typeof(_Reference))]
        public _Reference[] MyReferenceArray { get; set; }

        [XmlArray(ElementName = "guidArray")]
        [XmlArrayItem(ElementName = "Guid", Type=typeof(_Guid))]
        public _Guid[] GuidArray { get; set; }

        [XmlArray(ElementName = "localeArray")]
        [XmlArrayItem(ElementName = "Locale", Type=typeof(_Locale))]
        public _Locale[] LocaleArray { get; set; }

    }
}
