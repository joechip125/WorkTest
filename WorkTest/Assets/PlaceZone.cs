using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceZone : MonoBehaviour
{
    public GameObject shadowLadderProto;
    private GameObject _shadowLadderKeep;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Placeable"))
        {
            other.gameObject.GetComponent<Ladder>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Placeable"))
        {
            other.GameObject();
        }
    }

   
}
