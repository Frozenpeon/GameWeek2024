using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    public static UnityEvent BossDie = new UnityEvent();

    public void TakeDamage()
    {
        BossDie.Invoke();
        Destroy(gameObject);
    }
}
