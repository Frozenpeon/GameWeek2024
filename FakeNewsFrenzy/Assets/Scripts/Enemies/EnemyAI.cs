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
    [SerializeField] private GameObject meleeHitbox;

    public EnemySprites sprites;
    private bool canShoot = true;
    private bool canMove = true;
    [SerializeField] private float distanceToAttack = 2.5f;
    [SerializeField] private float _Speed = 3.5f;


    // Start is called before the first frame update
    void Start()
    {
        navmeshAgent.speed = _Speed;
    }

   

    // Juste appelle ça quand tu veux tirer en sah
    private void Shoot()
    {
        if(canShoot == true)
        {
            if (transform.GetChild(0).GetComponent<EnemyWeaponPicker>() != null)
                transform.GetChild(0).GetComponent<EnemyWeaponPicker>().Shoot();
            else
            {
                //Appeler / faire l'attaque cac 
                canShoot = false;
                StartCoroutine(ShowHitbox());
                if (sprites != null)
                    sprites.ShowMeleAttack();
            }
        }
      
    }


    // Update is called once per frame
    void Update()
    {
        if (playerPos != null && playerDetected == true && canMove)
        {
            navmeshAgent.SetDestination(playerPos);
            transform.LookAt(playerPos);
            if (navmeshAgent.remainingDistance >= distanceToAttack)
            {
                navmeshAgent.isStopped = false;
            }
            else navmeshAgent.isStopped = true;

        }

        if (Input.GetMouseButtonDown(0) || navmeshAgent.remainingDistance <= distanceToAttack)
        {
            Shoot();
        }



    }

    private IEnumerator ShowHitbox ()
    {
        meleeHitbox.SetActive(true);
        yield return new WaitForSeconds(.7f);
        meleeHitbox.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        canShoot = true;
    }
}
