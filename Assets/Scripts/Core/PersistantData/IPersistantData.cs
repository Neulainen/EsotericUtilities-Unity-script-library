using UnityEngine;
namespace EsotericUtilities.PersistantData
{
    public interface IPersistantData
    {

        public void SaveData(ref GameData data);
        public void LoadData(GameData data);
    }
}
