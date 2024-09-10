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

    [SerializeField] private WeaponHandler currentWeapon;
    private GameObject weaponLoot;
    private GameObject _WeaponLoot;

    [SerializeField] GameObject grenadeLoot;
    private GameObject _GrenadeLoot;

    // Start is called before the first frame update
    void Start()
    {
        weaponLoot = currentWeapon.weapon.objectDrop;
    }

    // Update is called once per frame
    void Update()
    {
        //Used to debug and test
        if (Input.GetKeyDown(KeyCode.Space))
            onDeathDrop();
    }


    //Call this method when the enemy dies
    private void onDeathDrop()
    {

            int weaponResult = Random.Range(0, 101);
            if (weaponResult <= weaponDropRate)
            {
                Debug.Log($"DroppingWeapon, result = {weaponResult}");
                //Dropping logic
                _WeaponLoot = Instantiate(weaponLoot);
                _WeaponLoot.transform.position = transform.position;
            }
            else Debug.Log(weaponResult);
       

            int grenadeResult = Random.Range(0, 101);
            if (grenadeResult <= grenadeDropRate)
            {
                Debug.Log($"DroppingGrenade, result = {grenadeResult}");
                //Dropping logic
                _GrenadeLoot = Instantiate(grenadeLoot);
                _GrenadeLoot.transform.position = transform.position + new Vector3(0,1f,0);
            }
            else Debug.Log(grenadeResult);

        Destroy(gameObject);
    }
}
