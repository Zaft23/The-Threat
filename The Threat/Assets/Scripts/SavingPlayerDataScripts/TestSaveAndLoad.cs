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
    int playerSP;


    Transform playerPos;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        playerStats = _player.GetComponent<Player>();
        playerLevel = _player.GetComponent<LevelSystem>();
        playerPos = _player.GetComponent<Transform>();
        actions = _player.GetComponent<PlayerActions>();
        playerSP = _player.GetComponent<Player>().SkillPoint;

    }



    public void SavePlayer()
    {
        SavePlayerData.SavePlayer(playerStats, playerLevel, actions);
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
