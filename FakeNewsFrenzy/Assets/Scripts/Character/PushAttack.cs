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
        //GetComponent<Movement>().spriteChanger.ShowAttack();

        Collider[] colliders = Physics.OverlapBox(transform.position + transform.forward * 3,new Vector3(1,2,1));

        foreach (Collider collider in colliders)
        {
            if(collider.TryGetComponent(out PushableObject pPo)){
                if(pPo.transform != transform) pPo.Push(transform.forward, 20, transform);
            }
        }

        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 1))
        {
            if(hitInfo.collider.transform.TryGetComponent(out PushableObject test))
            {
                test.Push(transform.forward, 20, transform);
            }
        }

    }
}
