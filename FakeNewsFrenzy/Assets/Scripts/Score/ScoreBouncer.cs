using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBouncer : MonoBehaviour
{
    [SerializeField] int powerShake;
    [SerializeField] int duration;

    TMP_Text m_TextMeshPro;


    void Start()
    {
        m_TextMeshPro = GetComponent<TMP_Text>();
        ScoreManager.ScoreHaschanged += ChangeScore;
    }

    public void ChangeScore(int pNewScore)
    {
        m_TextMeshPro.text = pNewScore.ToString();
    }
}
