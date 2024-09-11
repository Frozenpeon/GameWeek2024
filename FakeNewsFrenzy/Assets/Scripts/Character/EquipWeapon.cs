using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public static event Action<WeaponType> Player1WeaponTypeChanged;

    public static event Action<WeaponType> Player2WeaponTypeChanged;


    public bool isOnWeapon = false;
    private WeaponType newWeapon;
    private WeaponType _Weapon;
    private GameObject lootToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipNewWeapon(int PlayerIndex)
    {
        if(isOnWeapon)
        {
            if (PlayerIndex == 0)
                Player1WeaponTypeChanged(newWeapon);
            else 
                Player2WeaponTypeChanged(newWeapon);
            isOnWeapon = false;
            Destroy(lootToDestroy);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            newWeapon = other.transform.parent.GetComponent<WeaponLoot>().inHandWeapon;
            lootToDestroy = other.transform.parent.gameObject;
            isOnWeapon = true;
            Debug.Log("ITEM DETECTED");

            if (newWeapon == WeaponType.Grenade)
            {
                //TO DO : Ajouter au compteur de grenades du joueur en question
                Debug.Log("Looted a nade");
                isOnWeapon = false;
                Destroy(lootToDestroy);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            newWeapon = 0;
            lootToDestroy = null;
            isOnWeapon = false;
            Debug.Log("ITEM LEFT");

        }

    }
}
