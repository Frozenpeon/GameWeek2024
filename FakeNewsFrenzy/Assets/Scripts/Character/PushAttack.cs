using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAttack : MonoBehaviour
{

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);
        
    }

    public void OnAttack()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 1))
        {
            if(hitInfo.collider.transform.TryGetComponent(out PushableObject test))
            {
                test.Push(transform.forward, 20);
            }
        }

    }
}
