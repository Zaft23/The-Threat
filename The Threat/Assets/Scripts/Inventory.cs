using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<Item> _itemList;
    
    public Inventory()
    {
        _itemList = new List<Item>();

        Debug.Log("Inv");

    }


}
