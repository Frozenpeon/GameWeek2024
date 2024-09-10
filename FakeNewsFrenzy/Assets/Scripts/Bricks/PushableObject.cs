using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
    public void Push(Vector3 pDir, float pStrengh)
    {
        if (TryGetComponent(out Movement movement))
        {
            movement.StartPush();
        }
        else GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(pDir * pStrengh, ForceMode.Impulse);
    }
}
