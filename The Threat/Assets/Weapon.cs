using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName ="Weapons")]
public class Weapon : ScriptableObject
{
    public string WeaponName;
    //public string description;
    public Sprite WeaponSprite;
    public GameObject WeaponPrefab;
    public GameObject BulletPrefab;
    public GameObject PickAble;
    
    public _WeaponType WeaponType;
    public _WeaponSlot WeaponSlot;


    


    public void FirePoint()
    {
        Transform FirePointTransform = WeaponPrefab.transform;

    }

    public enum _WeaponType
    {
        Rifles,
        SMG,
        Shotgun,
        SniperRifle,
        Empty,
    }

    public enum _WeaponSlot
    {
        Primary,
        Secondary,
        Empty,
    }


    public float Damage;
    public float RateOfFire;
    public float BulletSpread;
    public int BulletsAmount;
    public int Mags;
    public float BulletSpeed;



}
