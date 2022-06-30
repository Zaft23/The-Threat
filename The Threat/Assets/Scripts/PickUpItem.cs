using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    //PlayerActions PlayerAmmo;

    //public AudioSource audioSource;
    //public AudioClip PickUpSound;

    public bool IsRifle;
    public bool IsSmg;
    public bool IsShotgun;
    public bool IsSniper;

    public bool IsPrimary;
    public bool isSecondary;

    //set random or fix later 
    public int Rifle = 10;
    public int Smg = 15;
    public int Shotgun = 2;
    public int Sniper = 2;



    private void Start()
    {
        StartCoroutine(DestroyObject());
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        //audioSource.PlayOneShot(PickUpSound);


        //if(PlayerAmmo == null)
        //{
        //    return;
        //}

        var PlayerAmmo = target.gameObject.GetComponent<PlayerActions>();

        //also to check if item will exceed player max ammo
        //this is actually retarded but hey as long as it works.
        if ( PlayerAmmo.StoredRifleAmmo < PlayerAmmo.MaxRifleSize  || PlayerAmmo.StoredSmgAmmo < PlayerAmmo.MaxSmgSize || PlayerAmmo.StoredShotgunAmmo < PlayerAmmo.MaxShotgunSize
                || PlayerAmmo.StoredSniperAmmo < PlayerAmmo.MaxSniperSize)
        {
            if (target.gameObject.tag == "Player")
            {
                //audioSource.PlayOneShot(PickUpSound);
                if (IsRifle == true)
                {
                    PlayerAmmo.StoredRifleAmmo += Rifle;
                    if(PlayerAmmo.StoredRifleAmmo > PlayerAmmo.MaxRifleSize)
                    {
                        PlayerAmmo.StoredRifleAmmo = PlayerAmmo.MaxRifleSize;
                    }

                }

                if (IsSmg == true)
                {
                    PlayerAmmo.StoredSmgAmmo += Smg;
                    if (PlayerAmmo.StoredSmgAmmo > PlayerAmmo.MaxSmgSize)
                    {
                        PlayerAmmo.StoredSmgAmmo = PlayerAmmo.MaxSmgSize;
                    }

                }

                if (IsShotgun == true)
                {
                    PlayerAmmo.StoredShotgunAmmo += Shotgun;
                    if (PlayerAmmo.StoredShotgunAmmo > PlayerAmmo.MaxShotgunSize)
                    {
                        PlayerAmmo.StoredShotgunAmmo = PlayerAmmo.MaxShotgunSize;
                    }

                }

                if (IsRifle == true)
                {
                    PlayerAmmo.StoredSniperAmmo += Sniper;
                    if (PlayerAmmo.StoredSniperAmmo > PlayerAmmo.MaxSniperSize)
                    {
                        PlayerAmmo.StoredSniperAmmo = PlayerAmmo.MaxSniperSize;
                    }

                }



                Destroy(gameObject);

            }
        }
        

       

    }

    //number of mags / bullet remember

    private IEnumerator DestroyObject()
    {
        float time = 10f;
        yield return new WaitForSeconds(time);
        //_trailRenderer.emitting = false;
        Destroy(gameObject);

    }
}

   

