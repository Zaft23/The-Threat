using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private Inventory _inventory;
    private InventoryManager _manager;
    float lookAngle;


    [Header("Weapon Details")]
    public Transform FirePoint;
    
    private float _lastShootTime = 0;

    [SerializeField] private int _primaryCurrentAmmo;
    public int PrimaryStoredAmmo;

    [SerializeField] private int _secondaryCurrentAmmo;
    public  int SecondaryStoredAmmo;

    [SerializeField] private bool _primaryMagIsEmpty = false;
    [SerializeField] private bool _secondaryMagIsEmpty = false;
    [SerializeField] private bool _canShoot;
    public bool CanReload = true;

    //Store primary
    [SerializeField] private int _storedRifleAmmo;
    [SerializeField] private int _storedSmgAmmo;
    [SerializeField] private int _storedShotgunAmmo;
    [SerializeField] private int _storedSniperAmmo;




    //primary
    public int MaxRifleSize = 300;
    public int MaxSmgSize = 500;
    public int MaxShotgunSize = 32;
    public int MaxSniperSize = 20;

    //secondary
    public int MaxSecondaryMags = 50;


    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.collider.gameObject.layer == LayerMask.NameToLayer("PickUp"))
        {
            Weapon newItem = target.transform.GetComponent<WeaponPickUp>().Weapon;
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
        _canShoot = true;
        CanReload = true;
    }

    private void OnEnable()
    {
       // isReloading = false;

    }


    void Update()
    {


        Vector3 gunPose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (gunPose.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);

        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }


        if (Input.GetButton("Fire1"))
        {
  
                Shooting();
               
        }

        //reload
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine (Reload(_manager.CurrentlyEquippedWeapon));
            return;

        }

        if (Input.GetKeyDown(KeyCode.G))
        {

                ThrowGun();
                
        }
        

    }


    

    //HERE
    private void CheckCanShoot(int slot)
    {
        //primary
        if(slot == 0)
        {
            if (_primaryMagIsEmpty)
                _canShoot = false;
            else
                _canShoot = true;
        }

        //secondary
        if(slot == 1)
        {
            if (_secondaryMagIsEmpty)
                _canShoot = false;
            else
                _canShoot = true;
        }

       
    }

    //play around with ammo type
    public void InitAmmo(int slot, Weapon weapon)
    {
        //primary
        if (slot == 0)
        {
            _primaryCurrentAmmo = weapon.BulletAmount;
            
        }


        //secondary
        if (slot == 1)
        {
            _secondaryCurrentAmmo = weapon.BulletAmount;
            
        }
    }

    //HERE
    private void UseAmmo(int slot, int currentAmmoUsed, int currentStoredAmmoUsed)
    {
        

        //primary
        if (slot == 0)
        {
            if (_primaryCurrentAmmo <= 0)
            {
                _primaryMagIsEmpty = true;

                CheckCanShoot(_manager.CurrentlyEquippedWeapon);
            }

            else
            {
                _primaryCurrentAmmo -= currentAmmoUsed;
                PrimaryStoredAmmo = _storedRifleAmmo;
                PrimaryStoredAmmo -= currentStoredAmmoUsed;
            }


        }

        //secondary
        if (slot == 1)
        {
            if (_secondaryCurrentAmmo <= 0)
            {
                _secondaryMagIsEmpty = true;

                CheckCanShoot(_manager.CurrentlyEquippedWeapon);
            }
            
            else
            {
                _secondaryCurrentAmmo -= currentAmmoUsed;
                SecondaryStoredAmmo -= currentStoredAmmoUsed;
            }

        }
    }


    


    public void BulletShoot(Weapon currentWeapon)
    {
        //lame set up shit again ffs
        var currWeapon = _inventory.GetItem(_manager.CurrentlyEquippedWeapon);
        var currWeaponSpeed = currWeapon.BulletSpeed;

 
            GameObject fire = Instantiate(currWeapon.BulletPrefab);

            fire.transform.position = GameObject.Find("FirePoint/NewPoint").transform.position;

            fire.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            fire.GetComponent<Rigidbody2D>().velocity = FirePoint.right * currWeaponSpeed;

    }

    void Shooting()
    {
        CheckCanShoot(_manager.CurrentlyEquippedWeapon);

        if (_canShoot && CanReload)
        {
            Weapon currentWeapon = _inventory.GetItem(_manager.CurrentlyEquippedWeapon);

            if (Time.time > _lastShootTime + currentWeapon.RateOfFire)
            {
                _lastShootTime = Time.time;

                BulletShoot(currentWeapon);

                UseAmmo((int)currentWeapon.WeaponSlot, 1, 0);

            }
        }
        else
            Debug.Log("No Ammo!");


    }

    IEnumerator Reload(int slot)
    {
        if (CanReload)
        {
            //yield return new WaitForSeconds(_inventory.Get)
            var pAmmoType = _manager.CurrentlEquippedWeaponType;

            if (slot == 0)
            {
                yield return new WaitForSeconds(_inventory.GetItem(0).ReloadTime);

                int ammoToReload = _inventory.GetItem(0).BulletAmount - _primaryCurrentAmmo;

                if (PrimaryStoredAmmo >= ammoToReload)
                {
                    if (_primaryCurrentAmmo == _inventory.GetItem(0).BulletAmount)
                    {
                        Debug.Log("Mag is already full");
                        //return;
                    }
                    _primaryCurrentAmmo += ammoToReload;
                    PrimaryStoredAmmo -= ammoToReload;

                    _primaryMagIsEmpty = false;
                    CheckCanShoot(slot);
                }
                else
                    Debug.Log("Not enough Ammo!");


            }

            if (slot == 1)
            {
                yield return new WaitForSeconds(_inventory.GetItem(1).ReloadTime);

                int ammoToReload = _inventory.GetItem(1).BulletAmount - _secondaryCurrentAmmo;
                if (SecondaryStoredAmmo >= ammoToReload)
                {

                    if (_secondaryCurrentAmmo == _inventory.GetItem(1).BulletAmount)
                    {
                        Debug.Log("Mag is already full");
                        //return;
                    }
                    _secondaryCurrentAmmo += ammoToReload;
                    SecondaryStoredAmmo -= ammoToReload;

                    _secondaryMagIsEmpty = false;
                    CheckCanShoot(slot);
                }
                else
                    Debug.Log("Not enough Ammo!");

            }

        }
        else
            Debug.Log("Can't reload now");
        

        

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
        //_currentPrimaryAmmo = MaxPrimaryAmmo;
        //_currentSecondaryAmmo = MaxSecondaryAmmo;

        _inventory = GetComponent<Inventory>();
        _manager = GetComponent<InventoryManager>();
        var cam = GetComponentInChildren<AimRotation>();

    }


}

