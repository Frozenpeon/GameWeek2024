using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public static UnityEvent<bool> WinScreenEvent = new UnityEvent<bool>();

    [SerializeField] private Sprite _FirstEnd;
    [SerializeField] private Sprite _SecondEnd;
    private void Start()
    {
        WinScreenEvent.AddListener(ShowWinScreen);
        gameObject.SetActive(false);
    }

    private void ShowWinScreen(bool isFirstEnd)
    {
        gameObject.SetActive(true);
        Sprite winScreen = isFirstEnd ? _FirstEnd : _SecondEnd;

        GetComponent<Image>().sprite = winScreen;

    }
}
