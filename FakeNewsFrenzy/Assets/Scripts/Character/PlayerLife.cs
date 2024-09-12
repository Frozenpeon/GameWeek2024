using System.Collections;
using System.Drawing;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int _StartLifePoint = 2;
    [SerializeField] private float _InvicibleTime = 3;
    [SerializeField] private Collider _ReviveZoneCollider;
    private int _LifePoint;

    [HideInInspector] public InputHandler myIH;

    [SerializeField] private Transform spriteContainer;

    private bool isInvicible = false;

    private Coroutine blinkCoroutine;

    private Transform _currentSprite;

    private void Start()
    {
        _LifePoint = _StartLifePoint;
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            LoseLifePoint();
        }
    }

    public int GetLifePoint()
    {
        return _LifePoint;
    }

    public void LoseLifePoint()
    {
        if (isInvicible || _LifePoint <= 0) return;

        if(--_LifePoint == 0)
        {
            //Mort
            Debug.Log("Tié mort le sang");
            GetComponent<Movement>().spriteChanger.ShowDeath();
            GetComponent<Movement>().enabled = false;
            _ReviveZoneCollider.enabled = true;

            return;
        }

        //Dégats
        Debug.Log("Tu t'es pris un dégats chakal, prudence est mère de sureté n'oublie jamais");

        StartCoroutine(WaitInvicible());
        blinkCoroutine = StartCoroutine(BlinkPlayer());
    }

    public void Revive()
    {
        _ReviveZoneCollider.enabled = false;
        GetComponent<Movement>().enabled = true;
        GetComponent<Movement>().spriteChanger.ShowWeapon();
        _LifePoint = _StartLifePoint;
    }

    IEnumerator WaitInvicible()
    {
        isInvicible = true;
        yield return new WaitForSeconds(_InvicibleTime);
        isInvicible = false;
    }

    IEnumerator BlinkPlayer()
    {
        Transform child = null;

        UnityEngine.Color color;
        float _count = 0;
        while(true)
        {
            foreach (Transform pChild in spriteContainer)
            {
                if (pChild.gameObject.activeInHierarchy)
                {
                    child = pChild;
                    break;
                }
            }
            color = child.GetComponent<Renderer>().material.color;
            child.GetComponent<Renderer>().material.color = new UnityEngine.Color(color.r, color.g, color.b, Mathf.Lerp(1f, .5f, Mathf.Cos(_count * 5) / 2 + .5f));
            _count += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == _ReviveZoneCollider) return;
        if (other.TryGetComponent(out ReviveZone pRz))
        {
            if (myIH.GetReviveKey()) pRz.SetModeRevive();
            else pRz.SetModeUnRevive();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == _ReviveZoneCollider) return;
        if (other.TryGetComponent(out ReviveZone pRz))
        {
            pRz.SetModeUnRevive();
        }
    }






}
