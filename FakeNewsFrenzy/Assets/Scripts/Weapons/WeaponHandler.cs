using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHandler : MonoBehaviour
{
    public Transform firePosiion;

    [SerializeField]
    private SO_BaseWeapon SOWeapon;
    [HideInInspector]
    public SO_BaseWeapon weapon;

    private float elapsedTime;
    [HideInInspector] public bool isShooting = false;

    private void Start()
    {
        weapon = Instantiate(SOWeapon);
    }
    void Update()
    {
        if (isShooting) Shoot();
        elapsedTime += Time.deltaTime;

    }
    /// <summary>
    /// Do not put a PlayerID if shooting from pc or if it's an enemy shooting
    /// </summary>
    /// <param name="PlayerID">aaa</param>
    public void Shoot(int PlayerID = -1)
    {
        if (elapsedTime <= weapon.fireRate)
            return;
        weapon.Fire(firePosiion.right, firePosiion.position);
        if (PlayerID != -1)
        {
            RumbleManager.instance.StartShaking(PlayerID, weapon.power / 400, weapon.power / 400, 0.1f);
        }
        elapsedTime = 0;
    }
}
