using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class Player : MonoBehaviour
{
    #region
    public float Health;
    public float BaseDamage;
    public Vector3 Direction;

    public Transform MyRotation;

    public PlayerActions Actions;

    private Animator MyAnimator;

    public GameObject Arm1;
    public GameObject Arm2;

    public bool Holstered;

    //
    


    [SerializeField]
    private bool _facingRight;


    public static Player Instance { get; private set; }
    #endregion

    //private LevelSystemAnimator _levelSystemAnimator;
    //private LevelSystem _levelSystem;
    //
    //public TMPro.TextMeshProUGUI levelText;

    public GameMaster Gm;

    [SerializeField] private PlayerMovement _playerMovement;
    // [SerializeField] private PlayerActions _playerActions;
    // PlayerUpgrades PlayerUpgrades;

    //delegate
    public int SkillPoint;
    public int LvlUpSkillPoint = 10;

    private void Awake()
    {
        GetAwakeRefrence();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetRefrence();

    }

    // Update is called once per frame
    void Update()
    {


        #region
        float eulerAngY = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).y;

        if (Input.GetKeyDown(KeyCode.D) && eulerAngY == 0)
        {

            Debug.Log("Forward1");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", 1.0f);

        }
        else if (Input.GetKeyDown(KeyCode.A) && eulerAngY == -180)
        {
            Debug.Log("Forward2");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.A) && eulerAngY == 0)
        {

            Debug.Log("BackWard1");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", -1.0f);

        }
        else if (Input.GetKeyDown(KeyCode.D) && eulerAngY == -180)
        {
            Debug.Log("BackWard2");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", -1.0f);
        }

        if (Holstered == false)
        {
            MyAnimator.SetBool("holstered", false);
        }
        else if(Holstered == true)
        {
            MyAnimator.SetBool("holstered", true);
        }



        if (eulerAngY == 180 || eulerAngY == 0)
        {
            Debug.Log("Right!!!!!!!!!!");
            _facingRight = true;
        }
        else if(eulerAngY == -180 )
        {
            Debug.Log("Left!!!!!!!!!!");
            _facingRight = false;
        }

        //GetDirection();

        //if(_facingRight == false)
        //{
        //ChangeDirection();
        //}
        #endregion

    }

    public void GiveSkillPoints()
    {
        //(int skillpoint/level)
        //some other logic if following the guys tutorial
        SkillPoint += LvlUpSkillPoint;
        
    }











    void OnUpgradeMenuToggle(bool active)
    {
        //handle what happens when menu open
       Actions.enabled = !active;
       _playerMovement.enabled = !active;
    }

    #region Handles Levelling old and shit
    //public void SetLevelSystemAnimator(LevelSystemAnimator levelSystemAnimator)
    //{
    //    this._levelSystemAnimator = levelSystemAnimator;

    //    levelSystemAnimator.OnLevelChanged += LevelSystem_OnLevelChanged;

    //    //here can change stats

    //}

    //private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    //{
    //    //play sound probable later add lah
    //    Debug.Log("Your Level Increase");

    //}

    //public PlayerUpgrades GetPlayerUpgrades()
    //{
    //    return PlayerUpgrades;
    //}


    //public bool TestIncreaseHealth()
    //{
    //    return PlayerUpgrades.IsUpgradesUnlocked(PlayerUpgrades.Upgrades.TestIncreaseHealth);
    //}

    //public bool CanTestIncreaseHealth()
    //{
    //    return true;
    //}


    #endregion


    #region Handles Damage
    public void TakeDamage(float Damage)
    {

        Health -= Damage;

        //do animation

        if (Health <= 0)
        {
            Debug.Log("i die");
            //Die();
        }

    }
    #endregion

    #region misc
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector2 GetDirection()
    {
        return _facingRight ? Vector2.right : Vector2.left;
    }

    public void ChangeDirection()
    {
        _facingRight = !_facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    #endregion

    private void GetRefrence()
    {
        //_facingRight = true;
        
        Holstered = true;
        MyAnimator = GetComponent<Animator>();
        Gm.OnToggleUpgradeMenu += OnUpgradeMenuToggle;
    }

    private void GetAwakeRefrence()
    {
        Actions = GetComponent<PlayerActions>();
        _playerMovement = GetComponent<PlayerMovement>();

        //PlayerUpgrades = new PlayerUpgrades();
        //_levelSystem = new LevelSystem();
        //_levelSystemAnimator = new LevelSystemAnimator(_levelSystem);


    }

}
