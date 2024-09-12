using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private EventReference musicsToPlayOnStart;
    [SerializeField] private EventReference ambToPlayOnStart;

    static EventInstance currentMusic;
    static EventInstance currentAmb;

    private void Start()
    {
        if (currentMusic.isValid()) currentMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        if(!musicsToPlayOnStart.IsNull)
        {
            currentMusic = RuntimeManager.CreateInstance(musicsToPlayOnStart);
            currentMusic.start();
        }
        
        if (currentAmb.isValid()) currentAmb.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        if(!ambToPlayOnStart.IsNull)
        {
            currentAmb = RuntimeManager.CreateInstance(ambToPlayOnStart);
            currentAmb.start();
        }
    }

    public static void AddParametersToMusic(int paramValue)
    {
        currentMusic.setParameterByName("Filter", paramValue);
    }
}
