using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int OpeningDirection;
    /*
    1 --> Need bottom bridge
    2 --> Need top bridge
    3 --> Need left bridge
    4 --> Need right bridge
    */

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            switch (OpeningDirection)
            {
                case 1:
                    //Spawn room with a bottom bridge.
                    rand = Random.Range(0, templates.BottomRooms.Length);
                    Instantiate(templates.BottomRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 2:
                    //Spawn room with a top bridge.
                    rand = Random.Range(0, templates.TopRooms.Length);
                    Instantiate(templates.TopRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 3:
                    //Spawn room with a left bridge.
                    rand = Random.Range(0, templates.LeftRooms.Length);
                    Instantiate(templates.LeftRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 4:
                    //Spawn room with a right bridge.
                    rand = Random.Range(0, templates.RightRooms.Length);
                    Instantiate(templates.RightRooms[rand], transform.position, Quaternion.identity);
                    break;
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoomSpawner"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.Platform, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
