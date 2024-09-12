using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public static List<PlayerCamera> cameras = new List<PlayerCamera>();

    private Action doAction;

    [SerializeField] private Transform target;

    [SerializeField] private float _TimeToLerp = .5f;

    public static float _CameraHeight = 60;

    private void Start()
    {
        cameras.Add(this);
        doAction = DoActionBetween;
    }

    private void Update()
    {
        if (doAction != null) doAction();
    }

    public void SetModeBetween()
    {
        StopAllCoroutines();
        StartCoroutine(LerpToBetween());
    }

    private IEnumerator LerpToBetween()
    {
        Vector3 basePos = transform.position;
        float _count = 0;

        while (_count < _TimeToLerp)
        {
            transform.position = Vector3.Lerp(basePos, CameraManager.GetInstance().GetMidPos(), _count / _TimeToLerp);
            _count += Time.deltaTime ;
            yield return null;
        }
        transform.position = CameraManager.GetInstance().GetMidPos();
        doAction = DoActionBetween;
    }

    private void DoActionBetween()
    {
        transform.position = CameraManager.GetInstance().GetMidPos();
    }

    public void SetModeFollow()
    {
        StopAllCoroutines();
        StartCoroutine(LerpToFollow());
    }

    private IEnumerator LerpToFollow()
    {
        Vector3 basePos = transform.position;
        float _count = 0;

        Vector3 camOffset;

        while (_count < _TimeToLerp)
        {
            camOffset = GetCamOffset();
            transform.position= Vector3.Lerp(basePos,
                                new Vector3(target.position.x + camOffset.x, _CameraHeight, target.position.z + camOffset.z),
                                _count / _TimeToLerp);
            _count += Time.deltaTime;
            yield return null;
        }
        doAction = DoActionFollow;

        camOffset = GetCamOffset();
        transform.position = new Vector3(target.position.x + camOffset.x, _CameraHeight, target.position.z + camOffset.z);
    }

    private void DoActionFollow()
    {
        Vector3 camOffset = GetCamOffset();
        transform.position = new Vector3(target.position.x + camOffset.x, _CameraHeight, target.position.z + camOffset.z);
    }

    private Vector3 GetCamOffset()
    {
        int factor = 1;
        if (target.GetComponent<Movement>().GetPlayerIndex() == 1) factor = -1;

        float frustumHeight = 2.0f * _CameraHeight * Mathf.Tan(GetComponent<Camera>().fieldOfView * 0.5f * Mathf.Deg2Rad);
        float frustumWidth = frustumHeight * GetComponent<Camera>().aspect;

        Vector3 aspect = new Vector3(frustumWidth,0 ,frustumHeight) / 4;

        Vector3 vecBtwPlys = CameraManager.GetInstance().GetVecBetweenPlayer().normalized;

        return new Vector3(vecBtwPlys.x * aspect.x, 0, vecBtwPlys.z * aspect.z) * factor;
    }

    private void OnDestroy()
    {
        cameras.Remove(this);
    }
}
