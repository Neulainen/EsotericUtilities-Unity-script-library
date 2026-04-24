using EsotericUtilities.ObjectPool;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace EsotericUtilities
{
    public class PoolableComponent : MonoBehaviour, IPoolable
    {
        [field: SerializeField] public PoolManager PoolManager { get; private set; }
        public string ID { get; }

        public void SetPoolManager(PoolManager poolManager) 
        { 
            PoolManager = poolManager; 
        }
        public UnityEvent OnActivation;
        public IEnumerator ActivatePoolable()
        {
            OnActivation?.Invoke();
            yield return null;
        }
        public UnityEvent OnReturn;
        public IEnumerator ReturnPoolable()
        {
            OnReturn?.Invoke();
            yield return null;
        }
    }

}
