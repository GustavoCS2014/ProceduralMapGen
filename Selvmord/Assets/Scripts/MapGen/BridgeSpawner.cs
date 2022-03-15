using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSpawner : MonoBehaviour
{
    [SerializeField] private bool _facingSouth;
    [SerializeField] private bool _facingNorth;
    [SerializeField] private bool _facingEast;
    [SerializeField] private bool _facingWest;

    public bool HasSpawned;

    private RoomTemplates templates;



    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomTemplates>();
        Invoke("SpawnBridge", 1f);

    }

    void SpawnBridge()
    {
        if (templates.BridgeList.Count < templates.RoomCount && !HasSpawned)
        {
            if (_facingSouth)
            {
                
                GameObject bridge = templates.SouthBridge;
                BridgeAtributes bridge_Atributes = bridge.GetComponent<BridgeAtributes>();
                Vector3 pos = gameObject.transform.position;
                templates.BridgeList.Add(Instantiate(bridge, pos + bridge_Atributes.Offset, Quaternion.identity));
            }
            else if (_facingNorth)
            {
                GameObject bridge = templates.NorthBridge;
                BridgeAtributes bridge_Atributes = bridge.GetComponent<BridgeAtributes>();
                Vector3 pos = gameObject.transform.position;
                templates.BridgeList.Add(Instantiate(bridge, pos + bridge_Atributes.Offset, Quaternion.identity));
            }
            else if (_facingEast)
            {
                GameObject bridge = templates.EastBridge;
                BridgeAtributes bridge_Atributes = bridge.GetComponent<BridgeAtributes>();
                Vector3 pos = gameObject.transform.position;
                templates.BridgeList.Add(Instantiate(bridge, pos + bridge_Atributes.Offset, Quaternion.identity));
            }
            else if (_facingWest)
            {
                GameObject bridge = templates.WestBridge;
                BridgeAtributes bridge_Atributes = bridge.GetComponent<BridgeAtributes>();
                Vector3 pos = gameObject.transform.position;
                templates.BridgeList.Add(Instantiate(bridge, pos + bridge_Atributes.Offset, Quaternion.identity));
            }

            HasSpawned = true;
        }
    }
}
