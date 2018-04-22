using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour {

    public Texture2D[] maps;

    public ColorToPrefab[] colorMappings;

    public Transform parentTrasform;

    private Texture2D map;
    private float offsetX = 14.5f;
    private float offsetY = 7.5f;
    private float totalOffsetX;
    private float totalOffsetY;

    void Start()
    {
        map = maps[Random.Range(0, maps.Length)];

        totalOffsetX = parentTrasform.position.x - offsetX;
        totalOffsetY = parentTrasform.position.y - offsetY;
        GenerateRoom();
    }

    void GenerateRoom()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x + totalOffsetX, y + totalOffsetY);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
