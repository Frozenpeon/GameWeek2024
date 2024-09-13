using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAttack : MonoBehaviour
{
    [SerializeField] private EventReference cacPlayerSound;
    [SerializeField] private List<WeaponHandler> weapons = new List<WeaponHandler>();

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);
        
    }

    public void OnAttack()
    {
        if (GetComponent<Movement>().isBeingPushed || GetComponent<PlayerLife>().dead)
            return;

        foreach (WeaponHandler weapon in weapons)
        {
            if (weapon.isReloading) return;
        }

        GetComponent<SoundEmmiter>().PlaySound(cacPlayerSound);

        GetComponent<Movement>().spriteChanger.ShowAttack();

        Collider[] colliders = Physics.OverlapBox(transform.position + transform.forward * 3,new Vector3(3,6,3));

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
