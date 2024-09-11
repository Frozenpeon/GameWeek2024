using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ConnexionScreen : MonoBehaviour
{
    [SerializeField] private Image P1Image;
    [SerializeField] private Sprite _P1PictureValid;
    [SerializeField] private Sprite _P1PictureInvalid;
    [SerializeField] private Image P2Image;
    [SerializeField] private Sprite _P2PictureValid;
    [SerializeField] private Sprite _P2PictureInvalid;
    [SerializeField] private GameObject _StartButton;
    private EventSystem eventSystem;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        CheckControllersAmount();

    }

    void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    // Update is called once per frame
    void Update()
    {
        if(Gamepad.all.Count == 1)
        {

        }
    }

    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        // Check if the change is an addition of a gamepad
        if (change == InputDeviceChange.Added && device is Gamepad)
        {
            Debug.Log($"Gamepad connected: {device.displayName}");

            CheckControllersAmount();

        }
        else if(change == InputDeviceChange.Removed)
        {
            CheckControllersAmount();
        }
    }


    private void CheckControllersAmount()
    {
        if(Gamepad.all.Count == 0)
        {
            P1Image.sprite = _P1PictureInvalid;
            P2Image.sprite = _P2PictureInvalid;
            _StartButton.SetActive(false);

        }
        else if (Gamepad.all.Count == 1)
        {
            P1Image.sprite = _P1PictureValid;
            P2Image.sprite= _P2PictureInvalid;
            _StartButton.SetActive(false);

        }
        else if (Gamepad.all.Count == 2)
        {
            P1Image.sprite = _P1PictureValid;
            P2Image.sprite = _P2PictureValid;
            _StartButton.SetActive(true);
            eventSystem.SetSelectedGameObject(_StartButton);
        }
    }
}
