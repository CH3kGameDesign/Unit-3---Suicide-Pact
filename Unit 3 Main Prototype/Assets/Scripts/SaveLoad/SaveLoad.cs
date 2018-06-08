using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/levelComplete.gd");
        bf.Serialize(file, GameProgress.levelComplete);
        Debug.Log("Saved To " + Application.persistentDataPath + "/levelComplete.gd");
        file.Close();
    }
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/levelComplete.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/levelComplete.gd", FileMode.Open);
            GameProgress.levelComplete = (List<int>)bf.Deserialize(file);
            file.Close();
        }

    }
}
