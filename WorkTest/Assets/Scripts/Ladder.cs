using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ladder : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 _startingPoint;
    private Vector3 _startingScale;
    [HideInInspector] public Vector3 placePoint;
    [HideInInspector] public bool validArea;
    private Transform _zoneTransform;
    
    private bool _hasPlaced;
    
    public bool HasPlaced => _hasPlaced;

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
        if (_hasPlaced) return;
        if (!validArea)
        {
            transform.position = _startingPoint;
            transform.localScale = _startingScale;
        }
        else
        {
            transform.position = placePoint;
            _hasPlaced = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_hasPlaced) return;
        
        var aPos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        var placePos = new Vector3(aPos.x, aPos.y, -0.11f);
        transform.position = placePos;
    }
    
}
