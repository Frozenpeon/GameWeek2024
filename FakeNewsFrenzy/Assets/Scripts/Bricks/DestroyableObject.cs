using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    [HideInInspector] public bool isActivated = false;

    [HideInInspector] public Transform pusher;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isActivated || collision.transform == pusher) return;

        if (!collision.gameObject.CompareTag("Wall") && !collision.gameObject.CompareTag("Player")) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PushableObject>().Push(GetComponent<Rigidbody>().velocity.normalized, 20, pusher);
        }

        Destroy(gameObject);
    }
}
