using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public float speed;

	void Start () 
    {
        PlayerPrefs.SetFloat("CameraX", 0f);
        PlayerPrefs.SetFloat("CameraY", 0f);
	}
	
	void Update () 
    {
        Vector3 newPosition = new Vector3(PlayerPrefs.GetFloat("CameraX"), PlayerPrefs.GetFloat("CameraY"), transform.position.z);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
	}
}
