using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public Weapon CurrentWeapon;
    public Sprite currentWeaponSpr;
    private float _nextTimeOfFire = 0;

    public Transform FirePoint;
    Vector2 lookDirection;
    float lookAngle;

    // Start is called before the first frame update
    void Awake()
    {
        transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = CurrentWeapon.Artwork;
       
    }

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.WorldToScreenPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        lookDirection = new Vector2(lookDirection.x - transform.position.x, lookDirection.y - transform.position.y);
        FirePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        
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
