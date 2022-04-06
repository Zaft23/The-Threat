using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Weapon CurrentWeapon;
    public Sprite currentWeaponSpr;
    private float _nextTimeOfFire = 0;

    
    
    

    // Start is called before the first frame update
    void Awake()
    {
        transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = CurrentWeapon.Artwork;
       
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 gunPose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(gunPose.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);

        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }

        if (Input.GetButton("Fire1"))
        {
            if(Time.time >= _nextTimeOfFire)
            {
                CurrentWeapon.Shoot();
                _nextTimeOfFire = Time.time + 1 / CurrentWeapon.RateOfFire;
            }

        }


    }
}

