using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviveZone : MonoBehaviour
{
    [SerializeField] private float _TimeToRevive = 2f;
    private float _Count = 0;
    private float _lastCount = 0;
    [SerializeField] private Transform myPlayer;

    [SerializeField] private GameObject reviveSliderContainer;
    private Slider reviveSlider;

    private Action doAction;

    private void Start()
    {   
        reviveSlider = reviveSliderContainer.GetComponentInChildren<Slider>();
        SetModeUnRevive();
    }

    private void Update()
    {
        if (GetComponent<Collider>().enabled)
        {
            transform.position = myPlayer.position;
        }

        if (doAction != null) doAction();
    }

    public void SetModeRevive()
    {
        doAction = DoActionRevive;
        reviveSliderContainer.SetActive(true);
    }

    private void DoActionRevive()
    {
        _Count += Time.deltaTime;
        if (_Count >= 0) reviveSlider.value = _Count;
        if (_Count >= _TimeToRevive)
        {
            myPlayer.GetComponent<PlayerLife>().Revive();
            _Count = 0;
            SetModeUnRevive();
        }
    }

    public void SetModeUnRevive()
    {
        doAction = DoActionUnRevive;
        reviveSliderContainer.SetActive(false);
    }

    public void DoActionUnRevive()
    {
        _Count -= Time.deltaTime;
        if (_Count >= 0) reviveSlider.value = _Count;
        if (_Count < 0) _Count = 0;
    }

}
