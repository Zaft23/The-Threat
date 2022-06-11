using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //0 = primary, 1 = secondary ???
    //[SerializeField] 
    public Weapon[] Weapons;
    private InventoryManager _slot;
    //
    private PlayerActions _actions;

    public bool PrimaryExist;
    public bool SecondaryExist;


    private void Start()
    {
        _actions = GetComponent<PlayerActions>();
        IniVariables();

        //
        PrimaryExist = false;
        SecondaryExist = false;

    }

    public void AddItem(Weapon newItem)
    {

        
        int newItemIndex = (int)newItem.WeaponSlot;


        //if (_weapons[newItemIndex] != null)
        //{ 
        //    //Debug.Log("here!!");
        //  RemoveItem(newItemIndex);
        //}

        if(Weapons[0] == null)
        //if (Weapons[0] == null && PrimaryExist == false)
        //if (PrimaryExist == false)
        {
            //RemoveItem(newItemIndex);

            Weapons[newItemIndex] = newItem;

            _actions.InitAmmo((int)newItem.WeaponSlot, newItem);

            PrimaryExist = true;

        }

        if(Weapons[1] == null)
        //else if (Weapons[1] == null && SecondaryExist == false)
        //if (Weapons[1] == null && SecondaryExist == false)
        //else if (SecondaryExist == false)
        {
            //RemoveItem(newItemIndex);

            Weapons[newItemIndex] = newItem;

            _actions.InitAmmo((int)newItem.WeaponSlot, newItem);

            SecondaryExist = true;
        }

        
        //type?

    }

    public void RemoveItem(int index)
    {
        //better actions
        Weapons[index] = null;

    }

    public Weapon GetItem(int index)
    {
        return Weapons[index];
    }

    private void IniVariables()
    {
        Weapons = new Weapon[2];
    }

}
