using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace EsotericUtilities.ObjectPool
{
    public interface IPoolable
    {
        public string ID { get; }
        public GameObject gameObject { get; }
        public Transform transform { get; }
        public PoolManager PoolManager { get; }

        /// <summary>
        /// Actions to be done before returning the poolable to the pool
        /// </summary>
        public IEnumerator ReturnPoolable();
        /// <summary>
        /// Actions to be done the moment this poolable is activated
        /// </summary>
        public IEnumerator ActivatePoolable();
    }
}
