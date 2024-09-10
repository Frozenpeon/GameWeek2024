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
        if (elapsedTime > weapon.fireRate)
        if (Input.GetKey(KeyCode.Mouse0)) 
        {
            weapon.Fire(transform.right, firePosiion.position);
                elapsedTime = 0;
        }
    }
}
