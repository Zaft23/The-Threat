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
    //weapon's fire point -> transform



    public float Damage;
    public float RateOfFire;
    public float BulletSpread;
    public int BulletsAmount;
    public int Mags;

    public void Shoot()
    {
    

        //shoot function
        GameObject bullet = Instantiate(BulletPrefab, GameObject.Find("FirePoint/Point").transform.position, Quaternion.identity);

        //Muzzle Effect

        //destroy on time or on hit object
    }

}
