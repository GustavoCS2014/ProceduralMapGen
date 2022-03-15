using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAtributes : MonoBehaviour
{
    
    public Vector3 SouthOffset;
    public Vector3 NorthOffset;
    public Vector3 WestOffset;
    public Vector3 EastOffset;

    private RoomSpawner roomSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Rooms") || other.CompareTag("Bridge")){
            Destroy(this.gameObject);
            roomSpawner.HasSpawned = false;
            roomSpawner.HasScanned = false;
        }
        else
        {
            roomSpawner.HasScanned = true;
            Destroy(this);
        }
    }


}
