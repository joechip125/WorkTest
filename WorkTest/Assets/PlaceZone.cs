using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private bool moveUpOrDown;
    private GameObject _shadowLadderKeep;
    private bool _objectPlaced;
    public Action<Guid, bool> PlaceCallback;
    private Ladder _aLadder;
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

        if (col.CompareTag("Placeable"))
        {
            _aLadder = col.GetComponent<Ladder>();
            if (!_objectPlaced)
            {
                _shadowLadderKeep.SetActive(true);
                _aLadder.placePoint = transform.position;
                _aLadder.validArea = true;
            }
            else
            {
                _aLadder.validArea = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Placeable"))
        {
            _shadowLadderKeep.SetActive(false);
            _aLadder.validArea = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
       
    }
}
