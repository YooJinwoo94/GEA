using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadUIDataManager 
{


    public static void save(SaveUIData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Path.Combine(Application.dataPath, "UIData.bin");
        FileStream stream = File.Create(path);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveUIData load()
    {
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Path.Combine(Application.dataPath, "UIData.bin");
            FileStream stream = File.OpenRead(path);
            SaveUIData data = (SaveUIData)formatter.Deserialize(stream);
            stream.Close();
            return data;
        }

        catch
        {
            return default;
        }
    }
}
