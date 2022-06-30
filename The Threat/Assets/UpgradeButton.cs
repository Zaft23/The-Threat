using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UpgradeButton : MonoBehaviour
{

    public Image UpgradeIcon;
    public TextMeshProUGUI UpgradeNameText;
    public TextMeshProUGUI UpgradeDesText;
    public TextMeshProUGUI UpgradeReqText;

    public int UpgradeID;

    public Button BuySkill;

    public AudioClip ButtonPress;

    [SerializeField]
    private GameObject _upgrade;
    UpgradeManager upgradeManager;




    public void PressUpgradeButton()
    {
        UpgradeHandler.instance._activateUpgrade = transform.GetComponent<Upgrade>();

        UpgradeIcon.sprite = UpgradeHandler.instance.upgrades[UpgradeID].SkillIcon;
        UpgradeNameText.text = UpgradeHandler.instance.upgrades[UpgradeID].SkillName;
        UpgradeDesText.text = UpgradeHandler.instance.upgrades[UpgradeID].SkillDes;
        UpgradeReqText.text = UpgradeHandler.instance.upgrades[UpgradeID].SkillReq;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
