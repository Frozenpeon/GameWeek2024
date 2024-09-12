using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private static ParticleManager instance;

    private int _ParticleEmmiterCount = -1;
    private int _lastEmmiterUse = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    public static ParticleManager GetInstance()
    {
        if (instance != null) return instance; 
        return new ParticleManager();
    }

    private void Start()
    {
        _ParticleEmmiterCount = transform.childCount;
    }

    public void PlayParticle(Vector3 pos)
    {
        int pIndex = (_lastEmmiterUse + 1) % _ParticleEmmiterCount;
        ParticleSystem pPs = transform.GetChild(pIndex).GetComponent<ParticleSystem>();
        pPs.transform.position = pos;
        pPs.Play();

        _lastEmmiterUse = pIndex;
    }

    private void OnDestroy()
    {
        if(instance == this) instance = null;
    }
}
