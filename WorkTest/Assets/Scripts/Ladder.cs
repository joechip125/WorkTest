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
    private Action _theCallback;
    private Transform _zoneTransform;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    
    public bool canPlace = true;
    private bool _hasPlaced;
    
    public bool HasPlaced => _hasPlaced;

    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
        _startingPoint = transform.position;
        _startingScale = transform.localScale;
        canPlace = true;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       
    }
    
    public void ReturnToSender()
    {
        transform.position = _startingPoint;
        transform.localScale = _startingScale;
    }

    public void PlaceTheLadder(Vector3 placePos)
    {
        transform.position = placePos;
        _theCallback?.Invoke();
        canPlace = false;
        
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (_hasPlaced) return;
        if (!canPlace || !validArea)
        {
            transform.position = _startingPoint;
            transform.localScale = _startingScale;
        }
        else
        {
            transform.position = placePoint;
            _theCallback?.Invoke();
            canPlace = false;
            _hasPlaced = true;
        }
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!canPlace) return;
        
        _rectTransform.anchoredPosition = eventData.delta;
        var aPos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        var placePos = new Vector3(aPos.x, aPos.y, -0.11f);
        transform.position = placePos;
    }
    
}
