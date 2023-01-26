using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ladder : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 _startingPoint;
    private Vector3 _startingScale;
    private Vector3 _placePoint;
    private Action _theCallback;
    private Transform _zoneTransform;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    
    public bool canPlace;
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _rectTransform = GetComponent<RectTransform>();
        _startingPoint = transform.position;
        _startingScale = transform.localScale;
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0.5f;
    }

    public void TargetHit(Vector3 placePos, Action callBack)
    {
        _placePoint = placePos;
        _theCallback = callBack;
        canPlace = true;
    }

    public void TargetLost()
    {
        canPlace = false;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!canPlace)
        {
            transform.position = _startingPoint;
            transform.localScale = _startingScale;
        }
        else
        {
            transform.position = _placePoint;
            _theCallback?.Invoke();
            canPlace = false;
        }
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.alpha = 1f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlaceZone"))
        {
            _zoneTransform = col.GetComponent<PlaceZone>().ZoneChange(true);
            _placePoint = _zoneTransform.position;
            canPlace = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("PlaceZone"))
        {
            //col.GetComponent<PlaceZone>().ZoneChange(false);
            //canPlace = false;
        }
    }
    

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition = eventData.delta;
        var aPos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        var placePos = new Vector3(aPos.x, aPos.y, -0.11f);
        transform.position = placePos;
    }
    
}
