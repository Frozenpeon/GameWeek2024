using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringEntity : MonoBehaviour
{
    public static event Action<int> AddingScore;

    public int ScoreToAdd;


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            AddAScore();
        }
    }

    public void AddAScore()
    {
        AddAScore(ScoreToAdd);
    }

    public void AddAScore(int pScore)
    {
        AddingScore.Invoke(ScoreToAdd);
    }
}
