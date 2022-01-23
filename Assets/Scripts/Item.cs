using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item")]
public class Item : ScriptableObject
{
    public string name;
    public Sprite icon;
    [TextArea(5, 50)]
    public string description;
}
