using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "BTSendSignalToGroup")]
    public partial class BTSendSignalToGroup : BTNode
    {
        [XmlArray(ElementName = "Name")]
        [XmlArrayItem(Type = typeof(BTInput_SendSignalToGroup_Name))]
        [XmlArrayItem(Type = typeof(BTInput_SendSignalToGroup_Name_String))]
        [XmlArrayItem(Type = typeof(BTInput_SendSignalToGroup_Name_Var))]
        [XmlArrayItem(Type = typeof(BTInput_SendSignalToGroup_Name_BB))]
        public BTInput_SendSignalToGroup_Name[] Name { get; set; }

        [XmlArray(ElementName = "Category")]
        [XmlArrayItem(Type = typeof(BTInput_SendSignalToGroup_Category))]
        [XmlArrayItem(Type = typeof(BTInput_SendSignalToGroup_Category_String))]
        [XmlArrayItem(Type = typeof(BTInput_SendSignalToGroup_Category_Var))]
        [XmlArrayItem(Type = typeof(BTInput_SendSignalToGroup_Category_BB))]
        public BTInput_SendSignalToGroup_Category[] Category { get; set; }

    }
}
