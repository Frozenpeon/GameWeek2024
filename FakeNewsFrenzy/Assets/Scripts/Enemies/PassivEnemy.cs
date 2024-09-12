using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassivEnemy : MonoBehaviour
{
    public List<Sprite> sprites;

    public SpriteRenderer spriteRenderer;

    Coroutine corou;

    private void Start()
    {
        corou = StartCoroutine(idle());
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
