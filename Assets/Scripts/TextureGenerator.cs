using UnityEngine;
using System.Collections;

public static class TextureGenerator
{

    public static Texture2D TextureFromColourMap(Color[] ColourMap, int Width, int Height)
    {
        Texture2D Texture = new Texture2D(Width, Height);
        Texture.filterMode = FilterMode.Point;
        Texture.wrapMode = TextureWrapMode.Clamp;
        Texture.SetPixels(ColourMap);
        Texture.Apply();
        return Texture;
    }

    public static Texture2D TextureFromHeightMap(float[,] HeightMap)
    {
        int Width = HeightMap.GetLength(0);
        int Height = HeightMap.GetLength(1);

        Color[] ColourMap = new Color[Width * Height];
        for(int y = 0; y < Height; y++)
        {
            for(int x = 0; x < Width; x++)
            {
                ColourMap[y * Width + x] = Color.Lerp(Color.black, Color.white, HeightMap[x, y]);
            }
        }

        return TextureFromColourMap(ColourMap, Width, Height);
    }
}
