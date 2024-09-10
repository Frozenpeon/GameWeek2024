using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public bool isOnWeapon = false;
    private GameObject newWeapon;
    private GameObject _Weapon;
    private GameObject lootToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipNewWeapon()
    {
        if(isOnWeapon)
        {
            _Weapon = Instantiate(newWeapon);
            _Weapon.transform.parent = transform;
            _Weapon.transform.localPosition = Vector3.zero; //Replace by correct position when sprites are done

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

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            newWeapon = null;
            lootToDestroy = null;
            isOnWeapon = false;
            Debug.Log("ITEM LEFT");

        }

    }
}
