using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InventoryManager : MonoBehaviour
{
    public int CurrentlyEquippedWeapon;
    public int CurrentlyEquippedWeaponType;
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
            InstantiateWeapon(inventory.GetItem(0));
            
        }
        {

            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UnEquipWeapon();
            InstantiateWeapon(inventory.GetItem(1));
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UnEquipWeapon();
            //CurrentlyEquippedWeapon = 1;

        }
    }

    private void InstantiateWeapon(Weapon weapon)
    {
        if(weapon!=null)
        {
            CurrentWeaponObject = Instantiate(weapon.WeaponPrefab, _weaponHolder);
            CurrentlyEquippedWeapon = (int)weapon.WeaponSlot;
            CurrentlyEquippedWeaponType = (int)weapon.WeaponType;
        }

    }

    


    public void UnEquipWeapon()
    {
        Destroy(CurrentWeaponObject);
    }




    //video refrence by Single Sapling Games on Youtube https://www.youtube.com/watch?v=tHzt9_vzqgk thx mate

}