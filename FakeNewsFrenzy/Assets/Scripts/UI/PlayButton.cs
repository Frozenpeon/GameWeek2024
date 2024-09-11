using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    [SerializeField] private GameObject nextScreen;
    [SerializeField] private GameObject menuScreen;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onPlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onPlay()
    {
        Debug.Log("PLAY");
        StartCoroutine(SimulateButtonPress());

    }
    private IEnumerator SimulateButtonPress()
    {

        yield return new WaitForSeconds(0.1f); // Wait for a short duration to show the pressed state

        // Revert back to the normal state and perform the action
        button.interactable = true;
        nextScreen.SetActive(true);
        menuScreen.SetActive(false);
    }
}
