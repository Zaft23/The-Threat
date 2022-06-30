using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;




public class UpgradeManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip ButtonPress;

    public UnlockableMatrix unlockableMatrix;

    private GameObject _player;
    LevelSystem playerLevel;
    Player playerStats;
    PlayerActions playerAct;

    private string unlockMatrixPath;

    //public UpgradeButton[] upgradeButton;
    //private GameObject _upgrade;

    //public UpgradeButton[] upgradeButtons

    //public Sprite LockedImage, UnlockedImage;
    //public GameObject SkillWindow;
    //public GameObject OpenIncreaseBase;
    //public Button IncreaseBaseButton, IncreasHealthButton;
    //public Image IncreaseBaseIcon, IncreaseHealthIcon;


    // Start is called before the first frame update
    private void Awake()
    {
        //_upgrade = GameObject.FindGameObjectWithTag("Upgrade");
        //upgradeButton = _upgrade.GetComponent<UpgradeButton>();

        _player = GameObject.FindGameObjectWithTag("Player");
        playerStats = _player.GetComponent<Player>();
        playerLevel = _player.GetComponent<LevelSystem>();
        playerAct = _player.GetComponent<PlayerActions>();
    }

    void Start()
    {
        

        unlockMatrixPath = $"{Application.persistentDataPath}/UnlockMatrix.json";

        if(File.Exists(unlockMatrixPath))
        {
            string json = File.ReadAllText(unlockMatrixPath);
            unlockableMatrix = JsonUtility.FromJson<UnlockableMatrix>(json);

        }


        RerenderShop(); 



    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("please begone");
            DeleteJson();


        }


    }



    //this is an upgrade


    #region 

    //public void ToggleOnIncreaseBase()
    //{
    //    OpenIncreaseBase.SetActive(true);
    //    audioSource.PlayOneShot(ButtonPress);
    //    audioSource.volume = 0.7f;
    //}
    //public void ToggleOffIncreaseBase()
    //{
    //    OpenIncreaseBase.SetActive(false);
    //    audioSource.PlayOneShot(ButtonPress);
    //    audioSource.volume = 0.7f;
    //}
    #endregion


    #region 
    public void BuyIncreaseBase()
    {
        audioSource.PlayOneShot(ButtonPress);
        audioSource.volume = 0.7f;
        //true matrix
        if (playerStats.SkillPoint >= 4 && playerLevel.Level >= 1 && unlockableMatrix.HasIncreaseBase == false)
        {
            playerStats.SkillPoint -= 4;

            unlockableMatrix.HasIncreaseBase = true;
            playerStats.MaxHealth = playerStats.MaxHealth + 50;
            playerStats.Health = playerStats.Health + 50;
            playerStats.BaseDamage = 10;
            RerenderShop();
            SaveJson();
            //Debug.Log("SHIT");
        }
        else
        {
            // Debug.Log("SHIT");
        }

    }


    public void BuyIncreaseHealth()
    {
        audioSource.PlayOneShot(ButtonPress);
        audioSource.volume = 0.7f;
        if (playerStats.SkillPoint >= 2 && playerLevel.Level >= 3 && unlockableMatrix.HasIncreaseHealth == false)
        {
            playerStats.SkillPoint -= 2;

            unlockableMatrix.HasIncreaseHealth = true;
            //bool matrix
            playerStats.MaxHealth = playerStats.MaxHealth + 100;
            playerStats.Health = playerStats.Health + 100;
            RerenderShop();
            SaveJson();

        }
        else
        {
            // Debug.Log("Fuck");
        }

    }

    public void BuyIncreaseHealth2()
    {
        audioSource.PlayOneShot(ButtonPress);
        audioSource.volume = 0.7f;
        if (playerStats.SkillPoint >= 5 && playerLevel.Level >= 7 && unlockableMatrix.HasIncreaseHealth2 == false && unlockableMatrix.HasIncreaseHealth == true)
        {
            playerStats.SkillPoint -= 5;

            //bool matrix
            unlockableMatrix.HasIncreaseHealth2 = true;
            playerStats.MaxHealth = playerStats.MaxHealth + 200;
            playerStats.Health = playerStats.Health + 200;
            RerenderShop();
            SaveJson();

        }
        else
        {
            // Debug.Log("Fuck");
        }
    }

    public void BuyBaseDamage()
    {
        audioSource.PlayOneShot(ButtonPress);
        audioSource.volume = 0.7f;
        if (playerStats.SkillPoint >= 3 && playerLevel.Level >= 3 && unlockableMatrix.HasIncreaseBaseDamage == false)
        {
            playerStats.SkillPoint -= 3;

            //bool matrix
            unlockableMatrix.HasIncreaseHealth = true;
            playerStats.BaseDamage = playerStats.BaseDamage + 15;
            RerenderShop();
            SaveJson();

        }
        else
        {
            // Debug.Log("Fuck");
        }
    }

    public void BuyBaseDamage2()
    {
        audioSource.PlayOneShot(ButtonPress);
        audioSource.volume = 0.7f;
        if (playerStats.SkillPoint >= 5 && playerLevel.Level >= 8 && unlockableMatrix.HasIncreaseBaseDamage2 == false && unlockableMatrix.HasIncreaseBaseDamage2 == true)
        {
            playerStats.SkillPoint -= 5;

            //bool matrix
            unlockableMatrix.HasIncreaseHealth2 = true;
            playerStats.BaseDamage = playerStats.BaseDamage + 30;
            RerenderShop();
            SaveJson();

        }
        else
        {
            // Debug.Log("Fuck");
        }

    }

    public void BuyReloadSpeed()
    {
        audioSource.PlayOneShot(ButtonPress);
        audioSource.volume = 0.7f;
        if (playerStats.SkillPoint >= 4 && playerLevel.Level >= 7 && unlockableMatrix.HasReloadSpeed == false)
        {
            playerStats.SkillPoint -= 4;

            //bool matrix
            unlockableMatrix.HasReloadSpeed = true;
            playerAct.reloadSpeed = playerAct.reloadSpeed + 0.5f ;
            RerenderShop();
            SaveJson();

        }
        else
        {
            // Debug.Log("Fuck");
        }
    }

    public void BuyMoveSpeed()
    {

        audioSource.PlayOneShot(ButtonPress);
        audioSource.volume = 0.7f;
        if (playerStats.SkillPoint >= 4 && playerLevel.Level >= 5 && unlockableMatrix.HasMoveSpeed == false)
        {
            playerStats.SkillPoint -= 4;

            //bool matrix
            unlockableMatrix.HasMoveSpeed = true;

            //effect
            playerStats.BaseSpeed = playerStats.BaseSpeed + 2;

            RerenderShop();
            SaveJson();

        }
        else
        {
            // Debug.Log("Fuck");
        }

    }

    public void BuyMoveSpeed2()
    {

        audioSource.PlayOneShot(ButtonPress);
        audioSource.volume = 0.7f;
        if (playerStats.SkillPoint >= 6 && playerLevel.Level >= 10 && unlockableMatrix.HasMoveSpeed2 == false && unlockableMatrix.HasMoveSpeed == true)
        {
            playerStats.SkillPoint -= 4;

            //bool matrix
            unlockableMatrix.HasMoveSpeed2 = true;

            //effect
            playerStats.BaseSpeed = playerStats.BaseSpeed + 3;

            RerenderShop();
            SaveJson();

        }
        else
        {
            // Debug.Log("Fuck");
        }

    }





    #endregion


    #region
    //public void BuyUpgrade()
    //{
    //    audioSource.PlayOneShot(ButtonPress);
    //    audioSource.volume = 0.7f;
    //    //true matrix
    //    //refrence singleton

    //    if (playerStats.SkillPoint >= 4 && playerLevel.Level >= 1 && upgradeButton[0] && unlockableMatrix.HasIncreaseBase == false )
    //    {
    //        playerStats.SkillPoint -= 2;

    //        unlockableMatrix.HasIncreaseBase = true;
    //        playerStats.MaxHealth = playerStats.MaxHealth + 50;
    //        playerStats.Health = playerStats.Health + 50;
    //        playerStats.BaseDamage = 10;
    //        RerenderShop();
    //        SaveJson();
    //        Debug.Log("Bought Base Mutation");
    //    }
    //    else if (playerStats.SkillPoint >= 2 && playerLevel.Level >= 2 && upgradeButton[1] & unlockableMatrix.HasIncreaseHealth == false)
    //    {
    //        playerStats.SkillPoint -= 2;

    //        unlockableMatrix.HasIncreaseHealth = true;
    //        playerStats.MaxHealth = playerStats.MaxHealth + 100;
    //        playerStats.Health = playerStats.Health + 100;
    //        RerenderShop();
    //        SaveJson();
    //        Debug.Log("Bought Health Increase");
    //    }
    //    else
    //    {
    //        Debug.Log("Fuck");
    //    }


    //}

    #endregion test

    public void RerenderShop()
    {
        if(unlockableMatrix.HasIncreaseBase)
        {
            //IncreaseBaseIcon.sprite = UnlockedImage;
            //IncreaseBaseButton.interactable = false;

        }

        if (unlockableMatrix.HasIncreaseHealth)
        {
           //IncreaseHealthIcon.sprite = UnlockedImage;
           //IncreasHealthButton.interactable = false;

        }


    }




















    private void SaveJson()
    {
        string json = JsonUtility.ToJson(unlockableMatrix);
        File.WriteAllText(unlockMatrixPath, json);


    }

    private void DeleteJson()
    {
        string json = JsonUtility.ToJson(unlockableMatrix);
        File.Delete(Application.persistentDataPath + "/UnlockMatrix.json");
    }




}
