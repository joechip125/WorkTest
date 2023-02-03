using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class DataManager : MonoBehaviour
{
    private float _lastTime;
    private string _path;
    private List<PlayerData> _allData = new();
    [SerializeField] TextHolder textHolder;


    private void Awake()
    {
        _lastTime = PlayerPrefs.GetFloat("FinalTime");
        _path = Application.persistentDataPath + "/gameData.json";
        //_path = Application.persistentDataPath + "/testData.json";
        LoadData();
        
    }

    private void CheckList()
    {
        if (_allData.Count > 9)
        {
            if (_allData.Any(x => x.playerScore > _lastTime))
            {
                
            }
        }
    }

    public void LoadData()
    {
        if (File.Exists(_path))
        {
            var fileContents = File.ReadAllBytes(_path);
            string result = Encoding.Default.GetString(fileContents);
            var data = JsonUtility.FromJson<MultiData>(result);
            _allData = data.playerData;
            textHolder.UpdateRankings(_allData);
        }
        else
        {
            
        }
    }

    public void SaveData()
    {
       _allData.Add(new PlayerData("berk", 15));
       var allDat = new MultiData()
       {
           playerData = _allData
       };
       var data = JsonUtility.ToJson(allDat);
       var bytes = Encoding.Default.GetBytes(data);
       File.WriteAllBytes(_path, bytes);
    }
    
}
