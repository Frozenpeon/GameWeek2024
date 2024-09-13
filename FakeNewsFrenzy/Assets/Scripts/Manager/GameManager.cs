using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static UnityEvent PlayerDead = new UnityEvent();
    public static UnityEvent PlayerRevive = new UnityEvent();

    private void Start()
    {
        PlayerDead.AddListener(CheckPlayerAlive);
        PlayerRevive.AddListener(CheckPlayerAlive);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {

            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void CheckPlayerAlive()
    {
        int countPlayerAlive = 0;
        foreach(PlayerLife pf in PlayerLife.list)
        {
            if(!pf.dead) countPlayerAlive++;
        }
        SoundManager.AddParametersToMusic(2 - countPlayerAlive);

        if (countPlayerAlive == 0) GameOverScreen.GameOverEvent.Invoke();
    }

    private void OnDestroy()
    {
        PlayerDead.RemoveListener(CheckPlayerAlive);
        PlayerRevive.RemoveListener(CheckPlayerAlive);
    }

}
