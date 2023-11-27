using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveCoin(gameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/coin.money";
        FileStream stream = new FileStream(path, FileMode.Create);
        SavingData data = new SavingData(gameManager);
        
        formatter.Serialize(stream,data);
        stream.Close();
    }

    public static SavingData LoadData()
    {
        string path = Application.persistentDataPath + "/coin.money";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            SavingData data = formatter.Deserialize(stream) as SavingData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogWarning("merde");
            return null;
        }
    }
}
