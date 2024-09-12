using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemySprites : MonoBehaviour
{
    public Sprite Aggro;

    public List<Sprite> chill = new List<Sprite>();

    public Sprite melee;

    public Sprite meleeAttack;

    public SpriteRenderer ShowedSprite;

    private Coroutine Coroutine;

    private void Awake()
    {
        Coroutine = StartCoroutine(Iddle());
    }

    private void Start()
    {
        //ShowedSprite.sprite = chill[0];    
    }

    int i = 0;
    private IEnumerator Iddle()
    {
        while (true)
        {
            ShowedSprite.sprite = chill[i % 3];
            i++;
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator Melee()
    {
        ShowedSprite.sprite = meleeAttack;
        yield return new WaitForSeconds(0.2f);
        ShowedSprite.sprite = melee;
    }

    public void ShowAggro()
    {
        StopAllCoroutines();
        StopCoroutine(Coroutine);
        ShowedSprite.sprite = Aggro;
    }

    public void ShowMeleAttack()
    {
        StopAllCoroutines();
        StopCoroutine(Coroutine);
        Coroutine = StartCoroutine(Melee());
    }

    public void ShowMele()
    {
        StopAllCoroutines();
        StopCoroutine(Coroutine);
        ShowedSprite.sprite = melee;
    }
}
