using System;
using System.IO;
using UnityEngine;
namespace EsotericUtilities.PersistantData
{
    public abstract class FileDataHandler
    {
        private readonly string DataPath, DataFileName = "";
        private const string encryptionCode = "TESTWORD";
        public FileDataHandler(string dataPath, string dataFileName)
        {
            DataPath = dataPath;
            DataFileName = dataFileName;
        }
        public abstract GameData Load();
        public abstract void Save(GameData DataToWrite);


    }
}
