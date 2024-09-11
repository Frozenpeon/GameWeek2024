using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject _SettingsScreen;
    [SerializeField] private Button _PlayButton;
    [SerializeField] private Button _SettingsButton;
    [SerializeField] private Button _QuitButton;
    [SerializeField] private GameObject Mastervolume;
    private EventSystem eventSystem;


    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ShowSettings);
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
}
