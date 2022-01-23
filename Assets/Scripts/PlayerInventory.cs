using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInventory")]
public class PlayerInventory : MonoBehaviour
{
    public List<Item> _itemList;

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
