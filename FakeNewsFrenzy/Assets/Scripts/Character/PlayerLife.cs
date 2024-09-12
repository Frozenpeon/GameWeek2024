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

    private bool isInvicible = false;

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
        float pCount = 0;
        UnityEngine.Color color = GetComponent<Renderer>().material.color;
        isInvicible = true;
        while (pCount < _InvicibleTime)
        {
            yield return null;
            GetComponent<Renderer>().material.color = new UnityEngine.Color(color.r,color.g, color.b,Mathf.Lerp(1f, .5f, Mathf.Cos(pCount * 5) / 2 + .5f));
            pCount += Time.deltaTime;
        }
        isInvicible = false;
        GetComponent<Renderer>().material.color = new UnityEngine.Color(color.r, color.g, color.b, 1.0f);
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
