using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UpgradeButton : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip ButtonPress;

    public Image UpgradeIcon;
    public TextMeshProUGUI UpgradeNameText;
    public TextMeshProUGUI UpgradeDesText;
    public TextMeshProUGUI UpgradeReqText;

    public int UpgradeID;

    public Button Buy;

    //public AudioClip ButtonPress;
    public UpgradeManager manager;


    //

    private GameObject _player;
    Player playerStats;
    LevelSystem playerLevel;
    PlayerActions actions;
    Inventory inventory;
    int playerSP;


    Transform playerPos;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        playerStats = _player.GetComponent<Player>();
        playerLevel = _player.GetComponent<LevelSystem>();
        playerPos = _player.GetComponent<Transform>();
        actions = _player.GetComponent<PlayerActions>();
        inventory = _player.GetComponent<Inventory>();
        playerSP = _player.GetComponent<Player>().SkillPoint;

    }

    public void SavePlayer()
    {
        SavePlayerData.SavePlayer(playerStats, playerLevel, actions, inventory);
    }

    //


    public void PressUpgradeButton()
    {
        audioSource.PlayOneShot(ButtonPress);

        UpgradeHandler.instance._activateUpgrade = transform.GetComponent<Upgrade>();

        UpgradeIcon.sprite = UpgradeHandler.instance.upgrades[UpgradeID].SkillIcon;
        UpgradeNameText.text = UpgradeHandler.instance.upgrades[UpgradeID].SkillName;
        UpgradeDesText.text = UpgradeHandler.instance.upgrades[UpgradeID].SkillDes;
        UpgradeReqText.text = UpgradeHandler.instance.upgrades[UpgradeID].SkillReq;
        Buy.onClick.AddListener(UpgradeBuy);


    }

    public void UpgradeBuy()
    {
        //audioSource.PlayOneShot(ButtonPress);

        if (UpgradeID == 0)
        {
            manager.BuyIncreaseBase();
        }

        if(UpgradeID == 1)
        {
            manager.BuyIncreaseHealth();
        }

        if(UpgradeID == 2)
        {
            manager.BuyIncreaseHealth2();
        }

        if(UpgradeID == 3)
        {
            manager.BuyBaseDamage();
        }

        if(UpgradeID == 4)
        {
            manager.BuyBaseDamage2();
        }
        if(UpgradeID == 5)
        {
            manager.BuyReloadSpeed();
        }
        if (UpgradeID == 6)
        {
            manager.BuyMoveSpeed();
        }
        if (UpgradeID == 7)
        {
            manager.BuyMoveSpeed2();
        }

        SavePlayer();


    }

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
