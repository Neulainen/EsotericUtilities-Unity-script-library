using UnityEngine;
namespace EsotericUtilities
{
    /// <summary>
    /// A scriptable object with an identifier. ID is wiped on reset.
    /// </summary>
    public abstract class IdentifiableScriptableObject : ScriptableObject
    {
        /// <summary>
        /// The unique ID of this object. Formatted as {TypeName}:{GUID}
        /// </summary>
        [field: SerializeField]
        public string ID { get; private set; }
        protected string Guid;
#if UNITY_EDITOR
        protected virtual void Reset()
        {
            Guid = System.Guid.NewGuid().ToString();
            ID = $"{GetType().Name}:{Guid}";
        }
#endif

    }
}

