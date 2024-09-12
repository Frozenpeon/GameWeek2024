using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    /// <summary>
    /// Drop chance in %
    /// </summary>
    [SerializeField] private int weaponDropRate = 50;

    /// <summary>
    /// Drop chance in %
    /// </summary>
    [SerializeField] private int grenadeDropRate = 80;

    private WeaponHandler currentWeapon;
    private GameObject weaponLoot;
    private GameObject _WeaponLoot;

    [SerializeField] GameObject grenadeLoot;
    private GameObject _GrenadeLoot;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.GetChild(0).GetComponent<EnemyWeaponPicker>() != null) 
            currentWeapon = transform.GetChild(0).GetComponent<EnemyWeaponPicker>().activWeapon;
        if (currentWeapon != null ) 
            weaponLoot = currentWeapon.weapon.objectDrop;
    }


    //Call this method when the enemy dies
    public void onDeathDrop()
    {
        if (currentWeapon != null)
        {

            int weaponResult = Random.Range(0, 101);
            if (weaponResult <= weaponDropRate)
            {
                //Dropping logic
                _WeaponLoot = Instantiate(weaponLoot);
                _WeaponLoot.transform.position = transform.position;
            }
            //else Debug.Log(weaponResult);
        }

            int grenadeResult = Random.Range(0, 101);
            if (grenadeResult <= grenadeDropRate)
            {
                //Dropping logic
                _GrenadeLoot = Instantiate(grenadeLoot);
                _GrenadeLoot.transform.position = transform.position + new Vector3(0,1f,0);
            }
            else Debug.Log(grenadeResult);

        Destroy(gameObject);
    }
}
