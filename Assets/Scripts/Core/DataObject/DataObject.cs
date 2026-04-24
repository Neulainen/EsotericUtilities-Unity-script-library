using UnityEditor;
using UnityEngine;

namespace EsotericUtilities
{

    public abstract class DataObject<T> : ScriptableObject where T : new()
    {
        [field: SerializeField] public T Data { get; private set; }
#if UNITY_EDITOR
        private void OnEnable()
        {
            EditorApplication.playModeStateChanged += OnPlaymodeStateChanged;
        }
        private void OnDisable()
        {
            EditorApplication.playModeStateChanged -= OnPlaymodeStateChanged;
        }
        void OnPlaymodeStateChanged(PlayModeStateChange stateChange)
        {
            switch (stateChange)
            {
                case PlayModeStateChange.EnteredPlayMode:
                    {
                        OnPlaymodeEnter();
                        break;
                    }
                case PlayModeStateChange.ExitingPlayMode:
                    {
                        OnPlaymodeExit();
                        break;
                    }
                default: { return; }
            }
        }
        protected virtual void OnPlaymodeExit()
        {
            Data = new();
        }
        protected virtual void OnPlaymodeEnter() { }
#endif
    }

}
