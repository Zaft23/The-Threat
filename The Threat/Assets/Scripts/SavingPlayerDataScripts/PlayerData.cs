using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    public float Health;
    public float MaxHP;
    //public float HealthRegen;
    public float Speed;
    public float Damage;
    public int RifleAmmo;
    public int SMGAmmo;
    public int ShotgunAmmo;
    public int SniperAmmo;

    //
    public int Level;
    public float Exp;
    public int SkillPoints;
    public int NextLevelExp;


    //test position
    public float XPosition;
    public float YPosition;
    public float ZPosition;

    //Upgrades use array maybe?
    //later damage or something

    //save player's ammo data
    //save gameobject

    public PlayerData(Player player, LevelSystem level, PlayerActions actions)
    {
        Level = level.Level;
        Health = player.Health;
        MaxHP = player.MaxHealth;

        Speed = player.BaseSpeed;
        Damage = player.BaseDamage;
        RifleAmmo = actions.StoredRifleAmmo;
        SMGAmmo = actions.StoredSmgAmmo;
        ShotgunAmmo = actions.StoredShotgunAmmo;
        SniperAmmo = actions.StoredSniperAmmo;


        Exp = level.currentXp;
        NextLevelExp = level.nextLevelXp;
        SkillPoints = player.SkillPoint;


        XPosition = player.transform.position.x;
        YPosition = player.transform.position.y;
        ZPosition = player.transform.position.z;


        //test position
        //position = new float[3];
        //position[0] = player.transform.position.x;
        //position[1] = player.transform.position.y;
        //position[2] = player.transform.position.z;



    }

    //public PlayerSPs()









}
