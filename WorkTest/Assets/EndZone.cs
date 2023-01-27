using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public Action OnAvatarEnter;
    private bool _groundMoving;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Avatar"))
        {
            if (_groundMoving) return;
            StartCoroutine(DelayMove());
        }
    }

    private IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(1);
        OnAvatarEnter?.Invoke();
        _groundMoving = true;
    }
}
