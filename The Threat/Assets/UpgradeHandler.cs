using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    public static UpgradeHandler instance;

    public Upgrade[] upgrades;
    public UpgradeButton[] upgradeButtons;

    

    [SerializeField]
     public Upgrade _activateUpgrade;
    //private GameObject _upgrade;
    UpgradeManager upgradeManager;


    private void Awake()
    {
        
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);

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
