using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;

    public float baseSpeed = 1000f;

    private float actualSpeed;

    public float lifeTime = 5;
    public float elaspedTime = 0;

    private void Start()
    {
        //GetComponent<Rigidbody>().AddForce(direction * actualSpeed);
    }

    public void SetUp(Vector3 pDirection, float pPower)
    {
        direction = pDirection;
        actualSpeed = pPower * baseSpeed;
        GetComponent<Rigidbody>().AddForce(direction * actualSpeed);
        transform.rotation = Quaternion.LookRotation(pDirection, Vector3.up);
    }

    private void Update()
    {
        elaspedTime += Time.deltaTime;
        if (elaspedTime >= lifeTime) 
        {
            Destroy(gameObject);
        }
    }
}
