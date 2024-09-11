using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDamage : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerLife pPl))
        {
            pPl.LoseLifePoint();
        }
    }

}
