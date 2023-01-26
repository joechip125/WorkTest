using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]private List<AvatarMovement> moveObjects = new();
    [SerializeField] private List<PlaceZone> placedLadders = new();
    
    public Action OnMove; 

    void Start()
    {
        OnMove += MoveGround;
        foreach (var p in placedLadders)
        {
            
        }
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
