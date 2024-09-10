using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    /// <summary>
    /// Drops weapon randomly if ticked, else will automatically drop it.
    /// </summary>
    [SerializeField] private bool randomWeaponDrop = true;
    [SerializeField] private int weaponDropRate = 50;

    /// <summary>
    /// Drops a grenade randomly if ticked, else will automatically drop it.
    /// </summary>
    [SerializeField] private bool randomGrenadeDrop = true;
    [SerializeField] private int grenadeDropRate = 80;

    [SerializeField] private GameObject weaponLoot;
    private GameObject _WeaponLoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Destroy(gameObject  );
    }

    private void onDeathDrop()
    {
        if(randomWeaponDrop == true)
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
        }

        if(randomGrenadeDrop == true)
        {
            int grenadeResult = Random.Range(0, 101);
            if (grenadeResult <= grenadeDropRate)
            {
                Debug.Log($"DroppingGrenade, result = {grenadeResult}");
                //Dropping logic
            }
            else Debug.Log(grenadeResult);
        }

    }

    private void OnDestroy()
    {
        onDeathDrop();
    }
}
