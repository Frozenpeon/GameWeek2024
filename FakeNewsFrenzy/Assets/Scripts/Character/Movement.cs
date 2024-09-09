using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _Speed = 10;
    [SerializeField] private float _RollDistance = 2;
    [SerializeField] private float _RollSpeed = 2;

    [SerializeField] private int _PlayerIndex = 0;

    private bool isRolling = false;

    private Vector3 _Dir= Vector2.zero;

    public int GetPlayerIndex()
    {
        return _PlayerIndex;
    } 

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (isRolling) return;
        transform.position += _Dir * Time.deltaTime * _Speed;
    }

    public void SetDirVector(Vector3 lDir)
    {
        _Dir = lDir;
    }

    public void SetRoll()
    {
        isRolling = true;

        IEnumerator corountine = DoActionRoll(_Dir.normalized);
        StartCoroutine(corountine);
    }

    IEnumerator DoActionRoll(Vector3 pDir)
    {
        float lCountDistance = 0;
        while(lCountDistance < _RollDistance)
        {
            float lSpeed = _RollSpeed * Time.deltaTime;
            lCountDistance += lSpeed;
            transform.position += pDir * lSpeed;
            yield return null;
        }

        isRolling = false;
    }
}
