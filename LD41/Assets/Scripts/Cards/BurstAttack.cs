using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstAttack : MonoBehaviour {

    public GameObject projectile;

    public float speed;

    public bool burst = false;
    private float burstTimer = 0.5f;
    private float burstReset;
    private Transform playerTransform;

    void Start()
    {
        burstReset = burstTimer;
    }



    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        if (burst && burstTimer >= 0.5f)
        {
            

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                    {

                    }
                    else
                    {
                        GameObject pj = Instantiate(projectile, playerTransform.position, Quaternion.identity);
                        pj.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * speed);
                    }
                }
            }
        }
        burstTimer -= Time.deltaTime;
        if(burstTimer <= 0) burstTimer = burstReset;
    }
}
