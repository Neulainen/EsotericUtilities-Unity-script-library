using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace EsotericUtilities.ObjectPool
{
    public interface IPoolable
    {
        public GameObject gameObject { get; }
        public void PlacePoolable(Transform newParent);
        public string ID { get; }
        public void ResetPoolable();
        public UnityEvent ActivatePoolable { get; }
    }
}
