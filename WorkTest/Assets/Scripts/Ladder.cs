using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ladder : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 _startingPoint;
    private Vector3 _startingScale;
    public bool canPlace;
    void Start()
    {
        _startingPoint = transform.position;
        _startingScale = transform.localScale;
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!canPlace)
        {
            transform.position = _startingPoint;
            transform.localScale = _startingScale;
        }
       
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        var aPos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        transform.position = aPos + new Vector3(0,0,9.7f);
    }
}
