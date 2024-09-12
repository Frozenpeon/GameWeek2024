using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponPicker : MonoBehaviour
{
    public bool AssaultRifle;

    public bool ShotGun;

    public bool pistol;

    public GameObject AR, Shotgun, Pistol;

    public WeaponHandler activWeapon;

    public EnemySprites spriteHandler;

    private void Start()
    {
        AR.SetActive(false);
        Shotgun.SetActive(false);
        Pistol.SetActive(false);

        if (AssaultRifle)
        {
            activWeapon = AR.GetComponent<WeaponHandler>();
           // AR.SetActive(true);
        }
        else if (ShotGun)
        {
            activWeapon = Shotgun.GetComponent<WeaponHandler>();
            //Shotgun.SetActive(true);
        }
        else if (Pistol) 
        {
            activWeapon = Pistol.GetComponent<WeaponHandler>();
           // Pistol.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GoAggroVisual();
        }
    }

    public void GoAggroVisual()
    {
        spriteHandler.ShowAggro();
        activWeapon.gameObject.SetActive(true);
    }

    public void Shoot()
    {
        if (activWeapon != null)
        {
            activWeapon.Shoot();
        }
    }


}
