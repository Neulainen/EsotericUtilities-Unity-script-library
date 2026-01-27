using System.Collections;
using UnityEngine;

namespace EsotericUtilities
{
    public interface IInitializable
    {
        IEnumerator PrepareInitialize();
        IEnumerator Initialize();
        IEnumerator Finalize();

    }
}
