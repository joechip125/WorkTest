using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceZone : MonoBehaviour, IDropHandler
{
    private GameObject _shadowLadderKeep;
    private bool _objectPlaced;
    public Action<Guid, bool> PlaceCallback;
    public Guid Guid;


    private void Awake()
    {
        _shadowLadderKeep = GetComponentInChildren<PreStartObject>().gameObject;
        _shadowLadderKeep.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Avatar"))
        {
            var move = col.GetComponent<AvatarMovement>().shouldMove = false;
        }
    }
    
    
    

    public Transform ZoneChange(bool comeOrGo)
    {
        _shadowLadderKeep.SetActive(comeOrGo);
        _objectPlaced = comeOrGo;
        PlaceCallback?.Invoke(Guid, comeOrGo);
        return transform;
    }

    public void OnDrop(PointerEventData eventData)
    {
        PlaceCallback?.Invoke(Guid, true);
    }
}
