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

    private int bulletCount;
    private bool isReloading;

    public int idShooter = -1;

    private void Start()
    {
        weapon = Instantiate(SOWeapon);
        reloadSlider = reloadSliderContainer.GetComponentInChildren<Slider>();
    }
    void Update()
    {
        if (isShooting && !isReloading) Shoot(gamepad);
        elapsedTime += Time.deltaTime;
        if(isReloading){
            reloadTimer += Time.deltaTime;
            reloadSlider.value = reloadTimer;
        }
    }


     public void Reload(){
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
        weapon.Fire(firePosiion.right, firePosiion.position);
        if (pGamepad != null)
        {
            RumbleManager.instance.StartShaking(pGamepad, weapon.power / 100, weapon.power / 100, 0.1f);
        }
        elapsedTime = 0;
        ++bulletCount;

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
        Debug.Log(reloadSlider.value +" ");
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

}
