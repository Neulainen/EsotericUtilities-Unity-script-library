using System;
using System.Collections.Generic;
using UnityEngine;

namespace EsotericUtilities.ObjectPool
{
    public abstract class PoolManager : MonoBehaviour
    {
        //Currently there is an issue where the pool manager sometimes sends out an item as it is being received.
        //These actions should not happen on the same frame, but it's hard to enforce this rule.
        //Thus, we make sure that if there is only 1 piece in the queue, it won't be sent out. This does waste some space for each queue slot, but it's the easiest fix
        protected Dictionary<string, Queue<IPoolable>> Pool;
        [SerializeField] Transform PoolTransform;
        private void Awake()
        {
            GeneratePool();
            if (Pool == null) throw new Exception($"Generation of pool failed!");
        }
        public void AddItem(IPoolable poolable)
        {
            //ResetPoolable poolable and place it under us
            poolable.ResetPoolable();
            poolable.PlacePoolable(PoolTransform);

            //Add item to pool slot for storage
            if (Pool.ContainsKey(poolable.ID)) { Pool[poolable.ID].Enqueue(poolable); }
            else
            {
                var newQueue = new Queue<IPoolable>();
                newQueue.Enqueue(poolable);
                Pool.Add(poolable.ID, newQueue);
            }
        }
        public IPoolable GetItem(string ID, Transform NewParent)
        {
            if (!Pool.ContainsKey(ID))
            {
                Debug.Log($"No item of ID {ID} found!");
                return null;
            }
            if (Pool[ID].Count > 1) //We don't return the latest item we got
            {
                var item = Pool[ID].Dequeue();
                item.PlacePoolable(NewParent);
                return item;
            }
            return null;
        }
        protected abstract void GeneratePool();
    }
}
