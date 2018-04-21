using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour 
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;

    public Transform parentTrasform;

    private float offsetX = 15.5f;
    private float offsetY = 8.5f;
    private float totalOffsetX;
    private float totalOffsetY;

	void Start () 
    {
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

        if(pixelColor.a == 0)
        {
            return;
        }

        foreach(ColorToPrefab colorMapping in colorMappings)
        {
            if(colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x + totalOffsetX, y + totalOffsetY);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}
