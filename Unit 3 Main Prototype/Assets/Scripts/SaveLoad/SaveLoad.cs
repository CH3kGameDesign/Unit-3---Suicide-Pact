using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{
    /*
        WHAT SCRIPT DOES:
        -   Saves Progress (Called by LevelEnd)
        -   Loads Progress (Called by MainMenuManager)
        -   Resets Progress (Called by MainMenuManager)
    */

    //SAVE
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/levelComplete.gd");
        bf.Serialize(file, GameProgress.levelComplete);
        Debug.Log("Saved To " + Application.persistentDataPath + "/levelComplete.gd");
        file.Close();
    }
    //LOAD
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
    //RESET PROGRESS
    public static void ResetProgress()
    {
        //if (File.Exists(Application.persistentDataPath + "/levelComplete.gd"))
        //{
            File.Delete(Application.persistentDataPath + "/levelComplete.gd");
        //}

    }
}
