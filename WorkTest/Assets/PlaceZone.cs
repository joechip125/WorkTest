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
    private Ladder _aLadder;

    
    private void Awake()
    {
        _shadowLadderKeep = GetComponentInChildren<PreStartObject>().gameObject;
        _shadowLadderKeep.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Avatar"))
        {
          //  col.GetComponent<AvatarMovement>().MoveDirection = MoveDirection.None;
        }

        if (col.CompareTag("Placeable"))
        {
            _aLadder = col.GetComponent<Ladder>();
            if (!_objectPlaced)
            {
                _shadowLadderKeep.SetActive(true);
                _aLadder.placePoint = transform.position;
                _aLadder.validArea = true;
                _objectPlaced = true;
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
            _objectPlaced = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
       Debug.Log("On Drop");
    }
}
