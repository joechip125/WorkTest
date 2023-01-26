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
    public Action<Guid, bool> PlaceCallback;
    public Guid Guid;


    private void Awake()
    {
        _shadowLadderKeep = Instantiate(shadowLadderProto, transform.position, quaternion.identity);
        _shadowLadderKeep.SetActive(false);
    }


    public Transform ZoneChange(bool comeOrGo)
    {
        _shadowLadderKeep.SetActive(comeOrGo);
        _objectPlaced = comeOrGo;
        PlaceCallback?.Invoke(Guid, comeOrGo);
        return transform;
    }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        //if (col.CompareTag("Placeable") && !_objectPlaced)
        //{
        //    col.transform.parent = transform;
        //    _shadowLadderKeep.SetActive(true);
        //    col.gameObject.GetComponent<Ladder>().TargetHit(transform.position, () =>
        //    {
        //        _shadowLadderKeep.SetActive(false);
        //    });
        //    _objectPlaced = true;
        //    PlaceCallback?.Invoke(Guid, true);
        //}
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.CompareTag("Placeable"))
        //{
        //    _shadowLadderKeep.SetActive(false);
        //    other.gameObject.GetComponent<Ladder>().TargetLost();
        //    _objectPlaced = false;
        //    PlaceCallback?.Invoke(Guid, false);
        //}
    }
}
