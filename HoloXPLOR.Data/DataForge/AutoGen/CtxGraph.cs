using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "CtxGraph")]
    public partial class CtxGraph
    {
        [XmlArray(ElementName = "groups")]
        [XmlArrayItem(ElementName = "WeakPointer", Type=typeof(_WeakPointer))]
        public _WeakPointer[] Groups { get; set; }

        [XmlArray(ElementName = "nodes")]
        [XmlArrayItem(Type = typeof(CtxGraph_Node))]
        [XmlArrayItem(Type = typeof(CtxGraph_Group))]
        [XmlArrayItem(Type = typeof(CtxGraph_Context))]
        [XmlArrayItem(Type = typeof(CtxGraph_Component))]
        [XmlArrayItem(Type = typeof(UIGraph_LoadoutSelectorComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_Group))]
        [XmlArrayItem(Type = typeof(UIGraph_DockingGroup))]
        [XmlArrayItem(Type = typeof(UIGraph_ControllerComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_Context))]
        [XmlArrayItem(Type = typeof(UIGraph_SimpleComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_FlashDockingStationComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_MouseControlComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_ContactWidgetComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_ChatComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_FastContactListComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_ARModeComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_ARModeDockComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_TacticalVisorModeComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_TacticalVisorModeDockComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_MarkerARDockComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_MarkerARProviderComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_BlockingMessagePopUpComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_HoloTableComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_ShipSelectorConsoleComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_UniverseMatchmakingComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_MovieClipTransformationInterpolatorComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_HomeScreenDockComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_HomeScreenComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_MissionDockComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_MissionMgrComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_JournalEntryDockComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_JournalComponent))]
        [XmlArrayItem(Type = typeof(UIGraph_ShopComponent))]
        public CtxGraph_Node[] Nodes { get; set; }

    }
}
