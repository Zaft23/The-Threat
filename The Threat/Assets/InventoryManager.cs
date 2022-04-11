using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InventoryManager : MonoBehaviour
{
    private int _currentlyEquippedWeapon = 1;
    private GameObject _currentWeaponObject = null;


    [SerializeField] private Transform _weaponHolder = null;
    private Inventory inventory;

    [SerializeField] Weapon _defaultPrimaryWeapon = null;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && _currentlyEquippedWeapon != 0)
        {
            UnEquipWeapon();
            EquipWeapon(inventory.GetItem(0));

        }
        {

            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && _currentlyEquippedWeapon != 1)
        {
            UnEquipWeapon();
            EquipWeapon(inventory.GetItem(1));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && _currentlyEquippedWeapon != 2)
        {
            UnEquipWeapon();

        }
    }

    private void EquipWeapon(Weapon weapon)
    {
        _currentlyEquippedWeapon = (int)weapon.WeaponSlot;
        _currentWeaponObject = Instantiate(weapon.WeaponPrefab, _weaponHolder);

    }

    private void UnEquipWeapon()
    {
        Destroy(_currentWeaponObject);
    }




    //video refrence by Single Sapling Games on Youtube https://www.youtube.com/watch?v=tHzt9_vzqgk thx mate

}