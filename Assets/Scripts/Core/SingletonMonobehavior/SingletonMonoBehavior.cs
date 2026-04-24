using UnityEngine;
namespace EsotericUtilities
{
    /// <summary>
    /// Holds a static instance reference to a single monobehavior. 
    /// </summary>
    /// <typeparam name="T">Monobehavior to turn into a singleton</typeparam>
    public abstract class SingletonMonoBehavior<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// The active singleton instance. Attempts to get an instance if it does not have one. 
        /// Creates a new instance if none found, destroys alternatives if multiple found.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (Instance == null)
                {
                    //If we don't have an instance, attempt to find one
                    T instance = null;
                    T[] instances = FindObjectsByType<T>(FindObjectsSortMode.None);
                    if (instances.Length > 1)
                    {
                        Debug.LogWarning($"Multiple Singleton instances of {nameof(T)} found! Disabling alternatives.");
                        instance = instances[0];
                        for (int i = 1; i < instances.Length; i++)
                        {
                            instances[i].gameObject.SetActive(false);
                        }
                    }
                    //If one could not be found, create one
                    if (instance == null)
                    {
                        GameObject go = new GameObject();
                        go.name = typeof(T).Name;
                        instance = go.AddComponent<T>();
                        Debug.LogWarning($"No instance of singleton mono behavior {nameof(T)} was found, one was created!");
                    }
                    //Assing new or found instance
                    Instance = instance;
                }
                //If instance has been found, return it
                return Instance;
            }
            private set
            {
                Instance = value;
            }
        }
        /// <summary>
        /// Wipes the current instance reference and removes the game object
        /// </summary>
        public static void WipeInstance()
        {
            GameObject go = Instance.gameObject;
            Instance = null;
            Destroy(go);
        }
    }
}
