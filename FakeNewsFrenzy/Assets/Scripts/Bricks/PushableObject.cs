using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : MonoBehaviour
{
    private Transform pusher;

    public void Push(Vector3 pDir, float pStrengh, Transform pusher)
    {
        if (TryGetComponent(out Movement movement))
        {
            movement.StartPush();
        }
        else GetComponent<Rigidbody>().isKinematic = false;
        if(TryGetComponent(out DestroyableObject pDo)){
            pDo.pusher = pusher;
            pDo.isActivated = true;
        }
        GetComponent<Rigidbody>().AddForce(pDir * pStrengh, ForceMode.Impulse);
    }
}
