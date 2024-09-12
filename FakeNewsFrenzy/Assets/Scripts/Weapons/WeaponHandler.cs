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

    private int bulletCount;
    private bool isReloading;

    public int idShooter = -1;

    private void Start()
    {
        weapon = Instantiate(SOWeapon);
    }
    void Update()
    {
        if (isShooting && !isReloading) Shoot(gamepad);
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
        weapon.Fire(firePosiion.right, firePosiion.position);
        if (pGamepad != null)
        {
            RumbleManager.instance.StartShaking(pGamepad, weapon.power / 100, weapon.power / 100, 0.1f);
        }
        elapsedTime = 0;
        ++bulletCount;

        if(weapon.bulletPerReload <= bulletCount)
        {
            StartCoroutine(Reloading());
            bulletCount = 0;
        }
    }

    IEnumerator Reloading()
    {
        isReloading = true;
        yield return new WaitForSeconds(weapon.ReloadTime);
        isReloading = false;
    }
}
