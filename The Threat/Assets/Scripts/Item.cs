using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public enum ItemTypes
    {
        Primary,
        Secondary,
        Grenades,
        OtherQuest,
    }

    public ItemTypes ItemType;
    public int amount;



}
