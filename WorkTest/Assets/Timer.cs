using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _time;
    private TextMeshProUGUI _text;

    public float TheTime => _time;
    
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }


    private void Start()
    {
    //    Debug.Log(Application.persistentDataPath);
    }

    private void UpdateTime()
    {
        //_time = Mathf.Round((_time) * 100f) / 100f;
        _text.text = $"{Mathf.Round((_time) * 100f) / 100f}";
    }
    
    void Update()
    {
        _time += Time.deltaTime;
        UpdateTime();
    }
}
