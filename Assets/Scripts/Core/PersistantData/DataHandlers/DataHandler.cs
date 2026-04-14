using System;
using System.IO;
using UnityEngine;
namespace EsotericUtilities.PersistantData
{
    public abstract class DataHandler
    {
        public abstract GameData Load();
        public abstract void Save(GameData DataToWrite);
    }
}
