using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInventory")]
public class PlayerInventory : ScriptableObject
{
    public List<Item> _itemList;

    public void AddItem(Item i_itemToAdd)
    {
        if (!_itemList.Contains(i_itemToAdd))
            _itemList.Add(i_itemToAdd);
    }

    public void RemoveItem(Item i_itemToRemove)
    {
        if (_itemList.Contains(i_itemToRemove))
            _itemList.Remove(i_itemToRemove);
    }

    public bool PlayerHasItem(Item i_itemToCheck)
    {
        return _itemList.IndexOf(i_itemToCheck) > -1;
    }

    public bool PlayerHasItems(List<Item> i_itemsToCheck)
    {
        foreach (var item in _itemList)
        {
            if (_itemList.IndexOf(item) > -1)
                continue;
            else
                return false;
        }

        return true;
    }
}
