using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowUI : MonoBehaviour, IPointerClickHandler
{
    private AudioSource _error;
    
    void Start()
    {
        _error = GetComponent<AudioSource>();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
       // _error.Play();
    }
}
