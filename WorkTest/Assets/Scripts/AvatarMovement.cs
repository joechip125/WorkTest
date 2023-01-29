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
    ToPoint,
    ToPoints
}

public class AvatarMovement : MonoBehaviour
{
    private bool _shouldMove;
    public float moveSpeed = 3.0f;
    public Vector3 movePoint;
    public Vector3 startPoint;
    private bool _arrivedAtPoint;
    private float _lerpTime = 0;
    public Action FinishedMoving;
    private WalkPoints _walkPoints;

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
        _walkPoints = FindObjectOfType<WalkPoints>();
    }

    private void NextPoint()
    {
        startPoint = transform.position;
        if (_walkPoints.GetNextPoint(out var point))
        {
            movePoint = point;
            _lerpTime = 0;
        }
        else
        {
            MoveDirection = MoveDirection.None;
        }
    }
    
    private void UpdateDirection()
    {
        if (_moveDirection == MoveDirection.None)
        {
            _shouldMove = false;
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

        _shouldMove = true;
    }
    
    private void Update()
    {
        if (_shouldMove && _moveDirection != MoveDirection.ToPoint)
        {
            transform.position += _currentDirection * (Time.deltaTime * moveSpeed);
        }

        if (_shouldMove && _moveDirection == MoveDirection.ToPoint && !_arrivedAtPoint)
        {
            transform.position = Vector3.MoveTowards(startPoint, movePoint, _lerpTime);
            _lerpTime += Time.deltaTime * moveSpeed;

            if (!(_lerpTime >= 0.99f)) return;
            
            _arrivedAtPoint = true;
            FinishedMoving?.Invoke();
        }
        
        if (_shouldMove && _moveDirection == MoveDirection.ToPoints)
        {
            transform.position = Vector3.MoveTowards(startPoint, movePoint, _lerpTime);
            _lerpTime += Time.deltaTime * moveSpeed;

            if (_lerpTime >= 0.99f)
            {
                NextPoint();
            }
        }
    }
}
