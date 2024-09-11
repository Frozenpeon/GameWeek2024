using System;
using System.Collections;
using System.Collections.Generic;
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

    float elapsedTime  = 0;

    private void Start()
    {
        rangeCollider.radius = range;
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
        Destroy(gameObject);
        Debug.Log("BOOOOOM");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PushableObject>() != null)
        {
            pushObjects.Add(other.GetComponent<PushableObject>());
            Debug.Log("Pushable in range");
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PushableObject>() != null)
        {
            pushObjects.Remove(other.GetComponent<PushableObject>());
            Debug.Log("Pushable got out of range");
        }

    }
}
