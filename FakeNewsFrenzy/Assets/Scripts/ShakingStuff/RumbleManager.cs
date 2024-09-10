using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class RumbleManager : MonoBehaviour
{


    private Coroutine RumblingCoroutine;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //StartShaking();
        }
    }

    public void StartShaking(Gamepad pad, float highFrequency, float lowFrequency, float duration)
    {
        
        pad.SetMotorSpeeds(highFrequency, lowFrequency);

        RumblingCoroutine = StartCoroutine(StopRumble(duration, pad));

    }

    private IEnumerator StopRumble(float duration, Gamepad pad)
    {

        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        pad.SetMotorSpeeds(0f, 0f);
    }

}
