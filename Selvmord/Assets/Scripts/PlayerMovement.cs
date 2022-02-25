using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : TacticsMovement
{
    void Start()
    {
        init(); 
    }

    void Update()
    {
        if (!Moving)
        {
            FindSelectableTiles();
            CheckMouse();
        }
        else
        {
            Move();
        }
    }
}
