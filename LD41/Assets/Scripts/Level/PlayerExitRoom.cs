using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExitRoom : MonoBehaviour {
    
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.tag == "Player")
        {
            PlayerPrefs.SetFloat("CameraX", transform.position.x);
            PlayerPrefs.SetFloat("CameraY", transform.position.y);
        }
	}
}
