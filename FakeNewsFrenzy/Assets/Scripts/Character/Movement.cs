using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _Speed = 50;
    [SerializeField] private float _RollDistance = 2;
    [SerializeField] private float _RollSpeed = 2;

    [SerializeField] public int _PlayerIndex = 0;

    private bool isRolling = false;

    private Vector3 _Dir= Vector2.zero;
    [HideInInspector] public bool canMoveWithMouse = false;
    public bool isBeingPushed = false;

    [SerializeField] private Camera _Cam;

    private Rigidbody rb;
    public int GrenadeCount = 0;
    public int maxGrenades = 1;

    public static List<Movement> movements = new List<Movement>();

    [SerializeField] private float footStepFrequency = .2f;
    private float _countFootStep;

    public WeaponSwapper WeaponSwapper;

    public GenadeLauncher grenadeLauncher;

    public SpriteChanger spriteChanger;

    [SerializeField] private EventReference footStep;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        movements.Add(this);
        if (_PlayerIndex == 0)
            EquipWeapon.Player1GotaNade += AddANade;
        else
            EquipWeapon.Player2GotaNade += AddANade;

        ChangeWeapon(WeaponSelectionManager.weapons[_PlayerIndex]);
    }

    public void AddANade()
    {
        if (GrenadeCount + 1 > maxGrenades)
        {
            return;
        }
        GrenadeCount++;
    }
    public int GetPlayerIndex()
    {
        return _PlayerIndex;
    } 

    private void Update()
    {
        Move();
    }

    public void ThrowANade()
    {
       grenadeLauncher.ThrowAGrenade();
    }

    public void ChangeWeapon(WeaponType weapon)
    {
        if (WeaponSwapper == null)
        {
            Debug.Log("Y'a pas de swapper");
            return;
        }
        WeaponSwapper.ChangeAWeapon(weapon);
    }

    private void Move()
    {
        if (isRolling || isBeingPushed) return;
        rb.velocity = _Dir * _Speed;
        if (!canMoveWithMouse) return;
        Ray ray = _Cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            Vector3 hitPoint = hitInfo.point;
            transform.LookAt(new Vector3(hitPoint.x, transform.position.y,hitPoint.z));;
        }
        _countFootStep += Time.deltaTime;
        if (rb.velocity.magnitude < .1f) return;
        if (_countFootStep > footStepFrequency)
        {
            _countFootStep = 0;
            GetComponent<SoundEmmiter>().PlaySound(footStep); 
        }
    }

    public void MakePlayerLookAt(Vector2 _Dir)
    {
        if (isRolling || GetComponent<PlayerLife>().GetLifePoint() <= 0) return;

        transform.LookAt(new Vector3(transform.position.x + _Dir.x, transform.position.y, transform.position.z + _Dir.y ));
    }

    public void SetDirVector(Vector3 lDir)
    {
        _Dir = lDir;
    }

    public void SetRoll()
    {
        if(isBeingPushed || GetComponent<PlayerLife>().GetLifePoint() <= 0) return;
        isRolling = true;

        IEnumerator corountine = DoActionRoll(_Dir.normalized);
        StartCoroutine(corountine);
    }

    public void StartPush()
    {
        isBeingPushed = true;
        if (!GetComponent<PlayerLife>().dead)
            spriteChanger.ShowStun();
        StartCoroutine(WaitToBePush());
    }

    IEnumerator WaitToBePush()
    {
        yield return new WaitForSeconds(1.2f);
        if (!GetComponent<PlayerLife>().dead)
            spriteChanger.ShowWeapon();
        isBeingPushed = false;
    }

    IEnumerator DoActionRoll(Vector3 pDir)
    {
        float lCountDistance = 0;
        while(lCountDistance < _RollDistance)
        {
            float lSpeed = _RollSpeed;
            lCountDistance += lSpeed * Time.deltaTime;
            rb.velocity = pDir * lSpeed;
            yield return null;
        }

        isRolling = false;
    }

    private void OnDestroy()
    {
        movements.Remove(this);
    }
}
