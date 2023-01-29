using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interact_Arrow : MonoBehaviour
{
    private bool _startedMovement;
    public AvatarMovement moveObject;
    private List<Ladder> _ladders = new();
    private AudioSource _error;

    private void Awake()
    {
        _error = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (_startedMovement) return;
        
        if (_ladders.Count < 1) _ladders = transform.parent
                .GetComponentsInChildren<Ladder>().ToList();
        
        if (_ladders.Any(x => !x.HasPlaced)) _error.Play();
        
        else
        {
            _startedMovement = true;
            moveObject.MoveDirection = MoveDirection.ToPoints;
        }
    }
}
