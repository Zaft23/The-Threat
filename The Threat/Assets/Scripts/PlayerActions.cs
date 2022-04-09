using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Weapon CurrentPrimaryWeapon;
    public Sprite currentPrimaryWeaponSpr;
    public Transform FirePoint;
    float lookAngle;

    private float _nextTimeOfFire = 0;

    // Start is called before the first frame update
    void Start()
    {

        //this is some lame shit
        //this cause an error if currentWeapon == null you use awake function instead of start,
        if(CurrentPrimaryWeapon == null)
        {
            Debug.Log("Player has no Weapon");
        }
        else
        {
            GameObject.Find("Hand?").GetComponent<SpriteRenderer>().sprite = CurrentPrimaryWeapon.Artwork;
        }
        

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
                if (CurrentPrimaryWeapon == null)
                {
                    Debug.Log("Player Shooting Blanks");
                }
                else
                {
                    Shoot();
                    _nextTimeOfFire = Time.time + 1 / CurrentPrimaryWeapon.RateOfFire;
                    //rb = 

                    //rb.AddForce(FirePoint.up * CurrentWeapon.BulletSpeed, ForceMode2D.Impulse);
                }
            }
        }

        if(Input.GetButton("Throw"))
        {
            if (CurrentPrimaryWeapon != null)
            {
                ThrowGun();
            }
            else
            {
                Debug.Log("Can't Throw Gun");
            }
        }


    }

    public void Shoot()
    {
        // OK i have no fucking idea why and i don't have the courage to find out how it works
        // and it shouldn't have taken me this long
        // but without these lines of codes, the bullet won't go where i want them to go 
        // and you don't actually fucking need look angle variable because i didn't event set it to any value
        // and i'm not even sure do i even need to set it to anything
        // i made these lines of codes from combining 5 or 6 youtube tutorials and answers from some forums
        // and this shit somehow works
        // honestly if this were an animal, i've mixed some many weird animals that shouldn't have been possible to be mixed
        // to create this god forsaken hybrids 
        // ... and i've created god knows how many of them in this project... HELP me

            GameObject bullet = Instantiate(CurrentPrimaryWeapon.BulletPrefab);
            bullet.transform.position = FirePoint.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            bullet.GetComponent<Rigidbody2D>().velocity = FirePoint.right * CurrentPrimaryWeapon.BulletSpeed;

        //posisi fire point
        //Muzzle Effect

        //destroy on time or on hit object
    }

    //throw gun: there's probably a better and efficient way of doing this.. but Too Bad!
    public void ThrowGun()
    {
        float speed = 5f;

        //give force only exist in this script
        //Instantiate pickup prefab
        GameObject gun = Instantiate(CurrentPrimaryWeapon.PickAble);
        gun.transform.position = FirePoint.position;
        gun.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        gun.GetComponent<Rigidbody2D>().velocity = FirePoint.right * speed;
        gameObject.GetComponent<PlayerActions>().CurrentPrimaryWeapon = null;
        


    }



}

