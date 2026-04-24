using UnityEngine;
using UnityEngine.Events;

namespace EsotericUtilities.GlobalEventChannel
{
    public abstract class GenericGlobalEventChannel<TParam> : EmptyGlobalEventChannel where TParam : struct
    {
        /// <summary>
        /// Action with the given parameter that fires when the event is called. 
        /// Listen to this action, if you need the params of the event too.
        /// Is invoked after OnEventTrigger.
        /// </summary>
        public UnityAction<TParam> OnEventCall;

        /// <summary>
        /// Calls and triggers the event, causing both OnEventCall and OnEventTrigger to happen.
        /// </summary>
        /// <param name="param">Given parameter for the OnEventCallAction</param>
        public virtual void CallEvent(TParam param)
        {
            OnEventTrigger?.Invoke();
            OnEventCall?.Invoke(param);
        } 
    }
}
