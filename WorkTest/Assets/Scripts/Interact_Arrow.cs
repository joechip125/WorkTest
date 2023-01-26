using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interact_Arrow : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private bool _startedMovement;
    public bool laddersPlaced;

    public AvatarMovement moveObject;

    private void Awake()
    {
    }
    
    
    private void OnMouseDown()
    {
        if (!_startedMovement)
        {
            moveObject.shouldMove = true;
            moveObject.MoveDirection = MoveDirection.Forward;
            _startedMovement = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }
}
