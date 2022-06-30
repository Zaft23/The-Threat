using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestSaveAndLoad : MonoBehaviour
{

    private GameObject _player;
    Player playerStats;
    LevelSystem playerLevel;
    
    Transform playerPos;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        playerStats = _player.GetComponent<Player>();
        playerLevel = _player.GetComponent<LevelSystem>();
        playerPos = _player.GetComponent<Transform>();
        
    }



    public void SavePlayer()
    {
        SavePlayerData.SavePlayer(playerStats, playerLevel);
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

        Vector3 Pos;
        Pos = playerPos.transform.position;
        Debug.Log("LOADDDDD");
        //Vector3 position;
        Pos.x = data.XPosition;
        Pos.y = data.YPosition;
        Pos.z = data.ZPosition;
        playerPos.transform.position = Pos;

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
