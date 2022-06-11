using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //0 = primary, 1 = secondary ???
    [SerializeField] public Weapon[] IWeapons;

    //
    private PlayerActions _actions;
   

    private void Start()
    {
        _actions = GetComponent<PlayerActions>();
        IniVariables();
    }


    private void Update()
    {
        if(IWeapons[0] == null)
        {
            _actions.PrimaryExist = false;
        }

        if(IWeapons[1] == null)
        {
            _actions.SecondaryExist = false;
        }

    }

    public void AddItem(Weapon newItem)
    {

        
        int newItemIndex = (int)newItem.WeaponSlot;

        //if (IWeapons[0] == null)
        //{
        //    IWeapons[newItemIndex] = newItem;

        //    _actions.InitAmmo((int)newItem.WeaponSlot, newItem);
        //}


            IWeapons[newItemIndex] = newItem;

            _actions.InitAmmo((int)newItem.WeaponSlot, newItem);

        


        //IWeapons[newItemIndex] = newItem;

        //_actions.InitAmmo((int)newItem.WeaponSlot, newItem);
        //type?

    }

    public void RemoveItem(int index)
    {
        //better actions
        IWeapons[index] = null;

    }

    public Weapon GetItem(int index)
    {
        return IWeapons[index];
    }

    private void IniVariables()
    {
        IWeapons = new Weapon[2];
    }

}
 