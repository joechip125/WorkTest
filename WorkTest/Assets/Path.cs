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
    [HideInInspector]private int _currentPoint;

    public int NumberPoints => points.Count;

    void Start()
    {
        _currentPoint = 0;

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
        return points[index].transform.localPosition;
    }

    public bool GetNextPoint(out Vector3 thePoint)
    {
        thePoint = transform.position;
        if (_currentPoint > points.Count - 1)
        {
            return false;
        }

        var parent = transform;
        thePoint = points[_currentPoint].transform.localPosition + transform.position;
        
        _currentPoint++;
        return true;
    }
}
