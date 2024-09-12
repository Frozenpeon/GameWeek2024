using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidebarFollowPlayer : MonoBehaviour
{

    [SerializeField] private GameObject player;


    // Update is called once per frame
    void Update()
    {
        if(player != null) transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z + 5);
        
    }
}
