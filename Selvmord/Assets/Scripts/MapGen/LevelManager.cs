using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float TimeRemaining;

    public GameObject[] SouthPlatforms;
    public GameObject[] NorthPlatforms;
    public GameObject[] EastPlatforms;
    public GameObject[] WestPlatforms;

    public GameObject SouthBridge;
    public GameObject NorthBridge;
    public GameObject EastBridge;
    public GameObject WestBridge;

    public List<GameObject> RoomList;
    public List<GameObject> BridgeList;

    public int BridgeCount;
}
