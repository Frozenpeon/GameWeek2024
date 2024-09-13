using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUi : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            WinScreen.WinScreenEvent.Invoke(true);
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            WinScreen.WinScreenEvent.Invoke(false);
        }
    }
}
