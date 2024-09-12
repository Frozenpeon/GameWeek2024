using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public GameObject WeaponSprite, deathSprite, stunSprite, attackSprite;

    Coroutine corou;

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
        StopAllCoroutines();
        ShowWeapon();
        corou = StartCoroutine(ShowAttackCorou());
    }

    private IEnumerator ShowAttackCorou()
    {
        deathSprite.SetActive(false);
        stunSprite.SetActive(false);
        WeaponSprite.SetActive(false);
        attackSprite.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        ShowWeapon();
    }

    public void ShowStun()
    {
        StopAllCoroutines();
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
        attackSprite.SetActive(false);
    }

}
