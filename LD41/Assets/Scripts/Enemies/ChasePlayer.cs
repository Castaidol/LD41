using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour {

    public Transform target;

    public float speed;

	void Start () 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update () 
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
	}
}
