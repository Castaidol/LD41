using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {

    public int healtPoint;

    public Animator anim;

	void Start () 
    {
        anim = GetComponent<Animator>();
	}
	
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        anim.SetTrigger("attack");

        if(collision.tag == "Player")
        {
            Debug.Log("colpito");
            anim.SetTrigger("attack");
        }

	}
}
