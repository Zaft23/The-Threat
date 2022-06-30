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
 



    //public Sprite LockedImage, UnlockedImage;
    public GameObject SkillWindow;
    public GameObject OpenIncreaseBase;
    public Button IncreaseBaseButton, IncreasHealthButton;
    //public Image IncreaseBaseIcon, IncreaseHealthIcon;

    private string unlockMatrixPath;

    //get player's stat's SP
    //get player's level


    // Start is called before the first frame update
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        playerStats = _player.GetComponent<Player>();
        playerLevel = _player.GetComponent<LevelSystem>();

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

    #region IncreaseBase
    public void ToggleOnIncreaseBase()
    {
        OpenIncreaseBase.SetActive(true);
        audioSource.PlayOneShot(ButtonPress);
        audioSource.volume = 0.7f;
    }
    public void ToggleOffIncreaseBase()
    {
        OpenIncreaseBase.SetActive(false);
        audioSource.PlayOneShot(ButtonPress);
        audioSource.volume = 0.7f;
    }

    public void BuyIncreaseBase()
    {
        audioSource.PlayOneShot(ButtonPress);
        audioSource.volume = 0.7f;
        //true matrix
        if (playerStats.SkillPoint >= 4 && playerLevel.Level >= 1)
        {
            playerStats.SkillPoint -= 2;

            unlockableMatrix.HasIncreaseBase = true;
            playerStats.MaxHealth = playerStats.MaxHealth + 100;
            playerStats.Health = playerStats.Health +  100;
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
    #endregion

    public void BuyIncreaseHealth()
    {
        audioSource.PlayOneShot(ButtonPress);
        audioSource.volume = 0.7f;
        if (playerStats.SkillPoint >= 2 && playerLevel.Level >= 2)
        {
            playerStats.SkillPoint -= 2;

            unlockableMatrix.HasIncreaseHealth = true;
            playerStats.MaxHealth = playerStats.MaxHealth + 50;
            playerStats.Health = playerStats.Health + 50;
            RerenderShop();
            SaveJson();
            
        }
        else
        {
          // Debug.Log("Fuck");
        }
        
    }

    



    //





    public void RerenderShop()
    {
        if(unlockableMatrix.HasIncreaseBase)
        {
            //IncreaseBaseIcon.sprite = UnlockedImage;
            IncreaseBaseButton.interactable = false;

        }

        if (unlockableMatrix.HasIncreaseHealth)
        {
           //IncreaseHealthIcon.sprite = UnlockedImage;
           IncreasHealthButton.interactable = false;

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
