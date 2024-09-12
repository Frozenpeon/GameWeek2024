using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmmiter : MonoBehaviour
{
    public void PlaySound(EventReference pSfx)
    {
        EventInstance lInstance;
        lInstance = RuntimeManager.CreateInstance(pSfx);
        RuntimeManager.AttachInstanceToGameObject(lInstance, transform);
    }
}
