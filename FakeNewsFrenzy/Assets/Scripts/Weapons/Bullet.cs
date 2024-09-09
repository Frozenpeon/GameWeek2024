using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;

    public float baseSpeed = 1000f;

    private float actualSpeed;

    public float lifeTime = 5;
    public float elaspedTime = 0;

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(direction * actualSpeed);
    }

    public void SetUp(Vector2 pDirection, float pPower)
    {
        direction = pDirection;
        actualSpeed = pPower * baseSpeed;
        GetComponent<Rigidbody2D>().AddForce(direction * actualSpeed);
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
