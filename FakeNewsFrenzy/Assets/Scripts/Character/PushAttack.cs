using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAttack : MonoBehaviour
{
    
    public void OnAttack()
    {
        Debug.Log("Player " + GetComponent<Movement>().GetPlayerIndex() + " Attack");
    }
}
