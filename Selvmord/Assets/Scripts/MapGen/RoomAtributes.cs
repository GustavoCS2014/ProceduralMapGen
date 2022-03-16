using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomAtributes : MonoBehaviour
{
    
    public Vector3 SouthOffset;
    public Vector3 NorthOffset;
    public Vector3 WestOffset;
    public Vector3 EastOffset;

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
