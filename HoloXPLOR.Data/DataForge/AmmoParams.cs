using System;
using System.Xml.Serialization;

namespace HoloXPLOR.Data.DataForge
{
    public partial class AmmoParams
    {
        [XmlIgnore]
        public Object Json
        {
            get
            {
                if (this.ProjectileParams == null) return null;

                if (this.ProjectileParams.Length == 0) return null;

                if (this.ProjectileParams[0] is BulletProjectileParams)
                {
                    var ammo = this.ProjectileParams[0] as BulletProjectileParams;
                    var damage = ammo.Damage;

                    return new
                    {
                        Damage_Physical = damage.DamagePhysical,
                        Damage_Energy = damage.DamageEnergy,
                        Damage_Distortion = damage.DamageDistortion,
                        Speed = this.Speed,
                        Range = this.Lifetime * this.Speed,
                    };
                }
                else if (this.ProjectileParams[0] is RocketProjectileParams)
                {
                    var ammo = this.ProjectileParams[0] as RocketProjectileParams;
                    var damage = ammo.DetonationParams[0].ExplosionParams.Damage;

                    return new
                    {
                        Speed = this.Speed,
                        Range = this.Lifetime * this.Speed,
                        Explosion = new
                        {
                            Damage_Physical = damage.DamagePhysical,
                            Damage_Energy = damage.DamageEnergy,
                            Damage_Distortion = damage.DamageDistortion,
                            MaxRadius = ammo.DetonationParams[0].ExplosionParams.MaxRadius,
                            Pressure = ammo.DetonationParams[0].ExplosionParams.Pressure,
                        },
                    };
                }

                return null;
            }
        }
    }
}