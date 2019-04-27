using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
	public string ItemName { get; private set; }
	public Sprite ItemIcon { get; private set; }
	
	public Item(string itemName, Sprite itemIcon)
	{
		ItemName = itemName;
		ItemIcon = itemIcon;
	}
}
