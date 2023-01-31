using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private new GameObject transformObject;
    [SerializeField, Range(0, 12)] private int numberNodes;
    [SerializeField] private List<GameObject> points = new();
    
    public int NumberPoints => points.Count;

    void Start()
    {
        points = points
           .OrderBy(x => 
               Vector3.Distance(transform.position, x.transform.position)).ToList();
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
        if (Application.isPlaying) return;
        
        if (points.Count != numberNodes)
        {
            UpdateNodes();
        }
        
        for (int i = 0; i < points.Count; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(points[i].transform.position, 10f);

            if (i > 0 )
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(points[i - 1].transform.position, points[i].transform.position);
            }
        }
    }

    public Vector3 GetPointAtIndex(int index)
    {
        var local =points[index].transform.localPosition;
        var something = transform.position + local;
        
        return something;
    }
}
