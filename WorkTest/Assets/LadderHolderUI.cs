using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class LadderHolderUI : MonoBehaviour
{
    [HideInInspector] private List<RectTransform> _tilePositions;
    [SerializeField] [CanBeNull] private GameObject ladderProto;
    
    void Start()
    {
       _tilePositions = GetComponentsInChildren<RectTransform>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
