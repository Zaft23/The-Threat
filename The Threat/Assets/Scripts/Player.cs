using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class Player : MonoBehaviour
{
    #region
    public float Health;
    public float MaxHealth;
    public float HealthRegenPerSecond;
    public float StartHealthRegen;

    [SerializeField]
    private bool _canHeal;

    public float BaseDamage;
    public float BaseSpeed;
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
    [SerializeField] private PlayerActions _playerActions;
    // PlayerUpgrades PlayerUpgrades;
    private PlayerSkills playerSkills;




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
        //cooldownTimer = 0f;
    }


    //[SerializeField]
    //private float cooldownTimer;
    [SerializeField]
    private float canHealTimer;

    // Update is called once per frame
    void Update()
    {

        //start health regen

        //Health += HealthRegenPerSecond * Time.deltaTime;
        

        //HealthRegen
        if (Health >= MaxHealth)
        {
            Health = MaxHealth;
            //cooldownTimer = 0;

        }

        if (_canHeal == false)
        {
            canHealTimer += Time.deltaTime;
            if (canHealTimer >= StartHealthRegen )
            {
                _canHeal = true;
                canHealTimer = 0;
            }

        }

        else if (Health < MaxHealth && _canHeal == true)
        {
            //cooldownTimer += Time.deltaTime;
            //if (cooldownTimer >= StartHealthRegen)
            //{
                Health += HealthRegenPerSecond * Time.deltaTime;
                
            //}
        }

      














        #region
        float eulerAngY = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).y;

        if (Input.GetKeyDown(KeyCode.D) && eulerAngY == 0)
        {

            //Debug.Log("Forward1");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", 1.0f);

        }
        else if (Input.GetKeyDown(KeyCode.A) && eulerAngY == -180)
        {
            //Debug.Log("Forward2");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.A) && eulerAngY == 0)
        {

            //Debug.Log("BackWard1");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", -1.0f);

        }
        else if (Input.GetKeyDown(KeyCode.D) && eulerAngY == -180)
        {
            //Debug.Log("BackWard2");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", -1.0f);
        }

        if (Holstered == false)
        {
            MyAnimator.SetBool("holstered", false);
        }
        else if (Holstered == true)
        {
            MyAnimator.SetBool("holstered", true);
        }



        if (eulerAngY == 180 || eulerAngY == 0)
        {
            //Debug.Log("Right!!!!!!!!!!");
            _facingRight = true;
        }
        else if (eulerAngY == -180)
        {
            //Debug.Log("Left!!!!!!!!!!");
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


    public PlayerSkills GetPlayerSkills()
    {
        return playerSkills;
    }


        void OnUpgradeMenuToggle(bool active)
        {
            //handle what happens when menu open
            Actions.enabled = !active;
            _playerMovement.enabled = !active;
        }




        #region Handles Damage
        public void TakeDamage(float Damage)
        {
            _canHeal = false;
            Health -= Damage;
            canHealTimer = 0;

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
            _canHeal = true;
            Holstered = true;
            MyAnimator = GetComponent<Animator>();
            Gm.OnToggleUpgradeMenu += OnUpgradeMenuToggle;
        }

        private void GetAwakeRefrence()
        {
            Actions = GetComponent<PlayerActions>();
            _playerMovement = GetComponent<PlayerMovement>();
            playerSkills = new PlayerSkills();
            




            //PlayerUpgrades = new PlayerUpgrades();
            //_levelSystem = new LevelSystem();
            //_levelSystemAnimator = new LevelSystemAnimator(_levelSystem);


        }

    
}
