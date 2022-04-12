using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{


    private Inventory _inventory;
    private InventoryManager _manager;
    public Transform FirePoint;
    float lookAngle;
    public Weapon weapon;


    // TEST
    //need magazine

    public int MaxPrimaryAmmo = 50;
    private int _currentPrimaryAmmo;
    public int MaxSecondaryAmmo = 20;
    private int _currentSecondaryAmmo;
    public float ReloadTime = 4;

    private bool isReloading = false;

    // TEST


    private float _nextTimeOfFire = 0;

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.collider.gameObject.layer == LayerMask.NameToLayer("PickUp"))
        {
            Weapon newItem = target.transform.GetComponent<PickUpItem>().Weapon;
            _inventory.AddItem(newItem);
            Destroy(target.transform.gameObject);

        }

    }

    private void OnApplicationQuit()
    {
      
    }

    void Start()
    {
        GetRefrences();
    }

    private void OnEnable()
    {
        isReloading = false;

    }


    void Update()
    {
        //float coolDownTime = 5;
        //float ThrowAgain = 0;

        Vector3 gunPose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (gunPose.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);

        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }

        if (isReloading)
            return;

        //to reload
        if(_currentPrimaryAmmo < MaxPrimaryAmmo || _currentSecondaryAmmo < MaxSecondaryAmmo)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
                return;
            }

        }

        if (Input.GetButton("Fire1"))
        {
            if (Time.time >= _nextTimeOfFire)
            {
                Shoot();
                _nextTimeOfFire = Time.time + 1 / _inventory.GetItem(_manager.CurrentlyEquippedWeapon).RateOfFire;
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {

                ThrowGun();
                
        }
        



    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(ReloadTime);
        if(_manager.CurrentlyEquippedWeapon == 0)
        {
            _currentPrimaryAmmo = MaxPrimaryAmmo;
        }
        if (_manager.CurrentlyEquippedWeapon == 1)
        {
            _currentSecondaryAmmo = MaxSecondaryAmmo;
        }
        isReloading = false;

    }



    public void Shoot()
    {
        //lame set up shit again ffs
        var currWeapon = _inventory.GetItem(_manager.CurrentlyEquippedWeapon);
        var currWeaponSpeed = currWeapon.BulletSpeed;

        if(_manager.CurrentlyEquippedWeapon == 0 )
        {
            _currentPrimaryAmmo--;
            GameObject fire = Instantiate(currWeapon.BulletPrefab);

            fire.transform.position = GameObject.Find("FirePoint/NewPoint").transform.position;

            fire.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            fire.GetComponent<Rigidbody2D>().velocity = FirePoint.right * currWeaponSpeed;
        }



        if(_manager.CurrentlyEquippedWeapon == 1)
        {
            _currentSecondaryAmmo--;
            GameObject fire = Instantiate(currWeapon.BulletPrefab);

            fire.transform.position = GameObject.Find("FirePoint/NewPoint").transform.position;

            fire.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            fire.GetComponent<Rigidbody2D>().velocity = FirePoint.right * currWeaponSpeed;
        }
    }

    //throw gun: there's probably a better and efficient way of doing this... Too Bad!
    public void ThrowGun()
    {
        //after many trial and errors creating the gun slot system this still causes a short time memory leak if player suddenly throw the gun again right after pick up...Too Bad!
        //spent waaaay to much time creating this system instead of moving on to another task 
        //so might need to search for solution later if i got time :P

        float force = 5f;
        var currWeapon = _inventory.GetItem(_manager.CurrentlyEquippedWeapon);
        gameObject.GetComponent<Inventory>().RemoveItem(_manager.CurrentlyEquippedWeapon);
        GameObject PickAbleGun = Instantiate(currWeapon.PickAble);

        //limit = limit - 1;

        PickAbleGun.transform.position = GameObject.Find("FirePoint/NewPoint").transform.position;
        PickAbleGun.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        PickAbleGun.GetComponent<Rigidbody2D>().velocity = FirePoint.right * force;


        
        _manager.UnEquipWeapon();

    }


    private void GetRefrences()
    {
        _currentPrimaryAmmo = MaxPrimaryAmmo;
        _currentSecondaryAmmo = MaxSecondaryAmmo;

        _inventory = GetComponent<Inventory>();
        _manager = GetComponent<InventoryManager>();
        var cam = GetComponentInChildren<AimRotation>();

    }


}

