using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerUI : MonoBehaviour
{
    [SerializeField] private List<AvatarMovement> moveLevels  = new();
    [SerializeField] private AvatarMovement player;


    private void Start()
    {
        player.ChangeLevels += MoveTheLevels;
    }

    private void OnDisable()
    {
        player.ChangeLevels -= MoveTheLevels;
    }

    private void MoveTheLevels()
    {
        player.transform.parent = moveLevels[1].transform;

        foreach (var l in moveLevels)
        {
            l.movePoint = l.transform.position + new Vector3(-1300, 0, 0);
            l.MoveDirection = MoveDirection.ToPoint;
        }
    }
}
