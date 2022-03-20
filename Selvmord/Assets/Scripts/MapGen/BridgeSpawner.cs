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

    }
    private void Update()
    {
        SpawnBridge();
        DestroySpawner();
    }
    void SpawnBridge()
    {
        if (templates.BridgeList.Count < templates.BridgeCount && !HasSpawned)
        {
            if (_facingSouth)
            {
                InstantiateBridge(templates.SouthBridge);
            }
            else if (_facingNorth)
            {
                InstantiateBridge(templates.NorthBridge);
            }
            else if (_facingEast)
            {
                InstantiateBridge(templates.EastBridge);
            }
            else if (_facingWest)
            {
                InstantiateBridge(templates.WestBridge);
            }
        }
    }
    void InstantiateBridge(GameObject bridge)
    {
        BridgeAtributes atributes = bridge.GetComponent<BridgeAtributes>();
        Vector3 position = gameObject.transform.position;
        templates.BridgeList.Add(Instantiate(bridge, position + atributes.Offset, Quaternion.identity));

        HasSpawned = true;
    }

    //Destroys the gameObject containing this script once the time runs off for performance reasons.
    void DestroySpawner()
    {
        if (templates.TimeRemaining < 0f)
            Destroy(gameObject);
    }
}
