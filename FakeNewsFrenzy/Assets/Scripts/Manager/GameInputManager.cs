using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputManager : MonoBehaviour
{
    private static GameInputManager instance;

    public static InputDevice[] inputDevices = new InputDevice[2] {null,null };

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    private void Start()
    {
        PlayerInputManager myPIM = GetComponent<PlayerInputManager>();
        myPIM.JoinPlayer(0, 0, null, inputDevices[0]);
        myPIM.JoinPlayer(1, 1, null, inputDevices[1]);
    }

    public static GameInputManager GetInstance()
    {
        if(instance == null ) return new GameInputManager();
        return instance;
    }

    private void OnDestroy()
    {
        if(instance == this) instance = null;
    }
}
