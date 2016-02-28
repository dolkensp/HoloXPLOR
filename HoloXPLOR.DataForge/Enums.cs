using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public enum EDataType : ushort
    {
        varReference = 0x0310,
        varWeakPointer = 0x0210,
        varStrongPointer = 0x0110,
        varClass = 0x0010,
        varEnum = 0x000F,
        varGuid = 0x000E,
        varLocale = 0x000D,
        varDouble = 0x000C,
        varSingle = 0x000B,
        varString = 0x000A,
        varUInt64 = 0x0009,
        varUInt32 = 0x0008,
        varUInt16 = 0x0007,
        varUInt8 = 0x0006,
        varInt64 = 0x0005,
        varInt32 = 0x0004,
        varInt16 = 0x0003,
        varInt8 = 0x0002,
        varBoolean = 0x0001,
    }

    public enum EConversionType : ushort
    {
        varAttribute = 0x6900,
        varComplexArray = 0x6901,
        varSimpleArray = 0x6902,
    }
}
