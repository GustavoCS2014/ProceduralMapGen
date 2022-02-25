using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public bool Walkable = true;
    public bool Current = false;
    public bool Target = false;
    public bool Selectable = false;

    private Color Original;

    public List<Tile> AdjacencyList = new List<Tile>();

    // Needed for BFS (Breadth First Search)
    public bool Visited = false;
    public Tile Parent = null;
    public int Distance = 0;


    // Start is called before the first frame update
    void Start()
    {
        Original = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Walkable)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (Current)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (Target)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (Selectable)
        {
            GetComponent<Renderer>().material.color = Color.cyan;
        }
        else
        {
            GetComponent<Renderer>().material.color = Original;
        }
    }

    public void Reset()
    {
        AdjacencyList.Clear();

        Current = false;
        Target = false;
        Selectable = false;

        Visited = false;
        Parent = null;
        Distance = 0;

    }

    public void FindNeighbors()
    {
        Reset();

        CheckTile(Vector3.forward);
        CheckTile(-Vector3.forward);
        CheckTile(Vector3.right);
        CheckTile(-Vector3.right);
    }

    public void CheckTile(Vector3 direction)
    {

        Vector3 halfExtents = new Vector3(0.25f, 0f, 0.25f);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, halfExtents);

        foreach (Collider item in colliders)
        { 
            Tile tile = item.GetComponent<Tile>();
            if(tile != null && tile.Walkable)
            {
                RaycastHit hit;

                if(!Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1))
                {
                    AdjacencyList.Add(tile);
                }
            }
        }
    }
}
