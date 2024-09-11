using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject _SettingsScreen;
    [SerializeField] private GameObject _ControlScreen;
    [SerializeField] private GameObject _ControlButton;
    [SerializeField] private Button _PlayButton;
    [SerializeField] private Button _SettingsButton;
    [SerializeField] private Button _QuitButton;
    [SerializeField] private Button _ControlsButton;
    [SerializeField] private GameObject Mastervolume;
    private EventSystem eventSystem;
    private bool isControlsOpen = false;

    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ShowSettings);
        _ControlsButton.onClick.AddListener(ShowControls);
        eventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowSettings()
    {
        StartCoroutine(SimulateButtonPress());

    }

    private IEnumerator SimulateButtonPress()
    {
        button.interactable = false;
        yield return new WaitForSeconds(0.1f); // Wait for a short duration to show the pressed state

        // Revert back to the normal state and perform the action
        button.interactable = true;
        _SettingsScreen.SetActive(true);
        _PlayButton.enabled = false;
        _SettingsButton.enabled = false;
        _QuitButton.enabled = false;
        eventSystem.SetSelectedGameObject(Mastervolume);
        
    }

    private void ShowControls()
    {
        if(isControlsOpen == false)
        {
            _PlayButton.enabled = false;
            _SettingsButton.enabled = false;
            _QuitButton.enabled = false;
            _ControlScreen.SetActive(true);
            StartCoroutine(DebugButton());

        }

    }

    public void CloseScreen(InputAction.CallbackContext obj)
    {
        if(obj.canceled && isControlsOpen)
        {
            _ControlScreen.SetActive(false);
  
            eventSystem.SetSelectedGameObject(_ControlButton);
            _PlayButton.enabled = true;
            _SettingsButton.enabled = true;
            _QuitButton.enabled = true;
            isControlsOpen = false;
        }
       
    }

    private IEnumerator DebugButton()
    {

        yield return new WaitForSeconds(0.1f);

        isControlsOpen = true;
    }
}
