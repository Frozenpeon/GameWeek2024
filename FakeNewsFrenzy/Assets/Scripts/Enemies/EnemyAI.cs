using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private Transform playerPos;
    [SerializeField] private NavMeshAgent navmeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos != null)
        {
            navmeshAgent.SetDestination(playerPos.position);
        }
        
    }
}
