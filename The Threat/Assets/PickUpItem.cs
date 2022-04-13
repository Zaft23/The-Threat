using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    public bool IsPrimary;
    public bool IsSecondary;

    //set random or fix later 
    private int _primary = 10;
    private int _secondary = 5;

    private void Start()
    {
        StartCoroutine(DestroyObject());
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        var PlayerAmmo = target.gameObject.GetComponent<PlayerActions>();

        //also to check if item will exceed player max ammo
        //this is actually retarded but hey as long as it works.
        if ( PlayerAmmo.PrimaryStoredAmmo < PlayerAmmo.MaxRifleSize  || PlayerAmmo.SecondaryStoredAmmo < PlayerAmmo.MaxSecondaryMags)
        {
            if (target.gameObject.tag == "Player")
            {
                if (IsPrimary == true)
                {
                    PlayerAmmo.PrimaryStoredAmmo += _primary;
                    if(PlayerAmmo.PrimaryStoredAmmo > PlayerAmmo.MaxRifleSize)
                    {
                        PlayerAmmo.PrimaryStoredAmmo = PlayerAmmo.MaxRifleSize;
                    }

                }

                if (IsSecondary == true)
                {

                    PlayerAmmo.SecondaryStoredAmmo += _secondary;
                    if(PlayerAmmo.SecondaryStoredAmmo > PlayerAmmo.MaxSecondaryMags)
                    {
                        PlayerAmmo.SecondaryStoredAmmo = PlayerAmmo.MaxSecondaryMags;
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

   

