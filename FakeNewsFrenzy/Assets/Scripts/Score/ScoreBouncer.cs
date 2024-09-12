using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreBouncer : MonoBehaviour
{
    int showedScore, oldScore, newScore;

    [SerializeField] float speed = 0.05f;
    [SerializeField] float amountIncreasedEachStep = 0.1f;
    Vector3 actualScale, maxScale, minScale;
    Coroutine increment;
    float step = 0;

    TMP_Text m_TextMeshPro;

    void Start()
    {
        minScale = transform.localScale;
        actualScale = transform.localScale * 2;
        maxScale = transform.localScale * 4;
        m_TextMeshPro = GetComponent<TMP_Text>();
        ScoreManager.ScoreHaschanged += ChangeScore;
    }


    private void Update()
    {
        if (actualScale.x > minScale.x)
        {
            actualScale -= Vector3.one * Time.deltaTime;
        }
        m_TextMeshPro.text = showedScore.ToString();
        transform.localScale = actualScale;
    }
    private IEnumerator IncrementScore()
    {
        while (step < 1)
        {
            step += amountIncreasedEachStep;
            showedScore = (int)Mathf.Lerp(oldScore, newScore, step);
            yield return new WaitForSeconds(speed);
        }
        
    }

    public void ChangeScore(int pNewScore)
    {
        step = 0;
        oldScore = showedScore;
        newScore = pNewScore;
        Debug.Log(newScore);
        increment = StartCoroutine(IncrementScore());

        actualScale += Vector3.one;
        transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(-12,12));
        if (actualScale.x > maxScale.x)
        {
            actualScale = maxScale;
        }
    }
}
