using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ConnexionScreen : MonoBehaviour
{
    [SerializeField] private Image _P1Picture;
    [SerializeField] private Image _P2Picture;
    // Start is called before the first frame update
    void Start()
    {
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
            _P1Picture.color = Color.red;
            _P2Picture.color = Color.red;
        }
        else if (Gamepad.all.Count == 1)
        {
            _P1Picture.color = Color.green;
            _P2Picture.color = Color.red;
        }
        else if (Gamepad.all.Count == 2)
        {
            _P1Picture.color = Color.green;
            _P2Picture.color = Color.green;
        }
    }
}
