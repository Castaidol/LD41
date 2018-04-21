using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSpawner : MonoBehaviour {

    public GameObject firstRoom;

    public bool spawned = false;

	void Start () {
        Invoke("Spawn", 0.1f);
	}
	
    private void Spawn()
    {
        if(spawned == false)
        {
            if (firstRoom != null)
            {
                Instantiate(firstRoom, transform.position, Quaternion.identity);
            }
            spawned = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Spawner") && collision.GetComponent<RoomSpawner>().spawned == true) || (collision.CompareTag("Spawner") && collision.GetComponent<FirstSpawner>().spawned == true))
        {
            Destroy(gameObject);
        }
    }
}
