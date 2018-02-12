using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{

    public int MapWidth;
    public int MapHeight;
    public float NoiseScale;

    public bool AutoUpdate;

    public void GenerateMap()
    {
        float[,] NoiseMap = Noise.GenerateNoiseMap(MapWidth, MapHeight, NoiseScale);

        MapDisplay Display = FindObjectOfType<MapDisplay>();
        Display.DrawNoiseMap(NoiseMap);
    }
}
