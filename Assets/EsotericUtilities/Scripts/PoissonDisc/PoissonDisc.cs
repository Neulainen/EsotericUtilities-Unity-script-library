using System.Collections.Generic;
using UnityEngine;

namespace EsotericUtilities
{
    public static class PoissonDisc
    {
        public static List<Vector2> GeneratePoints(float radius, Vector2 sampleRegionSize, int sampleAttempts)
        {
            float cellSize = radius / Mathf.Sqrt(2);
            List<Vector2> points = new(), spawnPoints = new();
            int[,] grid = new int[Mathf.CeilToInt(sampleRegionSize.x / cellSize), Mathf.CeilToInt(sampleRegionSize.y / cellSize)];

            spawnPoints.Add(sampleRegionSize / 2);
            while (spawnPoints.Count > 0)
            {
                int spawnInd = Random.Range(0, spawnPoints.Count);
                Vector2 spawnPoint = spawnPoints[spawnInd];
                bool accepted = false;
                for (int i = 0; i < sampleAttempts; i++)
                {
                    float angle = Random.Range(0f, 360f);
                    Vector2 dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
                    Vector2 newPoint = spawnPoint + dir * Random.Range(radius, 2 * radius);
                    if (IsValid(newPoint))
                    {
                        points.Add(newPoint);
                        spawnPoints.Add(newPoint);
                        grid[(int)(newPoint.x/cellSize), (int)(newPoint.y/cellSize)] = points.Count;
                        accepted = true;
                        break;
                    }
                }
                if(!accepted)
                {
                    spawnPoints.RemoveAt(spawnInd);
                }

            }
        }
        private static bool IsValid(Vector2 point, Vector2 sampleRegionSize, List<Vector2> previousSamples, int[,] grid)
        {

        }
    }
}
