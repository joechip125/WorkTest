using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WalkPoints : MonoBehaviour
{
    public List<Transform> points;
    private int _currentPoint;

    void Start()
    {
        points = GetComponentsInChildren<Transform>().ToList();
    }

    public bool GetNextPoint(out Transform thePoint)
    {
        thePoint = transform;
        if (_currentPoint > points.Count - 1)
        {
            return false;
        }
        thePoint = points[_currentPoint];
        _currentPoint++;
        return true;
    }
    
}
