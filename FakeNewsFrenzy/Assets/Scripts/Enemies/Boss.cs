using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    public static UnityEvent BossDie = new UnityEvent();
    [SerializeField] WinScreen winScreen;

    public void TakeDamage()
    {
        BossDie.Invoke();
        WinScreen.WinScreenEvent.Invoke(false);
        Destroy(gameObject);
    }
}
