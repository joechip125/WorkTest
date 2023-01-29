using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LadderUI : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    private Vector3 _startPos;
    private bool _ladderHeld;

    public bool ladderOnDropArea;
    public bool LadderHeld => _ladderHeld;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _startPos = _rectTransform.position;
    }

    public void ReturnToSender()
    {
        _rectTransform.localScale = new Vector3(0.6f,0.6f,0.6f);
        _rectTransform.position = _startPos;
        _canvasGroup.blocksRaycasts = true;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _rectTransform.localScale = new Vector3(2.8f,2.8f,2.8f);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        _ladderHeld = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!ladderOnDropArea)
        {
            ReturnToSender();
        }
        
        _ladderHeld = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta;
    }
}
