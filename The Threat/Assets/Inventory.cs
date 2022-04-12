using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //0 = primary, 1 = secondary ???
    [SerializeField] private Weapon[] _weapons;

    

    private void Start()
    {
        IniVariables();
    }

    public void AddItem(Weapon newItem)
    {
        int newItemIndex = (int)newItem.WeaponSlot;

        if (_weapons[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        _weapons[newItemIndex] = newItem;
        

    }

    public void RemoveItem(int index)
    {
        //better actions
        _weapons[index] = null;

    }

    public Weapon GetItem(int index)
    {
        return _weapons[index];
    }

    private void IniVariables()
    {
        _weapons = new Weapon[3];
    }

}