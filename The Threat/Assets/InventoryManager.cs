using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InventoryManager : MonoBehaviour
{
    public int CurrentlyEquippedWeapon;
    public GameObject CurrentWeaponObject = null;


    [SerializeField] private Transform _weaponHolder = null;
    private Inventory inventory;

    //[SerializeField] Weapon EmptyWeapon = null;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            UnEquipWeapon();
            EquipWeapon(inventory.GetItem(0));
            
        }
        {

            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UnEquipWeapon();
            EquipWeapon(inventory.GetItem(1));
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UnEquipWeapon();
            //CurrentlyEquippedWeapon = 1;

        }
    }

    private void EquipWeapon(Weapon weapon)
    {
        CurrentlyEquippedWeapon = (int)weapon.WeaponSlot;
        CurrentWeaponObject = Instantiate(weapon.WeaponPrefab, _weaponHolder);

    }

    public void UnEquipWeapon()
    {
        Destroy(CurrentWeaponObject);
    }




    //video refrence by Single Sapling Games on Youtube https://www.youtube.com/watch?v=tHzt9_vzqgk thx mate

}