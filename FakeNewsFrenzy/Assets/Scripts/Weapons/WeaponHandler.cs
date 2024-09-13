using System;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WeaponHandler : MonoBehaviour
{
    public Transform firePosiion;
    //2 30 6
    [SerializeField] GameObject reloadSliderContainer;
    private Slider reloadSlider;
    private float reloadTimer = 0;

    [SerializeField]
    private SO_BaseWeapon SOWeapon;
    [HideInInspector]
    public SO_BaseWeapon weapon;

    public float elapsedTime;
    [HideInInspector] public bool isShooting = false;

    [HideInInspector] public Gamepad gamepad;

    public event Action<float> shoot;

    private int bulletCount;
    [HideInInspector] public bool isReloading;

    public int idShooter = -1;

    private bool canReaload = false;

    private void Start()
    {
        weapon = Instantiate(SOWeapon);
        if (reloadSliderContainer != null)
        {
            reloadSlider = reloadSliderContainer.GetComponentInChildren<Slider>();
            canReaload = true;
        }
    }
    void Update()
    {
        if (isShooting && !isReloading) 
            Shoot(gamepad);
        elapsedTime += Time.deltaTime;
        if(isReloading){
            reloadTimer += Time.deltaTime;
            reloadSlider.value = reloadTimer;
        }
    }


     public void Reload(){
        if (!canReaload)

        GetComponent<SoundEmmiter>().PlaySound(weapon.reloadSound);
        StartCoroutine(Reloading());
    }


    /// <summary>
    /// Do not put a PlayerID if shooting from pc or if it's an enemy shooting
    /// </summary>
    /// <param name="PlayerID">aaa</param>
    public void Shoot(Gamepad pGamepad = null)
    {
        if (elapsedTime <= weapon.fireRate)
            return;
        elapsedTime = 0;
        weapon.Fire(firePosiion.right, firePosiion.position);
        if (pGamepad != null)
        {
            RumbleManager.instance.StartShaking(pGamepad, weapon.power / 100, weapon.power / 100, 0.1f);
        }
        ++bulletCount;
        GetComponent<SoundEmmiter>().PlaySound(weapon.shotSound);
        Debug.Log(weapon.shotSound);

        if (weapon.bulletPerReload == 0) return;
        if(weapon.bulletPerReload <= bulletCount)
        {
            Reload();
        }
    } 

   

    IEnumerator Reloading()
    {
        isReloading = true;
        reloadSlider.maxValue = weapon.ReloadTime;
        reloadSliderContainer.SetActive(true);
        yield return new WaitForSeconds(weapon.ReloadTime);
        reloadSliderContainer.SetActive(false);
        reloadTimer = 0;
        reloadSlider.value = reloadTimer;
        bulletCount = 0;
        isReloading = false;
    }

    public int GetBulletCount(){
        return bulletCount;
    }

    public bool GetIsReloading(){
        return isReloading;
    }

    private void OnDisable()
    {
        if (!canReaload)
            return;
        
        reloadSliderContainer.SetActive(false);
        reloadTimer = 0;
        reloadSlider.value = reloadTimer;
        bulletCount = 0;
        isReloading = false;
    }
}
