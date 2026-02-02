using System;
using System.IO;
using UnityEngine;

namespace EsotericUtilities.PersistantData
{
    public class LocalFileDataHandler : FileDataHandler
    {
        private readonly string DataPath, DataFileName = "";
        private const string encryptionCode = "TESTWORD";
        public bool EncryptionOn;

        public LocalFileDataHandler(string dataPath, string dataFileName) : base(dataPath, dataFileName)
        {
        }

        public override GameData Load()
        {
            string FullPath = Path.Combine(DataPath, DataFileName);
            GameData LoadedData = null;
            if (File.Exists(FullPath))
            {
                try
                {
                    string StringToLoad = "";
                    using FileStream stream = new(FullPath, FileMode.Open);
                    using StreamReader reader = new(stream);
                    StringToLoad = reader.ReadToEnd();
                    if (EncryptionOn) StringToLoad = EncryptDecrypt(StringToLoad);
                    LoadedData = JsonUtility.FromJson<GameData>(StringToLoad);
                }
                catch (Exception e)
                {
                    Debug.LogError("Error: " + e + " occured whilst loading data from file: " + FullPath);
                }
            }
            return LoadedData;
        }
        public override void Save(GameData DataToWrite)
        {
            string FullPath = Path.Combine(DataPath, DataFileName);

            try
            {
                //Create a directory
                Directory.CreateDirectory(Path.GetDirectoryName(FullPath));

                //convert data to json string
                string StringToWrite = JsonUtility.ToJson(DataToWrite);

                using FileStream stream = new(FullPath, FileMode.Create);
                using StreamWriter writer = new(stream);
                if (EncryptionOn) StringToWrite = EncryptDecrypt(StringToWrite);
                writer.Write(StringToWrite);
                Debug.Log(FullPath);
            }
            catch (Exception e)
            {
                Debug.LogError("Error: " + e + " occured whilst saving data to file: " + FullPath);
            }

        }
        private string EncryptDecrypt(string data)
        {
            string UsedData = "";
            for (int i = 0; i < data.Length; i++)
            {
                UsedData += (char)(data[i] ^ encryptionCode[i % encryptionCode.Length]);
            }
            return UsedData;
        }
    }
}
