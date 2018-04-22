using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour 
{

    public float speed;
    [HideInInspector]
    public Vector2 playerDirection;
    [HideInInspector]
    public Vector2 moveVelocity;

    private Rigidbody2D rb2D;

	void Start () 
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerDirection = new Vector2(0, -1);
	}
	
	
	void Update () 
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = movementInput.normalized * speed;

        if(movementInput.x != 0 || moveVelocity.y != 0)
        {
            playerDirection = movementInput;
        }
	}

	private void FixedUpdate()
	{
        rb2D.MovePosition(rb2D.position + moveVelocity * Time.deltaTime);
	}
}
