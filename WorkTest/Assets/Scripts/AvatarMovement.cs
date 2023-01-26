using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public enum MoveDirection
{
    None,
    Forward,
    Back,
    Up,
    Down,
    ToPoint
}

public class AvatarMovement : MonoBehaviour
{
    public bool shouldMove;
    public float moveSpeed = 3.0f;
    public Vector3 movePoint;
    public Vector3 startPoint;
    private bool _arrivedAtPoint;
    private float _lerpTime = 0;

    public MoveDirection MoveDirection
    {
        get => _moveDirection;
        set
        {
            _moveDirection = value;
            UpdateDirection();
        }
    }
    private MoveDirection _moveDirection;
    private Vector3 _currentDirection;

    private void Awake()
    {
        startPoint = transform.position;
    }

    private void UpdateDirection()
    {
        if (_moveDirection == MoveDirection.None)
        {
            shouldMove = false;
            return;
        }
        switch (_moveDirection)
        {
            case MoveDirection.Forward:
                _currentDirection = transform.right;
                break;
            case MoveDirection.Back:
                _currentDirection = -transform.right;
                break;
            case MoveDirection.Up:
                _currentDirection = transform.up;
                break;
            case MoveDirection.Down:
                _currentDirection = -transform.up;
                break;
        }

        shouldMove = true;
    }
    
    void Update()
    {
        if (shouldMove && _moveDirection != MoveDirection.ToPoint)
        {
            transform.position += _currentDirection * (Time.deltaTime * moveSpeed);
        }

        if (shouldMove && _moveDirection == MoveDirection.ToPoint && !_arrivedAtPoint)
        {
            transform.position = Vector3.Lerp(startPoint, movePoint, _lerpTime);
            _lerpTime += Time.deltaTime * moveSpeed;
        }
    }
}
