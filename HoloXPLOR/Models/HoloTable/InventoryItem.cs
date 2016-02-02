using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory = HoloXPLOR.Data.XML.Inventory;
using Ships = HoloXPLOR.Data.XML.Vehicles.Implementations;
using Items = HoloXPLOR.Data.XML.Spaceships;
using System.Text;
using HoloXPLOR.Data;

namespace HoloXPLOR.Models.HoloTable
{
    public class InventoryItem
    {
        public Inventory.Item Inventory_Item { get; set; }
        public Inventory.Ship Inventory_Ship { get; set; }
        public Inventory.Item Inventory_EquippedItem { get; set; }
        public Inventory.Port Inventory_EquippedPort { get; set; }

        public override String ToString()
        {
            return this.Inventory_Item.ToString();
        }

        public Items.Item GameData_Item { get; set; }
        public Items.Item GameData_EquippedItem { get; set; }
        public Ships.Vehicle GameData_Ship { get; set; }

        public Data.XML.ItemPort GameData_EquippedPort { get; set; }

        public HtmlString HTML_Attributes
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (this.GameData_Ship != null)
                {
                    sb.AppendFormat(@" data-ship-port-tags=""{0}""", this.GameData_Ship.ItemPortTags);
                }
                if (this.Inventory_Item != null)
                {
                    sb.Append(this.Inventory_Item.HTML_Attributes);
                }
                if (this.GameData_Item != null)
                {
                    sb.Append(this.GameData_Item.HTML_Attributes);
                }
                if (this.GameData_EquippedPort != null)
                {
                    sb.Append(this.GameData_EquippedPort.HTML_Attributes);

                    if (!String.IsNullOrWhiteSpace(this.GameData_EquippedPort.DisplayName))
                        sb.AppendFormat(@" data-port-name=""{0}""", Scripts.Localization.GetValue(this.GameData_EquippedPort.DisplayName, this.GameData_EquippedPort.DisplayName));
                }
                if (this.Inventory_EquippedItem != null)
                {
                    sb.AppendFormat(@" data-parent-id=""{0}""", this.Inventory_EquippedItem.ID);
                }
                if (this.GameData_EquippedItem != null)
                {
                    sb.Append(this.GameData_EquippedItem.HTML_Attributes.Replace("data-item-", "data-parent-"));
                    sb.AppendFormat(@" data-parent-name=""{0}""", Scripts.Localization.GetValue(this.GameData_EquippedItem.DisplayName, this.GameData_EquippedItem.DisplayName));
                }

                return new HtmlString(sb.ToString().Trim());
            }
        }

        public String Item_Type { get { return this.GameData_Item == null ? null : String.Format("{0}:{1}", this.GameData_Item.Params["itemType"], this.GameData_Item.Params["itemSubType"]); } }
        public String Port_DisplayName { get { return this.GameData_EquippedPort == null ? null : this.GameData_EquippedPort.DisplayName.ToLocalized(); } }
        public String Item_DisplayName { get { return this.GameData_Item == null ? null : this.GameData_Item.DisplayName.ToLocalized(); } }
        public Int32? MaxSize { get { return this.GameData_EquippedPort == null ? (Int32?)null : this.GameData_EquippedPort.MaxSize; } }
        public Int32? MinSize { get { return this.GameData_EquippedPort == null ? (Int32?)null : this.GameData_EquippedPort.MinSize; } }
        public Int32? ItemSize { get { return this.GameData_Item == null ? (Int32?)null : this.GameData_Item.ItemSize; } }
    }
}