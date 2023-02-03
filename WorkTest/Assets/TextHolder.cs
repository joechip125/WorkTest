using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TextHolder : MonoBehaviour
{
    private List<TextMeshProUGUI> _texts = new();
    void Start()
    {
        _texts = GetComponentsInChildren<TextMeshProUGUI>().ToList();
    }

    void Update()
    {
        
    }
}
