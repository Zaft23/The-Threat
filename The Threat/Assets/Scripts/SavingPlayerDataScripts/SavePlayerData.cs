using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SavePlayerData 
{
    public static void SavePlayer(Player player, LevelSystem levelSystem)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player, levelSystem);

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Player.txt";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();


            return data;

        }
        else
        {
            Debug.LogError("Data Save File Not Found in" + path);
            return null;

        }
    }






}
