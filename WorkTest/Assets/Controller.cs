using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]private List<AvatarMovement> moveObjects = new();
    [SerializeField] private List<PlaceZone> placedLadders = new();
    [SerializeField] private Interact_Arrow arrow;
    [SerializeField] private EndZone endZone;
    [SerializeField] private WalkPath secondPath;

    public Action OnMove;
    private int _numberPlaced;

    void Start()
    {
        OnMove += MoveGround;
        foreach (var p in placedLadders)
        {
            p.PlaceCallback += LadderCount;
        }

        moveObjects[0].FinishedMoving += MoveAvatar;
        endZone.OnAvatarEnter += MoveGround;
    }

    private void MoveAvatar()
    {
        Debug.Log("last move");
        secondPath.moveOnPath = true;
    }
    
    private void OnApplicationQuit()
    {
        foreach (var p in placedLadders)
        {
            p.PlaceCallback -= LadderCount;
        }
        
        moveObjects[0].FinishedMoving -= MoveAvatar;
        endZone.OnAvatarEnter -= MoveGround;
    }

    private void LadderCount(int plusOrMinus)
    {
        _numberPlaced += plusOrMinus;
        Debug.Log(_numberPlaced);

        arrow.laddersPlaced = _numberPlaced == placedLadders.Count;
    }
    
    private void OnDisable()
    {
        OnMove -= MoveGround;
    }

    public void MoveGround()
    {
        for (int i = 0; i < moveObjects.Count; i++)
        {
            var temp = moveObjects[i];
            temp.movePoint = temp.startPoint - new Vector3(12.5f, 0, 0);
            temp.MoveDirection = MoveDirection.ToPoint;
            temp.shouldMove = true;
        }
    }
    
}
