using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveLevel (GameData gameData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath +"/player.joke"; //fix this
        FileStream stream = new FileStream(path, FileMode.Create);
        

        SavedGameData data = new SavedGameData(gameData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SavedGameData LoadLevel()
    {
        string path = Application.persistentDataPath +"/player.joke";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedGameData data = formatter.Deserialize(stream) as SavedGameData;
            stream.Close();
            
            return data;

        }else
        {
            Debug.LogError("Save file not found in "+ path);
            return null;
        }
    }
}