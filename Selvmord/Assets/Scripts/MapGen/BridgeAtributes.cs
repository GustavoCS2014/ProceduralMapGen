using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeAtributes : MonoBehaviour
{
    public Vector3 Offset;

    private BridgeSpawner bridgeSpawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rooms") || other.CompareTag("Bridge"))
        {
            Destroy(this.gameObject);
            bridgeSpawner.HasSpawned = false;
        }
    }
}
