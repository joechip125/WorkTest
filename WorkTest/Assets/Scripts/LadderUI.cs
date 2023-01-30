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
    [SerializeField] public bool flipLadder;
    [HideInInspector]public bool ladderOnDropArea;
    
    public bool LadderHeld => _ladderHeld;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _startPos = _rectTransform.localPosition;
    }

    public void ReturnToSender()
    {
        _rectTransform.localScale = new Vector3(1.0f,1.0f,1.0f);
        if (flipLadder)
        {
            _rectTransform.Rotate(new Vector3(0,1,0), -180f);
        }
        _rectTransform.localPosition = _startPos;
        _canvasGroup.blocksRaycasts = true;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _rectTransform.localScale = new Vector3(2.5f,2.5f,2.5f);
        if (flipLadder)
        {
            _rectTransform.Rotate(new Vector3(0,1,0), 180f);
        }
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
