using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public Action OnAvatarEnter;
    private bool _groundMoving;
    private Transform _theParent;
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Avatar"))
        {
            Debug.Log("arrived");
            col.GetComponent<AvatarMovement>().MoveDirection = MoveDirection.None;
            if (_groundMoving) return;
            StartCoroutine(DelayMove());
        }
    }

    private IEnumerator DelayMove()
    {
        yield return new WaitForSeconds(0.4f);
        OnAvatarEnter?.Invoke();
        _groundMoving = true;
    }
}
