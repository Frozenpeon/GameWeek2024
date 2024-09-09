using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _Speed = 10;
    [SerializeField] private float _RollDistance = 2;
    [SerializeField] private float _RollSpeed = 2;
    private Action doAction;

    private void Start()
    {
        SetModeMove();
    }

    private void Update()
    {
        if (doAction != null) doAction();

    }

    private void SetModeVoid()
    {
        doAction = DoActionVoid;
    }

    private void DoActionVoid()
    {

    }

    private void SetModeMove()
    {
        doAction = DoActionMove;
    }

    private void DoActionMove()
    {
        transform.position += Input.GetAxisRaw("Horizontal") * Vector3.right * Time.deltaTime * _Speed;
        transform.position += Input.GetAxisRaw("Vertical") * Vector3.up * Time.deltaTime * _Speed;
        if (Input.GetKeyDown(KeyCode.Space)) SetModeRoll();
    }

    private void SetModeRoll()
    {
        Vector3 lDir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        lDir = lDir.normalized;

        IEnumerator corountine = DoActionRoll(lDir);
        SetModeVoid();
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

        SetModeMove();
    }
}
