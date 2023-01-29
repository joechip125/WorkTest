using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private new GameObject transformObject;
    [SerializeField, Range(0, 12)] private int numberNodes;
    [SerializeField] private List<GameObject> points = new();
    [HideInInspector]private int _currentNodes;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateNodes()
    {
        if (numberNodes > points.Count)
        {
            var trans = Instantiate(transformObject, transform.position, 
                quaternion.identity, transform);
             points.Add(trans);
        }
        else if (numberNodes < points.Count)
        {
            if (points.Count > 0)
            {
                DestroyImmediate(points[^1]);
                points.RemoveAt(points.Count - 1);
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        if (points.Count != numberNodes)
        {
            UpdateNodes();
        }
        
        for (int i = 0; i < points.Count; i++)
        {
            Gizmos.color = Color.red;
           // Gizmos.DrawSphere(points[i], 0.1f);

            if (i > 0 )
            {
                Gizmos.color = Color.green;
             //   Gizmos.DrawLine(points[i - 1], points[i]);
            }
        }
    }
}
