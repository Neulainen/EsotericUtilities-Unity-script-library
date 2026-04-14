using UnityEngine;
namespace EsotericUtilities.PersistantData
{
    public interface IPersistantData
    {
        public void SaveData();
        public void LoadData();
    }
}
