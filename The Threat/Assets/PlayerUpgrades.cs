using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades 
{
    //skillType
    public enum Upgrades
    {
        TestIncreaseHealth,
        TestIncreaseDamage,

    }

    private List<Upgrades> unlockedUpgradesTypeList;

    public PlayerUpgrades()
    {
        unlockedUpgradesTypeList = new List<Upgrades>();
    }


    public void UnlockUpgrade(Upgrades upgrades)
    {
        unlockedUpgradesTypeList.Add(upgrades);
    }

    public bool IsUpgradesUnlocked(Upgrades upgrades)
    {

        return unlockedUpgradesTypeList.Contains(upgrades);
    }






}
