using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaceZoneUI : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool _canPlace = true;
    private LadderUI _ladderUI;
    private Image _shadowImage;
    private Color _sC;

    private void Awake()
    {
        _shadowImage = GetComponentInChildren<Image>();
       // _shadowImage.SetActive(false);
       _sC = _shadowImage.color;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (!_canPlace)
            {
                _ladderUI.ReturnToSender();
                return;
            }
            
            var pos = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = pos;
            _canPlace = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("pointer enter");
        _shadowImage.color = _sC + new Color(0, 0, 0, -255);
//        _ladderUI =  eventData.pointerDrag.GetComponent<LadderUI>();
        if (_ladderUI)
        {
            if (_ladderUI.LadderHeld && _canPlace)
            {
                
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("pointer exit");
        _shadowImage.color = _sC + new Color(0, 0, 0, 255);
    }
}
