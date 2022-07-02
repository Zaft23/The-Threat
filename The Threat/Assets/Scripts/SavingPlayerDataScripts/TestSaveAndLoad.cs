using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestSaveAndLoad : MonoBehaviour
{

    private GameObject _player;
    Player playerStats;
    LevelSystem playerLevel;
    PlayerActions actions;
    Inventory inventory;
    int playerSP;

    public GameObject PlayerHierarchy;

   



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


    public void LoadPlayerTwice()
    {
        LoadPlayer();
        LoadPlayer();
    }

    public void LoadPlayer()
    {
        PlayerData data = SavePlayerData.LoadPlayer();

        playerStats.Health = data.Health;
        playerStats.SkillPoint = data.SkillPoints;
        playerLevel.Level = data.Level;
        playerLevel.currentXp = data.Exp;
        playerLevel.nextLevelXp = data.NextLevelExp;

        playerStats.MaxHealth = data.MaxHP;
        playerStats.BaseDamage = data.Damage;
        playerStats.BaseSpeed = data.Speed;
        actions.StoredRifleAmmo = data.RifleAmmo;
        actions.StoredSmgAmmo = data.SMGAmmo;
        actions.StoredShotgunAmmo = data.ShotgunAmmo;
        actions.StoredSniperAmmo = data.SniperAmmo;



        Vector3 Pos;
        Pos = playerPos.transform.position;
        Debug.Log("LOADDDDD");
        //Vector3 position;
        Pos.x = data.XPosition;
        Pos.y = data.YPosition;
        Pos.z = data.ZPosition;
        playerPos.transform.position = Pos;

        //
        //inventory.IWeapons[0] = data.weapon1;
        //inventory.IWeapons[1] = data.weapon2;


        //



    }

    public void LoadPlayerAlive()
    {
        PlayerHierarchy.SetActive(true);

        PlayerData data = SavePlayerData.LoadPlayer();

        playerStats.Health = data.Health;
        playerStats.SkillPoint = data.SkillPoints;
        playerLevel.Level = data.Level;
        playerLevel.currentXp = data.Exp;
        playerLevel.nextLevelXp = data.NextLevelExp;

        playerStats.MaxHealth = data.MaxHP;
        playerStats.BaseDamage = data.Damage;
        playerStats.BaseSpeed = data.Speed;
        actions.StoredRifleAmmo = data.RifleAmmo;
        actions.StoredSmgAmmo = data.SMGAmmo;
        actions.StoredShotgunAmmo = data.ShotgunAmmo;
        actions.StoredSniperAmmo = data.SniperAmmo;



        Vector3 Pos;
        Pos = playerPos.transform.position;
        Debug.Log("LOADDDDD");
        //Vector3 position;
        Pos.x = data.XPosition;
        Pos.y = data.YPosition;
        Pos.z = data.ZPosition;
        playerPos.transform.position = Pos;



        //inventory.IWeapons[0] = data.weapon1;
        //inventory.IWeapons[1] = data.weapon2;


    }

    //public void SaveSkillPoints()
    //{
    //    SavePlayerData.playerSP;


    //}


    public void LoadSkillPoint()
    {
        PlayerData data = SavePlayerData.LoadPlayer();

        playerStats.SkillPoint = data.SkillPoints;


    }


    public void LoadPosition()
    {

        PlayerData data = SavePlayerData.LoadPlayer();

        Vector3 Pos;
        Pos = playerPos.transform.position;
        Debug.Log("LOADDDDD");
        //Vector3 position;
        Pos.x = data.XPosition;
        Pos.y = data.YPosition;
        Pos.z = data.ZPosition;
        playerPos.transform.position = Pos;
    }



}
