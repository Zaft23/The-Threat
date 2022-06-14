using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InventoryManager : MonoBehaviour
{
    public int CurrentlyEquippedWeapon;
    public int CurrentlEquippedWeaponType;
    public GameObject CurrentWeaponObject = null;

    public GameObject Arm1;
    public GameObject Arm2;

    public Player Player;

    [SerializeField] private Transform _weaponHolder = null;
    private Inventory inventory;

    //[SerializeField] Weapon EmptyWeapon = null;

    private void Start()
    {
        inventory = GetComponent<Inventory>();

        Player = GetComponent<Player>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            UnEquipWeapon();
            InstantiateWeapon(inventory.GetItem(0));

            Player.Holstered = false;
            Arm1.SetActive(true);
            Arm2.SetActive(true);
            //inventory.RemoveItem(0);
        }
        {

            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UnEquipWeapon();
            InstantiateWeapon(inventory.GetItem(1));
            //inventory.RemoveItem(1);
            Player.Holstered = false;
            Arm1.SetActive(true);
            Arm2.SetActive(true);
            

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UnEquipWeapon();
            Player.Holstered = true;
            Arm1.SetActive(false);
            Arm2.SetActive(false);
            //CurrentlyEquippedWeapon = 1;

        }
    }

    private void InstantiateWeapon(Weapon weapon)
    {
        if(weapon!=null)
        {
            CurrentWeaponObject = Instantiate(weapon.WeaponPrefab, _weaponHolder);
            CurrentlyEquippedWeapon = (int)weapon.WeaponSlot;
            CurrentlEquippedWeaponType = (int)weapon.WeaponType;
        }

    }

    


    public void UnEquipWeapon()
    {
        Destroy(CurrentWeaponObject);
    }




    //video refrence by Single Sapling Games on Youtube https://www.youtube.com/watch?v=tHzt9_vzqgk thx mate

}