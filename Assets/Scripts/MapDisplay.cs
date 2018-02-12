using UnityEngine;
using System.Collections;

public class MapDisplay : MonoBehaviour
{

    public Renderer TextureRenderer;

    public void DrawNoiseMap(float[,] NoiseMap)
    {
        int Width = NoiseMap.GetLength(0);
        int Height = NoiseMap.GetLength(1);

        Texture2D Texture = new Texture2D(Width, Height);

        Color[] ColourMap = new Color[Width * Height];
        for(int y = 0; y < Height; y++)
        {
            for(int x = 0; x < Width; x++)
            {
                ColourMap[y * Width + x] = Color.Lerp(Color.black, Color.white, NoiseMap[x, y]);
            }
        }

        Texture.SetPixels(ColourMap);
        Texture.Apply();

        TextureRenderer.sharedMaterial.mainTexture = Texture;
        TextureRenderer.transform.localScale = new Vector3(Width, 1, Height);
    }
}
