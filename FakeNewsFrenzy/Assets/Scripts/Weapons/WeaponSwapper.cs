using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    AR,
    ShotGun,
    Pistol,
    Grenade
}

public class WeaponSwapper : MonoBehaviour
{
    public int ID;

    [SerializeField]
    GameObject AR_Weapon;

    [SerializeField]
    GameObject Shotgun_Weapon;

    [SerializeField]
    GameObject Pistol_Weapon;


    // Start is called before the first frame update
    void Start()
    {
        AR_Weapon.SetActive(false);
        Shotgun_Weapon.SetActive(false);
        Pistol_Weapon.SetActive(false);

        ChangeAWeapon(WeaponType.Pistol);
        if (ID == 0)
            EquipWeapon.Player1WeaponTypeChanged += ChangeAWeapon;
        else if (ID == 1)
            EquipWeapon.Player2WeaponTypeChanged += ChangeAWeapon;
    }

    public void ChangeAWeapon(WeaponType pWeapon)
    {
        switch (pWeapon)
        {
            case WeaponType.AR:
                AR_Weapon.SetActive(true);
                Shotgun_Weapon.SetActive(false);
                Pistol_Weapon.SetActive(false);
                break;
            case WeaponType.ShotGun:
                Shotgun_Weapon.SetActive(true);
                AR_Weapon.SetActive(false);
                Pistol_Weapon.SetActive(false);
                break;
            case WeaponType.Pistol:
                Pistol_Weapon.SetActive(true);
                AR_Weapon.SetActive(false);
                Shotgun_Weapon.SetActive(false);
                break;
            default:
                Debug.Log("Il y a un soucis sur le type d'arme demandé");
                break;
        }
    }

}
