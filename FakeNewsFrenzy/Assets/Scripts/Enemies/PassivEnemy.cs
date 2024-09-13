using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassivEnemy : MonoBehaviour
{
    public List<Sprite> sprites;

    public Sprite plot;

    public SpriteRenderer spriteRenderer;

    Coroutine corou;

    public bool isTyping = true;


    private void Start()
    {
        i = Random.Range(0, 3);
        if (isTyping)
            corou = StartCoroutine(idle());
        else
            spriteRenderer.sprite = plot;
    }

    int i = 0;
    public IEnumerator idle()
    {    
            while (true)
            {
            spriteRenderer.sprite = sprites[i % sprites.Count];
                i++;
                yield return new WaitForSeconds(0.2f);
            }      
    }
}
