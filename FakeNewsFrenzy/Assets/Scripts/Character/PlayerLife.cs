using System.Collections;
using System.Drawing;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int _StartLifePoint = 2;
    [SerializeField] private float _InvicibleTime = 3;
    private bool isInvicible = false;

    public void LoseLifePoint()
    {
        if (isInvicible) return;

        if(--_StartLifePoint == 0)
        {
            //Mort
            Debug.Log("Tié mort le sang");
            GetComponent<Movement>().enabled = false;
            return;
        }

        //Dégats
        Debug.Log("Tu t'es pris un dégats chakal, prudence est mère de sureté n'oublie jamais");

        StartCoroutine(WaitInvicible());
    }

    IEnumerator WaitInvicible()
    {
        float pCount = 0;
        UnityEngine.Color color = GetComponent<Renderer>().material.color;

        while (pCount < _InvicibleTime)
        {
            yield return null;
            GetComponent<Renderer>().material.color = new UnityEngine.Color(color.r,color.g, color.b,Mathf.Lerp(1f, .5f, Mathf.Cos(pCount * 5) / 2 + .5f));
            pCount += Time.deltaTime;
        }
        isInvicible = false;
        GetComponent<Renderer>().material.color = new UnityEngine.Color(color.r, color.g, color.b, 1.0f);
    }
}
