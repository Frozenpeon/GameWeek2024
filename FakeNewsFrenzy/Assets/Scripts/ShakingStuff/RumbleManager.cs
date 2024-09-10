using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class RumbleManager : MonoBehaviour
{
    public static RumbleManager isntance;

    private Coroutine RumblingCoroutinePlayerOne;
    private Coroutine RumblingCoroutinePlayerTwo;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            StartShaking(Gamepad.all[0], 1f, 1f, 1f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartShaking(Gamepad.all[1], 1f, 1f, 1f);
        }

    }

    public void StartShaking(Gamepad pad, float highFrequency, float lowFrequency, float duration)
    {
        
        pad.SetMotorSpeeds(highFrequency, lowFrequency);

        if (pad.deviceId == 0)
            RumblingCoroutinePlayerOne = StartCoroutine(StopRumble(duration, pad));
        else
            RumblingCoroutinePlayerTwo = StartCoroutine(StopRumble(duration, pad));

    }

    private IEnumerator StopRumble(float duration, Gamepad pad)
    {

        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        pad.ResetHaptics();
    }

}
