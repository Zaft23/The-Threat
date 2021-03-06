using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;



public class PlayerActions : MonoBehaviour
{
    #region

    //Handles Player actions like firing weapons, melee, and etc


    private Inventory _inventory;
    private InventoryManager _manager;
    private Player _player;

    WeaponRecoil Recoil;
    Weapon newItem;
    private Animator MyAnimator;

    public bool IsMelee;
    public float MeleeTime;

    float lookAngle;
    #region Weapon Details
    [Header("Weapon Details")]
    public Transform FirePoint;
    public GameObject MuzzleFlash;

    //

    public TextMeshProUGUI CurrentPrimaryAmmoText;
    public TextMeshProUGUI CurrentPrimaryMagText;

    public TextMeshProUGUI CurrentSecondaryAmmoText;
    public TextMeshProUGUI CurrentSecondaryMagText;




    //
    public float reloadSpeed;

    private float _lastShootTime = 0;

    [SerializeField] private int _primaryCurrentAmmo;
    public int PrimaryStoredAmmo;

    [SerializeField] private int _secondaryCurrentAmmo;
    public int SecondaryStoredAmmo;

    [SerializeField] private bool _primaryMagIsEmpty = false;
    [SerializeField] private bool _secondaryMagIsEmpty = false;
    [SerializeField] private bool _canShoot;
    public bool CanReload = true;

    //Store primary
    public int StoredRifleAmmo;
    public int StoredSmgAmmo;
    public int StoredShotgunAmmo;
    public int StoredSniperAmmo;


    //primary
    public int MaxRifleSize = 300;
    public int MaxSmgSize = 500;
    public int MaxShotgunSize = 32;
    public int MaxSniperSize = 20;

    //secondary
    //public int MaxSecondaryMags = 50;
    #endregion
    // public Animator Animator;

    public Transform ThrowPoint;


    public float MeleeDamage = 10;
    public Transform MeleePoint;
    public float AttackRange = 0.5f;
    public LayerMask EnemyLayers;

    public bool PrimaryExist = false;
    public bool SecondaryExist = false;
    #endregion


    [Header("Audio Details")]
    public AudioSource audioSource;
    public AudioClip ReloadingSound;
    public AudioClip Sword;
    


    //collision for weapon system
    private void OnCollisionEnter2D(Collision2D target)
    {
        //if(newItem == null)
        //{
        //    return;
        //}

        if (target.collider.gameObject.layer == LayerMask.NameToLayer("Ammo"))
        {

            Destroy(target.transform.gameObject);

        }

            newItem = target.transform.GetComponent<WeaponPickUp>().Weapon;

        var newSlot = target.transform.GetComponent<PickUpItem>();
        // after the && part apparently that fixes the still can grab weapon problem.. holy fuck i don't know how i did it but thank God.. i did it
        // praise the Code God!!

        if (target.collider.gameObject.layer == LayerMask.NameToLayer("PickUp"))
        //if (target.collider.gameObject.layer == LayerMask.NameToLayer("PickUp"))
        {





            if (newSlot.IsPrimary == true && _inventory.IWeapons[0] == null && PrimaryExist == false)
            {
                //Debug.Log("1");
                //Weapon newItem = target.transform.GetComponent<WeaponPickUp>().Weapon;
                _inventory.AddItem(newItem);
                Destroy(target.transform.gameObject);
                PrimaryExist = true;
            }

            else if (newSlot.isSecondary == true && _inventory.IWeapons[1] == null && SecondaryExist == false)
            {
                //Debug.Log("1");
                //Weapon newItem = target.transform.GetComponent<WeaponPickUp>().Weapon;
                _inventory.AddItem(newItem);
                Destroy(target.transform.gameObject);
                SecondaryExist = true;
            }


        }

        //else if (target.collider.gameObject.layer == LayerMask.NameToLayer("PickUp") && _inventory.IWeapons[1] == null)
        ////if (target.collider.gameObject.layer == LayerMask.NameToLayer("PickUp"))
        //{
        //    Debug.Log("2");
        //    //Weapon newItem = target.transform.GetComponent<WeaponPickUp>().Weapon;
        //    _inventory.AddItem(newItem);
        //    Destroy(target.transform.gameObject);

        //}

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

    }

    private void OnDrawGizmos()
    {

        if (MeleePoint == null)
            return;

        Gizmos.DrawWireSphere(MeleePoint.position, AttackRange);

    }

    void Update()
    {
        //Weapon currentWeapon = _inventory.GetItem(_manager.CurrentlyEquippedWeapon);

        //UseAmmo((int)currentWeapon.WeaponSlot, 1, 0);

        AmmoUI();


        #region
        if (Input.GetKeyDown(KeyCode.E) && IsMelee == false)
        {
            MyAnimator.SetTrigger("sword");
            StartCoroutine(MeleeCooldown());
            IsMelee = true;
            _manager.Arm1.SetActive(false);
            _manager.Arm2.SetActive(false);
            _manager.WeaponHand.SetActive(false);
            
            //MeleeAttack();

        }
        //if(Input.GetKeyUp(KeyCode.E))
        //{
        //    _manager.Arm1.SetActive(true);
        //    _manager.Arm2.SetActive(true);
        //}

        Vector3 gunPose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (gunPose.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);

        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }

        //if(Recoil == null)
        //{
        //    return;
        ////    Debug.Log("No recoil");
        //}

        //Recoil = GameObject.Find("Recoil").GetComponent<WeaponRecoil>();

        //try
        //if (Recoil != null)
        //{
            if (Input.GetButton("Fire1") && _manager.Arm1.activeInHierarchy == true)
            {
                //Recoil.AddRecoil();
                //Weapon currentWeapon = _inventory.GetItem(_manager.CurrentlyEquippedWeapon);
                


                //audioSource.Play();
                Shooting();

            }
            //else if (Input.GetButtonUp("Fire1"))
            //{
                //Recoil.StopRecoil();

            //}

        //}
        //else
        //catch
        //{
            //Debug.Log("69");
        //}
        //if (!Recoil)
        //return;




        //reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload(_manager.CurrentlyEquippedWeapon));
            return;

        }

        if (Input.GetKeyDown(KeyCode.G))
        {

            ThrowGun();

        }

        #endregion


    }


    void OnUpgradeMenuToggle(bool active)
    {
        //handle what happens when menu open

    }




    #region Check if player can shoot
    private void CheckCanShoot(int slot)
    {
        //primary
        if (slot == 0)
        {
            if (_primaryMagIsEmpty)
                _canShoot = false;
            else
                _canShoot = true;
        }

        //secondary
        if (slot == 1)
        {
            if (_secondaryMagIsEmpty)
                _canShoot = false;
            else
                _canShoot = true;
        }


    }
    #endregion

    #region initalize ammount of bullets guns can hold
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
    #endregion

    #region Use type of ammo correctly
    private void UseAmmo(int slot, int currentAmmoUsed, int currentStoredAmmoUsed)
    {


        //primary this is not particularly effiecent aswell as the update for the ammo is a bit late... too bad!
        if (slot == 0)
        {
            if (_primaryCurrentAmmo <= 0)
            {
                _primaryMagIsEmpty = true;

                CheckCanShoot(_manager.CurrentlyEquippedWeapon);
            }

            else if (_inventory.GetItem(0).WeaponType == Weapon._WeaponType.Rifles)
            {
                _primaryCurrentAmmo -= currentAmmoUsed;
                PrimaryStoredAmmo = StoredRifleAmmo;
                PrimaryStoredAmmo -= currentStoredAmmoUsed;
            }
            else if (_inventory.GetItem(0).WeaponType == Weapon._WeaponType.SMG)
            {
                _primaryCurrentAmmo -= currentAmmoUsed;
                PrimaryStoredAmmo = StoredSmgAmmo;
                PrimaryStoredAmmo -= currentStoredAmmoUsed;

            }
            else if (_inventory.GetItem(0).WeaponType == Weapon._WeaponType.Shotgun)
            {
                _primaryCurrentAmmo -= currentAmmoUsed;
                PrimaryStoredAmmo = StoredShotgunAmmo;
                PrimaryStoredAmmo -= currentStoredAmmoUsed;

            }
            else if (_inventory.GetItem(0).WeaponType == Weapon._WeaponType.SniperRifle)
            {
                _primaryCurrentAmmo -= currentAmmoUsed;
                PrimaryStoredAmmo = StoredSniperAmmo;
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

            else if (_inventory.GetItem(1).WeaponType == Weapon._WeaponType.Rifles)
            {
                _secondaryCurrentAmmo -= currentAmmoUsed;
                SecondaryStoredAmmo = StoredRifleAmmo;
                SecondaryStoredAmmo -= currentStoredAmmoUsed;
            }
            else if (_inventory.GetItem(1).WeaponType == Weapon._WeaponType.SMG)
            {
                _secondaryCurrentAmmo -= currentAmmoUsed;
                SecondaryStoredAmmo = StoredSmgAmmo;
                SecondaryStoredAmmo -= currentStoredAmmoUsed;
            }
            else if (_inventory.GetItem(1).WeaponType == Weapon._WeaponType.Shotgun)
            {
                _secondaryCurrentAmmo -= currentAmmoUsed;
                SecondaryStoredAmmo = StoredShotgunAmmo;
                SecondaryStoredAmmo -= currentStoredAmmoUsed;
            }
            else if (_inventory.GetItem(1).WeaponType == Weapon._WeaponType.SniperRifle)
            {
                _secondaryCurrentAmmo -= currentAmmoUsed;
                SecondaryStoredAmmo = StoredSniperAmmo;
                SecondaryStoredAmmo -= currentStoredAmmoUsed;
            }

        }
    }
    #endregion

    #region Gun Shoots bullets
    public void BulletShoot(Weapon currentWeapon)
    {
        //lame set up shit again ffs
        var currWeapon = _inventory.GetItem(_manager.CurrentlyEquippedWeapon);
        var currWeaponSpeed = currWeapon.BulletSpeed;


        GameObject fire = Instantiate(currWeapon.BulletPrefab);

        fire.transform.position = GameObject.Find("NewFirePoint/Recoil/NewPoint").transform.position;

        fire.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        fire.GetComponent<Rigidbody2D>().velocity = FirePoint.right * currWeaponSpeed;



        GameObject effect = Instantiate(MuzzleFlash);
        //Destroy(effect, 5f);
        effect.transform.position = GameObject.Find("NewFirePoint/Recoil/NewPoint").transform.position;

        effect.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        //effect.GetComponent<Rigidbody2D>().velocity = FirePoint.right * currWeaponSpeed;




    }
    #endregion

    #region shoot logic
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

                audioSource.PlayOneShot(currentWeapon.ShootingSound);

                UseAmmo((int)currentWeapon.WeaponSlot, 1, 0);

            }
        }
        else
            Debug.Log("No Ammo!");


    }
    #endregion

    #region reload logic
    IEnumerator Reload(int slot)
    {
        if (CanReload)
        {

            audioSource.PlayOneShot(ReloadingSound);

            //yield return new WaitForSeconds(_inventory.Get)
            var pAmmoType = _manager.CurrentlEquippedWeaponType;

            if (slot == 0)
            {
                yield return new WaitForSeconds(_inventory.GetItem(0).ReloadTime - reloadSpeed);
                int ammoToReload = _inventory.GetItem(0).BulletAmount - _primaryCurrentAmmo;

                if (PrimaryStoredAmmo >= ammoToReload)
                {
                    if (_primaryCurrentAmmo == _inventory.GetItem(0).BulletAmount)
                    {
                        Debug.Log("Mag is already full");
                        //return;
                    }
                    else if (_inventory.GetItem(0).WeaponType == Weapon._WeaponType.Rifles)
                    {
                        _primaryCurrentAmmo += ammoToReload;
                        StoredRifleAmmo -= ammoToReload;

                        _primaryMagIsEmpty = false;
                        CheckCanShoot(slot);

                    }
                    else if (_inventory.GetItem(0).WeaponType == Weapon._WeaponType.SMG)
                    {
                        _primaryCurrentAmmo += ammoToReload;
                        StoredSmgAmmo -= ammoToReload;

                        _primaryMagIsEmpty = false;
                        CheckCanShoot(slot);

                    }
                    else if (_inventory.GetItem(0).WeaponType == Weapon._WeaponType.Shotgun)
                    {
                        _primaryCurrentAmmo += ammoToReload;
                        StoredShotgunAmmo -= ammoToReload;

                        _primaryMagIsEmpty = false;
                        CheckCanShoot(slot);

                    }
                    else if (_inventory.GetItem(0).WeaponType == Weapon._WeaponType.SniperRifle)
                    {
                        _primaryCurrentAmmo += ammoToReload;
                        StoredSniperAmmo -= ammoToReload;

                        _primaryMagIsEmpty = false;
                        CheckCanShoot(slot);

                    }

                }
                else
                    Debug.Log("Not enough Ammo!");


            }


            if (slot == 1)
            {
                yield return new WaitForSeconds(_inventory.GetItem(1).ReloadTime - reloadSpeed);

                int ammoToReload = _inventory.GetItem(1).BulletAmount - _secondaryCurrentAmmo;
                if (SecondaryStoredAmmo >= ammoToReload)
                {

                    if (_secondaryCurrentAmmo == _inventory.GetItem(1).BulletAmount)
                    {
                        Debug.Log("Mag is already full");
                        //return;
                    }
                    else if (_inventory.GetItem(1).WeaponType == Weapon._WeaponType.Rifles)
                    {
                        _secondaryCurrentAmmo += ammoToReload;
                        StoredRifleAmmo -= ammoToReload;

                        _secondaryMagIsEmpty = false;
                        CheckCanShoot(slot);

                    }

                    else if (_inventory.GetItem(1).WeaponType == Weapon._WeaponType.SMG)
                    {
                        _secondaryCurrentAmmo += ammoToReload;
                        StoredSmgAmmo -= ammoToReload;

                        _secondaryMagIsEmpty = false;
                        CheckCanShoot(slot);

                    }
                    else if (_inventory.GetItem(1).WeaponType == Weapon._WeaponType.SMG)
                    {
                        _secondaryCurrentAmmo += ammoToReload;
                        StoredShotgunAmmo -= ammoToReload;

                        _secondaryMagIsEmpty = false;
                        CheckCanShoot(slot);

                    }
                    else if (_inventory.GetItem(1).WeaponType == Weapon._WeaponType.SMG)
                    {
                        _secondaryCurrentAmmo += ammoToReload;
                        StoredSniperAmmo -= ammoToReload;

                        _secondaryMagIsEmpty = false;
                        CheckCanShoot(slot);

                    }

                }
                else
                    Debug.Log("Not enough Ammo!");

            }

        }
        else
            Debug.Log("Can't reload now");




    }
    #endregion

    #region throw or remove gun from slot
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

        PickAbleGun.transform.position = ThrowPoint.position;
        PickAbleGun.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
        PickAbleGun.GetComponent<Rigidbody2D>().velocity = FirePoint.right * force;



        _manager.UnEquipWeapon();

    }
    #endregion

    #region Melee
    void MeleeAttack()
    {

        //animation setup followw https://www.youtube.com/watch?v=sPiVz1k-fEs&ab_channel=Brackeys
        //MyAnimator.SetTrigger("sword");


        //detect range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(MeleePoint.position, AttackRange, EnemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            //rewrite  name
            //enemy stats component
            enemy.GetComponent<EnemyStats>().TakeDamage(MeleeDamage + _player.BaseDamage);

        }


    }


    public void ActivateHand()
    {
        if(_player.Holstered == false)
        {
            _manager.WeaponHand.SetActive(true);
            _manager.Arm1.SetActive(true);
            _manager.Arm2.SetActive(true);
            
        }
        else
        {
            Debug.Log("Player is not Holstered");
        }

    }
    public void DeactivateHand()
    {
        _manager.Arm1.SetActive(true);
        _manager.Arm2.SetActive(true);
    }


    private IEnumerator MeleeCooldown()
    {
        yield return new WaitForSeconds(MeleeTime);

        IsMelee = false;

        //if(_player.Holstered == false)
        //{
        //    _manager.Arm1.SetActive(true);
        //    _manager.Arm2.SetActive(true);
        //}



    }







    #endregion


    public void PlaySwordSound()
    {


        audioSource.PlayOneShot(Sword);
        audioSource.volume = 0.8f;
        //audioSource.pitch = Random.Range(0.5f, 1.1f);

    }


    public void AmmoUI()
    {
        CurrentPrimaryMagText.text = _primaryCurrentAmmo.ToString();
        CurrentPrimaryAmmoText.text = PrimaryStoredAmmo.ToString();

        CurrentSecondaryMagText.text = _secondaryCurrentAmmo.ToString();
        CurrentSecondaryAmmoText.text = SecondaryStoredAmmo.ToString();

        

    }


    private void GetRefrences()
    {
        
        //CheckAmmo((int)weapon.WeaponSlot, 0, 1);
        

        _canShoot = true;
        CanReload = true;
        _inventory = GetComponent<Inventory>();
        _manager = GetComponent<InventoryManager>();
        _player = GetComponent<Player>();
        var cam = GetComponentInChildren<AimRotation>();

        MyAnimator = GetComponent<Animator>();
        //Test
        IsMelee = false;


        //InitAmmo(_inventory.IWeapons[0].BulletAmount, _inventory.GetItem(0));
        //InitAmmo(_inventory.IWeapons[1].BulletAmount, _inventory.GetItem(1));
        //Test


    }

    public void CheckGun()
    {
        _inventory.IWeapons[0] = _inventory.IWeapons[0];
        _inventory.IWeapons[1] = _inventory.IWeapons[1];

    }





 




}

