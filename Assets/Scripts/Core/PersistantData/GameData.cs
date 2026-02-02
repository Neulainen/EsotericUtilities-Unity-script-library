using System.Collections.Generic;
using UnityEngine;
namespace EsotericUtilities.PersistantData
{
    [System.Serializable]
    public abstract class GameData : ISerializationCallbackReceiver
    {
        public abstract void OnAfterDeserialize();

        public abstract void OnBeforeSerialize();
    }
}
