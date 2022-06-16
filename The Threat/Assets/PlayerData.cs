using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    public float Health;
    public int Level;
    public float Exp;
    public int SkillPoints;
    public int NextLevelExp;

    //test position
    public float[] position;

    //Upgrades use array maybe?
    //later damage or something

 
    public PlayerData(Player player, LevelSystem level)
    {
        Level = level.Level;
        Health = player.Health;
        Exp = level.currentXp;
        NextLevelExp = level.nextLevelXp;
        SkillPoints = player.SkillPoint;


        //test position
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;



    }

   








}
