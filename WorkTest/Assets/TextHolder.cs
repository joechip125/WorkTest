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

    public void UpdateRankings(List<PlayerData> data)
    {
        for (int i = 0; i < _texts.Count; i++)
        {
            if (data.Count > i)
            {
                _texts[i].text = $"{data[i].playerName}: {data[i].playerScore}";
            }
        }
    }

    void Update()
    {
        
    }
}
