using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAtributes : MonoBehaviour
{
    
    public Vector3 Offset;

    //Used so platforms don't overlap with other objects. 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Platforms") || other.CompareTag("Bridge"))
        {
            if (gameObject.activeSelf)
            {
                other.gameObject.SetActive(false);
                Destroy(other.gameObject);
            }
        }
    }


}
