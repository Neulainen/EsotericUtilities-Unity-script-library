using UnityEditor;
using UnityEngine;

namespace EsotericUtilities
{

    public abstract class DataObject<T> : ScriptableObject where T : new()
    {
        [field: SerializeField] public T Data { get; private set; } = new();

#if UNITY_EDITOR
        protected virtual void OnEnable()
        {
            EditorApplication.playModeStateChanged += OnPlaymodeStateChanged;
        }
        protected virtual void OnDisable()
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
        /// <summary>
        /// Actions to do when we exist the playmode. Resets data object as default.
        /// </summary>
        protected virtual void OnPlaymodeExit()
        {
            Data = new();
        }
        /// <summary>
        /// Actions to do when we enter the playmode. Does nothing as default.
        /// </summary>
        protected virtual void OnPlaymodeEnter() { }
#endif
    }

}
