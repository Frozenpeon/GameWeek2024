using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life = 10;
    [SerializeField] private EventReference hitEnemySound;
    public void TakesDmg(int amount)
    {
        life -= amount;

        GetComponent<SoundEmmiter>().PlaySound(hitEnemySound);

        if (life <= 0)
            if (GetComponent<EnemyDrops>() != null)
            {
                GetComponent<EnemyDrops>().onDeathDrop();
            }
            else
                Destroy(transform.parent.gameObject);
    }

}
