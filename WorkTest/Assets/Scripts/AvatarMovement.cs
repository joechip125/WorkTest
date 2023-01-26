using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection
{
    None,
    Forward,
    Back,
    Up,
    Down
}

public class AvatarMovement : MonoBehaviour
{
    public bool shouldMove;
    public float moveSpeed = 3.0f;

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
        if (shouldMove)
        {
            transform.position += _currentDirection * (Time.deltaTime * moveSpeed);
        }
    }
}
