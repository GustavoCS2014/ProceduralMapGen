using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private GameObject _grid;
    [SerializeField] private GameObject _tile;
    [SerializeField] private PlayerScript _player;
    [SerializeField] private int _gridSize, _scale, _xOffset, _yOffset;

    private List<GameObject> activeTiles;

    public static int GridSize = 20;
    public static bool[,] PosibleTiles = new bool[GridSize, GridSize];

    private float offset = 0.5f;
    private int selectionX = -1, selectionY = -1;

    // Start is called before the first frame updates.
    void Start(){
        GenerateGrid();
        SpawnPlayer();
        Debug.Log($"Player Spawn Location ({_player.CurrentX} , {_player.CurrentY})");
    }

    // Update is called once per frame.
    void Update(){
        DrawGrid();
        UpdateSelection();

        if (Input.GetMouseButtonDown(0)){
            if (PosibleTiles[selectionX, selectionY]){
                Debug.Log(selectionX + " , " + selectionY);
            }else{
                Debug.Log("Not a valid move");
            }
        }
    }

    // Updates the selected tile.
    private void UpdateSelection(){
        if (!_mainCamera)
            return;

        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        if (Physics.Raycast(ray, out Hit, _mainCamera.farClipPlane, _layerMask)){
            selectionX = (int)(Hit.point.x);
            selectionY = (int)(Hit.point.z);
        }else{ //returning values to -1 when the mouse is not on the plane.

            selectionX = -1;
            selectionY = -1;
        }
    }

    // Draws the grid.
    private void DrawGrid(){
        Vector3 width = Vector3.right * _gridSize;
        Vector3 height = Vector3.forward * _gridSize;

        for (int x = 0; x <= _gridSize; x++){

            Vector3 start = Vector3.forward * x;
            Debug.DrawLine(start, start + width, Color.cyan);

            for (int y = 0; y <= _gridSize; y++){

                start = Vector3.right * y;
                Debug.DrawLine(start, start + height, Color.cyan);
            }
        }

        _grid.transform.localScale = new Vector3(_gridSize, 0.1f, _gridSize);

        _mainCamera.transform.localPosition = new Vector3((float)_gridSize / 2f, _gridSize, (float)_gridSize / 2f);
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
