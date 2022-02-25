using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public int CurrentX { set; get; }
    public int CurrentY { set; get; }
    private int GridSize = GridManager.GridSize;

    public void SetPosition(int x, int y){
        CurrentX = x;
        CurrentY = y;
    }
    
    public virtual bool[,] posibleMoves(){

        return new bool[GridSize, GridSize];
    }
}
