using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMovement : MonoBehaviour
{
    public bool shouldMove;
    public float moveSpeed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            transform.position += transform.right * (Time.deltaTime * moveSpeed);
        }
    }
}
