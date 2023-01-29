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

    public bool CanPlace => _canPlace;

    private void Awake()
    {
        _shadowImage = GetComponentInChildren<Image>();
        _sC = _shadowImage.color;
       _shadowImage.color = new Color(_sC.r, _sC.g, _sC.b, 0);
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
            _shadowImage.color = new Color(_sC.r, _sC.g, _sC.b, 0f);
            _canPlace = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag)
        {
            _ladderUI = eventData.pointerDrag.GetComponent<LadderUI>();
            _ladderUI.ladderOnDropArea = true;
        }
        
        if (_ladderUI)
        {
            if (_ladderUI.LadderHeld && _canPlace)
            {
                _shadowImage.color = new Color(_sC.r, _sC.g, _sC.b, 0.5f);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _shadowImage.color = new Color(_sC.r, _sC.g, _sC.b, 0);

        if (_ladderUI)
        {
            _ladderUI.ladderOnDropArea = false;
            _ladderUI = null;
        }
    }
}
