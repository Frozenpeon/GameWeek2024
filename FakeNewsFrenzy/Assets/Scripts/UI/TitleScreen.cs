using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

public class TitleScreen : MonoBehaviour
{
    private Gamepad gamepad;
    private EventSystem eventSystem;
    private bool gameStarted = false;
    [SerializeField] private GameObject _MenuScreen;
    [SerializeField] private GameObject _TitleScreen;
    [SerializeField] private GameObject _PlayButton;
    // Start is called before the first frame update
    void Start()
    {
        gamepad = Gamepad.current;
        eventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSelectMenu(InputAction.CallbackContext obj)
    {
        if (obj.canceled && !gameStarted)
        {
            gameStarted = true;
            _MenuScreen.SetActive(true);
            eventSystem.SetSelectedGameObject(_PlayButton);
            _TitleScreen.SetActive(false);
        }

    }



}
