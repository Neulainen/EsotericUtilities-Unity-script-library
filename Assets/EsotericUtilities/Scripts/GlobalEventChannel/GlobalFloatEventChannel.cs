using EsotericUtilities.GlobalEventChannel;
using UnityEngine;

namespace EsotericUtilities.GlobalEvent
{
    [CreateAssetMenu(fileName = "GlobalFloatEventChannel", menuName = "Global Event Channels/Common/GlobalFloatEventChannel")]
    public class GlobalFloatEventChannel : GenericGlobalEventChannel<float>
    {
    }
}
