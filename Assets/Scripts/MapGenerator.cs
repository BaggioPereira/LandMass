using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode { NoiseMap, ColourMap};
    public DrawMode DMode;

    public int MapWidth;
    public int MapHeight;
    public float NoiseScale;

    public int Octaves;
    [Range(0, 1)]
    public float Persistance;
    public float Lacunarity;

    public int Seed;
    public Vector2 Offset;
    
    public bool AutoUpdate;

    public TerrainType[] Regions;

     public void GenerateMap()
    {
        float[,] NoiseMap = Noise.GenerateNoiseMap(MapWidth, MapHeight, Seed, NoiseScale, Octaves, Persistance, Lacunarity, Offset);

        Color[] ColourMap = new Color[MapWidth * MapHeight];
        for(int y = 0; y < MapHeight; y++)
        {
            for (int x = 0; x < MapWidth; x++)
            {
                float CurrentHeight = NoiseMap[x, y];
                for (int i = 0; i< Regions.Length; i++)
                {
                    if(CurrentHeight <= Regions[i].Height)
                    {
                        ColourMap[y * MapWidth + x] = Regions[i].Colour;
                        break;
                    }
                }
            }
        }

        MapDisplay Display = FindObjectOfType<MapDisplay>();
        if (DMode == DrawMode.NoiseMap)
        {
            Display.DrawTexture(TextureGenerator.TextureFromHeightMap(NoiseMap));
        }        
        else if (DMode == DrawMode.ColourMap)
        {
            Display.DrawTexture(TextureGenerator.TextureFromColourMap(ColourMap, MapWidth, MapHeight));
        }
    }

    void OnValidate()
    {
        if(MapWidth < 1)
        {
            MapWidth = 1;
        }

        if(MapHeight < 1)
        {
            MapHeight = 1;
        }

        if(Lacunarity < 1)
        {
            Lacunarity = 1;
        }

        if(Octaves < 0)
        {
            Octaves = 0;
        }
    }
}

[System.Serializable]
public struct TerrainType
{
    public string Name;
    public float Height;
    public Color Colour;
}
