using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenadeLauncher : MonoBehaviour
{
    public GameObject grenadePrefab;

    public Transform throwPoint;

    public int throwPower = 100;

    Movement parent;

    private void Start()
    {
       parent = transform.parent.GetComponent<Movement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            ThrowAGrenade();
        }
    }

    public void ThrowAGrenade()
    {
        if (parent == null)
            return;
        if (parent.GrenadeCount <= 0)
            return;

        GameObject go = Instantiate(grenadePrefab);
        go.transform.position = throwPoint.position;
        go.GetComponent<Rigidbody>().AddForce(transform.forward * throwPower);
        parent.GrenadeCount--;
    }


}
