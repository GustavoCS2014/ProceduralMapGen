using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] SouthRooms;
    public GameObject[] NorthRooms;
    public GameObject[] EastRooms;
    public GameObject[] WestRooms;

    public GameObject SouthBridge;
    public GameObject NorthBridge;
    public GameObject EastBridge;
    public GameObject WestBridge;

    public List<GameObject> RoomList;
    public List<GameObject> BridgeList;
    public int RoomCount;
}
