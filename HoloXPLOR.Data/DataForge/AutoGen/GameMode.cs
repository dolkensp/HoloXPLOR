using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "GameMode")]
    public partial class GameMode
    {
        [XmlAttribute(AttributeName = "name")]
        public String Name { get; set; }

        [XmlAttribute(AttributeName = "displayName")]
        public String DisplayName { get; set; }

        [XmlAttribute(AttributeName = "alias")]
        public String Alias { get; set; }

        [XmlAttribute(AttributeName = "moduleType")]
        public EModuleType ModuleType { get; set; }

        [XmlAttribute(AttributeName = "playerToPlayerCollisionPolicy")]
        public EPlayerToPlayerCollisionPolicy PlayerToPlayerCollisionPolicy { get; set; }

        [XmlAttribute(AttributeName = "teamGame")]
        public Boolean TeamGame { get; set; }

        [XmlAttribute(AttributeName = "useReadOnlyDataStore")]
        public Boolean UseReadOnlyDataStore { get; set; }

        [XmlAttribute(AttributeName = "spawnInSpaceship")]
        public Boolean SpawnInSpaceship { get; set; }

        [XmlAttribute(AttributeName = "disableIFCSCruiseMode")]
        public Boolean DisableIFCSCruiseMode { get; set; }

        [XmlAttribute(AttributeName = "isSurvivalMode")]
        public Boolean IsSurvivalMode { get; set; }

        [XmlAttribute(AttributeName = "useEjectionPenalty")]
        public Boolean UseEjectionPenalty { get; set; }

        [XmlAttribute(AttributeName = "allowShipToSpaceExit")]
        public Boolean AllowShipToSpaceExit { get; set; }

        [XmlAttribute(AttributeName = "maxUnattendedVehicleMarkers")]
        public Byte MaxUnattendedVehicleMarkers { get; set; }

        [XmlAttribute(AttributeName = "disableThirdPersonCamera")]
        public Boolean DisableThirdPersonCamera { get; set; }

        [XmlAttribute(AttributeName = "rulesPath")]
        public String RulesPath { get; set; }

        [XmlAttribute(AttributeName = "levelLocation")]
        public String LevelLocation { get; set; }

        [XmlAttribute(AttributeName = "musicSuite")]
        public Guid MusicSuite { get; set; }

        [XmlAttribute(AttributeName = "announcerGameModeName")]
        public String AnnouncerGameModeName { get; set; }

        [XmlAttribute(AttributeName = "announcerGameModeTokenName")]
        public String AnnouncerGameModeTokenName { get; set; }

        [XmlAttribute(AttributeName = "audioOcclusionMaxDist")]
        public Single AudioOcclusionMaxDist { get; set; }

        [XmlAttribute(AttributeName = "requiresVisorScoreboard")]
        public Boolean RequiresVisorScoreboard { get; set; }

        [XmlAttribute(AttributeName = "requiresRoundTimer")]
        public Boolean RequiresRoundTimer { get; set; }

        [XmlAttribute(AttributeName = "loadoutProbabilities")]
        public Guid LoadoutProbabilities { get; set; }

        [XmlAttribute(AttributeName = "allowLoadoutCycling")]
        public Boolean AllowLoadoutCycling { get; set; }

        [XmlAttribute(AttributeName = "invalidShipGroup")]
        public Guid InvalidShipGroup { get; set; }

    }
}
