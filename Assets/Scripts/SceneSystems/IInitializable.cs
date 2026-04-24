using System.Collections;
using UnityEngine;

namespace EsotericUtilities.SceneSystems
{
    public interface IInitializable
    {
        IEnumerator PrepareInitialize();
        IEnumerator Initialize();
        IEnumerator Finalize();

    }
}
