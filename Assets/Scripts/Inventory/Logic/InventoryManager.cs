using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{

    public ItemDataList_SO itemData;

    private void OnEnable()
    {
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
        EventHandler.ChangeItemEvent += OnChangeItemEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
        EventHandler.ChangeItemEvent -= OnChangeItemEvent;
    }

    private void OnChangeItemEvent(int index)
    {
        if (index >= 0 && index < itemList.Count)
        {
            ItemDetails item = itemData.GetItemDetails(itemList[index]);
            EventHandler.CallUpdateUIEvent(item, index);
        }
    }

    private void OnItemUsedEvent(ItemName itemName)
    {
        var index = GetItemIndex(itemName);
        itemList.RemoveAt(index);

        if (itemList.Count == 0)
            EventHandler.CallUpdateUIEvent(null, -1);
    }

    [SerializeField] private List<ItemName> itemList = new List<ItemName> ();
    public void AddItem(ItemName itemName)
    {
        if (!itemList.Contains(itemName))
        {
            itemList.Add(itemName);
            //UI correlated display
            EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(itemName), itemList.Count - 1);
        }
    }

    private int GetItemIndex(ItemName itemName)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i] == itemName)
                return i;
        }
        return -1;
    }
}
