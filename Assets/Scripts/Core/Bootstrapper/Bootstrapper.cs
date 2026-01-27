using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EsotericUtilities
{
    public class Bootstrapper : MonoBehaviour
    {
        List<IInitializable> initializables = new List<IInitializable>();
        public IEnumerator Bootstrap()
        {
            foreach (var initializable in initializables)
            {
                yield return StartCoroutine(initializable.PrepareInitialize());
            }
            foreach (var initializable in initializables)
            {
                yield return StartCoroutine(initializable.Initialize());
            }
            foreach (var initializable in initializables)
            {
                yield return StartCoroutine(initializable.Finalize());
            }
        }
    }
}
