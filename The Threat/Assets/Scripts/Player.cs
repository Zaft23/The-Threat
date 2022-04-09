using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public Weapon CurrentWeapon;

    //private int _totalWeapons = 2;
    //public int CurrentWeaponIndex;

    //public GameObject[] Guns;
    //public GameObject WeaponHolder; 

    private Inventory _inventory;

    // Start is called before the first frame update
    void Awake()
    {
        _inventory = new Inventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
