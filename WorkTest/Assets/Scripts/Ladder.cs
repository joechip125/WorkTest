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
    private CanvasGroup _canvasGroup;
    
    public bool canPickUp = true;
    private bool _hasPlaced;
    
    public bool HasPlaced => _hasPlaced;

    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _startingPoint = transform.position;
        _startingScale = transform.localScale;
        canPickUp = true;
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
        if (!canPickUp || !validArea)
        {
            transform.position = _startingPoint;
            transform.localScale = _startingScale;
        }
        else
        {
            transform.position = placePoint;
            canPickUp = false;
            _hasPlaced = true;
        }
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_hasPlaced) return;
        
        var aPos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        var placePos = new Vector3(aPos.x, aPos.y, -0.11f);
        transform.position = placePos;
    }
    
}
