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

    private LevelManager templates;


    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        Invoke("SpawnBridge", 1f);

    }
    private void Update()
    {
        DestroySpawner();
    }
    void SpawnBridge()
    {
        if (templates.BridgeList.Count < templates.BridgeCount && !HasSpawned)
        {
            if (_facingSouth)
            {
                GameObject bridge = templates.SouthBridge;
                BridgeAtributes bridge_Atributes = bridge.GetComponent<BridgeAtributes>();
                Vector3 position = gameObject.transform.position;
                templates.BridgeList.Add(Instantiate(bridge, position + bridge_Atributes.Offset, Quaternion.identity));
            }
            else if (_facingNorth)
            {
                GameObject bridge = templates.NorthBridge;
                BridgeAtributes bridge_Atributes = bridge.GetComponent<BridgeAtributes>();
                Vector3 position = gameObject.transform.position;
                templates.BridgeList.Add(Instantiate(bridge, position + bridge_Atributes.Offset, Quaternion.identity));
            }
            else if (_facingEast)
            {
                GameObject bridge = templates.EastBridge;
                BridgeAtributes bridge_Atributes = bridge.GetComponent<BridgeAtributes>();
                Vector3 position = gameObject.transform.position;
                templates.BridgeList.Add(Instantiate(bridge, position + bridge_Atributes.Offset, Quaternion.identity));
            }
            else if (_facingWest)
            {
                GameObject bridge = templates.WestBridge;
                BridgeAtributes bridge_Atributes = bridge.GetComponent<BridgeAtributes>();
                Vector3 position = gameObject.transform.position;
                templates.BridgeList.Add(Instantiate(bridge, position + bridge_Atributes.Offset, Quaternion.identity));
            }

            HasSpawned = true;
        }
    }

    //Destroys the gameObject containing this script once the time runs off for performance reasons.
    void DestroySpawner()
    {
        if (templates.TimeRemaining < 0f)
            Destroy(gameObject);
    }
}
