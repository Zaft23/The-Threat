using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName ="Weapons")]
public class Weapon : ScriptableObject
{
    public string WeaponName;
    //public string description;
    public Sprite Artwork;
    public GameObject BulletPrefab;
    public Transform FirePointTransform = null;
    public GameObject PickAble;

    public float Damage;
    public float RateOfFire;
    public float BulletSpread;
    public int BulletsAmount;
    public int Mags;
    public float BulletSpeed;




}
