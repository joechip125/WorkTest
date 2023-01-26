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
    private Guid _guid;
    
    public bool canPlace;
    void Start()
    {
        _startingPoint = transform.position;
        _startingScale = transform.localScale;
        _guid = new Guid();
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
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
            col.GetComponent<PlaceZone>().ZoneChange(false);
            canPlace = false;
        }
    }
    

    public void OnDrag(PointerEventData eventData)
    {
        var aPos = Camera.main.ScreenPointToRay(Input.mousePosition).origin;
        transform.position = aPos + new Vector3(0,0,9.7f);
    }
}
