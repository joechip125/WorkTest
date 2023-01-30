using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlacement : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, new Vector3(50,50,50));
    }
}
