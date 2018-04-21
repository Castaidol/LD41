using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour 
{

    public float speed;

    private Rigidbody2D rb2D;
    private Vector2 moveVelocity;

	// Use this for initialization
	void Start () 
    {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	
	void Update () 
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = movementInput.normalized * speed;
	}

	private void FixedUpdate()
	{
        rb2D.MovePosition(rb2D.position + moveVelocity * Time.deltaTime);
	}
}
