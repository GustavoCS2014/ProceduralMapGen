using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MovementManager
{
    private int gridSize = GridManager.GridSize;
    private bool[,] posibleTiles = GridManager.PosibleTiles;

    public override bool[,] posibleMoves(){
        bool[,] availableMoves = new bool[gridSize, gridSize];
        int x, y;

        x = CurrentX - 1;
        y = CurrentY + 1;
        for(int i = 0; i < 3; i++)
        {
            if (posibleTiles[x, y]){
                availableMoves[x, y] = true;
            }
            x++;
        }

        x = CurrentX - 1;
        y = CurrentY - 1;
        for (int i = 0; i < 3; i++)
        {
            if (posibleTiles[x, y])
            {
                availableMoves[x, y] = true;
            }
            x++;
        }

        x = CurrentX + 1;
        y = CurrentY;
        if(posibleTiles[x,y])
        {
            availableMoves[x, y] = true;
        }

        x = CurrentX - 1;
        y = CurrentY;
        if (posibleTiles[x, y])
        {
            availableMoves[x, y] = true;
        }

        return availableMoves;
    }
}
