using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemName itemName;

    public void ItemClicked()
    {
        //Added to Inventory then the Object was hided
        InventoryManager.Instance.AddItem(itemName);
        this.gameObject.SetActive(false);
    }
 
}
