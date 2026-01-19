using System.Collections.Generic;

namespace EsotericUtilities.SerializationUtility
{
    public static class SerializationUtility
    {
        public static void SerializeDictionary<T0, T1>(Dictionary<T0, T1> Dict, out List<T0> Keys, out List<T1> Values) where T0 : notnull
        {
            if (Dict == null) { throw new System.ArgumentNullException(nameof(Dict)); }
            Keys = new List<T0>();
            Values = new List<T1>();
            foreach (var kvp in Dict)
            {
                Keys.Add(kvp.Key);
                Values.Add(kvp.Value);
            }
            return;
        }
        public static Dictionary<T0, T1> DeserializeDictionary<T0, T1>(List<T0> Keys, List<T1> Values) where T0 : notnull
        {
            if (Keys == null) { throw new System.ArgumentNullException(nameof(Keys)); }
            if (Values == null) { throw new System.ArgumentNullException(nameof(Values)); }
            if (Keys.Count != Values.Count) throw new System.ArgumentException("Keys and Values must have the same number of elements.");
            Dictionary<T0, T1> Dict = new Dictionary<T0, T1>();
            for (int i = 0; i < Keys.Count; i++)
            {
                Dict[Keys[i]] = Values[i];
            }
            return Dict;
        }
        public static Dictionary<T0, T1> Serialize<T0, T1>(this Dictionary<T0, T1> Dict, out List<T0> Keys, out List<T1> Values)
        {
            if (Dict == null) { throw new System.ArgumentNullException(nameof(Dict)); }
            Keys = new List<T0>();
            Values = new List<T1>();
            foreach (var kvp in Dict)
            {
                Keys.Add(kvp.Key);
                Values.Add(kvp.Value);
            }
            return Dict;
        }
    }
}
