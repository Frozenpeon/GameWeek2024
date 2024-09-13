using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverScreen : MonoBehaviour
{
    public static UnityEvent GameOverEvent = new UnityEvent();

    private void Start()
    {
        gameObject.SetActive(false);
        GameOverEvent.AddListener(ShowGameOver);
    }

    private void ShowGameOver()
    {
        gameObject.SetActive(true);
    }
}
