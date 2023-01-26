using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Unity.Mathematics;
using UnityEngine;

[ExecuteInEditMode]
public class AllLadderHolder : MonoBehaviour
{
    [SerializeField] private GameObject ladderHolder;
    [SerializeField, Range(0, 7)] private int numberLadders;
    [SerializeField, Range(0, 3)] private float gapDistance;
    private float _currentGapDistance;
    [SerializeField]private int currentLadders;
    [HideInInspector] private List<GameObject> _ladderList = new();

    private void UpdateLadders()
    {
        if (Application.isPlaying) return;
        
        var prevLoc = Vector3.zero;
        if (numberLadders > currentLadders)
        {
            prevLoc = _ladderList.Count > 0 ? 
                _ladderList[^1].transform.position : transform.position;
                
            var temp = Instantiate(ladderHolder, 
                prevLoc + new Vector3(0,-gapDistance,0), 
                quaternion.identity, transform);
            _ladderList.Add(temp);
            currentLadders++;
        }
        else if (numberLadders < currentLadders)
        {
            DestroyImmediate(_ladderList[^1].gameObject);
            _ladderList.RemoveAt(_ladderList.Count -1);
            currentLadders--;
        }

        currentLadders = numberLadders;
    }

   
    void Update()
    {
        if (numberLadders != currentLadders && Application.isEditor)
        {
            UpdateLadders();
        }
    }
}
