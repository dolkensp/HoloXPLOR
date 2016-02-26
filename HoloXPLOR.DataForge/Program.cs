using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloXPLOR.DataForge
{
    public static class Program
    {
        public class GOSTEntityStateMachine : DataForgeSerializable
        {
            //[desc:"Array of GOSTs"]
            public GOSTInstance[] GOSTs { get; set; }

            public GOSTEntityStateMachine(BinaryReader br)
                : base(br)
            {
                this.GOSTs = this.ReadArray<GOSTInstance>();
            }
        }

        public class GOSTInstance : DataForgeSerializable
        {
            //[desc:"Name of this GOST"]
            public String Name { get; set; }

            //[desc:"Array of constants for this state group"]
            public GOSTConstant[] Constants { get; set; }

            //[desc:"Array of state groups within this GOST"]
            public GOSTStateGroupImport[] StateGroups { get; set; }

            public Int32 _NodeType { get; set; }
            public Int32 _NodeIndex { get; set; }

            public GOSTInstance(BinaryReader br)
                : base(br)
            {
                this.Name = this.ReadString();

                var numConstants = br.ReadUInt32();
                var numStateGroups = br.ReadUInt32();

                if (numConstants < 0) numConstants = 0;
                if (numStateGroups < 0) numStateGroups = 0;

                this.Constants = this.ReadArray<GOSTConstant>(numConstants);
                this.StateGroups = this.ReadArray<GOSTStateGroupImport>(numStateGroups);

                this._NodeType = br.ReadInt32();
                this._NodeIndex = br.ReadInt32();
            }
        }

        public class GOSTConstant : DataForgeSerializable
        {
            //[desc:"Constant name"]
            public String Name { get; set; }

            //[desc:"Constant type"]
            public String Type { get; set; } // EGOSTVariableType

            //[desc:"Constant value"]
            public String Value { get; set; }

            public GOSTConstant(BinaryReader br)
                : base(br)
            {
                this.Name = this.ReadString();
                this.Type = this.ReadString();
                this.Value = this.ReadString();
            }
        }

        public class GOSTStateGroupImport : DataForgeSerializable
        {
            //[desc:"State group name to use within this entity"]
	        public String Name { get; set; }			
	
	        //[desc:"State group implementation from GOSTStateGroups.xml file"]
            public Guid? Implementation { get; set; } // ?? GOSTStateGroup&	

            public GOSTStateGroupImport(BinaryReader br)
                : base(br)
            {
                this.Name = this.ReadString();
                // br.ReadInt32();
                this.Implementation = this.ReadGuid();
            }
        }

        public class GameMode : DataForgeSerializable
        {
            public String Name { get; set; }
            public String DisplayName { get; set; }
            public String Alias { get; set; }
            public String ModuleType { get; set; }
            public String PlayerToPlayerCollisionPolicy { get; set; }
            public Boolean TeamGame { get; set; }
            public Boolean UseReadOnlyDataStore { get; set; }
            public Boolean SpawnInSpaceship { get; set; }
            public Boolean DisableIFCSCruiseMode { get; set; }
            public Boolean IsSurvivalMode { get; set; }
            public Boolean UseEjectionPenalty { get; set; }
            public Boolean DisableThirdPersonCamera { get; set; }
            public Int16 Unknown { get; set; }
            public String RulesPath { get; set; }
            public String LevelLocation { get; set; }
            public Guid? MusicSuite { get; set; }
            public String AnnouncerGameModeName { get; set; }
            public String AnnouncerGameModeTokenName { get; set; }
            public Single AudioOcclusionMaDist { get; set; }
            public Boolean RequiresVisorScoreboard { get; set; }
            public Boolean RequiresRoundTimer { get; set; }
            public Guid? LoadoutProbabilities { get; set; }
            public Boolean AllowLoadoutCycling { get; set; }
            public Guid? ShipArchetypeGroup { get; set; }

            public GameMode(BinaryReader br)
                : base(br)
            {
                this.Name = this.ReadString();
                this.DisplayName = this.ReadString();
                this.Alias = this.ReadString();
                this.ModuleType = this.ReadString();
                this.PlayerToPlayerCollisionPolicy = this.ReadString();
                this.TeamGame = br.ReadBoolean();
                this.UseReadOnlyDataStore = br.ReadBoolean();
                this.SpawnInSpaceship = br.ReadBoolean();
                this.DisableIFCSCruiseMode = br.ReadBoolean();
                this.IsSurvivalMode = br.ReadBoolean();
                this.UseEjectionPenalty = br.ReadBoolean();
                this.DisableThirdPersonCamera = br.ReadBoolean();
                this.Unknown = br.ReadInt16();
                this.RulesPath = this.ReadString();
                this.LevelLocation = this.ReadString();
                this.MusicSuite = this.ReadGuid();
                this.AnnouncerGameModeName = this.ReadString();
                this.AnnouncerGameModeTokenName = this.ReadString();
                this.AudioOcclusionMaDist = br.ReadSingle();
                this.RequiresVisorScoreboard = br.ReadBoolean();
                this.RequiresRoundTimer = br.ReadBoolean();
                this.LoadoutProbabilities = this.ReadGuid();
                this.AllowLoadoutCycling = br.ReadBoolean();
                this.ShipArchetypeGroup = this.ReadGuid();
            }
        }

        public class ForceFeedback : DataForgeSerializable
        {
            public ForceFeedbackPattern[] Patterns { get; set; }
            public ForceFeedbackEnvelope[] Envelopes { get; set; }
            public ForceFeedbackEffect[] Effects { get; set; }

            public ForceFeedback(BinaryReader br)
                : base(br)
            {
                var numPatterns = br.ReadUInt32(); br.ReadUInt32();
                var numEnvelopes = br.ReadUInt32(); br.ReadUInt32();
                var numEffects = br.ReadUInt32(); br.ReadUInt32();

                this.Patterns = this.ReadArray<ForceFeedbackPattern>(numPatterns);
                this.Envelopes = this.ReadArray<ForceFeedbackEnvelope>(numEnvelopes);
                this.Effects = this.ReadArray<ForceFeedbackEffect>(numEffects);
            }
        }

        public class ForceFeedbackPattern : DataForgeSerializable
        {
            public String Name { get; set; }
            public String Samples { get; set; }

            public ForceFeedbackPattern(BinaryReader br)
                : base(br)
            {
                this.Name = this.ReadString();
                this.Samples = this.ReadString();
            }
        }

        public class ForceFeedbackEnvelope : DataForgeSerializable
        {
            public String Name { get; set; }
            public String Samples { get; set; }
            
            public ForceFeedbackEnvelope(BinaryReader br)
                : base(br)
            {
                this.Name = this.ReadString();
                this.Samples = this.ReadString();
            }
        }

        public class ForceFeedbackEffect : DataForgeSerializable
        {
            public String Name { get; set; }
            public Single Time { get; set; }

            public ForceFeedbackMotor MotorA { get; set; }
            public ForceFeedbackMotor MotorB { get; set; }
            public ForceFeedbackMotor MotorAB { get; set; }

            public ForceFeedbackEffect(BinaryReader br)
                : base(br)
            {
                this.Name = this.ReadString();
                this.Time = br.ReadSingle();

                this.MotorAB = new ForceFeedbackMotor(br);
                this.MotorA = new ForceFeedbackMotor(br);
                this.MotorB = new ForceFeedbackMotor(br);
            }
        }

        // TODO: Figure out what the values here actually mean, as they don't map to the XML 1:1
        public class ForceFeedbackMotor : DataForgeSerializable
        {
            public Int32 _NodeType { get; set; }
            public Int32 _NodeIndex { get; set; }

            public ForceFeedbackMotor(BinaryReader br)
                : base(br)
            {
                this._NodeType = br.ReadInt32();
                this._NodeIndex = br.ReadInt32();
            }
        }

        public static void Main(params String[] args)
        {
            var inFile = "Game.dcb";
            using (BinaryReader br = new BinaryReader(File.OpenRead(inFile)))
            {
                var definitions = new List<Int64[]> {
                    new Int64[] { 0x00000000, 0x04 }, // Array Sizes
                    new Int64[] { 0x0000006c, 0x84, 0x04, 0x02, 0x02, 0x04 },
                    new Int64[] { 0x00002d9b, 0x84, 0x01, 0x02, 0x02, 0x01, 0x02 },
                    new Int64[] { 0x000075b4, 0x84, 0x02, 0x02 },
                    new Int64[] { 0x000077c4, 0x02, 0x02 },
                    new Int64[] { 0x000077d0, 0x02, 0x02 },
                    new Int64[] { 0x00007cac, 0x84 /* Element Name */, 0x04 /* Type? */, 0x16 /* Hash */, 0x02 /* Index */, 0x02 /* Parent */ }, // 
                    new Int64[] { 0x0001b678, 0x04, 0x04 },
                    new Int64[] { 0x0001bab4, 0x04, 0x04 },
                    new Int64[] { 0x0001bbf8, 0x84 },
                    new Int64[] { 0x0001c054, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04 },
                    new Int64[] { 0x0002e4d4, 0x04, 0x04, 0x04, 0x04, 0x04 },
                    new Int64[] { 0x0002e7cc, 0x84 },
                    new Int64[] { 0x0002f1dc, 0x80 }, // String Table
                    new Int64[] { 0x00096027, 0x84, 0x84 },
                    new Int64[] { 0x0009608b, 0x04, 0x04, }, // Somewhere here is a 0x04, 0x04, 0x04, 0x04, 0x04 struct
                    new Int64[] { 0x00097433, 0x84, 0x84 },
                    new Int64[] { 0x000977eb, 0x04 },
                    new Int64[] { 0x0009781f, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04 },
                    new Int64[] { 0x0009785f, 0x04, 0x04, 0x04, 0x04 },
                    new Int64[] { 0x00097e0b, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04 },
                    new Int64[] { 0x00097f27, 0x04, 0x04 },
                    new Int64[] { 0x000d2087, 0x01 },
                    new Int64[] { 0x000d20e0, 0x84, 0x84 },
                    new Int64[] { 0x000d21c0, 0x04, 0x04 },
                    new Int64[] { 0x000d21d8, 0x84, 0x84 }, // ForceFeedback.ForceFeedbackEffects > Patterns > ForceFeedbackPattern
                    new Int64[] { 0x000d2248, 0x84, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 0x04 },
                    new Int64[] { 0x000d2588, 0x04, 0x84, 0x84 },
                    new Int64[] {
                        0x000d2738, // GameRules.sch | 0x000001EF
                        0x84, // string name
                        0x84, // string displayName
                        0x84, // string alias
                        0x84, // EModuleType moduleType
                        0x84, // EPlayerToPlayerCollisionPolicy playerToPlayerCollisionPolicy
                        0x01, // bool teamGame
                        0x01, // bool useReadOnlyDataStore
                        0x01, // bool spawnInSpaceship
                        0x01, // bool disableIFCSCruiseMode
                        0x01, // bool isSurvivalMode
                        0x01, // bool useEjectionPenalty
                        0x01, // bool disableThirdPersonCamera
                        0x02, // MusicSuite unknown1
                        0x84, // string rulesPath
                        0x84, // string levelLocation
                        0x26, // guid musicSuite
                        0x84, // string announcerGameModeName 
                        0x84, // string announcerGameModeTokenName
                        0x44, // float audioOcclusionMaxDist
                        0x01, // bool requiresVisorScoreboard 
                        0x01, // bool requiresRoundTimer
                        0x26, // LoadoutProbabilities& loadoutProbabilities 
                        0x01, // bool allowLoadoutCycling 
                        0x26, // ShipArchetypeGroup& invalidShipGroup
                    },
                    // new Int64[] { 0x000d2738, 0x84, 0x84, 0x84, 0x84, 0x84, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x01, 0x84, 0x84, 0x04, 0x04, 0x04, 0x04, 0x04, 0x84, 0x84, 0x01, 0x01, 0x04, 0x26, 0x01, 0x26 },
                    new Int64[] { 0x000d2f88, 0x84, 0x84 },
                    new Int64[] { 0x000d3410, 0x04 },
                    new Int64[] { 0x000d3414, 0x84, 0x04, 0x04, 0x04, 0x04 },
                    new Int64[] { 0x000d3458, 0x84, 0x84 },
                    
                    // new Int64[] {
                    //     0x000d3414, // GOSTEntity_Schema.sch | 0x00001F41
                    //     0x84, // string name
                    // 
                    // },
                    new Int64[] { 0x000d5a94, 0x02 },
                    new Int64[] { 0x000d5aa2, 0x84, 0x84 },
                    new Int64[] { 0x000d6412, 0x02 },
                    new Int64[] { 0x000d6438, 0x84 },
                    new Int64[] { 0x000df844, 0x84, 0x04, 0x04, 0x04, 0x04 },
                    new Int64[] { 0x000df880, 0x84, 0x04 },
                    new Int64[] { 0x000dfc58, 0x04, 0x04 },
                    new Int64[] { 0x000E0018, 0x04, 0x04, 0x04 },
                    // new Int64[] { 0x000D33FC, 0x04, 0x04 },
                    new Int64[] { 0x000E0270, 0x04 },
                    new Int64[] { 0x000e0280,
                        0x84, // Name
                        0x04, // Manufacturer Type
                        0x04, // Manufacturer Offset
                    }, // Manufacturers
                    // new Int64[] { 0x000e02ec, 0x04 },
                    new Int64[] { 0x000e0300, // HudColors
                        0x84, // Name
                        0x04, // Flash Color Type
                        0x04, // Flash Color Index
                        0x03, // Diffuse
                        0x03, // Emmisive
                        0x03, // RimColor
                        0x03, // SilhouetteColor
                        0x04, // Texture Type
                        0x04  // Texture Index
                    }, // ShipColorPalettes
                    new Int64[] { 0x000E10E4,
                        0x84, // 
                        0x04, // 
                    },
                    new Int64[] { 0x000E1F04,
                        0x84, // 
                        0x04, // 
                    },
                    new Int64[] { br.BaseStream.Length },
                };

                var df = new DataForge(br);

                br.BaseStream.Seek(0x0001B678, SeekOrigin.Begin);
                
                for (Int32 i = 0, j = definitions.Count; i < j - 1; i++)
                {
                    var k = 0;
                    while (br.BaseStream.Position >= definitions[i][0] &&
                        br.BaseStream.Position < definitions[i + 1][0] &&
                        br.BaseStream.Position < br.BaseStream.Length - 0x20)
                    {
                        Console.Write("0x{0:X8} ", br.BaseStream.Position);
                        Console.Write("0x{0:X8} ", br.BaseStream.Position - definitions[i][0]);
                        Console.Write("0x{0:X6}: ", k++);

                        Object data = null;
                        String format = "{0} ";

                        for (Int32 l = 1, m = definitions[i].Length; l < m; l++)
                        {
                            var width = definitions[i][l];
                            var isNull = false;

                            if ((width & 0x20) == 0x20)
                            {
                                isNull = br.ReadInt32() == -1;
                            }

                            switch (width)
                            {
                                case 0x00:
                                    format = "| ";
                                    data = "";
                                    break;
                                case 0x80:
                                    format = @"""{0}"" ";
                                    data = (br.ReadCString() ?? String.Empty).Replace("\r", "\\r").Replace("\n", "\\n");
                                    break;
                                case 0x81:
                                case 0x01: 
                                    format = "0x{0:X2} ";
                                    data = br.ReadByte();
                                    break;
                                case 0x82:
                                case 0x02: 
                                    format = "0x{0:X4} ";
                                    data = br.ReadInt16();
                                    break;
                                case 0x03:
                                    format = "#{0} ";
                                    data = String.Format("{0:X2}{1:X2}{2:X2}", br.ReadByte(), br.ReadByte(), br.ReadByte());
                                    break;
                                case 0x84:
                                case 0x04: 
                                    format = "0x{0:X8} ";
                                    data = br.ReadInt32();
                                    break;
                                case 0x44:
                                    format = "{0} ";
                                    data = br.ReadSingle();
                                    break;
                                case 0x88:
                                case 0x08: 
                                    format = "0x{0:X16} ";
                                    data = br.ReadInt64();
                                    break;
                                case 0x48:
                                    format = "{0} ";
                                    data = br.ReadDouble();
                                    break;
                                case 0x26:
                                case 0x16:
                                    format = "{0} ";
                                    var p3 = br.ReadInt16();
                                    var p2 = br.ReadInt16();
                                    var p1 = br.ReadInt32();
                                    var p4 = br.ReadByte();
                                    var p5 = br.ReadByte();
                                    var p6 = br.ReadByte();
                                    var p7 = br.ReadByte();
                                    var p8 = br.ReadByte();
                                    var p9 = br.ReadByte();
                                    var p10 = br.ReadByte();
                                    var p11 = br.ReadByte();
                                    data = new Guid(p1, p2, p3, p11, p10, p9, p8, p7, p6, p5, p4);
                                    break;
                            }

                            if (isNull)
                            {
                                data = null;
                            }

                            if ((width & 0x80) == 0x80 && (width != 0x80))
                            {
                                var stringOffset = (data as Int64? ?? data as Int32? ?? data as Int16? ?? -1);

                                if (stringOffset <= 0x00066E19 &&
                                    stringOffset >= 0x00000000)
                                {
                                    var oldPos = br.BaseStream.Position;
                                    br.BaseStream.Seek(stringOffset + 0x0002F1DC, SeekOrigin.Begin);
                                    Console.Write(@"[{0}] ", (br.ReadCString() ?? String.Empty).Replace("\r", "\\r").Replace("\n", "\\n"));
                                    br.BaseStream.Seek(oldPos, SeekOrigin.Begin);
                                }
                                else if (stringOffset == -1)
                                {
                                    Console.Write("[__NULL__] ");
                                }
                                else
                                {
                                    Console.Write("[__{0:X8}__] ", data);
                                }
                            }
                            else
                            {
                                Console.Write(format, data ?? "NULL");
                            }
                        }

                        Console.WriteLine();
                    }
                    Console.WriteLine("Total Records: 0x{0:X8}", k);
                    Console.WriteLine();
                }
            }

            // Console.ReadKey();
        }

        public static void XmlBin(params String[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                Console.WriteLine("Usage: HoloXPLOR.DataForge.exe [infile]");
                Console.WriteLine();
                Console.WriteLine("Converts an SC binary `xml` file into an actual XML file, and saves it as a .raw file in the original location");
                return;
            }


            try
            {
                if (File.Exists(args[0]))
                {
                    var xml = CryXmlSerializer.ReadFile(args[0], args.Length == 2);
                    xml.Save(Path.ChangeExtension(args[0], "raw"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error converting {0}: {1}", args[0], ex.Message);
            }
        }
    }
}