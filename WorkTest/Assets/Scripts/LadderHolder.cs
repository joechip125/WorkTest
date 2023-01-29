using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LadderHolder : MonoBehaviour
{
    [SerializeField] private GameObject displayLadder;

    private void Awake()
    {
        var temp = Instantiate(displayLadder, 
            transform.position + new Vector3(0, 0, -0.01f), 
            quaternion.identity, transform);
        temp.transform.localScale = new Vector3(0.4f, 0.4f);
    }
}
