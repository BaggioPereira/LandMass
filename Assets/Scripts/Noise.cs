using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise {

	public static float[,] GenerateNoiseMap(int MapWidth, int MapHeight, float Scale)
    {
        float[,] NoiseMap = new float[MapWidth, MapHeight];

        if(Scale <= 0)
        {
            Scale = 0.0001f;
        }

        for(int y = 0; y < MapHeight; y++)
        {
            for(int x = 0; x <MapWidth; x++)
            {
                float SampleX = x / Scale;
                float SampleY = y / Scale;

                float PerlinValue = Mathf.PerlinNoise(SampleX, SampleY);
                NoiseMap[x, y] = PerlinValue;
            }
        }
        return NoiseMap;
    }
}
