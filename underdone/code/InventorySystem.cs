using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.UI;

namespace Underdone
{
	
	public class InventorySystem
	{
		public int maxItems = 20;
		private List<Item> items = new List<Item>();

		public bool AddItem( Item item )
		{
			if ( items.Count >= maxItems )
			{
				Log.Info( "Inventory is full" );
				return false;
			}

			items.Add( item );
			return true;
		}

		public void RemoveItem( Item item )
		{
			items.Remove( item );
		}

		public List<Item> GetItems()
		{
			return items;
		}
	}

	[Serializable]
	public class Item
	{
		public string name;
		public string icon;
		public int quantity;

		public Item(String name, String icon, int quantity )
		{
			this.name = name;
			this.icon = icon;
			this.quantity = quantity;	
		}
	}
}
