using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveZone : MonoBehaviour
{
    [SerializeField] private float _TimeToRevive = 2f;
    private float _Count = 0;
    private float _lastCount = 0;
    [SerializeField] private Transform myPlayer;

    private Action doAction;

    private void Start()
    {
        SetModeUnRevive();
    }

    private void Update()
    {
        if (GetComponent<Collider>().enabled)
        {
            transform.position = myPlayer.position;
        }

        if (doAction != null) doAction();
    }

    public void SetModeRevive()
    {
        doAction = DoActionRevive;
    }

    private void DoActionRevive()
    {
        _Count += Time.deltaTime;
        if (_Count >= _TimeToRevive)
        {
            myPlayer.GetComponent<PlayerLife>().Revive();
            SetModeUnRevive();
        }
    }

    public void SetModeUnRevive()
    {
        doAction = DoActionUnRevive;
    }

    public void DoActionUnRevive()
    {
        _Count -= Time.deltaTime;
        if (_Count < 0) _Count = 0;
    }

}
