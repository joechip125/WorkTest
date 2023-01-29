using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]private List<AvatarMovement> moveObjects = new();
    [SerializeField] private EndZone endZone;

    public Action OnMove;
    private int _numberPlaced;

    void Start()
    {
        OnMove += MoveGround;
        endZone.OnAvatarEnter += MoveGround;
    }
    
    private void OnApplicationQuit()
    {
        endZone.OnAvatarEnter -= MoveGround;
    }
    
    private void OnDisable()
    {
        OnMove -= MoveGround;
    }

    private void MoveGround()
    {
        foreach (var movement in moveObjects)
        {
            movement.movePoint = movement.startPoint - new Vector3(12.5f, 0, 0);
            movement.MoveDirection = MoveDirection.ToPoint;
        }
    }
    
}
