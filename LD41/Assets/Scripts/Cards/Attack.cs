using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public AttackCard card;
    public float duration;

    private Transform playerTransform;
    private Vector2 playerDirection;

    [Header("Burst Attack")]
    public GameObject burstProjectile;

    public bool burstAttack = false;

    [HideInInspector]
    public bool burst = false;

    private float burstReset;
    private float burstTimer;
    private float burstSpeed;

    [Header("Auto Attack")]
    public GameObject autoProjectile;

    public bool autoAttack = false;

    [HideInInspector]
    public bool auto = false;

    private float autoReset;
    private float autoSpeed;
    private float autoTimer;



    void Start()
    {
        burstTimer = card.nextShootTime;
        burstSpeed = card.projectileSpeed;

        autoTimer = card.nextShootTime;
        autoSpeed = card.projectileSpeed;

        duration = card.duration;

        burstReset = burstTimer;
        autoReset = autoTimer;
    }



    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerDirection = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().playerDirection;

        if(burstAttack)
        {
            if (burst && burstTimer >= burstReset)
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
                            GameObject pj = Instantiate(burstProjectile, playerTransform.position, Quaternion.identity);
                            pj.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y) * burstSpeed);
                        }
                    }
                }
            }
            burstTimer -= Time.deltaTime;
            if (burstTimer <= 0) burstTimer = burstReset; 
        }

        if(autoAttack)
        {
            


            if(auto && autoTimer >= autoReset)
            {
                GameObject pj = Instantiate(autoProjectile, playerTransform.position, Quaternion.identity, playerTransform);
                pj.GetComponent<Rigidbody2D>().AddForce(playerDirection * autoSpeed);
            }
            autoTimer -= Time.deltaTime;
            if (autoTimer <= 0) autoTimer = autoReset;
        }
    }
}
