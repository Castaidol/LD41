using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    public int OpeningDirection;
    //1 need Bottom door
    //2 need Left door
    //3 need Top door
    //4 need Right door

    private RoomTemplate roomTemplate;
    private int rng;
    public bool spawned = false;

	private void Start()
	{
        roomTemplate = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
	}

	private void Spawn()
	{
        if (spawned == false)
        {
            if (OpeningDirection == 1)
            {
                rng = Random.Range(0, roomTemplate.bottomDoor.Length);
                Instantiate(roomTemplate.bottomDoor[rng], transform.position, Quaternion.identity);

            }
            else if (OpeningDirection == 2)
            {
                rng = Random.Range(0, roomTemplate.leftDoor.Length);
                Instantiate(roomTemplate.leftDoor[rng], transform.position, Quaternion.identity);

            }
            else if (OpeningDirection == 3)
            {
                rng = Random.Range(0, roomTemplate.topDoor.Length);
                Instantiate(roomTemplate.topDoor[rng], transform.position, Quaternion.identity);
            }
            else if (OpeningDirection == 4)
            {
                rng = Random.Range(0, roomTemplate.rightDoor.Length);
                Instantiate(roomTemplate.rightDoor[rng], transform.position, Quaternion.identity);
            }
            spawned = true;
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.CompareTag("Spawner"))
        {
            if(collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(roomTemplate.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
	}
}
