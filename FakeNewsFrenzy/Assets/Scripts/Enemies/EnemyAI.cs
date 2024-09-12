using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public Vector3 playerPos;
    [SerializeField] private NavMeshAgent navmeshAgent;

    public bool playerDetected = false;

    public EnemySprites sprites;


    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    // Juste appelle ça quand tu veux tirer en sah
    private void Shoot()
    {
        if (transform.GetChild(0).GetComponent<EnemyWeaponPicker>()!=null)
            transform.GetChild(0).GetComponent<EnemyWeaponPicker>().Shoot();
        else
        {
            //Appeler / faire l'attaque cac 
            sprites.ShowMeleAttack();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (playerPos != null && playerDetected == true)
        {
            navmeshAgent.SetDestination(playerPos);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }
}
