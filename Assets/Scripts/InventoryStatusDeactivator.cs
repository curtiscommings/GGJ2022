using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryStatusDeactivator : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private List<Item> _itemsToRequire = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        if (!_playerInventory.PlayerHasItems(_itemsToRequire))
        {
            Destroy(gameObject);
        }
    }
}
