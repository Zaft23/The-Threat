using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestSaveAndLoad : MonoBehaviour
{

    private GameObject _player;
    Player playerStats;
    LevelSystem playerLevel;
    Vector3 Pos;
    Transform playerPos;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        playerStats = _player.GetComponent<Player>();
        playerLevel = _player.GetComponent<LevelSystem>();
        playerPos = _player.GetComponent<Transform>();
        Pos = playerPos.transform.position; 
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

        //Vector3 position;
        Pos.x = data.position[0];
        Pos.y = data.position[1];
        Pos.z = data.position[2];


    }

}
