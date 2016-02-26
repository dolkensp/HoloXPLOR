using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public class DataForge : DataForgeSerializable
    {
        public Int64 FileVersion { get; set; }
        public DataForgeTypeDefinition[] TypeDefinitionTable { get; set; }
        public DataForgePropertyDefinition[] PropertyDefinitionTable { get; set; }
        public DataForgeEnumDefinition[] EnumDefinitionTable { get; set; }
        public DataForgeRecord4[] RecordTable4 { get; set; }
        public DataForgeSchema[] SchemaTable { get; set; }
        public DataForgeStringLookup[] EnumValueTable { get; set; }
        public DataForgeString[] ValueTable { get; set; }

        public DataForge(BinaryReader br)
            : base(br)
        {
            this.FileVersion = br.ReadInt64();

            var numRecords1 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords2 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords3 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords4 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords5 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords6 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords7 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords8 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords9 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords10 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords11 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords12 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords13 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords14 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords15 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords16 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords17 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords18 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords19 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords20 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords21 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords22 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords23 = br.ReadUInt16(); br.ReadUInt16();
            var numRecords24 = br.ReadUInt16(); br.ReadUInt16();
            var totalLength25 = br.ReadUInt32();

            br.BaseStream.Seek(0x0000006c, SeekOrigin.Begin);

            this.TypeDefinitionTable = this.ReadArray<DataForgeTypeDefinition>(numRecords1);
            this.PropertyDefinitionTable = this.ReadArray<DataForgePropertyDefinition>(numRecords2);
            this.EnumDefinitionTable = this.ReadArray<DataForgeEnumDefinition>(numRecords3);
            this.RecordTable4 = this.ReadArray<DataForgeRecord4>(numRecords4);
            this.SchemaTable = this.ReadArray<DataForgeSchema>(numRecords5);

            var temp6 = this.ReadArray<DataForgeRecord6>(numRecords6);
            var temp7 = this.ReadArray<DataForgeRecord7>(numRecords7);
            var temp8 = this.ReadArray<DataForgeRecord8>(numRecords8);
            var temp9 = this.ReadArray<DataForgeRecord9>(numRecords9);
            var temp10 = this.ReadArray<DataForgeTuple>(numRecords10);
            var temp11 = this.ReadArray<DataForgeTuple>(numRecords11);
            var temp12 = this.ReadArray<DataForgeTuple>(numRecords12);
            var temp13 = this.ReadArray<DataForgeTuple>(numRecords13);
            var temp14 = this.ReadArray<DataForgeTuple>(numRecords14);
            var temp15 = this.ReadArray<DataForgeTuple>(numRecords15);
            var temp16 = this.ReadArray<DataForgeTuple>(numRecords16);
            var temp17 = this.ReadArray<DataForgeTuple>(numRecords17);
            var temp18 = this.ReadArray<DataForgeTuple>(numRecords18);
            var temp19 = this.ReadArray<DataForgeTuple>(numRecords19);
            var temp20 = this.ReadArray<DataForgeTuple>(numRecords20);
            var temp21 = this.ReadArray<DataForgeTuple>(numRecords21);
            var temp22 = this.ReadArray<DataForgeTuple>(numRecords22);

            var wrong = br.BaseStream.Position - 0x0002e4d4;

            // HACK: Skip unknown tables at this stage
            br.BaseStream.Seek(0x0002e4d4, SeekOrigin.Begin);

            var temp23 = this.ReadArray<DataForgeRecord23>(numRecords23);

            br.BaseStream.Seek(0x0002e7cc, SeekOrigin.Begin);

            this.EnumValueTable = this.ReadArray<DataForgeStringLookup>(numRecords24);

            var buffer = new List<DataForgeString> { };
            var maxPosition = br.BaseStream.Position + totalLength25;
            while (br.BaseStream.Position < maxPosition)
            {
                buffer.Add(new DataForgeString(br));
            }
            this.ValueTable = buffer.ToArray();
        }
    }

    // TODO: Verify this
    public class DataForgeTypeDefinition : DataForgeSerializable
    {
        public String Name { get; set; }
        public UInt32 ParentTypeIndex { get; set; }
        public UInt16 AttributeCount { get; set; }
        public UInt16 FirstAttributeIndex { get; set; }
        public UInt32 NodeType { get; set; }

        public DataForgeTypeDefinition(BinaryReader br)
            : base(br)
        {
            this.Name = this.ReadString();
            this.ParentTypeIndex = br.ReadUInt32();
            this.AttributeCount = br.ReadUInt16();
            this.FirstAttributeIndex = br.ReadUInt16();
            this.NodeType = br.ReadUInt32();
        }
    }

    public enum EDataType : ushort
    {
        varString = 0x000A,
        varInteger = 0x000B,
        nodeRequired = 0x0010,
        nodeOptional = 0x0110,
    }

    public enum EConversionType : ushort
    {
        varSingle = 0x6900,
        varChild = 0x6901,
        varArray = 0x6902,
    }

    // TODO: Verify this
    public class DataForgePropertyDefinition : DataForgeSerializable
    {
        public String Name { get; set; }
        public UInt16 ChildType { get; set; }
        public EDataType DataType { get; set; }
        public EConversionType ConversionType { get; set; }
        public UInt16 Unknown { get; set; }

        public DataForgePropertyDefinition(BinaryReader br)
            : base(br)
        {
            this.Name = this.ReadString();
            this.ChildType = br.ReadUInt16();
            this.DataType = (EDataType)br.ReadUInt16();
            this.ConversionType = (EConversionType)br.ReadUInt16();
            this.Unknown = br.ReadUInt16();
        }
    }

    public class DataForgeEnumDefinition : DataForgeSerializable
    {
        public String Name { get; set; }
        public UInt16 ValueCount { get; set; }
        public UInt16 FirstValueIndex { get; set; }

        public DataForgeEnumDefinition(BinaryReader br)
            : base(br)
        {
            this.Name = this.ReadString();
            this.ValueCount = br.ReadUInt16();
            this.FirstValueIndex = br.ReadUInt16();
        }
    }

    public class DataForgeRecord4 : DataForgeSerializable
    {
        public UInt16 Item1 { get; set; }
        public UInt16 Item2 { get; set; }

        public DataForgeRecord4(BinaryReader br)
            : base(br)
        {
            this.Item1 = br.ReadUInt16();
            this.Item2 = br.ReadUInt16();
        }
    }

    public class DataForgeSchema : DataForgeSerializable
    {
        public String Name { get; set; }
        public UInt32 TypeIndex { get; set; }
        public Guid? Hash { get; set; }

        public UInt16 VariantIndex { get; set; }
        public UInt16 Item1 { get; set; }

        public DataForgeSchema(BinaryReader br)
            : base(br)
        {
            this.Name = this.ReadString();
            this.TypeIndex = br.ReadUInt32();
            this.Hash = this.ReadGuid(false);

            this.VariantIndex = br.ReadUInt16();
            this.Item1 = br.ReadUInt16();
        }
    }

    public class DataForgeRecord23 : DataForgeSerializable
    {
        public UInt32 Item1 { get; set; }
        public UInt32 Item2 { get; set; }
        public UInt32 Item3 { get; set; }
        public UInt32 Item4 { get; set; }
        public UInt32 Item5 { get; set; }

        public DataForgeRecord23(BinaryReader br)
            : base(br)
        {
            this.Item1 = br.ReadUInt32();
            this.Item2 = br.ReadUInt32();
            this.Item3 = br.ReadUInt32();
            this.Item4 = br.ReadUInt32();
            this.Item5 = br.ReadUInt32();
        }

        public override String ToString()
        {
            return String.Format("0x{0:X8} 0x{1:X8} 0x{2:X8} 0x{3:X8} 0x{4:X8}", this.Item1, this.Item2, this.Item3, this.Item4, this.Item5);
        }
    }

    public class DataForgeStringLookup : DataForgeSerializable
    {
        public String Value { get; set; }

        public DataForgeStringLookup(BinaryReader br)
            : base(br)
        {
            this.Value = this.ReadString();
        }

        public override String ToString()
        {
            return this.Value;
        }
    }

    public class DataForgeUInt32 : DataForgeSerializable
    {
        public UInt32 Value { get; set; }

        public DataForgeUInt32(BinaryReader br)
            : base(br)
        {
            this.Value = br.ReadUInt32();
        }

        public override String ToString()
        {
            return String.Format("0x{0:X8}", this.Value);
        }
    }

    public class DataForgeString : DataForgeSerializable
    {
        public String Value { get; set; }

        public DataForgeString(BinaryReader br)
            : base(br)
        {
            this.Value = br.ReadCString();
        }

        public override String ToString()
        {
            return this.Value;
        }
    }

    public class DataForgeTuple : DataForgeSerializable
    {
        public UInt32 Item1 { get; set; }
        public UInt32 Item2 { get; set; }

        public DataForgeTuple(BinaryReader br)
            : base(br)
        {
            this.Item1 = br.ReadUInt32();
            this.Item2 = br.ReadUInt32();
        }

        public override String ToString()
        {
            return String.Format("0x{0:X8} 0x{1:X8}", this.Item1, this.Item2);
        }
    }

    public class DataForgeRecord6 : DataForgeSerializable
    {
        public UInt32 Item1 { get; set; }
        public UInt32 Item2 { get; set; }
        public UInt32 Item3 { get; set; }
        public UInt32 Item4 { get; set; }
        public UInt32 Item5 { get; set; }
        public UInt32 Item6 { get; set; }
        public UInt32 Item7 { get; set; }
        public UInt32 Item8 { get; set; }

        public DataForgeRecord6(BinaryReader br)
            : base(br)
        {
            this.Item1 = br.ReadUInt32();
            this.Item2 = br.ReadUInt32();
            this.Item3 = br.ReadUInt32();
            this.Item4 = br.ReadUInt32();
            this.Item5 = br.ReadUInt32();
            this.Item6 = br.ReadUInt32();
            this.Item7 = br.ReadUInt32();
            this.Item8 = br.ReadUInt32();
        }

        public override String ToString()
        {
            return String.Format("0x{0:X8} 0x{1:X8} 0x{2:X8} 0x{3:X8} 0x{4:X8} 0x{5:X8} 0x{6:X8} 0x{7:X8}", this.Item1, this.Item2, this.Item3, this.Item4, this.Item5, this.Item6, this.Item7, this.Item8);
        }
    }

    public class DataForgeRecord7 : DataForgeSerializable
    {
        public UInt32 Item1 { get; set; }
        public UInt32 Item2 { get; set; }
        public UInt32 Item3 { get; set; }
        public UInt32 Item4 { get; set; }
        public UInt32 Item5 { get; set; }
        public UInt32 Item6 { get; set; }
        public UInt32 Item7 { get; set; }
        public UInt32 Item8 { get; set; }

        public DataForgeRecord7(BinaryReader br)
            : base(br)
        {
            this.Item1 = br.ReadUInt32();
            this.Item2 = br.ReadUInt32();
            this.Item3 = br.ReadUInt32();
            this.Item4 = br.ReadUInt32();
            this.Item5 = br.ReadUInt32();
            this.Item6 = br.ReadUInt32();
            this.Item7 = br.ReadUInt32();
            this.Item8 = br.ReadUInt32();
        }

        public override String ToString()
        {
            return String.Format("0x{0:X8} 0x{1:X8} 0x{2:X8} 0x{3:X8} 0x{4:X8} 0x{5:X8} 0x{6:X8} 0x{7:X8}", this.Item1, this.Item2, this.Item3, this.Item4, this.Item5, this.Item6, this.Item7, this.Item8);
        }
    }

    public class DataForgeRecord8 : DataForgeSerializable
    {
        public UInt32 Item1 { get; set; }
        public UInt32 Item2 { get; set; }
        public UInt32 Item3 { get; set; }
        public UInt32 Item4 { get; set; }
        public UInt32 Item5 { get; set; }
        public UInt32 Item6 { get; set; }
        public UInt32 Item7 { get; set; }
        public UInt32 Item8 { get; set; }

        public DataForgeRecord8(BinaryReader br)
            : base(br)
        {
            this.Item1 = br.ReadUInt32();
            this.Item2 = br.ReadUInt32();
            this.Item3 = br.ReadUInt32();
            this.Item4 = br.ReadUInt32();
            this.Item5 = br.ReadUInt32();
            this.Item6 = br.ReadUInt32();
            this.Item7 = br.ReadUInt32();
            this.Item8 = br.ReadUInt32();
        }

        public override String ToString()
        {
            return String.Format("0x{0:X8} 0x{1:X8} 0x{2:X8} 0x{3:X8} 0x{4:X8} 0x{5:X8} 0x{6:X8} 0x{7:X8}", this.Item1, this.Item2, this.Item3, this.Item4, this.Item5, this.Item6, this.Item7, this.Item8);
        }
    }

    public class DataForgeRecord9 : DataForgeSerializable
    {
        public UInt32 Item1 { get; set; }
        public UInt32 Item2 { get; set; }
        public UInt32 Item3 { get; set; }
        public UInt32 Item4 { get; set; }
        public UInt32 Item5 { get; set; }
        public UInt32 Item6 { get; set; }
        public UInt32 Item7 { get; set; }
        public UInt32 Item8 { get; set; }

        public DataForgeRecord9(BinaryReader br)
            : base(br)
        {
            this.Item1 = br.ReadUInt32();
            this.Item2 = br.ReadUInt32();
            this.Item3 = br.ReadUInt32();
            this.Item4 = br.ReadUInt32();
            this.Item5 = br.ReadUInt32();
            this.Item6 = br.ReadUInt32();
            this.Item7 = br.ReadUInt32();
            this.Item8 = br.ReadUInt32();
        }

        public override String ToString()
        {
            return String.Format("0x{0:X8} 0x{1:X8} 0x{2:X8} 0x{3:X8} 0x{4:X8} 0x{5:X8} 0x{6:X8} 0x{7:X8}", this.Item1, this.Item2, this.Item3, this.Item4, this.Item5, this.Item6, this.Item7, this.Item8);
        }
    }
}
