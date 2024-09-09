using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class SO_BaseWeapon : ScriptableObject
{

    [SerializeField] protected GameObject bullet;

    [SerializeField] protected float spread;

    [SerializeField] protected float fireRate;

    [SerializeField] protected float power;

    [SerializeField] protected int bulletPerShot;

    public void Fire(Vector2 pDirection, Vector2 pPosition)
    {
        GameObject go = Instantiate(bullet, pPosition, Quaternion.identity);
        go.GetComponent<Bullet>().SetUp(pDirection, power);
    }




}
