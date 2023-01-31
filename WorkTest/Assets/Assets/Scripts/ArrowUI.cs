using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowUI : MonoBehaviour, IPointerClickHandler
{
    private AudioSource _error;
    private List<PlaceZoneUI> _placeZones = new();
    [SerializeField] private AvatarMovement avatarMovement;
    private bool _startedWalk;

    void Start()
    {
        _error = GetComponent<AudioSource>();
        _placeZones = transform.parent.GetComponentsInChildren<PlaceZoneUI>().ToList();
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_startedWalk) return;
        if (_placeZones.Any(x => x.CanPlace))
        {
            _error.Play();
        }
        else
        {
            avatarMovement.MoveDirection = MoveDirection.ToPoints;
            _startedWalk = true;
        }
    }
}
