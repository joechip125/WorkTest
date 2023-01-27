using System;
using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;

public class WalkPath : MonoBehaviour
{
    private GameObject generated;
    private Spline spline;
    private float rate = 0;

    public GameObject Follower;
    public float DurationInSecond;
    public bool moveOnPath;
    public bool finishedWalking;
    [SerializeField] private float finishPoint;

    private void OnEnable()
    {
        spline = GetComponent<Spline>(); 
        
        rate = 0;
    }

    void EditorUpdate() 
    {
        rate += Time.deltaTime / DurationInSecond;
        if (rate > spline.nodes.Count - 1) 
        {
            rate -= spline.nodes.Count - 1;
        }
        PlaceFollower();
    }

    private void PlaceFollower()
    {
        Debug.Log(rate);
        CurveSample sample = spline.GetSample(rate);
        var worldPos = transform.TransformPoint(sample.location);
        Follower.transform.position = new Vector3(worldPos.x, worldPos.y, -1);
        finishedWalking = rate > finishPoint;
    }
    
   

    // Update is called once per frame
    void Update()
    {
        if(moveOnPath && !finishedWalking) EditorUpdate();
    }
}
