using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class DataManager : MonoBehaviour
{
    private float _lastTime;
    private string _path;
    private MultiData _allData;

    private void Awake()
    {
        _lastTime = PlayerPrefs.GetFloat("FinalTime");
        //_path = Application.persistentDataPath + "/gameData.json";
        _path = Application.persistentDataPath + "/testData.json";
        LoadData();
        
    }

    private void LoadData()
    {
        if (File.Exists(_path))
        {
            var fileContents = File.ReadAllBytes(_path);
            string result = Encoding.Default.GetString(fileContents);
            var data = JsonUtility.FromJson<MultiData>(result);
        }
        else
        {
            
        }
    }

    public void SaveData()
    {
       _allData.playerData.Add(new PlayerData("berk", 15));
       var data = JsonUtility.ToJson(_allData);
       var bytes  = Encoding.Default.GetBytes(data);
       File.WriteAllBytes(_path, bytes);
    }
    
}
