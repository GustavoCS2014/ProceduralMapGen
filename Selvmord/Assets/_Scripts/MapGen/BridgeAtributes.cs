using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeAtributes : MonoBehaviour
{
    public Vector3 Offset;

    //Used so bridges don't overlap with other objects. 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platforms") || other.CompareTag("Bridge"))
        {
            if (gameObject.activeSelf)
            {
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);
            }
        }
    }
}
