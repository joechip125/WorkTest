using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Arrow : MonoBehaviour
{
    private bool _startedMovement;
    public bool laddersPlaced;
    private AvatarMovement _avatarMovement;

    private void Awake()
    {
       _avatarMovement = FindObjectOfType<AvatarMovement>();
    }
    
    private void OnMouseDown()
    {
        if (!_startedMovement)
        {
            _avatarMovement.shouldMove = true;
            _avatarMovement.MoveDirection = MoveDirection.Forward;
            _startedMovement = true;
        }
    }
}
