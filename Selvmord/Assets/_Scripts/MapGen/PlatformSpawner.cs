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
    private GameObject thisRoom;
    
    private bool connected;
    private int rand;

    public bool HasSpawned;


    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }
    private void Update()
    {
        if(templates.TimeRemaining > 0f)
            templates.TimeRemaining -= Time.deltaTime;
        SpawnPlatforms();
        DestroyBridgeIfNotConnectedToRoom();
        DestroySpawner();
    }

    void SpawnPlatforms()
    {
        if (!HasSpawned)
        {
            if (_facingSouth)
            {
                InstantiatePlatform(templates.SouthPlatforms);
            }
            else if (_facingNorth)
            {
                InstantiatePlatform(templates.NorthPlatforms);
            }
            else if (_facingEast)
            {
                InstantiatePlatform(templates.EastPlatforms);
            }
            else if (_facingWest)
            {
                InstantiatePlatform(templates.WestPlatforms);
            }
            
        }
    }

    void InstantiatePlatform(GameObject[] roomsArray)
    {
        rand = Random.Range(0, roomsArray.Length);

        GameObject platform = roomsArray[rand];
        PlatformAtributes atributes = platform.GetComponent<PlatformAtributes>();
        Vector3 position = gameObject.transform.position;
        var thisRoom = Instantiate(platform, position + atributes.Offset, Quaternion.identity);
        thisRoom.transform.parent = GameObject.Find("Level").transform;

        templates.RoomList.Add(thisRoom);
        HasSpawned = true;
    }

    void DestroyBridgeIfNotConnectedToRoom()
    {
        if (templates.TimeRemaining < 0f && !connected)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    //Destroys the gameObject containing this script once the time runs off for performance reasons.
    void DestroySpawner()
    {
        if (templates.TimeRemaining < 0f)
            Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Platforms"))
        {
            connected = true;
        }
    }
}
