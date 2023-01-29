using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowUI : MonoBehaviour, IPointerClickHandler
{
    private AudioSource _error;
    private List<PlaceZoneUI> _placeZones = new();

    void Start()
    {
        _error = GetComponent<AudioSource>();
        _placeZones = FindObjectsOfType<PlaceZoneUI>().ToList();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_placeZones.Any(x => x.CanPlace))
        {
            _error.Play();
        }
        else
        {
            
        }
    }
}
