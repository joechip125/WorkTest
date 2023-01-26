using System;
using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;

public class SplineReader : MonoBehaviour
{
    private Spline _spline;
    private void Awake()
    {
        _spline = GetComponentInChildren<Spline>();
      
        var counter = 0.0f;
        for (int i = 0; i < 10; i++)
        {

            var sample = _spline.GetSampleAtDistance(counter);
            Debug.Log(_spline.Length);
            counter += 0.01f;
        }
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
