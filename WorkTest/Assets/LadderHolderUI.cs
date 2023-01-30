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
       var temp = Instantiate(ladderProto, transform.position, Quaternion.identity);
       Debug.Log(_tilePositions[0].anchoredPosition);
    }
}
