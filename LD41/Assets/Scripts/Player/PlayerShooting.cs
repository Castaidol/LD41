using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject projectile;

    public float speed;

    public bool burst = false;
    private float burstTimer = 0.5f;
    private float burstReset;

	void Start () 
    {
        burstReset = burstTimer;
	}
	
	

	void Update () {
		
        if(burst && burstTimer >= 0.5f)
        {
            burstTimer -= Time.deltaTime;
            
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        
                    }
                    else
                    {
                        GameObject pj = Instantiate(projectile, this.transform.position, Quaternion.identity);
                        pj.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * speed);
                    }
                }
            }
            if (burstTimer <= 0) burstTimer = burstReset;
        }

	}
}
