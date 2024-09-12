using System;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHandler : MonoBehaviour
{
    public Transform firePosiion;
    //2 30 6
    [SerializeField]
    private SO_BaseWeapon SOWeapon;
    [HideInInspector]
    public SO_BaseWeapon weapon;

    public float elapsedTime;
    [HideInInspector] public bool isShooting = false;

    [HideInInspector] public Gamepad gamepad;

    public event Action<float> shoot;

    private int bulletCount;
    private bool isReloading;

    public int idShooter = -1;

    private void Start()
    {
        weapon = Instantiate(SOWeapon);
    }
    void Update()
    {
        if (isShooting && !isReloading) 
            Shoot(gamepad);
        elapsedTime += Time.deltaTime;

    }
    /// <summary>
    /// Do not put a PlayerID if shooting from pc or if it's an enemy shooting
    /// </summary>
    /// <param name="PlayerID">aaa</param>
    public void Shoot(Gamepad pGamepad = null)
    {
        if (elapsedTime <= weapon.fireRate)
            return;
        elapsedTime = 0;
        weapon.Fire(firePosiion.right, firePosiion.position);
        if (pGamepad != null)
        {
            RumbleManager.instance.StartShaking(pGamepad, weapon.power / 100, weapon.power / 100, 0.1f);
        }
        shoot.Invoke(weapon.power);      
        ++bulletCount;
        GetComponent<SoundEmmiter>().PlaySound(weapon.shotSound);

        if(weapon.bulletPerReload <= bulletCount)
        {
            StartCoroutine(Reloading());
            bulletCount = 0;
            GetComponent<SoundEmmiter>().PlaySound(weapon.reloadSound);
        }
    }

    IEnumerator Reloading()
    {
        isReloading = true;
        yield return new WaitForSeconds(weapon.ReloadTime);
        isReloading = false;
    }
}
