using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class SO_BaseWeapon : ScriptableObject
{
    public WeaponType Type;

    [SerializeField] protected GameObject bullet;

    [SerializeField] protected float spread;

    /// <summary>
    /// Time between bullets.
    /// </summary>
    [SerializeField] public float fireRate;

    [SerializeField] public float bulletPerReload;
    [SerializeField] public float ReloadTime;

    [SerializeField] public float power;

    [SerializeField] protected int bulletPerShot;

    [SerializeField] public GameObject objectDrop;

    public void Fire(Vector3 pDirection, Vector3 pPosition)
    {
        float spreadValue = 0;
        for (int i = 1; i <= bulletPerShot; i++) {
            spreadValue =  Random.Range(-spread, spread);
            GameObject go = Instantiate(bullet, pPosition, Quaternion.identity);     
            go.GetComponent<Bullet>().SetUp((Quaternion.Euler(0, spreadValue, 0) * pDirection).normalized, power);
        }
    }




}
