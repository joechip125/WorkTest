using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceZone : MonoBehaviour
{
    public GameObject shadowLadderProto;
    private GameObject _shadowLadderKeep;
    private bool _objectPlaced;
    public Action<int> PlaceCallback;
    

    private void Awake()
    {
        _shadowLadderKeep = Instantiate(shadowLadderProto, transform.position, quaternion.identity);
        _shadowLadderKeep.SetActive(false);
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Placeable") && !_objectPlaced)
        {
            _shadowLadderKeep.SetActive(true);
            col.gameObject.GetComponent<Ladder>().TargetHit(transform.position, () =>
            {
                _shadowLadderKeep.SetActive(false);
            });
            _objectPlaced = true;
            PlaceCallback?.Invoke(1);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Placeable"))
        {
            _shadowLadderKeep.SetActive(false);
            other.gameObject.GetComponent<Ladder>().TargetLost();
            _objectPlaced = false;
            PlaceCallback?.Invoke(-1);
        }
    }
}
