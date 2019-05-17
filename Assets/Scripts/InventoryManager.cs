using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager instance;
	private List<Item> itemsList = new List<Item>();
	public delegate void OnItemPicked();
	public OnItemPicked onItemPicked;

	private void Awake () {
		if (instance != null)
        {
            return;
        }
        instance = this;
    }
	
	
	public bool AddItem(Item item)
	{
		if (onItemPicked != null) onItemPicked.Invoke();
		if (itemsList.Count >= 3)
		{
			Debug.Log("nie ma już miejsca w ekwipunku");
			return false;
		}

		itemsList.Add(item);

		return true;
		
	}

	public void RemoveItem(Item item)
	{
		if (onItemPicked != null) onItemPicked.Invoke();
		itemsList.Remove(item);
	}

	public List<Item> GetItemsList()
	{
		return itemsList;
	}


}

