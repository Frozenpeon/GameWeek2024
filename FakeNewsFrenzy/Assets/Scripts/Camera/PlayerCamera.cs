using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public static List<PlayerCamera> cameras = new List<PlayerCamera>();

    private Action doAction;

    [SerializeField] private Transform target;

    private void Start()
    {
        cameras.Add(this);
    }

    private void Update()
    {
        if (doAction != null) doAction();
    }

    public void SetModeBetween()
    {
        doAction = DoActionBetween;
    }

    private void DoActionBetween()
    {
        transform.position = CameraManager.GetInstance().GetMidPos();
    }

    public void SetModeFollow()
    {
        doAction = DoActionFollow;
    }

    private void DoActionFollow()
    {
        int factor = 1;
        if(target.GetComponent<Movement>().GetPlayerIndex() == 1) factor = -1;

        Vector2 camOffset = new Vector2(CameraManager.GetInstance().GetVecBetweenPlayer().x, CameraManager.GetInstance().GetVecBetweenPlayer().z).normalized * 5;
        transform.position = new Vector3(target.position.x + camOffset.x * factor, 20, target.position.z + camOffset.y * factor);
    }

    private void OnDestroy()
    {
        cameras.Remove(this);
    }
}
