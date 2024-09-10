using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private EnemyAI enemyAI;
    public Vector3 _TargetPos;
    private Vector3 _TargetDirection;
    private bool isPlayerInRange = false;
    private bool isPlayerDetected = false;
    private GameObject _Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_Player != null)
        _TargetPos = _Player.transform.position;
        enemyAI.playerPos = _TargetPos;

        // Only check for detection if the player has not been detected yet
        if (!isPlayerDetected)
        {
            if (isPlayerInRange && !CheckForWalls())
            {
                enemyAI.playerDetected = true;
                isPlayerDetected = true;  
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isPlayerDetected)
        {
            Debug.Log("Player in range");
            _Player = collision.gameObject;
            isPlayerInRange = true;
        }
    }


    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deactivating the raycast verification if the player left unseen
            isPlayerInRange = false;
        }
    }
    private bool CheckForWalls()
    {
        _TargetDirection = _TargetPos - transform.position;

        RaycastHit[] hits = Physics.RaycastAll(transform.position, _TargetDirection);

        bool isWallDetected = false;

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Wall"))
            {
                isWallDetected = true;
                break;
            }
        }

        return isWallDetected; 
    }
}
