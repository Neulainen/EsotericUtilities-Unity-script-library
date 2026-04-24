using EsotericUtilities.GlobalEventChannel;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace EsotericUtilities.GlobalEvent
{
    [CreateAssetMenu(fileName = "GlobalBooleanEventChannel", menuName = "Global Event Channels/Common/Global Boolean Event")]
    public class GlobalBoolEventChannel : GenericGlobalEventChannel<bool>
    {
    }
}
