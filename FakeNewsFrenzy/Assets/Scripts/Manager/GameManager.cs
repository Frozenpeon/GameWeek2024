using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static UnityEvent PlayerDead = new UnityEvent();
    public static UnityEvent PlayerRevive = new UnityEvent();

    private void Start()
    {
        PlayerDead.AddListener(CheckPlayerAlive);
        PlayerRevive.AddListener(CheckPlayerAlive);
    }

    private void CheckPlayerAlive()
    {
        int countPlayerAlive = 0;
        foreach(PlayerLife pf in PlayerLife.list)
        {
            if(!pf.dead) countPlayerAlive++;
        }
        SoundManager.AddParametersToMusic(2 - countPlayerAlive);
    }

    private void OnDestroy()
    {
        PlayerDead.RemoveListener(CheckPlayerAlive);
        PlayerRevive.RemoveListener(CheckPlayerAlive);
    }

}
