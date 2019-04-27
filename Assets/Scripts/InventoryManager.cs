using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager instance;
	private List<Item> itemsList = new List<Item>();

	private void Awake () {
		if (instance != null)
        {
            return;
        }
        instance = this;
    }
	
	
	private bool AddItem(Item item)
	{
		if (itemsList.Count >= 3) return false;
		itemsList.Add(item);

		return true;
	}


}

