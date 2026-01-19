using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace EsotericUtilities.GlobalEventChannel
{
    [CreateAssetMenu(fileName = "EmptyGlobalEventChannel", menuName = "Global Event Channels/Common/Empty Global Event")]
    public class EmptyGlobalEventChannel : ScriptableObject
    {
        /// <summary>
        /// OnEventTrigger fires when the event is activated or triggered. Listen to this action, if you only wish to know when this event channel is active.
        /// </summary>
        public UnityAction OnEventTrigger;
        /// <summary>
        /// Trigger the event. Calling this does not activate the event.
        /// </summary>
        public virtual void TriggerEvent() => OnEventTrigger?.Invoke();
    }
}
