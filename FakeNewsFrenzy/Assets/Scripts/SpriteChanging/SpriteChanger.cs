using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public GameObject WeaponSprite, deathSprite, stunSprite, attackSprite;

    private void Start()
    {
        deathSprite.SetActive(false);
        stunSprite.SetActive(false);
        attackSprite.SetActive(false);
    }

    public void ShowDeath()
    {
        deathSprite.SetActive(true);
        stunSprite.SetActive(false);
        WeaponSprite.SetActive(false);
        attackSprite.SetActive(false);
    }

    public void ShowAttack()
    {

    }

    public void ShowStun()
    {
        deathSprite.SetActive(false);
        stunSprite.SetActive(true);
        WeaponSprite.SetActive(false);
        attackSprite.SetActive(false);
    }

    public void ShowWeapon()
    {
        deathSprite.SetActive(false);
        stunSprite.SetActive(false);
        WeaponSprite.SetActive(true);
    }

}
