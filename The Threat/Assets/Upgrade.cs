using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public string SkillName;
    public Sprite SkillIcon;


    [TextArea(1, 4)]
    public string SkillDes;


    [TextArea(1, 6)]
    public string SkillReq;

    public Button BuySkill;

    public AudioClip ButtonPress;

    [SerializeField]
    private GameObject _upgrade;
    UpgradeManager upgradeManager;

    private void Awake()
    {
        _upgrade = GameObject.FindGameObjectWithTag("Upgrade");
        upgradeManager = _upgrade.GetComponent<UpgradeManager>();
    }


    private void Start()
    {
        
    }

   












}
