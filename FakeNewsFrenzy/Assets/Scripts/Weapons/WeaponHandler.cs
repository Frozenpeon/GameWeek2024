using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Transform firePosiion;

    public SO_BaseWeapon weapon;

    private float elapsedTime;
    void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    public void Shoot()
    {
        if (elapsedTime <= weapon.fireRate)
            return;
        weapon.Fire(firePosiion.right, firePosiion.position);
        elapsedTime = 0;
    }
}
