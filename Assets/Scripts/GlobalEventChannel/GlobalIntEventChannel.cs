using EsotericUtilities.GlobalEventChannel;
using UnityEngine;

namespace EsotericUtilities.GlobalEvent
{
    [CreateAssetMenu(fileName = "GlobalIntegerEvent", menuName = "Global Event Channels/Common/Global Integer Event")]
    public class GlobalIntEventChannel : GenericGlobalEventChannel<int>
    {
    }
}
