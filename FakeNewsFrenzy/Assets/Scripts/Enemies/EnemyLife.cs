using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life = 10;

    public void TakesDmg(int amount)
    {
        life -= amount;
        if (life <= 0)
            Destroy(gameObject);
    }

}
