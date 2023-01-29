using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WalkPoints : MonoBehaviour
{
    public List<Transform> points = new();
    private int _currentPoint;

    void Start()
    {
        _currentPoint = 0;
        points = GetComponentsInChildren<Transform>().ToList();
        Debug.Log(points.Count);
    }

    public bool GetNextPoint(out Vector3 thePoint)
    {
        thePoint = new Vector3();
        if (_currentPoint > points.Count - 1)
        {
            return false;
        }

        var parent = transform.parent.position;
        var add = points[_currentPoint].localPosition + parent;
        thePoint = transform.TransformPoint(points[_currentPoint].localPosition);
        Debug.Log(points[_currentPoint].localPosition);
        Debug.Log(points[_currentPoint].position);
        _currentPoint++;
        return true;
    }
    
}
