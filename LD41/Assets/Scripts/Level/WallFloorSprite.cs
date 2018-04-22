using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFloorSprite : MonoBehaviour {

    public Sprite[] sprites;
    public SpriteRenderer sprite;

	void Start () 
    {
        sprite.GetComponent<SpriteRenderer>();
        sprite.sprite = sprites[Random.Range(0, sprites.Length)];
	}
	
}
