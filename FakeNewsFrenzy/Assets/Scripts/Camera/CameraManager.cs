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
        SetModeBetween();
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
        midPos.y = 20;

        return midPos;
    }

    public Vector3 GetVecBetweenPlayer()
    {
        return secondPlayer.position - firstPlayer.position;
    }

    public float GetDistBetweenPlayers()
    {
        Vector3 distBetweenPlayers = secondPlayer.position - firstPlayer.position;
        return distBetweenPlayers.magnitude;
    }

    private void SetModeBetween()
    {
        foreach (PlayerCamera pCam in PlayerCamera.cameras) pCam.SetModeBetween();
        doAction = DoActionBetween;
    }

    private void DoActionBetween()
    {
        if (GetDistBetweenPlayers() > 10) SetModeFollowPlayer();
    }
    
    private void SetModeFollowPlayer()
    {
        foreach (PlayerCamera pCam in PlayerCamera.cameras) pCam.SetModeFollow();
        doAction = DoActionFollowPlayer;
    }

    private void DoActionFollowPlayer()
    {
        if (GetDistBetweenPlayers() < 10) SetModeBetween();
    }

    private void OnDestroy()
    {
        if(instance == this) instance = null;
    }
}
