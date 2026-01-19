using UnityEngine;
public static class NumericExtensions
{
    #region Remap functions
    /// <summary>
    /// Remap value within a range to another range
    /// </summary>
    /// <param name="min">Current lowest value in the range</param>
    /// <param name="max">Current highest value in the range</param>
    /// <param name="newMin">New lowest value in the range</param>
    /// <param name="newMax">New highest value in the range</param>
    /// <returns>The value remapped to the new range</returns>
    public static float Remap(this float value, float min, float max, float newMin, float newMax)
    {
        return newMin + (value - min) * (newMax - newMin) / (max - min);
    }
    /// <summary>
    /// Remap value within a range to another range
    /// </summary>
    /// <param name="min">Current lowest value in the range</param>
    /// <param name="max">Current highest value in the range</param>
    /// <param name="newMin">New lowest value in the range</param>
    /// <param name="newMax">New highest value in the range</param>
    /// <returns>The value remapped to the new range</returns>
    public static int Remap(this int value, int min, int max, int newMin, int newMax)
    {
        return newMin + (value - min) * (newMax - newMin) / (max - min);
    }
    /// <summary>
    /// Remap value within a range to another range
    /// </summary>
    /// <param name="min">Current lowest value in the range</param>
    /// <param name="max">Current highest value in the range</param>
    /// <param name="newMin">New lowest value in the range</param>
    /// <param name="newMax">New highest value in the range</param>
    /// <returns>The value remapped to the new range</returns>
    public static Vector2 Remap(this Vector2 value, float min, float max, float newMin, float newMax)
    {
        return new Vector2(value.x.Remap(min, max, newMin, newMax), value.y.Remap(min, max, newMin, newMax));
    }
    /// <summary>
    /// Remap value within a range to another range
    /// </summary>
    /// <param name="min">Current lowest value in the range</param>
    /// <param name="max">Current highest value in the range</param>
    /// <param name="newMin">New lowest value in the range</param>
    /// <param name="newMax">New highest value in the range</param>
    /// <returns>The value remapped to the new range</returns>
    public static Vector3 Remap(this Vector3 value, float min, float max, float newMin, float newMax)
    {
        return new Vector3(value.x.Remap(min, max, newMin, newMax), value.y.Remap(min, max, newMin, newMax), value.z.Remap(min, max, newMin, newMax));
    }
    #endregion

    #region IsWithin functions
    /// <summary>
    /// Returns true if value is less or equal to max, and greater or equal to min
    /// </summary>
    /// <param name="value"></param>
    /// <param name="Min"></param>
    /// <param name="Max"></param>
    /// <returns></returns>
    public static bool IsWithin(this int value, int Min, int Max)
    {
        return value <= Max && value >= Min;
    }
    public static bool IsWithin(this float value, float Min, float Max)
    {
        return value <= Max && value >= Min;
    }
    public static bool IsWithin(this Vector2 value, Vector2 Min, Vector2 Max)
    {
        return
            value.x.IsWithin(Min.x, Max.x)
            &&
            value.y.IsWithin(Min.y, Max.y);
    }
    public static bool IsWithin(this Vector3 value, Vector3 Min, Vector3 Max)
    {
        return
            value.x.IsWithin(Min.x, Max.x)
            &&
            value.y.IsWithin(Min.y, Max.y)
            &&
            value.z.IsWithin(Min.z, Max.z);
    }
    public static bool IsWithin(this Vector2Int value, Vector2Int Min, Vector2Int Max)
    {
        return
            value.x.IsWithin(Min.x, Max.x)
            &&
            value.y.IsWithin(Min.y, Max.y);
    }
    public static bool IsWithin(this Vector3Int value, Vector3Int Min, Vector3Int Max)
    {
        return
            value.x.IsWithin(Min.x, Max.x)
            &&
            value.y.IsWithin(Min.y, Max.y)
            &&
            value.z.IsWithin(Min.z, Max.z);
    }
    #endregion

    #region Circle Functions
    /// <summary>
    /// Normalize degrees to a space within 0...360 and return unsigned degrees
    /// </summary>
    /// <param name="Degrees"></param>
    /// <returns>Unsigned degrees less than 360 </returns>
    public static float GetSingleDegrees(this float Degrees)
    {

        float degs = Mathf.Abs(Degrees);

        if (degs < 360) return Degrees;

        degs -= Mathf.FloorToInt(degs / 360) * 360;

        return degs;
    }
    /// <summary>
    /// Normalize degrees to a range between 0...360 and return signed degrees
    /// </summary>
    /// <param name="Degrees"></param>
    /// <returns>Signed degrees less than 360 and greater than -360</returns>
    public static float GetSignedSingleDegrees(this float Degrees)
    {
        float sign = Mathf.Sign(Degrees);
        float degs = Mathf.Abs(Degrees);

        if (degs < 360) return Degrees;

        degs -= Mathf.FloorToInt(degs / 360) * 360;

        return degs * sign;
    }
    #endregion
}

