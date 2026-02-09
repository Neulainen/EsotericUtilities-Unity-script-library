using UnityEngine;

namespace EsotericUtilities.PersistantData
{
    public class PersistantDataManager : MonoBehaviour
    {
        GameData GameData;
        FileDataHandler Handler;
        System.Collections.Generic.List<IPersistantData> persistantDataObjects = new();
        [SerializeField] string SaveFileName;
        [SerializeField] bool EncryptFile;
        public static PersistantDataManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null) Debug.LogError("Duplicate persistant data manager!");
            Instance = this;
            Handler = new LocalFileDataHandler(Application.persistentDataPath, SaveFileName);
            DontDestroyOnLoad(this);
        }
        public void AddDataObject(IPersistantData objToAdd)
        {
            if (!persistantDataObjects.Contains(objToAdd)) persistantDataObjects.Add(objToAdd);
        }
        public void RemoveDataObject(IPersistantData objToRemove)
        {
            try
            {
                persistantDataObjects.Remove(objToRemove);
            }
            catch { }
        }
        public void SaveGame()
        {
            if (persistantDataObjects == null)
            {
                Debug.LogError("No persistant data to save");
            }
            else
            {
                foreach (var data in persistantDataObjects)
                {
                    data.SaveData(ref GameData);
                }
                Handler.Save(GameData);
            }

        }
        public void LoadGame()
        {
            GameData = Handler.Load();
            if (GameData == null)
            {
                NewGame();
            }
            foreach (var data in persistantDataObjects)
            {
                data.LoadData(GameData);
            }
        }
        public void ResetData()
        {
            NewGame();
            Handler.Save(GameData);
        }
        public void NewGame()
        {
            GameData = new();
        }
    }
}
