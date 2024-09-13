using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoorZone : MonoBehaviour
{
    private List<Collider> colliders = new List<Collider>();

    [SerializeField] private GameObject parent;

    private void Start()
    {
        
    }

    private void Update()
    {
        colliders.Clear();
        Collider[] StartCollider = Physics.OverlapBox(transform.position + GetComponent<BoxCollider>().center, GetComponent<BoxCollider>().size / 2f);
        foreach (Collider c in StartCollider)
        {
            if (c.CompareTag("Enemy")) colliders.Add(c);
        }
        if (colliders.Count == 0) Destroy(parent);
        
    }


}
