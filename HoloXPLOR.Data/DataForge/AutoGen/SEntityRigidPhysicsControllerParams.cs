using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    [XmlRoot(ElementName = "SEntityRigidPhysicsControllerParams")]
    public partial class SEntityRigidPhysicsControllerParams : SEntityPhysicsControllerParams
    {
        [XmlAttribute(AttributeName = "maxLoggedCollisions")]
        public Int32 MaxLoggedCollisions { get; set; }

    }
}
