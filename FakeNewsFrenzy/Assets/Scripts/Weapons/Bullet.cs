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

    public int dmg = 5;

    private void Start()
    {

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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit smth");

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.transform.GetComponent<EnemyLife>().TakesDmg(dmg);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Boss")
        {
            collision.transform.GetComponent<Boss>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
