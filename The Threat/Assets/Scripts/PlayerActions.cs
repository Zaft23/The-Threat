using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Weapon CurrentWeapon;
    public Sprite currentWeaponSpr;
    public Transform FirePoint;
    float lookAngle;
    
    

    //TEST
    //public Transform FirePoint;

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
                Shoot();
                _nextTimeOfFire = Time.time + 1 / CurrentWeapon.RateOfFire;
                //rb = 

                //rb.AddForce(FirePoint.up * CurrentWeapon.BulletSpeed, ForceMode2D.Impulse);

                
            }
            
        }


    }
    public void Shoot()
    {
        //Vector3 shootDirection;
        //shootDirection = Input.mousePosition;s
        //shootDirection.z = 0.0f;
        //shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        //shootDirection = shootDirection - transform.position;

        //shoot function

        // OK i have no i fucking idea why and i don't have the courage to find out how it works
        // and it shouldn't have taken me this long
        // but without these lines of codes, the bullet won't go where i want them to go 
        // and you don't actually fucking need look angle variable because i didn't event set it to any value
        // and i'm not even sure do i even need to set it to anything
        // i made these lines of codes from combining 5 or 6 youtube tutorials and answers from some forums
        // and this shit somehow works
        // honestly if this were an animal, i've mixed some many weird animals that shouldn't have been possible to be mixed
        // to create this god forsaken hybrids 
        // ... and i've created god knows how many of them in this project... HELP me


        GameObject bullet = Instantiate(CurrentWeapon.BulletPrefab);
        bullet.transform.position = FirePoint.position;
        bullet.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

        bullet.GetComponent<Rigidbody2D>().velocity = FirePoint.right * CurrentWeapon.BulletSpeed;


        //posisi fire point
        //Muzzle Effect

        //destroy on time or on hit object
    }
}

