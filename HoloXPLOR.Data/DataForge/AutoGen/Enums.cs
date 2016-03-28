using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    public enum ActorBone
    {
        [XmlEnum(Name = "Hips")]
        _Hips,
        [XmlEnum(Name = "Spine")]
        _Spine,
        [XmlEnum(Name = "Spine2")]
        _Spine2,
        [XmlEnum(Name = "Spine3")]
        _Spine3,
        [XmlEnum(Name = "Head")]
        _Head,
        [XmlEnum(Name = "EyeRight")]
        _EyeRight,
        [XmlEnum(Name = "EyeLeft")]
        _EyeLeft,
        [XmlEnum(Name = "Weapon")]
        _Weapon,
        [XmlEnum(Name = "Weapon2")]
        _Weapon2,
        [XmlEnum(Name = "FootRight")]
        _FootRight,
        [XmlEnum(Name = "FootLeft")]
        _FootLeft,
        [XmlEnum(Name = "ArmRight")]
        _ArmRight,
        [XmlEnum(Name = "ArmLeft")]
        _ArmLeft,
        [XmlEnum(Name = "ForearmRight")]
        _ForearmRight,
        [XmlEnum(Name = "ForearmLeft")]
        _ForearmLeft,
        [XmlEnum(Name = "CalfRight")]
        _CalfRight,
        [XmlEnum(Name = "CalfLeft")]
        _CalfLeft,
        [XmlEnum(Name = "Camera")]
        _Camera,
    }
    public enum AmmoSpawnType
    {
        [XmlEnum(Name = "AllClients")]
        _AllClients,
        [XmlEnum(Name = "ServerReplicated")]
        _ServerReplicated,
    }
    public enum BehaviorTree_GroupCategory
    {
        [XmlEnum(Name = "Wave")]
        _Wave,
        [XmlEnum(Name = "Territory")]
        _Territory,
        [XmlEnum(Name = "MyActionBubble")]
        _MyActionBubble,
        [XmlEnum(Name = "MySquad")]
        _MySquad,
    }
    public enum BehaviorTree_GroupSignal
    {
        [XmlEnum(Name = "OnGroupMemberEnteredCombat")]
        _OnGroupMemberEnteredCombat,
        [XmlEnum(Name = "OnNoThreatFoundAtDangerousSoundLocation")]
        _OnNoThreatFoundAtDangerousSoundLocation,
    }
    public enum BehaviorTree_CharacterSpeed
    {
        [XmlEnum(Name = "Slow")]
        _Slow,
        [XmlEnum(Name = "Walk")]
        _Walk,
        [XmlEnum(Name = "Run")]
        _Run,
        [XmlEnum(Name = "Sprint")]
        _Sprint,
    }
    public enum BehaviorTree_CharacterStance
    {
        [XmlEnum(Name = "Stand")]
        _Stand,
        [XmlEnum(Name = "Duck")]
        _Duck,
        [XmlEnum(Name = "VehicleSeat")]
        _VehicleSeat,
        [XmlEnum(Name = "Crouch")]
        _Crouch,
        [XmlEnum(Name = "Prone")]
        _Prone,
        [XmlEnum(Name = "Relaxed")]
        _Relaxed,
        [XmlEnum(Name = "Stealth")]
        _Stealth,
        [XmlEnum(Name = "Alerted")]
        _Alerted,
        [XmlEnum(Name = "LowCover")]
        _LowCover,
        [XmlEnum(Name = "HighCover")]
        _HighCover,
        [XmlEnum(Name = "Swim")]
        _Swim,
        [XmlEnum(Name = "MagBoots")]
        _MagBoots,
        [XmlEnum(Name = "BodyDrag")]
        _BodyDrag,
    }
    public enum BehaviorTree_SignalResponse
    {
        [XmlEnum(Name = "Success")]
        _Success,
        [XmlEnum(Name = "Failed")]
        _Failed,
        [XmlEnum(Name = "Exit")]
        _Exit,
        [XmlEnum(Name = "Interrupted")]
        _Interrupted,
        [XmlEnum(Name = "Unhandled")]
        _Unhandled,
    }
    public enum eCommunicationChoiceMethod
    {
        [XmlEnum(Name = "Random")]
        _Random,
        [XmlEnum(Name = "Sequence")]
        _Sequence,
        [XmlEnum(Name = "RandomSequence")]
        _RandomSequence,
    }
    public enum eCommunicationChannelType
    {
        [XmlEnum(Name = "Global")]
        _Global,
        [XmlEnum(Name = "Group")]
        _Group,
        [XmlEnum(Name = "Personal")]
        _Personal,
    }
    public enum eContextualCommunicationConcept
    {
        [XmlEnum(Name = "Custom")]
        _Custom,
        [XmlEnum(Name = "OnIdleChatter")]
        _OnIdleChatter,
        [XmlEnum(Name = "OnHit")]
        _OnHit,
        [XmlEnum(Name = "OnVehicleHit")]
        _OnVehicleHit,
        [XmlEnum(Name = "OnFriendlyDied")]
        _OnFriendlyDied,
        [XmlEnum(Name = "OnFriendlyKilledEnemy")]
        _OnFriendlyKilledEnemy,
        [XmlEnum(Name = "OnTargetKilled")]
        _OnTargetKilled,
        [XmlEnum(Name = "OnVehiclePartDestroyed")]
        _OnVehiclePartDestroyed,
        [XmlEnum(Name = "OnRespawn")]
        _OnRespawn,
        [XmlEnum(Name = "OnKilled")]
        _OnKilled,
        [XmlEnum(Name = "OnVehicleEnemySpotted")]
        _OnVehicleEnemySpotted,
        [XmlEnum(Name = "OnVehicleEnemyMissileLockingOn")]
        _OnVehicleEnemyMissileLockingOn,
        [XmlEnum(Name = "OnVehicleEnemyMissileLockedOn")]
        _OnVehicleEnemyMissileLockedOn,
        [XmlEnum(Name = "OnVehicleEnemyMissileLockLost")]
        _OnVehicleEnemyMissileLockLost,
        [XmlEnum(Name = "OnVehicleEnemyMissileLaunched")]
        _OnVehicleEnemyMissileLaunched,
        [XmlEnum(Name = "OnVehicleMissileLockingOn")]
        _OnVehicleMissileLockingOn,
        [XmlEnum(Name = "OnVehicleMissileLaunched")]
        _OnVehicleMissileLaunched,
        [XmlEnum(Name = "OnResponseFinished")]
        _OnResponseFinished,
    }
    public enum eCommunicationCriteriaOperant
    {
        [XmlEnum(Name = "None")]
        _None,
        [XmlEnum(Name = "Equals")]
        _Equals,
        [XmlEnum(Name = "LessThan")]
        _LessThan,
        [XmlEnum(Name = "LessThanOrEquals")]
        _LessThanOrEquals,
        [XmlEnum(Name = "GreaterThan")]
        _GreaterThan,
        [XmlEnum(Name = "GreaterThanOrEquals")]
        _GreaterThanOrEquals,
    }
    public enum eContextualCommunicationCriteria
    {
        [XmlEnum(Name = "Custom")]
        _Custom,
        [XmlEnum(Name = "Who")]
        _Who,
        [XmlEnum(Name = "LevelName")]
        _LevelName,
        [XmlEnum(Name = "LastResponse")]
        _LastResponse,
        [XmlEnum(Name = "LastDialog")]
        _LastDialog,
        [XmlEnum(Name = "Vehicle")]
        _Vehicle,
        [XmlEnum(Name = "VehicleHealth")]
        _VehicleHealth,
        [XmlEnum(Name = "VehicleShield")]
        _VehicleShield,
        [XmlEnum(Name = "VehicleSpeed")]
        _VehicleSpeed,
        [XmlEnum(Name = "VehicleHitTime")]
        _VehicleHitTime,
        [XmlEnum(Name = "VehicleHitShield")]
        _VehicleHitShield,
        [XmlEnum(Name = "VehicleHitDamage")]
        _VehicleHitDamage,
        [XmlEnum(Name = "VehicleStartFireTime")]
        _VehicleStartFireTime,
        [XmlEnum(Name = "VehicleStopFireTime")]
        _VehicleStopFireTime,
        [XmlEnum(Name = "VehicleFiringWeapons")]
        _VehicleFiringWeapons,
        [XmlEnum(Name = "Attacker_Vehicle")]
        _Attacker_Vehicle,
        [XmlEnum(Name = "Attacker_VehicleHealth")]
        _Attacker_VehicleHealth,
        [XmlEnum(Name = "Attacker_VehicleShield")]
        _Attacker_VehicleShield,
        [XmlEnum(Name = "Attacker_VehicleSpeed")]
        _Attacker_VehicleSpeed,
        [XmlEnum(Name = "Attacker_VehicleFiringWeapons")]
        _Attacker_VehicleFiringWeapons,
        [XmlEnum(Name = "Target_Vehicle")]
        _Target_Vehicle,
        [XmlEnum(Name = "Target_VehicleHealth")]
        _Target_VehicleHealth,
        [XmlEnum(Name = "Target_VehicleShield")]
        _Target_VehicleShield,
        [XmlEnum(Name = "Target_VehicleSpeed")]
        _Target_VehicleSpeed,
        [XmlEnum(Name = "Target_VehicleFiringWeapons")]
        _Target_VehicleFiringWeapons,
        [XmlEnum(Name = "ActorHealth")]
        _ActorHealth,
        [XmlEnum(Name = "IsDriving")]
        _IsDriving,
        [XmlEnum(Name = "IsOnFoot")]
        _IsOnFoot,
        [XmlEnum(Name = "IsEjecting")]
        _IsEjecting,
        [XmlEnum(Name = "IsEjected")]
        _IsEjected,
        [XmlEnum(Name = "IsDead")]
        _IsDead,
        [XmlEnum(Name = "Attacker_Who")]
        _Attacker_Who,
        [XmlEnum(Name = "Attacker_ActorHealth")]
        _Attacker_ActorHealth,
        [XmlEnum(Name = "Attacker_IsDriving")]
        _Attacker_IsDriving,
        [XmlEnum(Name = "Attacker_IsOnFoot")]
        _Attacker_IsOnFoot,
        [XmlEnum(Name = "Attacker_IsEjecting")]
        _Attacker_IsEjecting,
        [XmlEnum(Name = "Attacker_IsEjected")]
        _Attacker_IsEjected,
        [XmlEnum(Name = "Attacker_IsDead")]
        _Attacker_IsDead,
        [XmlEnum(Name = "Attacker_IsFriendly")]
        _Attacker_IsFriendly,
        [XmlEnum(Name = "Target_Who")]
        _Target_Who,
        [XmlEnum(Name = "Target_ActorHealth")]
        _Target_ActorHealth,
        [XmlEnum(Name = "Target_IsDriving")]
        _Target_IsDriving,
        [XmlEnum(Name = "Target_IsOnFoot")]
        _Target_IsOnFoot,
        [XmlEnum(Name = "Target_IsEjecting")]
        _Target_IsEjecting,
        [XmlEnum(Name = "Target_IsEjected")]
        _Target_IsEjected,
        [XmlEnum(Name = "Target_IsDead")]
        _Target_IsDead,
        [XmlEnum(Name = "Target_IsFriendly")]
        _Target_IsFriendly,
    }
    public enum CtxGraph_ContextActionType
    {
        [XmlEnum(Name = "Load")]
        _Load,
        [XmlEnum(Name = "Unload")]
        _Unload,
        [XmlEnum(Name = "Enter")]
        _Enter,
        [XmlEnum(Name = "Leave")]
        _Leave,
        [XmlEnum(Name = "Unfocus")]
        _Unfocus,
        [XmlEnum(Name = "Focus")]
        _Focus,
    }
    public enum EReputation
    {
        [XmlEnum(Name = "Good")]
        _Good,
        [XmlEnum(Name = "Average")]
        _Average,
        [XmlEnum(Name = "Poor")]
        _Poor,
    }
    public enum EReputationType
    {
        [XmlEnum(Name = "Military")]
        _Military,
    }
    public enum EConversationFragmentID
    {
        [XmlEnum(Name = "Conversation")]
        _Conversation,
        [XmlEnum(Name = "ConversationFacial")]
        _ConversationFacial,
        [XmlEnum(Name = "story_e1c04")]
        _story_e1c04,
    }
    public enum EFacialAnim
    {
        [XmlEnum(Name = "Neutral")]
        _Neutral,
        [XmlEnum(Name = "Happy")]
        _Happy,
        [XmlEnum(Name = "Sad")]
        _Sad,
        [XmlEnum(Name = "Angry")]
        _Angry,
        [XmlEnum(Name = "Intense")]
        _Intense,
        [XmlEnum(Name = "Interested")]
        _Interested,
    }
    public enum EGestureAnim
    {
        [XmlEnum(Name = "NodHead")]
        _NodHead,
        [XmlEnum(Name = "ShakeHead")]
        _ShakeHead,
    }
    public enum EConversationHubLinkType
    {
        [XmlEnum(Name = "First")]
        _First,
        [XmlEnum(Name = "Random")]
        _Random,
        [XmlEnum(Name = "RandomCanRepeat")]
        _RandomCanRepeat,
    }
    public enum FriendyFireType
    {
        [XmlEnum(Name = "None")]
        _None,
        [XmlEnum(Name = "Self")]
        _Self,
        [XmlEnum(Name = "Team")]
        _Team,
    }
    public enum EDynamicCameraEffectsContext
    {
        [XmlEnum(Name = "OnFoot")]
        _OnFoot,
        [XmlEnum(Name = "Conversation")]
        _Conversation,
        [XmlEnum(Name = "VehicleSeat")]
        _VehicleSeat,
        [XmlEnum(Name = "MobiGlass")]
        _MobiGlass,
        [XmlEnum(Name = "HintActive")]
        _HintActive,
    }
    public enum EDynamicCameraEffectsSubContext
    {
        [XmlEnum(Name = "Default")]
        _Default,
        [XmlEnum(Name = "TargetZoomed")]
        _TargetZoomed,
        [XmlEnum(Name = "LookAround")]
        _LookAround,
        [XmlEnum(Name = "LookAroundZoomed")]
        _LookAroundZoomed,
        [XmlEnum(Name = "LookAroundCockpitZoomed")]
        _LookAroundCockpitZoomed,
        [XmlEnum(Name = "ScreenFocus")]
        _ScreenFocus,
    }
    public enum EDynamicCameraEffectsFocusMode
    {
        [XmlEnum(Name = "UsingMinMax")]
        _UsingMinMax,
        [XmlEnum(Name = "NotUsingMinMax")]
        _NotUsingMinMax,
    }
    public enum EParticleInputs
    {
        [XmlEnum(Name = "Count")]
        _Count,
        [XmlEnum(Name = "Size")]
        _Size,
        [XmlEnum(Name = "Speed")]
        _Speed,
        [XmlEnum(Name = "Time")]
        _Time,
        [XmlEnum(Name = "Pulse")]
        _Pulse,
        [XmlEnum(Name = "Strength")]
        _Strength,
        [XmlEnum(Name = "Scale")]
        _Scale,
        [XmlEnum(Name = "Diffuse")]
        _Diffuse,
        [XmlEnum(Name = "Radius")]
        _Radius,
        [XmlEnum(Name = "UNDEFINED")]
        _UNDEFINED,
    }
    public enum ELightInputs
    {
        [XmlEnum(Name = "Radius")]
        _Radius,
        [XmlEnum(Name = "DiffuseMult")]
        _DiffuseMult,
        [XmlEnum(Name = "SpecularMult")]
        _SpecularMult,
        [XmlEnum(Name = "UNDEFINED")]
        _UNDEFINED,
    }
    public enum EMaterialInputs
    {
        [XmlEnum(Name = "FloatParam")]
        _FloatParam,
        [XmlEnum(Name = "VecParam")]
        _VecParam,
        [XmlEnum(Name = "UNDEFINED")]
        _UNDEFINED,
    }
    public enum ESoundInputs
    {
        [XmlEnum(Name = "FloatParam")]
        _FloatParam,
        [XmlEnum(Name = "Enable")]
        _Enable,
        [XmlEnum(Name = "Disable")]
        _Disable,
        [XmlEnum(Name = "UNDEFINED")]
        _UNDEFINED,
    }
    public enum EJointInputs
    {
        [XmlEnum(Name = "Rotation")]
        _Rotation,
        [XmlEnum(Name = "Offset")]
        _Offset,
        [XmlEnum(Name = "UNDEFINED")]
        _UNDEFINED,
    }
    public enum EPipePriorityGroup
    {
        [XmlEnum(Name = "Weapon")]
        _Weapon,
        [XmlEnum(Name = "Shield")]
        _Shield,
        [XmlEnum(Name = "Thruster")]
        _Thruster,
        [XmlEnum(Name = "Other")]
        _Other,
    }
    public enum EPipePriorityType
    {
        [XmlEnum(Name = "Critical")]
        _Critical,
        [XmlEnum(Name = "Aux")]
        _Aux,
        [XmlEnum(Name = "Manageable")]
        _Manageable,
    }
    public enum EPipeClass
    {
        [XmlEnum(Name = "Power")]
        _Power,
        [XmlEnum(Name = "Heat")]
        _Heat,
        [XmlEnum(Name = "Avionics")]
        _Avionics,
        [XmlEnum(Name = "Fuel")]
        _Fuel,
        [XmlEnum(Name = "Oxygen")]
        _Oxygen,
        [XmlEnum(Name = "Shield")]
        _Shield,
        [XmlEnum(Name = "Decibel")]
        _Decibel,
        [XmlEnum(Name = "Charge")]
        _Charge,
        [XmlEnum(Name = "Health")]
        _Health,
        [XmlEnum(Name = "Input")]
        _Input,
        [XmlEnum(Name = "Output")]
        _Output,
        [XmlEnum(Name = "UNDEFINED")]
        _UNDEFINED,
    }
    public enum EPipeValueType
    {
        [XmlEnum(Name = "Pool")]
        _Pool,
        [XmlEnum(Name = "Total")]
        _Total,
        [XmlEnum(Name = "NoPool")]
        _NoPool,
        [XmlEnum(Name = "Critical")]
        _Critical,
    }
    public enum EPipeStateValType
    {
        [XmlEnum(Name = "Normal")]
        _Normal,
        [XmlEnum(Name = "OtherPipe")]
        _OtherPipe,
    }
    public enum EModuleType
    {
        [XmlEnum(Name = "PersistentUniverse")]
        _PersistentUniverse,
        [XmlEnum(Name = "ArenaCommander")]
        _ArenaCommander,
        [XmlEnum(Name = "StarMarine")]
        _StarMarine,
        [XmlEnum(Name = "Squadron42")]
        _Squadron42,
    }
    public enum EPlayerToPlayerCollisionPolicy
    {
        [XmlEnum(Name = "EnabledAlways")]
        _EnabledAlways,
        [XmlEnum(Name = "DisableAlways")]
        _DisableAlways,
        [XmlEnum(Name = "EnableAfterSpawn")]
        _EnableAfterSpawn,
    }
    public enum EGOSTVariableType
    {
        [XmlEnum(Name = "int")]
        _int,
        [XmlEnum(Name = "float")]
        _float,
        [XmlEnum(Name = "EntityId")]
        _EntityId,
        [XmlEnum(Name = "Vec3")]
        _Vec3,
        [XmlEnum(Name = "string")]
        _string,
        [XmlEnum(Name = "bool")]
        _bool,
    }
    public enum HUDSilhouetteMode
    {
        [XmlEnum(Name = "ARLabel")]
        _ARLabel,
    }
    public enum EItemPortAttachImplType
    {
        [XmlEnum(Name = "Bone")]
        _Bone,
        [XmlEnum(Name = "Skin")]
        _Skin,
        [XmlEnum(Name = "Face")]
        _Face,
    }
    public enum EItemPipeType
    {
        [XmlEnum(Name = "Dynamic")]
        _Dynamic,
        [XmlEnum(Name = "Binary")]
        _Binary,
    }
    public enum EItemType
    {
        [XmlEnum(Name = "AIModule")]
        _AIModule,
        [XmlEnum(Name = "AmmoBox")]
        _AmmoBox,
        [XmlEnum(Name = "AmmoCrate")]
        _AmmoCrate,
        [XmlEnum(Name = "Armor")]
        _Armor,
        [XmlEnum(Name = "Audio")]
        _Audio,
        [XmlEnum(Name = "Avionics")]
        _Avionics,
        [XmlEnum(Name = "Battery")]
        _Battery,
        [XmlEnum(Name = "BodyArmor")]
        _BodyArmor,
        [XmlEnum(Name = "Bottle")]
        _Bottle,
        [XmlEnum(Name = "Cargo")]
        _Cargo,
        [XmlEnum(Name = "Container")]
        _Container,
        [XmlEnum(Name = "Cooler")]
        _Cooler,
        [XmlEnum(Name = "Debris")]
        _Debris,
        [XmlEnum(Name = "Display")]
        _Display,
        [XmlEnum(Name = "FuelTank")]
        _FuelTank,
        [XmlEnum(Name = "FuelIntake")]
        _FuelIntake,
        [XmlEnum(Name = "Gadget")]
        _Gadget,
        [XmlEnum(Name = "GravityGenerator")]
        _GravityGenerator,
        [XmlEnum(Name = "HumanArmor_Feet")]
        _HumanArmor_Feet,
        [XmlEnum(Name = "HumanArmor_Helmet")]
        _HumanArmor_Helmet,
        [XmlEnum(Name = "HumanArmor_Legs")]
        _HumanArmor_Legs,
        [XmlEnum(Name = "HumanArmor_Torso")]
        _HumanArmor_Torso,
        [XmlEnum(Name = "HumanCloth_Feet")]
        _HumanCloth_Feet,
        [XmlEnum(Name = "HumanCloth_Hands")]
        _HumanCloth_Hands,
        [XmlEnum(Name = "HumanCloth_Legs")]
        _HumanCloth_Legs,
        [XmlEnum(Name = "HumanCloth_Torso0")]
        _HumanCloth_Torso0,
        [XmlEnum(Name = "HumanCloth_Torso1")]
        _HumanCloth_Torso1,
        [XmlEnum(Name = "HumanSkin_Arms")]
        _HumanSkin_Arms,
        [XmlEnum(Name = "HumanSkin_Eyes")]
        _HumanSkin_Eyes,
        [XmlEnum(Name = "HumanSkin_Feet")]
        _HumanSkin_Feet,
        [XmlEnum(Name = "HumanSkin_Hair")]
        _HumanSkin_Hair,
        [XmlEnum(Name = "HumanSkin_Hands")]
        _HumanSkin_Hands,
        [XmlEnum(Name = "HumanSkin_Head")]
        _HumanSkin_Head,
        [XmlEnum(Name = "HumanSkin_Legs")]
        _HumanSkin_Legs,
        [XmlEnum(Name = "HumanSkin_Torso")]
        _HumanSkin_Torso,
        [XmlEnum(Name = "HumanWear_Eye")]
        _HumanWear_Eye,
        [XmlEnum(Name = "HumanWear_Head")]
        _HumanWear_Head,
        [XmlEnum(Name = "HumanWear_Mask")]
        _HumanWear_Mask,
        [XmlEnum(Name = "Interior")]
        _Interior,
        [XmlEnum(Name = "JumpDrive")]
        _JumpDrive,
        [XmlEnum(Name = "Light")]
        _Light,
        [XmlEnum(Name = "LiveSupport")]
        _LiveSupport,
        [XmlEnum(Name = "MainThruster")]
        _MainThruster,
        [XmlEnum(Name = "ManneuverThruster")]
        _ManneuverThruster,
        [XmlEnum(Name = "Missile")]
        _Missile,
        [XmlEnum(Name = "Misc")]
        _Misc,
        [XmlEnum(Name = "Ordinance")]
        _Ordinance,
        [XmlEnum(Name = "Player")]
        _Player,
        [XmlEnum(Name = "PowerPlant")]
        _PowerPlant,
        [XmlEnum(Name = "Radar")]
        _Radar,
        [XmlEnum(Name = "Room")]
        _Room,
        [XmlEnum(Name = "Seat")]
        _Seat,
        [XmlEnum(Name = "SelfDestruct")]
        _SelfDestruct,
        [XmlEnum(Name = "Shield")]
        _Shield,
        [XmlEnum(Name = "Ship")]
        _Ship,
        [XmlEnum(Name = "ShopDisplay")]
        _ShopDisplay,
        [XmlEnum(Name = "Suit")]
        _Suit,
        [XmlEnum(Name = "Turret")]
        _Turret,
        [XmlEnum(Name = "TurretBase")]
        _TurretBase,
        [XmlEnum(Name = "Visor")]
        _Visor,
        [XmlEnum(Name = "WeaponAttachment")]
        _WeaponAttachment,
        [XmlEnum(Name = "WeaponDefensive")]
        _WeaponDefensive,
        [XmlEnum(Name = "WeaponGun")]
        _WeaponGun,
        [XmlEnum(Name = "WeaponPersonal")]
        _WeaponPersonal,
        [XmlEnum(Name = "WeaponMissile")]
        _WeaponMissile,
        [XmlEnum(Name = "MobiGlas")]
        _MobiGlas,
        [XmlEnum(Name = "Paints")]
        _Paints,
        [XmlEnum(Name = "MultiLight")]
        _MultiLight,
        [XmlEnum(Name = "LandingSystem")]
        _LandingSystem,
        [XmlEnum(Name = "Grenade")]
        _Grenade,
        [XmlEnum(Name = "Magazine")]
        _Magazine,
        [XmlEnum(Name = "Cloth")]
        _Cloth,
        [XmlEnum(Name = "LifeSupport")]
        _LifeSupport,
        [XmlEnum(Name = "MainEngine")]
        _MainEngine,
        [XmlEnum(Name = "QuantumFuelTank")]
        _QuantumFuelTank,
        [XmlEnum(Name = "UNDEFINED")]
        _UNDEFINED,
    }
    public enum EItemSubType
    {
        [XmlEnum(Name = "ADSComputer")]
        _ADSComputer,
        [XmlEnum(Name = "Ammo_1000mm")]
        _Ammo_1000mm,
        [XmlEnum(Name = "Ammo_20mm")]
        _Ammo_20mm,
        [XmlEnum(Name = "Ammo_24mm")]
        _Ammo_24mm,
        [XmlEnum(Name = "Ammo_25mm")]
        _Ammo_25mm,
        [XmlEnum(Name = "Ammo_30mm")]
        _Ammo_30mm,
        [XmlEnum(Name = "Ammo_35mm")]
        _Ammo_35mm,
        [XmlEnum(Name = "Ammo_40mm")]
        _Ammo_40mm,
        [XmlEnum(Name = "Ammo_50mm")]
        _Ammo_50mm,
        [XmlEnum(Name = "Ammo_60mm")]
        _Ammo_60mm,
        [XmlEnum(Name = "Ammo_Rail_60mm")]
        _Ammo_Rail_60mm,
        [XmlEnum(Name = "Ammo_Rail_80mm")]
        _Ammo_Rail_80mm,
        [XmlEnum(Name = "AmmoBox_Ballistic_120rd_106mm_exp")]
        _AmmoBox_Ballistic_120rd_106mm_exp,
        [XmlEnum(Name = "Armor")]
        _Armor,
        [XmlEnum(Name = "Autopilot")]
        _Autopilot,
        [XmlEnum(Name = "Awesome")]
        _Awesome,
        [XmlEnum(Name = "BallTurret")]
        _BallTurret,
        [XmlEnum(Name = "BottomTurret")]
        _BottomTurret,
        [XmlEnum(Name = "CanardTurret")]
        _CanardTurret,
        [XmlEnum(Name = "Cargo")]
        _Cargo,
        [XmlEnum(Name = "Cockpit_Audio")]
        _Cockpit_Audio,
        [XmlEnum(Name = "Constellation")]
        _Constellation,
        [XmlEnum(Name = "CountermeasureLauncher")]
        _CountermeasureLauncher,
        [XmlEnum(Name = "CPU")]
        _CPU,
        [XmlEnum(Name = "Default")]
        _Default,
        [XmlEnum(Name = "delta")]
        _delta,
        [XmlEnum(Name = "External")]
        _External,
        [XmlEnum(Name = "EyeWare")]
        _EyeWare,
        [XmlEnum(Name = "FixedThruster")]
        _FixedThruster,
        [XmlEnum(Name = "Flashlight")]
        _Flashlight,
        [XmlEnum(Name = "FlexThruster")]
        _FlexThruster,
        [XmlEnum(Name = "Fuel")]
        _Fuel,
        [XmlEnum(Name = "Gadget")]
        _Gadget,
        [XmlEnum(Name = "ghostHornet")]
        _ghostHornet,
        [XmlEnum(Name = "Grapple")]
        _Grapple,
        [XmlEnum(Name = "Grenade")]
        _Grenade,
        [XmlEnum(Name = "Gun")]
        _Gun,
        [XmlEnum(Name = "GunTurret")]
        _GunTurret,
        [XmlEnum(Name = "Hat")]
        _Hat,
        [XmlEnum(Name = "Helmet")]
        _Helmet,
        [XmlEnum(Name = "Heavy")]
        _Heavy,
        [XmlEnum(Name = "Idris")]
        _Idris,
        [XmlEnum(Name = "Idris_Turret")]
        _Idris_Turret,
        [XmlEnum(Name = "Interior_Audio")]
        _Interior_Audio,
        [XmlEnum(Name = "IronSight")]
        _IronSight,
        [XmlEnum(Name = "JetPack")]
        _JetPack,
        [XmlEnum(Name = "JointThruster")]
        _JointThruster,
        [XmlEnum(Name = "Knife")]
        _Knife,
        [XmlEnum(Name = "LandingSystem")]
        _LandingSystem,
        [XmlEnum(Name = "Large")]
        _Large,
        [XmlEnum(Name = "legs")]
        _legs,
        [XmlEnum(Name = "Light")]
        _Light,
        [XmlEnum(Name = "LightArmor")]
        _LightArmor,
        [XmlEnum(Name = "ln")]
        _ln,
        [XmlEnum(Name = "LongRangeRadar")]
        _LongRangeRadar,
        [XmlEnum(Name = "Magazine")]
        _Magazine,
        [XmlEnum(Name = "MannedTurret")]
        _MannedTurret,
        [XmlEnum(Name = "Medium")]
        _Medium,
        [XmlEnum(Name = "MedPack")]
        _MedPack,
        [XmlEnum(Name = "MidRangeRadar")]
        _MidRangeRadar,
        [XmlEnum(Name = "Missile")]
        _Missile,
        [XmlEnum(Name = "MissileRack")]
        _MissileRack,
        [XmlEnum(Name = "MissileTurret")]
        _MissileTurret,
        [XmlEnum(Name = "Motherboard")]
        _Motherboard,
        [XmlEnum(Name = "NoseMounted")]
        _NoseMounted,
        [XmlEnum(Name = "Personal")]
        _Personal,
        [XmlEnum(Name = "Pilot")]
        _Pilot,
        [XmlEnum(Name = "Power")]
        _Power,
        [XmlEnum(Name = "Power_Idris")]
        _Power_Idris,
        [XmlEnum(Name = "QDrive")]
        _QDrive,
        [XmlEnum(Name = "QuantumFuel")]
        _QuantumFuel,
        [XmlEnum(Name = "Radar")]
        _Radar,
        [XmlEnum(Name = "Retaliator")]
        _Retaliator,
        [XmlEnum(Name = "Retro")]
        _Retro,
        [XmlEnum(Name = "Rocket")]
        _Rocket,
        [XmlEnum(Name = "SATABall")]
        _SATABall,
        [XmlEnum(Name = "ShortRangeRadar")]
        _ShortRangeRadar,
        [XmlEnum(Name = "SignatureReductor")]
        _SignatureReductor,
        [XmlEnum(Name = "SkinTest")]
        _SkinTest,
        [XmlEnum(Name = "Small")]
        _Small,
        [XmlEnum(Name = "superHornet")]
        _superHornet,
        [XmlEnum(Name = "TargetingComputer")]
        _TargetingComputer,
        [XmlEnum(Name = "ThrusterPack")]
        _ThrusterPack,
        [XmlEnum(Name = "TopTurret")]
        _TopTurret,
        [XmlEnum(Name = "Unmanned")]
        _Unmanned,
        [XmlEnum(Name = "VectorThruster")]
        _VectorThruster,
        [XmlEnum(Name = "Weapon")]
        _Weapon,
        [XmlEnum(Name = "WeaponControl")]
        _WeaponControl,
        [XmlEnum(Name = "UNDEFINED")]
        _UNDEFINED,
    }
    public enum ELoadingScreenType
    {
        [XmlEnum(Name = "ePlanetSide")]
        _ePlanetSide,
        [XmlEnum(Name = "eElectronicAccess")]
        _eElectronicAccess,
    }
    public enum StarMarineTeam
    {
        [XmlEnum(Name = "Marines")]
        _Marines,
        [XmlEnum(Name = "Outlaws")]
        _Outlaws,
    }
    public enum ArmorType
    {
        [XmlEnum(Name = "Light")]
        _Light,
        [XmlEnum(Name = "Medium")]
        _Medium,
        [XmlEnum(Name = "Heavy")]
        _Heavy,
    }
    public enum SlotType
    {
        [XmlEnum(Name = "Small")]
        _Small,
        [XmlEnum(Name = "Medium")]
        _Medium,
        [XmlEnum(Name = "Large")]
        _Large,
        [XmlEnum(Name = "Gadget")]
        _Gadget,
        [XmlEnum(Name = "Grenade")]
        _Grenade,
    }
    public enum StarMarineLoadoutBadges
    {
        [XmlEnum(Name = "Default")]
        _Default,
        [XmlEnum(Name = "LaserPistolAward")]
        _LaserPistolAward,
        [XmlEnum(Name = "ArclightLaserPistol")]
        _ArclightLaserPistol,
        [XmlEnum(Name = "MediumArmorAward")]
        _MediumArmorAward,
        [XmlEnum(Name = "MediumArmor")]
        _MediumArmor,
        [XmlEnum(Name = "FragGrenade")]
        _FragGrenade,
        [XmlEnum(Name = "EMPGrenade")]
        _EMPGrenade,
        [XmlEnum(Name = "SniperRifle")]
        _SniperRifle,
        [XmlEnum(Name = "Shotgun")]
        _Shotgun,
        [XmlEnum(Name = "LaserAssaultRifle")]
        _LaserAssaultRifle,
        [XmlEnum(Name = "HeavyArmor")]
        _HeavyArmor,
        [XmlEnum(Name = "Hologram")]
        _Hologram,
        [XmlEnum(Name = "EMPClaymore")]
        _EMPClaymore,
    }
    public enum ARModePrototypeMode
    {
        [XmlEnum(Name = "Off")]
        _Off,
        [XmlEnum(Name = "FloatingDynamic")]
        _FloatingDynamic,
        [XmlEnum(Name = "FloatingStatic")]
        _FloatingStatic,
    }
    public enum PostureType
    {
        [XmlEnum(Name = "Invalid")]
        _Invalid,
        [XmlEnum(Name = "Peek")]
        _Peek,
        [XmlEnum(Name = "Aim")]
        _Aim,
        [XmlEnum(Name = "Hide")]
        _Hide,
    }
    public enum AgentStance
    {
        [XmlEnum(Name = "STANCE_STAND")]
        _STANCE_STAND,
        [XmlEnum(Name = "STANCE_DUCK")]
        _STANCE_DUCK,
        [XmlEnum(Name = "STANCE_VEHICLE_SEAT")]
        _STANCE_VEHICLE_SEAT,
        [XmlEnum(Name = "STANCE_CROUCH")]
        _STANCE_CROUCH,
        [XmlEnum(Name = "STANCE_PRONE")]
        _STANCE_PRONE,
        [XmlEnum(Name = "STANCE_RELAXED")]
        _STANCE_RELAXED,
        [XmlEnum(Name = "STANCE_STEALTH")]
        _STANCE_STEALTH,
        [XmlEnum(Name = "STANCE_LOW_COVER")]
        _STANCE_LOW_COVER,
        [XmlEnum(Name = "STANCE_ALERTED")]
        _STANCE_ALERTED,
        [XmlEnum(Name = "STANCE_HIGH_COVER")]
        _STANCE_HIGH_COVER,
        [XmlEnum(Name = "STANCE_SWIM")]
        _STANCE_SWIM,
        [XmlEnum(Name = "STANCE_MAGBOOTS")]
        _STANCE_MAGBOOTS,
        [XmlEnum(Name = "STANCE_BODY_DRAG")]
        _STANCE_BODY_DRAG,
        [XmlEnum(Name = "STANCE_LAST")]
        _STANCE_LAST,
    }
    public enum ESignalTypes
    {
        [XmlEnum(Name = "Infrared")]
        _Infrared,
        [XmlEnum(Name = "Electromagnetic")]
        _Electromagnetic,
        [XmlEnum(Name = "CrossSection")]
        _CrossSection,
        [XmlEnum(Name = "Decibel")]
        _Decibel,
        [XmlEnum(Name = "UNDEFINED")]
        _UNDEFINED,
    }
    public enum ERadarEntityType
    {
        [XmlEnum(Name = "Player")]
        _Player,
        [XmlEnum(Name = "Ship")]
        _Ship,
        [XmlEnum(Name = "Missile")]
        _Missile,
        [XmlEnum(Name = "CounterMeasure")]
        _CounterMeasure,
        [XmlEnum(Name = "Hud_LandingArea")]
        _Hud_LandingArea,
        [XmlEnum(Name = "Hud_CTCBase")]
        _Hud_CTCBase,
        [XmlEnum(Name = "Hud_CTCCore")]
        _Hud_CTCCore,
        [XmlEnum(Name = "Hud_RaceCheckPoint")]
        _Hud_RaceCheckPoint,
        [XmlEnum(Name = "Hud_LandingHelper")]
        _Hud_LandingHelper,
        [XmlEnum(Name = "Hud_Beacon")]
        _Hud_Beacon,
        [XmlEnum(Name = "Hud_QTravelNavPoint")]
        _Hud_QTravelNavPoint,
        [XmlEnum(Name = "Unknown")]
        _Unknown,
    }
    public enum ScanningComponent
    {
        [XmlEnum(Name = "Ship")]
        _Ship,
        [XmlEnum(Name = "Turret")]
        _Turret,
        [XmlEnum(Name = "Gun")]
        _Gun,
        [XmlEnum(Name = "Missiles")]
        _Missiles,
        [XmlEnum(Name = "Countermeasures")]
        _Countermeasures,
        [XmlEnum(Name = "Shield")]
        _Shield,
        [XmlEnum(Name = "Armor")]
        _Armor,
        [XmlEnum(Name = "PowerPlant")]
        _PowerPlant,
        [XmlEnum(Name = "Engine")]
        _Engine,
        [XmlEnum(Name = "Radar")]
        _Radar,
        [XmlEnum(Name = "FuelTank")]
        _FuelTank,
        [XmlEnum(Name = "Radiator")]
        _Radiator,
        [XmlEnum(Name = "Cargo")]
        _Cargo,
        [XmlEnum(Name = "Cockpit")]
        _Cockpit,
    }
    public enum ScanningChannel
    {
        [XmlEnum(Name = "A")]
        _A,
        [XmlEnum(Name = "B")]
        _B,
        [XmlEnum(Name = "C")]
        _C,
    }
    public enum ScanningItemType
    {
        [XmlEnum(Name = "None")]
        _None,
        [XmlEnum(Name = "ShipType")]
        _ShipType,
        [XmlEnum(Name = "Affiliation")]
        _Affiliation,
        [XmlEnum(Name = "HullHealth")]
        _HullHealth,
        [XmlEnum(Name = "ShieldHealth")]
        _ShieldHealth,
        [XmlEnum(Name = "Guns")]
        _Guns,
        [XmlEnum(Name = "Missiles")]
        _Missiles,
        [XmlEnum(Name = "CountermeasureLaunchers")]
        _CountermeasureLaunchers,
        [XmlEnum(Name = "ShieldGenerator")]
        _ShieldGenerator,
        [XmlEnum(Name = "Armor")]
        _Armor,
        [XmlEnum(Name = "PowerPlant")]
        _PowerPlant,
        [XmlEnum(Name = "Engines")]
        _Engines,
        [XmlEnum(Name = "Radar")]
        _Radar,
        [XmlEnum(Name = "FuelType")]
        _FuelType,
        [XmlEnum(Name = "Radiator")]
        _Radiator,
        [XmlEnum(Name = "Cargo")]
        _Cargo,
        [XmlEnum(Name = "PassengerCapacity")]
        _PassengerCapacity,
        [XmlEnum(Name = "Cockpit")]
        _Cockpit,
        [XmlEnum(Name = "Owner")]
        _Owner,
        [XmlEnum(Name = "ShieldSegments")]
        _ShieldSegments,
        [XmlEnum(Name = "GunsAmmo")]
        _GunsAmmo,
        [XmlEnum(Name = "GunsPowerDraw")]
        _GunsPowerDraw,
        [XmlEnum(Name = "GunsHeatStatus")]
        _GunsHeatStatus,
        [XmlEnum(Name = "MissileType")]
        _MissileType,
        [XmlEnum(Name = "MissileCount")]
        _MissileCount,
        [XmlEnum(Name = "CountermeasureType")]
        _CountermeasureType,
        [XmlEnum(Name = "CountermeasureCount")]
        _CountermeasureCount,
        [XmlEnum(Name = "ShieldGeneratorPowerDraw")]
        _ShieldGeneratorPowerDraw,
        [XmlEnum(Name = "ShieldGeneratorHeatStatus")]
        _ShieldGeneratorHeatStatus,
        [XmlEnum(Name = "ShieldGeneratorStoppingPower")]
        _ShieldGeneratorStoppingPower,
        [XmlEnum(Name = "PowerPlantOutput")]
        _PowerPlantOutput,
        [XmlEnum(Name = "PowerPlantHeatStatus")]
        _PowerPlantHeatStatus,
        [XmlEnum(Name = "EnginesMaxSpeed")]
        _EnginesMaxSpeed,
        [XmlEnum(Name = "EnginesHeatStatus")]
        _EnginesHeatStatus,
        [XmlEnum(Name = "FuelRemaining")]
        _FuelRemaining,
        [XmlEnum(Name = "FuelTank")]
        _FuelTank,
        [XmlEnum(Name = "RadiatorHeatRemoval")]
        _RadiatorHeatRemoval,
        [XmlEnum(Name = "CargoUnitsFilled")]
        _CargoUnitsFilled,
        [XmlEnum(Name = "CargoMass")]
        _CargoMass,
        [XmlEnum(Name = "PassengerTotal")]
        _PassengerTotal,
        [XmlEnum(Name = "Pilot")]
        _Pilot,
        [XmlEnum(Name = "ShieldOverShield")]
        _ShieldOverShield,
        [XmlEnum(Name = "ShieldSegmentPowerAllocation")]
        _ShieldSegmentPowerAllocation,
        [XmlEnum(Name = "CargoType")]
        _CargoType,
        [XmlEnum(Name = "PassengerType")]
        _PassengerType,
        [XmlEnum(Name = "CargoUnitsPerCargoType")]
        _CargoUnitsPerCargoType,
        [XmlEnum(Name = "CargoMassPerCargoType")]
        _CargoMassPerCargoType,
        [XmlEnum(Name = "CargoHealth")]
        _CargoHealth,
    }
    public enum ScanningItemInformation
    {
        [XmlEnum(Name = "Position")]
        _Position,
        [XmlEnum(Name = "Health")]
        _Health,
        [XmlEnum(Name = "3DMesh")]
        _3DMesh,
        [XmlEnum(Name = "ShipClassName")]
        _ShipClassName,
        [XmlEnum(Name = "Faction")]
        _Faction,
        [XmlEnum(Name = "HullHealth")]
        _HullHealth,
        [XmlEnum(Name = "ShieldHealth")]
        _ShieldHealth,
        [XmlEnum(Name = "Type")]
        _Type,
        [XmlEnum(Name = "NameBrand")]
        _NameBrand,
        [XmlEnum(Name = "DamageResistance")]
        _DamageResistance,
        [XmlEnum(Name = "StealthModifications")]
        _StealthModifications,
        [XmlEnum(Name = "MassAdjustment")]
        _MassAdjustment,
        [XmlEnum(Name = "Size")]
        _Size,
        [XmlEnum(Name = "FuelType")]
        _FuelType,
        [XmlEnum(Name = "PassengerCapacity")]
        _PassengerCapacity,
        [XmlEnum(Name = "Owner")]
        _Owner,
        [XmlEnum(Name = "Damage")]
        _Damage,
        [XmlEnum(Name = "Range")]
        _Range,
        [XmlEnum(Name = "AmmoCount")]
        _AmmoCount,
        [XmlEnum(Name = "Heat")]
        _Heat,
        [XmlEnum(Name = "Count")]
        _Count,
        [XmlEnum(Name = "PowerDraw")]
        _PowerDraw,
        [XmlEnum(Name = "StoppingPower")]
        _StoppingPower,
        [XmlEnum(Name = "PowerOutput")]
        _PowerOutput,
        [XmlEnum(Name = "MaxSpeed")]
        _MaxSpeed,
        [XmlEnum(Name = "FuelRemaining")]
        _FuelRemaining,
        [XmlEnum(Name = "HeatRemoved")]
        _HeatRemoved,
        [XmlEnum(Name = "TotalHeat")]
        _TotalHeat,
        [XmlEnum(Name = "TotalHeatGenerated")]
        _TotalHeatGenerated,
        [XmlEnum(Name = "CargoUnitsFilled")]
        _CargoUnitsFilled,
        [XmlEnum(Name = "CargoUnitsMax")]
        _CargoUnitsMax,
        [XmlEnum(Name = "CargoMass")]
        _CargoMass,
        [XmlEnum(Name = "PassengerTotal")]
        _PassengerTotal,
        [XmlEnum(Name = "Pilot")]
        _Pilot,
        [XmlEnum(Name = "CargoTypes")]
        _CargoTypes,
        [XmlEnum(Name = "PassengerTypes")]
        _PassengerTypes,
        [XmlEnum(Name = "CargoHealth")]
        _CargoHealth,
    }
    public enum ScanningItemInfoDisplay
    {
        [XmlEnum(Name = "Normal")]
        _Normal,
        [XmlEnum(Name = "Distance")]
        _Distance,
        [XmlEnum(Name = "Time")]
        _Time,
    }
    public enum EFaceType
    {
        [XmlEnum(Name = "Bubble")]
        _Bubble,
        [XmlEnum(Name = "FrontBack")]
        _FrontBack,
        [XmlEnum(Name = "Quadrant")]
        _Quadrant,
        [XmlEnum(Name = "Box")]
        _Box,
    }
    public enum SeatScreensType
    {
        [XmlEnum(Name = "Pilot")]
        _Pilot,
        [XmlEnum(Name = "Turret")]
        _Turret,
        [XmlEnum(Name = "Console")]
        _Console,
        [XmlEnum(Name = "Copilot")]
        _Copilot,
    }
    public enum DockProvider
    {
        [XmlEnum(Name = "Player")]
        _Player,
        [XmlEnum(Name = "Notification")]
        _Notification,
        [XmlEnum(Name = "GameplayMode")]
        _GameplayMode,
        [XmlEnum(Name = "Contact")]
        _Contact,
        [XmlEnum(Name = "EasyShop")]
        _EasyShop,
        [XmlEnum(Name = "Spectate")]
        _Spectate,
        [XmlEnum(Name = "VehicleInfo")]
        _VehicleInfo,
        [XmlEnum(Name = "Player_GForce")]
        _Player_GForce,
        [XmlEnum(Name = "Player_Reticles")]
        _Player_Reticles,
        [XmlEnum(Name = "Vehicle_Main_Target")]
        _Vehicle_Main_Target,
        [XmlEnum(Name = "Vehicle_Main_Status")]
        _Vehicle_Main_Status,
        [XmlEnum(Name = "Vehicle_Radar")]
        _Vehicle_Radar,
        [XmlEnum(Name = "Vehicle_Shield")]
        _Vehicle_Shield,
        [XmlEnum(Name = "Vehicle_Emission")]
        _Vehicle_Emission,
        [XmlEnum(Name = "Vehicle_Countermeasures")]
        _Vehicle_Countermeasures,
        [XmlEnum(Name = "Vehicle_Fixed_Display_DEPRECATED")]
        _Vehicle_Fixed_Display_DEPRECATED,
        [XmlEnum(Name = "Vehicle_Messages")]
        _Vehicle_Messages,
        [XmlEnum(Name = "Seat_Selected_Item")]
        _Seat_Selected_Item,
        [XmlEnum(Name = "Seat_Weapon_Grouping")]
        _Seat_Weapon_Grouping,
        [XmlEnum(Name = "Seat_Overview")]
        _Seat_Overview,
        [XmlEnum(Name = "Seat_Power")]
        _Seat_Power,
        [XmlEnum(Name = "Seat_Display_Screen_Info")]
        _Seat_Display_Screen_Info,
    }
    public enum InterpolationMode
    {
        [XmlEnum(Name = "Linear")]
        _Linear,
        [XmlEnum(Name = "EaseInQuad")]
        _EaseInQuad,
        [XmlEnum(Name = "EaseOutQuad")]
        _EaseOutQuad,
        [XmlEnum(Name = "EaseInOutQuad")]
        _EaseInOutQuad,
        [XmlEnum(Name = "EaseInCubic")]
        _EaseInCubic,
        [XmlEnum(Name = "EaseOutCubic")]
        _EaseOutCubic,
        [XmlEnum(Name = "EaseInOutCubic")]
        _EaseInOutCubic,
    }
    public enum HUDPalleteEntry
    {
        [XmlEnum(Name = "Moderate")]
        _Moderate,
        [XmlEnum(Name = "Positive")]
        _Positive,
        [XmlEnum(Name = "Neutral")]
        _Neutral,
        [XmlEnum(Name = "Hostile")]
        _Hostile,
        [XmlEnum(Name = "Critical")]
        _Critical,
        [XmlEnum(Name = "Unknown")]
        _Unknown,
        [XmlEnum(Name = "Highlight")]
        _Highlight,
        [XmlEnum(Name = "Friendly")]
        _Friendly,
    }
    public enum UIGraph_SimpleComponentType
    {
        [XmlEnum(Name = "ElectronicAccessFullscreen")]
        _ElectronicAccessFullscreen,
        [XmlEnum(Name = "ARModeQueryAndFocus")]
        _ARModeQueryAndFocus,
        [XmlEnum(Name = "TacticalVisorModeQueryAndFocus")]
        _TacticalVisorModeQueryAndFocus,
        [XmlEnum(Name = "Tutorial")]
        _Tutorial,
        [XmlEnum(Name = "Subtitles")]
        _Subtitles,
        [XmlEnum(Name = "ChatWidget")]
        _ChatWidget,
        [XmlEnum(Name = "EAIntroLogo")]
        _EAIntroLogo,
        [XmlEnum(Name = "EAEmpty")]
        _EAEmpty,
        [XmlEnum(Name = "EAGameSelection")]
        _EAGameSelection,
        [XmlEnum(Name = "ACGameSelection")]
        _ACGameSelection,
        [XmlEnum(Name = "ACIntro")]
        _ACIntro,
        [XmlEnum(Name = "ACDroneSimMatchSetup")]
        _ACDroneSimMatchSetup,
        [XmlEnum(Name = "ACLobby")]
        _ACLobby,
        [XmlEnum(Name = "ACTutorialMatchSetup")]
        _ACTutorialMatchSetup,
        [XmlEnum(Name = "ACDomainTypeSelection")]
        _ACDomainTypeSelection,
        [XmlEnum(Name = "ACLobbyTypeSelection")]
        _ACLobbyTypeSelection,
        [XmlEnum(Name = "SMIntro")]
        _SMIntro,
        [XmlEnum(Name = "SMLobby")]
        _SMLobby,
        [XmlEnum(Name = "SMLobbyType")]
        _SMLobbyType,
        [XmlEnum(Name = "EAConnectionPopUp")]
        _EAConnectionPopUp,
        [XmlEnum(Name = "EALoadoutWarningPopUp")]
        _EALoadoutWarningPopUp,
        [XmlEnum(Name = "EAShipDetailsKickNoticePopUp")]
        _EAShipDetailsKickNoticePopUp,
        [XmlEnum(Name = "EAShipDetailsKickWarningPopUp")]
        _EAShipDetailsKickWarningPopUp,
        [XmlEnum(Name = "EALobbyConnection")]
        _EALobbyConnection,
        [XmlEnum(Name = "EALoadoutCustomization")]
        _EALoadoutCustomization,
        [XmlEnum(Name = "EAShipSelectionPopUp")]
        _EAShipSelectionPopUp,
        [XmlEnum(Name = "EAShipDetailsPopUp")]
        _EAShipDetailsPopUp,
        [XmlEnum(Name = "EALoadingScreen")]
        _EALoadingScreen,
        [XmlEnum(Name = "EAOpaqueBackground")]
        _EAOpaqueBackground,
        [XmlEnum(Name = "GGULoadingScreen")]
        _GGULoadingScreen,
        [XmlEnum(Name = "GGUNotificationScreen")]
        _GGUNotificationScreen,
    }
    public enum UIGraph_BackBehavior
    {
        [XmlEnum(Name = "Unsuported")]
        _Unsuported,
        [XmlEnum(Name = "NoAction")]
        _NoAction,
        [XmlEnum(Name = "LastDoNothing")]
        _LastDoNothing,
        [XmlEnum(Name = "LastRequestContextEnd")]
        _LastRequestContextEnd,
        [XmlEnum(Name = "LastRequestClose")]
        _LastRequestClose,
        [XmlEnum(Name = "LastCustomCallback")]
        _LastCustomCallback,
    }
    public enum UIGraph_BlockingMessagePopUpProvider
    {
        [XmlEnum(Name = "GlobalGame")]
        _GlobalGame,
        [XmlEnum(Name = "ElectronicAccess")]
        _ElectronicAccess,
    }
    public enum EMyEnum
    {
        [XmlEnum(Name = "First")]
        _First,
        [XmlEnum(Name = "Second")]
        _Second,
        [XmlEnum(Name = "Third")]
        _Third,
    }
    public enum WeaponMotionState
    {
        [XmlEnum(Name = "Any")]
        _Any,
        [XmlEnum(Name = "Idle")]
        _Idle,
        [XmlEnum(Name = "Movement")]
        _Movement,
    }
    public enum WeaponAimStance
    {
        [XmlEnum(Name = "Any")]
        _Any,
        [XmlEnum(Name = "Ready")]
        _Ready,
        [XmlEnum(Name = "ADS")]
        _ADS,
    }
    public enum WeaponMotionStance
    {
        [XmlEnum(Name = "Any")]
        _Any,
        [XmlEnum(Name = "Stand")]
        _Stand,
        [XmlEnum(Name = "Crouch")]
        _Crouch,
        [XmlEnum(Name = "Prone")]
        _Prone,
    }
    public enum WeaponCoverStance
    {
        [XmlEnum(Name = "Any")]
        _Any,
        [XmlEnum(Name = "Center")]
        _Center,
        [XmlEnum(Name = "Left")]
        _Left,
        [XmlEnum(Name = "Right")]
        _Right,
        [XmlEnum(Name = "Top")]
        _Top,
    }
    public enum WeaponPoseType
    {
        [XmlEnum(Name = "RightHand")]
        _RightHand,
        [XmlEnum(Name = "Zoom")]
        _Zoom,
        [XmlEnum(Name = "LeftHand")]
        _LeftHand,
    }
}
