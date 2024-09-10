using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHandler : MonoBehaviour
{
    public Transform firePosiion;

    public SO_BaseWeapon weapon;

    private float elapsedTime;
    void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    public void Shoot(int PlayerID = -1)
    {
        if (elapsedTime <= weapon.fireRate)
            return;
        weapon.Fire(firePosiion.right, firePosiion.position);
        if (PlayerID != -1)
        {
            RumbleManager.instance.StartShaking(PlayerID, weapon.power / 200, weapon.power / 200, 0.2f);
        }
        elapsedTime = 0;
    }
}
