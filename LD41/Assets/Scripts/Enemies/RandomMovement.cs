using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {
    

    public float speed;
    public float changeDirectionTimer;

    private float resetTimer;
    private Vector2 movementInput;

	private void Start()
	{
        resetTimer = changeDirectionTimer;
	}

	void Update () 
    {
        changeDirectionTimer -= Time.deltaTime;

        if (changeDirectionTimer <= 0)
        {
            movementInput = new Vector3(transform.position.x +  Random.Range(-5, 5), transform.position.y + Random.Range(-5, 5), transform.position.z);
            changeDirectionTimer = resetTimer;
        }

        transform.position = Vector3.MoveTowards(transform.position, movementInput, speed * Time.deltaTime);
	}

   
}
