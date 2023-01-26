using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[ExecuteInEditMode]
public class AllLadderHolder : MonoBehaviour
{
    [SerializeField] private GameObject ladderHolder;
    [SerializeField, Range(0, 7)] private int numberLadders;
    [SerializeField, Range(0, 3)] private float gapDistance;
    private float _currentGapDistance;
    private int _currentLadders;
    [HideInInspector] private List<GameObject> _ladderList = new();

    private void UpdateLadders()
    {
        var prevLoc = Vector3.zero;
        if (numberLadders > _currentLadders)
        {
            for (int i = _currentLadders; i < numberLadders; i++)
            {
                prevLoc = _ladderList.Count > 0 ? 
                    _ladderList[^1].transform.position : transform.position;
                
                var temp = Instantiate(ladderHolder, 
                    prevLoc + new Vector3(0,-gapDistance,0), 
                    quaternion.identity, transform);
                _ladderList.Add(temp);
                _currentLadders++;
            }
        }
        else if (numberLadders < _currentLadders)
        {
            DestroyImmediate(_ladderList[^1].gameObject);
            _ladderList.RemoveAt(_ladderList.Count -1);
            _currentLadders--;
        }
        
    }

   
    void Update()
    {
        if (numberLadders != _currentLadders)
        {
            UpdateLadders();
        }

        if (gapDistance != _currentGapDistance)
        {
            
        }
    }
}
