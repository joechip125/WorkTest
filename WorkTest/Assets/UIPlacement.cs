using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlacement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, new Vector3(50,50,50));
    }
}
