using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]private List<AvatarMovement> moveObjects = new();
    [SerializeField] private List<PlaceZone> placedLadders = new();
    [SerializeField] private Interact_Arrow arrow;

    public Action OnMove;
    private int _numberPlaced;

    void Start()
    {
        OnMove += MoveGround;
        foreach (var p in placedLadders)
        {
            p.PlaceCallback += LadderCount;
        }
    }

    private void OnApplicationQuit()
    {
        foreach (var p in placedLadders)
        {
            p.PlaceCallback -= LadderCount;
        }
    }

    private void LadderCount(int plusOrMinus)
    {
        _numberPlaced += plusOrMinus;
        Debug.Log(_numberPlaced);

        arrow.laddersPlaced = _numberPlaced == placedLadders.Count;
    }
    
    private void OnDisable()
    {
        OnMove -= MoveGround;
    }

    public void MoveGround()
    {
        for (int i = 0; i < moveObjects.Count; i++)
        {
            var temp = moveObjects[i];
            temp.movePoint = temp.startPoint - new Vector3(12.5f, 0, 0);
            temp.MoveDirection = MoveDirection.ToPoint;
            temp.shouldMove = true;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
