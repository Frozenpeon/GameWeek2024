using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class SO_BaseWeapon : ScriptableObject
{

    [SerializeField] protected GameObject bullet;

    [SerializeField] protected float spread;

    /// <summary>
    /// Time between bullets.
    /// </summary>
    [SerializeField] public float fireRate;

    [SerializeField] protected float power;

    [SerializeField] protected int bulletPerShot;

    public void Fire(Vector2 pDirection, Vector2 pPosition)
    {
        float spreadValue = 0;
        for (int i = 1; i <= bulletPerShot; i++) {
            spreadValue =  Random.Range(-spread, spread);
            GameObject go = Instantiate(bullet, pPosition, Quaternion.identity);     
            go.GetComponent<Bullet>().SetUp((Quaternion.Euler(0, 0, spreadValue) * pDirection).normalized, power);
        }
    }




}
