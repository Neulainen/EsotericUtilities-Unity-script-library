using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EsotericUtilities.AssetStorage
{
    public abstract class AssetStorage<T> : ScriptableObject where T : UnityEngine.Object
    {
        public List<T> Store => store;
        public string[] AssetFolderPath;
        [SerializeField] protected List<T> store;
        protected void UpdateAssets()
        {
            store.Clear();
            foreach (var dir in AssetFolderPath)
            {
                string[] fileNames = Directory.GetFiles(dir);
                foreach (var file in fileNames)
                {
                    T t = (T)AssetDatabase.LoadAssetAtPath(file, typeof(T));
                    if (t != null) store.Add(t);
                }
            }
        }
        protected virtual void OnValidate() => UpdateAssets();
    }
}

