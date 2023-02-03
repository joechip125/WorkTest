using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class ControllerUI : MonoBehaviour
{
    [SerializeField] private List<AvatarMovement> moveLevels  = new();
    [SerializeField] private AvatarMovement player;
    [SerializeField] int numberLevelChanges;
    [SerializeField] private DisplayText displayText;
    private int _changedLevels;
    [SerializeField] private Timer theTimer;
    
    private void Start()
    {
        player.ChangeLevels += MoveTheLevels;
    }

    private void OnDisable()
    {
        player.ChangeLevels -= MoveTheLevels;
    }

    private void EndLevel()
    {
        var finalTime = Mathf.Round((theTimer.TheTime) * 100f) / 100f;
        PlayerPrefs.SetFloat("FinalTime", finalTime);
        displayText.OnLevelComplete();
        
        StartCoroutine(DelayEnd());
    }

    private IEnumerator DelayEnd()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void MoveTheLevels()
    {
        if (_changedLevels >= numberLevelChanges)
        {
            EndLevel();
            return;
        }
        
        player.transform.parent = moveLevels[_changedLevels + 1].transform;

        foreach (var l in moveLevels)
        {
            l.movePoint = l.transform.position + new Vector3(-1300, 0, 0);
            l.MoveDirection = MoveDirection.ToPoint;
        }

        _changedLevels++;
    }
}
