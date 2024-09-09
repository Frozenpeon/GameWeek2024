using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_Listenner : MonoBehaviour
{
    public SO_BaseWeapon weapon;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            weapon.Fire(transform.right, transform.position);
        }
    }
}
