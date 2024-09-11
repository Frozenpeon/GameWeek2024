using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;

    public static event Action<int> ScoreHaschanged;

    private void Start()
    {
        ScoringEntity.AddingScore += AddScore;
    }


    public void AddScore(int pScore)
    {
        Score += pScore;
        ScoreHaschanged(Score);
    }


}
