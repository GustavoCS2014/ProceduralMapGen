using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] private bool _facingSouth;
    [SerializeField] private bool _facingNorth;
    [SerializeField] private bool _facingEast;
    [SerializeField] private bool _facingWest;

    public bool HasSpawned;
    public bool HasScanned;

    private RoomTemplates templates;
    private RoomAtributes roomAtributes;

    private int rand;
    private GameObject thisRoom;


    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomTemplates>();
        Invoke("SpawnRoom", 1f);

    }

    void SpawnRoom()
    {
        List<int> triedId = new List<int> ();
        do
        {
            if (!HasSpawned)
            {
                if (_facingSouth)
                {
                    rand = Random.Range(0, templates.NorthRooms.Length);
                    for (int i = 0; i < triedId.Count; i++)
                    {
                        if (rand != triedId[i])
                        {
                            GameObject room = templates.NorthRooms[rand];
                            roomAtributes = room.GetComponent<RoomAtributes>();
                            Vector3 pos = gameObject.transform.position;
                            thisRoom = Instantiate(room, pos + roomAtributes.SouthOffset, Quaternion.identity);
                            triedId.Add(rand);
                        }
                    }
                }
                else if (_facingNorth)
                {
                    rand = Random.Range(0, templates.SouthRooms.Length);
                    for (int i = 0; i < triedId.Count; i++)
                    {
                        if (rand != triedId[i])
                        {
                            GameObject room = templates.SouthRooms[rand];
                            roomAtributes = room.GetComponent<RoomAtributes>();
                            Vector3 pos = gameObject.transform.position;
                            thisRoom = Instantiate(room, pos + roomAtributes.NorthOffset, Quaternion.identity);
                            triedId.Add(rand);
                        }
                    }
                }
                else if (_facingEast)
                {
                    rand = Random.Range(0, templates.WestRooms.Length);
                    for (int i = 0; i < triedId.Count; i++)
                    {
                        if (rand != triedId[i])
                        {
                            GameObject room = templates.WestRooms[rand];
                            roomAtributes = room.GetComponent<RoomAtributes>();
                            Vector3 pos = gameObject.transform.position;
                            thisRoom = Instantiate(room, pos + roomAtributes.EastOffset, Quaternion.identity);
                            triedId.Add(rand);
                        }
                    }
                }
                else if (_facingWest)
                {
                    rand = Random.Range(0, templates.EastRooms.Length);
                    for (int i = 0; i < triedId.Count; i++)
                    {
                        if (rand != triedId[i])
                        {
                            GameObject room = templates.EastRooms[rand];
                            roomAtributes = room.GetComponent<RoomAtributes>();
                            Vector3 pos = gameObject.transform.position;
                            thisRoom = Instantiate(room, pos + roomAtributes.WestOffset, Quaternion.identity);
                            triedId.Add(rand);
                        }
                    }
                }

                HasSpawned = true;
            }
        } while (!HasScanned);
    }
}
