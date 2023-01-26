using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interact_Arrow : MonoBehaviour
{
    private bool _startedMovement;
    public bool laddersPlaced;

    public AvatarMovement moveObject;
    
    
    private void OnMouseDown()
    {
        if (!_startedMovement && laddersPlaced)
        {
            moveObject.shouldMove = true;
            moveObject.MoveDirection = MoveDirection.Forward;
            _startedMovement = true;
        }
    }
    
}
