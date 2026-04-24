using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif
namespace EsotericUtilities
{
    [CreateAssetMenu(fileName = "SceneReference", menuName = "EsotericUtilities/SceneReference")]
    public class SceneReference : IdentifiableScriptableObject
    {

        [field: SerializeField] public int BuildIndex { get; private set; }
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (Scene == null) return;
            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
            {
                if (Path.GetFileNameWithoutExtension(EditorBuildSettings.scenes[i].path) == Scene.name)
                {
                    BuildIndex = i;
                    return;
                }
            }
            Debug.LogWarning($"Scene by the name of {Scene.name} is not present in build scene list!");
        }
        private void OnEnable()
        {
            if (Scene == null) return;
            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
            {
                if (Path.GetFileNameWithoutExtension(EditorBuildSettings.scenes[i].path) == Scene.name)
                {
                    BuildIndex = i;
                    return;
                }
            }
            Debug.LogWarning($"Scene by the name of {Scene.name} is not present in build scene list!");
        }
        [field: SerializeField] public SceneAsset Scene { get; private set; }
#endif
    }
}

