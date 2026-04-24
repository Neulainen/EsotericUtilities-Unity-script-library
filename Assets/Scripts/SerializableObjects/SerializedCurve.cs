using UnityEngine;
namespace EsotericUtilities
{

    /// <summary>
    /// A scriptable object version of the AnimationCurve. 
    /// This allows a serialized Curve copied across multiple objects.
    /// </summary>
    [CreateAssetMenu(fileName = "SerializedCurve", menuName = "EsotericUtilities/SerializedCurve")]
    public class SerializedCurve : IdentifiableScriptableObject
    {
        [field: SerializeField] public AnimationCurve Curve { get; private set; }
    }
}

