using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EsotericUtilities
{
    public static class SceneUtilities
    {
        /// <summary>
        /// Get a list of all instances of type T in the currently active scene
        /// </summary>
        /// <typeparam name="T">Type to search for</typeparam>
        /// <returns>List of all instances of type T in active scene</returns>
        public static List<T> GetTypesInScene<T>()
        {
            return SceneManager.GetActiveScene().GetTypes<T>();
        }
        /// <summary>
        /// Get a list of all instances of type T in given scene
        /// </summary>
        /// <typeparam name="T">Type to search for</typeparam>
        /// <param name="scene">Scene to search in</param>
        /// <returns>A list of all instances of type T in given scene</returns>
        public static List<T> GetTypesInScene<T>(Scene scene)
        {
            return scene.GetTypes<T>();
        }
        /// <summary>
        /// Get a list of all instances of type T in scene
        /// </summary>
        /// <typeparam name="T">Type to search for</typeparam>
        /// <param name="scene">Scene to search in</param>
        /// <returns>A list of all instances of type T in scene</returns>
        public static List<T> GetTypes<T>(this Scene scene)
        {
            List<GameObject> GOList = scene.GetRootGameObjects().ToList();
            List<T> Returnables = new();
            GOList.ForEach(go => { Returnables.AddRange(go.GetComponentsInChildren<T>()); });
            return Returnables;
        }
    }
}
