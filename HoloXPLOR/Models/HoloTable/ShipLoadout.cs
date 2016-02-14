using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory = HoloXPLOR.Data.XML.Inventory;
using Ships = HoloXPLOR.Data.XML.Vehicles.Implementations;
using Items = HoloXPLOR.Data.XML.Spaceships;
using Xml = HoloXPLOR.Data.XML;
using HoloXPLOR.Data;

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
            this.DisplayName = model.GameData_Ship.DisplayName;

            this._weapons = model.View_CategoryLoadout[Items.CategoryEnum.Weapon].Select(s => s.GameData_Item).ToArray();
            this.Shields = model.View_CategoryLoadout[Items.CategoryEnum.Shield].Select(s => s.GameData_Item.Shields).ToArray();
            this.Armor = model.View_CategoryLoadout[Items.CategoryEnum.Armor]
                .Select(s => s.GameData_Item).SelectMany(i => i.Armor.DamageMultipliers).FirstOrDefault();

            this.MinHealth = this._Flatten(model.GameData_Ship.Parts).Select(p => p.DamageMax).Where(d => d > 0).FirstOrDefault();
            this.MaxHealth = this._Flatten(model.GameData_Ship.Parts).Select(p => p.DamageMax).Sum();
        }

        public ShipLoadout(Ships.Vehicle ship)
        {
            var loadout = this._Flatten(Scripts.Loadout[ship.Name].Ports).Select(p => Scripts.Items.GetValue(p.ItemName, null)).Where(i => i != null).ToArray();

            this.DisplayName = ship.DisplayName;

            this._weapons = loadout.Where(i => i.ItemCategory == Items.CategoryEnum.Weapon).ToArray();
            this.Shields = loadout.Where(i => i.ItemCategory == Items.CategoryEnum.Shield).Select(i => i.Shields).ToArray();
            this.Armor = loadout.Where(i => i.ItemCategory == Items.CategoryEnum.Armor)
                .SelectMany(i => i.Armor.DamageMultipliers).FirstOrDefault();
            
            this.MinHealth = this._Flatten(ship.Parts).Select(p => p.DamageMax).Where(d => d > 0).FirstOrDefault();
            this.MaxHealth = this._Flatten(ship.Parts).Select(p => p.DamageMax).Sum();
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
                                                       from firemode in weapon.FireModes
                                                       let ammoTypes1 = weapon.AmmoType ?? new String[] { firemode.Fire.AmmoType }
                                                       from ammoType1 in ammoTypes1
                                                       let ammoBox = Scripts.Items.GetValue(ammoType1, null)
                                                       let ammoType2 = ammoBox == null || ammoBox.AmmoBox == null ? ammoType1 : ammoBox.AmmoBox.AmmoName
                                                       let ammo = Scripts.Ammo.GetValue(ammoType2, null) ?? Scripts.Ammo.GetValue(ammoType1, null)
                                                       where ammo != null
                                                       let heatPipe = weapon.Pipes.Where(p => p.Class == "Heat").FirstOrDefault()
                                                       let heatPool = firemode.Pools.Where(p => p.Class == "Heat").FirstOrDefault()
                                                       group new WeaponSpec
                                                       {
                                                           Weapon = weapon.DisplayName,
                                                           FireMode = firemode.Name,
                                                           Ammo = ammo.Name,
                                                           Speed = ammo.Physics.Speed,
                                                           Rate = (firemode.Burst == null) ? firemode.Fire.Rate : (firemode.Burst.BurstSize * firemode.Burst.Rate),
                                                           MaxHeat = heatPipe.Pool.Capacity,
                                                           CoolingRate = heatPipe.Pool.Rate,
                                                           HeatingRate = heatPool.Value,
                                                           Physical = (ammo.Damage_Physical ?? 0) + (ammo.Explosion == null ? 0 : ammo.Explosion.Damage_Physical ?? 0),
                                                           Energy = (ammo.Damage_Energy ?? 0) + (ammo.Explosion == null ? 0 : ammo.Explosion.Damage_Energy ?? 0),
                                                           Distortion = (ammo.Damage_Distortion ?? 0) + (ammo.Explosion == null ? 0 : ammo.Explosion.Damage_Distortion ?? 0),
                                                           MaxRadius = ammo.Explosion == null ? 0 : ammo.Explosion.MaxRadius,
                                                           Pressure = ammo.Explosion == null ? 0 : ammo.Explosion.Pressure,
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

        public Double? Speed { get; set; }

        public Double? Rate { get; set; }

        public Double MaxHeat { get; set; }

        public Double CoolingRate { get; set; }

        public Double HeatingRate { get; set; }

        public Double Physical { get; set; }

        public Double Energy { get; set; }

        public Double Distortion { get; set; }

        public Double? MaxRadius { get; set; }

        public Double? Pressure { get; set; }
    }
}