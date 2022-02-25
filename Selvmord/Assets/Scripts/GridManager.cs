using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _grid;
    [SerializeField] private GameObject _tile;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private int _gridSize, _scale, _xOffset, _yOffset;

    public static int GridSize = 20;
    public static bool[,] PosibleTiles = new bool[GridSize, GridSize];

    private float offset = 0.5f;

    // Start is called before the first frame updates.
    void Start(){
        GenerateGrid();
        SpawnPlayer();
        
    }

    // Generates the perlin noise grid.
    private void GenerateGrid(){
        for (int x = 0; x < _gridSize; x++){
            for (int y = 0; y < _gridSize; y++){

                float xCoord = (float)x / _gridSize * _scale + _xOffset;
                float yCoord = (float)y / _gridSize * _scale + _yOffset;

                float noise = Mathf.PerlinNoise(xCoord, yCoord);


                if (noise > 0.4f){
                    PosibleTiles[x, y] = true;
                }else{
                    PosibleTiles[x, y] = false;
                }
            }
        }

        for (int x = 0; x < _gridSize; x++){
            for (int y = 0; y < _gridSize; y++){
                if (PosibleTiles[x, y] ){
                    var tile = Instantiate(_tile, new Vector3(x + offset, -0.5f, y + offset), Quaternion.identity);
                    tile.name = $"Tile {x} , {y}";
                    tile.gameObject.tag = "Tile";

                }
            }
        }
        _mainCamera.transform.localPosition = new Vector3((float)_gridSize / 2f, _gridSize, (float)_gridSize / 2f);
    }

    /// Spawns the player in 1,1 or any other location available.
    private void SpawnPlayer()
    {

        if (PosibleTiles[1, 1])
        {
            var p = Instantiate(_player, new Vector3(1 + offset, 1, 1 + offset), Quaternion.identity);
            p.name = $"Player";
            p.gameObject.tag = "Player";
        }
        else
        {
            for (int x = 0; x < _gridSize; x++)
            {
                for (int y = 0; y < _gridSize; y++)
                {
                    if (PosibleTiles[x, y] && GameObject.Find("Player") == null)
                    {
                        var p = Instantiate(_player, new Vector3(x + offset, 1, y + offset), Quaternion.identity);
                        p.name = $"Player";
                        p.gameObject.tag = "Player";
                    }

                }
            }
        }
    }
}
