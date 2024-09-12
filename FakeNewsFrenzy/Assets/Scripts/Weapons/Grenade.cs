using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private float timeBeforeExplosion;

    [SerializeField]
    private float range;

    [SerializeField]
    private float power;

    [SerializeField]
    private SphereCollider rangeCollider;

    private List<PushableObject> pushObjects = new List<PushableObject>();

    private List<EnemyLife> enmiesToKill = new List<EnemyLife>();

    float elapsedTime  = 0;

    public SpriteRenderer nade_Sprite;

    public float baseTimerBling = 0.5f;

    public int Damage = 10;


    Coroutine corou;

    private void Start()
    {
        rangeCollider.radius = range;
        corou = StartCoroutine(Blinking());
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeBeforeExplosion)
        {
            Explosion();
        }
    }


    private void Explosion()
    {
        foreach (PushableObject objToPush in pushObjects)
        {
            Vector3 force = (objToPush.transform.position - transform.position).normalized;
            force.y = 0;
            objToPush.Push(force, power, transform);
        }

        foreach (EnemyLife go in enmiesToKill)
        {
            go.TakesDmg(Damage);
        }
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PushableObject>() != null)
        {
            pushObjects.Add(other.GetComponent<PushableObject>());
        }
        if (other.GetComponent<EnemyLife>() != null)
        {
            enmiesToKill.Add(other.GetComponent<EnemyLife>());
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PushableObject>() != null)
        {
            pushObjects.Remove(other.GetComponent<PushableObject>());
        }
        if (other.GetComponent<EnemyLife>() != null)
        {
            enmiesToKill.Remove(other.GetComponent<EnemyLife>());
        }
    }

    List <Color> colorList = new List<Color>();
    int i = 0;
    private IEnumerator Blinking()
    {
        colorList.Add(Color.red);
        colorList.Add(Color.white);
        while (true)
        {
            nade_Sprite.color = colorList[i++ % 2];
            yield return new WaitForSeconds((timeBeforeExplosion - elapsedTime) / 4);
        }
    }



}
