using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interact_Arrow : MonoBehaviour
{
    private bool _startedMovement;
    public bool laddersPlaced;

    public AvatarMovement moveObject;
    [SerializeField] private WalkPath path;
    private AudioSource _error;

    private void Awake()
    {
        _error = GetComponent<AudioSource>();
        
    }

    private void OnMouseDown()
    {
        if (!_startedMovement && laddersPlaced)
        {
            _startedMovement = true;
            path.moveOnPath = true;
        }
        else if(!_startedMovement && !laddersPlaced)
        {
            _error.Play();
        }
    }
    
}
