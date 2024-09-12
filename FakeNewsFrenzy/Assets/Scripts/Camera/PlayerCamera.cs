using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public static List<PlayerCamera> cameras = new List<PlayerCamera>();

    private Action doAction;

    [SerializeField] private Transform target;

    [SerializeField] private float _TimeToLerp = .5f;

    public static float _CameraHeight = 60;

    private Vector3 _NextPos;

    public WeaponHandler AR;
    public WeaponHandler shotGun;
    public WeaponHandler pistol;

    private void Start()
    {
        cameras.Add(this);
        doAction = DoActionBetween;
        Grenade.explode += StartShakeCam;
        AR.shoot += StartShakeCamWeapon;
        shotGun.shoot += StartShakeCamWeapon;
        pistol.shoot += StartShakeCamWeapon;
    }

    private void Update()
    {
        _NextPos = transform.position;
        if (doAction != null) doAction();
    }

    private void LateUpdate()
    {
        transform.position = _NextPos;
    }

    public void StartShakeCamWeapon(float power)
    {
        //StartShakeCam(0.001f, 0.005f);
    }

    public void StartShakeCam()
    {
        StartShakeCam(2, 1);
    }
    public void StartShakeCam(float _MaxShakeStrengh = 2, float _ShakeTime = 1)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeCam(2,1));
    }

    private IEnumerator ShakeCam(float _MaxShakeStrengh, float _ShakeTime )
    {
        float _Count = 0;
        float _currentShakeStrengh = 0;

        while (_Count <= _ShakeTime)
        {
            _Count += Time.deltaTime;
            _currentShakeStrengh = Mathf.Lerp(_MaxShakeStrengh, 0, _Count/_ShakeTime);
            Vector2 shake = new Vector2(UnityEngine.Random.Range(-_currentShakeStrengh, _currentShakeStrengh), UnityEngine.Random.Range(-_currentShakeStrengh, _currentShakeStrengh));
            _NextPos += new Vector3(shake.x, 0, shake.y);
            yield return null;
        }
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
            _NextPos = Vector3.Lerp(basePos, CameraManager.GetInstance().GetMidPos(), _count / _TimeToLerp);
            _count += Time.deltaTime ;
            yield return null;
        }
        _NextPos = CameraManager.GetInstance().GetMidPos();
        doAction = DoActionBetween;
    }

    private void DoActionBetween()
    {
        _NextPos = CameraManager.GetInstance().GetMidPos();
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
            _NextPos = Vector3.Lerp(basePos,
                                new Vector3(target.position.x + camOffset.x, _CameraHeight, target.position.z + camOffset.z),
                                _count / _TimeToLerp);
            _count += Time.deltaTime;
            yield return null;
        }
        doAction = DoActionFollow;

        camOffset = GetCamOffset();
        _NextPos = new Vector3(target.position.x + camOffset.x, _CameraHeight, target.position.z + camOffset.z);
    }

    private void DoActionFollow()
    {
        Vector3 camOffset = GetCamOffset();
        _NextPos = new Vector3(target.position.x + camOffset.x, _CameraHeight, target.position.z + camOffset.z);
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
