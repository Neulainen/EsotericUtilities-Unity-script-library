using System.Collections.Generic;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
namespace EsotericUtilities
{
    public abstract class AssetStorage<T> : ScriptableObject where T : UnityEngine.Object
    {
        [field: SerializeField] public List<T> Store { get; protected set; } = new List<T>();

#if UNITY_EDITOR
        [SerializeField] protected string[] AssetFolderPath;
        protected virtual void UpdateAssets()
        {
            Store.Clear();
            foreach (var dir in AssetFolderPath)
            {
                string[] fileNames = Directory.GetFiles(dir);
                foreach (var file in fileNames)
                {
                    T t = (T)AssetDatabase.LoadAssetAtPath(file, typeof(T));
                    if (t != null) Store.Add(t);
                }
            }
        }
        protected virtual void OnValidate() => UpdateAssets();
#endif
    }
}

