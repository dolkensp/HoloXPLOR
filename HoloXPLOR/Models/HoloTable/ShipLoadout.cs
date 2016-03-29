using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory = HoloXPLOR.Data.Xml.Inventory;
using Ships = HoloXPLOR.Data.Xml.Vehicles.Implementations;
using Items = HoloXPLOR.Data.Xml.Spaceships;
using Xml = HoloXPLOR.Data.Xml;
using HoloXPLOR.Data;
using HoloXPLOR.Data.DataForge;

namespace HoloXPLOR.Models.HoloTable
{
    public partial class ShipLoadout
    {
        private Items.Item[] _weapons;

        public String DisplayName { get; private set; }
        public Items.Shield[] Shields { get; private set; }
        public Items.DamageMultiplier Armor { get; private set; }

        public Double MinHealth { get; private set; }
        public Double MaxHealth { get; private set; }

        private IEnumerable<Ships.Part> _Flatten(IEnumerable<Ships.Part> parts)
        {
            if (parts != null)
            {
                foreach (var part in parts)
                {
                    yield return part;

                    foreach (var childPart in this._Flatten(part.Parts))
                    {
                        yield return childPart;
                    }
                }
            }
        }
        
        public ShipLoadout(DetailModel model)
        {
            this.DisplayName = model.ShipJson.Name;

            this._weapons = model.View_CategoryLoadout[Items.CategoryEnum.Weapon]
                .Where(s => s.GameData_Item != null)
                .Select(s => s.GameData_Item)
                .ToArray();
            this.Shields = model.View_CategoryLoadout[Items.CategoryEnum.Shield]
                .Where(s => s.GameData_Item != null)
                .Select(s => s.GameData_Item.Shields)
                .ToArray();
            this.Armor = model.View_CategoryLoadout[Items.CategoryEnum.Armor]
                .Where(s => s.GameData_Item != null)
                .Select(s => s.GameData_Item)
                .SelectMany(i => i.Armor.DamageMultipliers)
                .FirstOrDefault();

            this.MinHealth = this._Flatten(model.GameData_Ship.Parts).Select(p => p.DamageMax).Where(d => d > 0).FirstOrDefault();
            this.MaxHealth = this._Flatten(model.GameData_Ship.Parts).Select(p => p.DamageMax).Sum();
        }

        public ShipLoadout(String targetShip)
        {
            var ship = HoloXPLOR_App.Scripts.Vehicles[targetShip];
            var loadout = this._Flatten(HoloXPLOR_App.Scripts.Loadout[targetShip].Ports).Select(p => HoloXPLOR_App.Scripts.Items.GetValue(p.ItemName, null)).Where(i => i != null).ToArray();

            loadout = this._Flatten(loadout).ToArray();

            this.DisplayName = HoloXPLOR_App.Scripts.ShipJsonMap.GetValue(HoloXPLOR_App.Scripts.ShipJsonLookup.GetValue(ship.Name, 0), new ShipMatrixJson { Name = ship.DisplayName }).Name;

            this._weapons = loadout
                .Where(i => i.ItemCategory == Items.CategoryEnum.Weapon)
                .ToArray();
            this.Shields = loadout
                .Where(i => i.ItemCategory == Items.CategoryEnum.Shield)
                .Select(i => i.Shields)
                .ToArray();
            this.Armor = loadout
                .Where(i => i.ItemCategory == Items.CategoryEnum.Armor)
                .SelectMany(i => i.Armor.DamageMultipliers)
                .FirstOrDefault();
            
            this.MinHealth = this._Flatten(ship.Parts).Select(p => p.DamageMax).Where(d => d > 0).FirstOrDefault();
            this.MaxHealth = this._Flatten(ship.Parts).Select(p => p.DamageMax).Sum();
        }

        public IEnumerable<Items.Item> _Flatten(IEnumerable<Items.Item> items)
        {
            if (items != null)
            {
                foreach ( var item in items)
                {
                    yield return item;

                    if (item.DefaultLoadout != null && item.DefaultLoadout.Ports != null)
                    {
                        foreach (var childItem in this._Flatten(item.DefaultLoadout.Ports.Select(p => HoloXPLOR_App.Scripts.Items.GetValue(p.ItemName, null)).Where(i => i != null)))
                        {
                            yield return childItem;
                        }

                        foreach (var port in item.DefaultLoadout.Ports.Where(p => p.Items != null))
                        {
                            foreach (var childItem in this._Flatten(port.Items).Select(i => HoloXPLOR_App.Scripts.Items.GetValue(i.ItemName, null)).Where(i => i != null))
                            {
                                yield return childItem;
                            }
                        }
                    }
                }
            }
        }

        public IEnumerable<Items.ItemLink> _Flatten(IEnumerable<Items.ItemLink> items)
        {
            if (items != null)
            {
                foreach (var item in items)
                {
                    yield return item;

                    foreach (var childItem in this._Flatten(item.Items))
                    {
                        yield return childItem;
                    }
                }
            }
        }

        private IEnumerable<WeaponSpec> _damage;
        public IEnumerable<WeaponSpec> Damage
        {
            get
            {
                return this._damage = this._damage ?? (from index in Enumerable.Range(0, this._weapons.Length)
                                                       let weapon = this._weapons[index]
                                                       where weapon != null
                                                       where weapon.FireModes != null
                                                       from firemode in weapon.FireModes
                                                       let ammoTypes1 = weapon.AmmoType ?? new String[] { firemode.Fire.AmmoType }
                                                       where ammoTypes1 != null
                                                       from ammoType1 in ammoTypes1
                                                       join item in HoloXPLOR_App.Scripts.Items.Values
                                                       on ammoType1.ToLowerInvariant() equals item.ItemSubType.ToLowerInvariant()
                                                       into ammoBoxes
                                                       from ammoBox in ammoBoxes.DefaultIfEmpty()
                                                       let ammoType2 = ammoBox == null || ammoBox.AmmoBox == null ? ammoType1 : ammoBox.AmmoBox.AmmoName
                                                       let ammo1 = HoloXPLOR_App.Scripts.Ammo.GetValue(ammoType1, null)
                                                       let ammo2 = HoloXPLOR_App.Scripts.Ammo.GetValue(ammoType2, null)
                                                       let ammo = ammo2 ?? ammo1
                                                       where ammo != null
                                                       let heatPipe = weapon.Pipes.Where(p => p.Class == "Heat").FirstOrDefault()
                                                       let heatPool = firemode.Pools == null ? null : firemode.Pools.Where(p => p.Class == "Heat").FirstOrDefault()
                                                       where ammo.ProjectileParams != null
                                                       where ammo.ProjectileParams.Length > 0
                                                       let bulletParams = ammo.ProjectileParams[0] as BulletProjectileParams
                                                       let rocketParams = ammo.ProjectileParams[0] as RocketProjectileParams
                                                       let damage = bulletParams != null ? bulletParams.Damage :
                                                                    rocketParams != null ? rocketParams.DetonationParams[0].ExplosionParams.Damage :
                                                                    null
                                                       group new WeaponSpec
                                                       {
                                                           Weapon = weapon.DisplayName,
                                                           WeaponName = weapon.Name,
                                                           FireMode = firemode.Name,
                                                           Ammo = ammo2 == null ? ammoType1 : ammoType2,
                                                           Speed = ammo.Speed,
                                                           Range = ammo.Lifetime * ammo.Speed,
                                                           Rate = ((firemode.Burst == null) ? firemode.Fire.Rate : (firemode.Burst.BurstSize * firemode.Burst.Rate)) ?? 0,
                                                           MaxHeat = heatPipe.Pool.Capacity,
                                                           CoolingRate = heatPipe.Pool.Rate,
                                                           HeatingRate = heatPool == null ? heatPipe.Pool.Rate : heatPool.Value,
                                                           Physical = damage != null ? damage.DamagePhysical : 0,
                                                           Energy = damage != null ? damage.DamageEnergy : 0,
                                                           Distortion = damage != null ? damage.DamageDistortion : 0,
                                                           MinSpread = (firemode.Spread == null) ? 0 : (firemode.Spread.Min ?? 0),
                                                           MaxSpread = (firemode.Spread == null) ? 0 : (firemode.Spread.Max ?? 0),
                                                       } by index into weapons
                                                       let optimum = weapons.OrderByDescending(a => a.Rate * (a.Physical + a.Energy + a.Distortion)).First()
                                                       select optimum).ToArray();
            }
        }
    }

    public class WeaponSpec
    {
        public String Weapon { get; set; }

        public String FireMode { get; set; }

        public String Ammo { get; set; }

        public Double Speed { get; set; }

        public Double Rate { get; set; }

        public Double MaxHeat { get; set; }

        public Double CoolingRate { get; set; }

        public Double HeatingRate { get; set; }

        public Double Physical { get; set; }

        public Double Energy { get; set; }

        public Double Distortion { get; set; }

        public Double MaxRadius { get; set; }

        public Double Pressure { get; set; }

        public Double MinSpread { get; set; }

        public Double MaxSpread { get; set; }

        public String WeaponName { get; set; }

        public Double Range { get; set; }
    }
}