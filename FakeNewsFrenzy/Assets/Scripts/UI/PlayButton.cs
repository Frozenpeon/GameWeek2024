using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    [SerializeField] private GameObject nextScreen;
    [SerializeField] private GameObject menuScreen;
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(onPlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onPlay()
    {
        Debug.Log("PLAY");
        nextScreen.SetActive(true);
        menuScreen.SetActive(false); 

    }
}
