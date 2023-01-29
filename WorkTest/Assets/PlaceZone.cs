using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceZone : MonoBehaviour, IDropHandler
{
    public GameObject shadowLadderProto;
    private GameObject _shadowLadderKeep;
    private bool _objectPlaced;
    public Action<Guid, bool> PlaceCallback;
    public Guid Guid;


    private void Awake()
    {
        Get
        _shadowLadderKeep = Instantiate(shadowLadderProto, 
            transform.position, 
            quaternion.identity, transform);
        _shadowLadderKeep.SetActive(false);
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
