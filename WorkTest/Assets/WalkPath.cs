using System;
using System.Collections;
using System.Collections.Generic;
using SplineMesh;
using UnityEngine;

public class WalkPath : MonoBehaviour
{
    private Spline _spline;
    private float _rate = 0;

    private GameObject _avatar;
    public float durationInSecond;
    public bool moveOnPath;
    public bool finishedWalking;

    private void OnEnable()
    {
        _spline = GetComponent<Spline>();
        _rate = 0;
    }

    private void Start()
    {
       _avatar = FindObjectOfType<AvatarMovement>().gameObject;
    }

    void PathUpdate() 
    {
        _rate += Time.deltaTime / durationInSecond;
        if (_rate > _spline.nodes.Count - 1)
        {
            finishedWalking = true;
        }
        PlaceFollower();
    }

    private void PlaceFollower()
    {
        CurveSample sample = _spline.GetSample(_rate);
        var worldPos = transform.TransformPoint(sample.location);
        _avatar.transform.position = new Vector3(worldPos.x, worldPos.y, -1);
    }
  
    void Update()
    {
        if(moveOnPath && !finishedWalking) PathUpdate();
    }
}
