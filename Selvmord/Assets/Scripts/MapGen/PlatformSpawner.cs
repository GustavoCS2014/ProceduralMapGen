using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private bool _facingSouth;
    [SerializeField] private bool _facingNorth;
    [SerializeField] private bool _facingEast;
    [SerializeField] private bool _facingWest;

    private LevelManager templates;
    private RoomAtributes roomAtributes;
    private GameObject thisRoom;
    
    private bool connected;
    private int rand;

    public bool HasSpawned;


    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        Invoke("SpawnPlatforms", 1f);

    }
    private void Update()
    {
        if(templates.TimeRemaining > 0f)
            templates.TimeRemaining -= Time.deltaTime;

        DestroyBridgeIfNotConnectedToRoom();
    }

    void SpawnPlatforms()
    {
        if (!HasSpawned)
        {
            if (_facingSouth)
            {
                rand = Random.Range(0, templates.SouthRooms.Length);
                    
                GameObject platform = templates.SouthRooms[rand];
                roomAtributes = platform.GetComponent<RoomAtributes>();
                Vector3 position = gameObject.transform.position;
                thisRoom = Instantiate(platform, position + roomAtributes.SouthOffset, Quaternion.identity);
            }
            else if (_facingNorth)
            {
                rand = Random.Range(0, templates.NorthRooms.Length);
                    
                GameObject platform = templates.NorthRooms[rand];
                roomAtributes = platform.GetComponent<RoomAtributes>();
                Vector3 position = gameObject.transform.position;
                thisRoom = Instantiate(platform, position + roomAtributes.NorthOffset, Quaternion.identity);
            }
            else if (_facingEast)
            {
                rand = Random.Range(0, templates.EastRooms.Length);
                    
                GameObject platform = templates.EastRooms[rand];
                roomAtributes = platform.GetComponent<RoomAtributes>();
                Vector3 position = gameObject.transform.position;
                thisRoom = Instantiate(platform, position + roomAtributes.EastOffset, Quaternion.identity);
            }
            else if (_facingWest)
            {
                rand = Random.Range(0, templates.WestRooms.Length);

                GameObject platform = templates.WestRooms[rand];
                roomAtributes = platform.GetComponent<RoomAtributes>();
                Vector3 position = gameObject.transform.position;
                thisRoom = Instantiate(platform, position + roomAtributes.WestOffset, Quaternion.identity);
            }
            templates.RoomList.Add(thisRoom);
            HasSpawned = true;
        }
    }

    void DestroyBridgeIfNotConnectedToRoom()
    {
        if (templates.TimeRemaining < 0f && !connected)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Platforms"))
        {
            connected = true;
        }
    }
}
