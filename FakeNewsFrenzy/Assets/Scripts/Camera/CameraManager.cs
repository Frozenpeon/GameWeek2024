using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform firstPlayer;
    [SerializeField] private Transform secondPlayer;

    [SerializeField] private Transform firstCam;
    [SerializeField] private Transform secondCam;

    [SerializeField] private Material _CamMat;

    private Action doAction;

    private float CamSpeed;

    private static CameraManager instance;

    private Vector2 splitDistance;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    void Start()
    {
        doAction = DoActionBetween;
        _CamMat.SetFloat("_CameraSplit", 0);

        float frustumHeight = 2.0f * PlayerCamera._CameraHeight * Mathf.Tan(GetComponent<Camera>().fieldOfView * 0.5f * Mathf.Deg2Rad);
        float frustumWidth = frustumHeight * GetComponent<Camera>().aspect;
        splitDistance = new Vector2(frustumWidth, frustumHeight) / 2f;
    }

    public static CameraManager GetInstance()
    {
        if (instance != null) return instance;
        return new CameraManager();
    }

    void Update()
    {
        Vector2 vecBetweenPlayers = new Vector2(secondPlayer.position.x, secondPlayer.position.z) - new Vector2(firstPlayer.position.x, firstPlayer.position.z);
        _CamMat.SetVector("_VectorDir", vecBetweenPlayers.normalized);

        if (doAction != null) doAction();
    }

    public Vector3 GetMidPos()
    {
        Vector3 distBetweenPlayers = secondPlayer.position - firstPlayer.position;
        Vector3 midPos = firstPlayer.position + distBetweenPlayers / 2f;
        midPos.y = PlayerCamera._CameraHeight;

        return midPos;
    }

    public Vector3 GetVecBetweenPlayer()
    {
        return secondPlayer.position - firstPlayer.position;
    }

    private void SetModeBetween()
    {
        foreach (PlayerCamera pCam in PlayerCamera.cameras) pCam.SetModeBetween();
        doAction = DoActionBetween;
        _CamMat.SetFloat("_CameraSplit", 0);

    }

    private void DoActionBetween()
    {
        Vector3 midPos = GetMidPos();
        midPos.y = Movement.movements[0].transform.position.y;
        if (!IsPointInsideEllipse(Movement.movements[0].transform.position, midPos) ) SetModeFollowPlayer();
    }
    
    private void SetModeFollowPlayer()
    {
        foreach (PlayerCamera pCam in PlayerCamera.cameras) pCam.SetModeFollow();
        doAction = DoActionFollowPlayer;
        _CamMat.SetFloat("_CameraSplit", 1);
    }

    private void DoActionFollowPlayer()
    {
        Vector3 midPos = GetMidPos();
        midPos.y = Movement.movements[0].transform.position.y;
        if (IsPointInsideEllipse(Movement.movements[0].transform.position, midPos) ) SetModeBetween();
    }

    private void OnDestroy()
    {
        if(instance == this) instance = null;
    }

    private bool IsPointInsideEllipse(Vector3 pos, Vector3 centerPos)
    {
        float a = splitDistance.x /2f;
        float b = splitDistance.y  / 2f;
        float dx = pos.x - centerPos.x;
        float dy = pos.z - centerPos.z;

        return (dx * dx) / (a * a) + (dy * dy) / (b * b) <= 1;
    }
}
