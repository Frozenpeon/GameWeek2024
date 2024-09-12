using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{
    [SerializeField] private int ControlerIndex = -1;
    [SerializeField] private TitleScreen titleScreen;
    [SerializeField] private Button leftWeapponSelect;
    [SerializeField] private Button rightWeapponSelect;


    public int GetControllerIndex()
    {
        return ControlerIndex;
    }

    public void SelectMenu(bool canceled)
    {
        titleScreen.OnSelectMenu(canceled);
    }

    public void LeftWeaponSelect()
    {
        if (leftWeapponSelect.gameObject.activeInHierarchy)
        {
            leftWeapponSelect.onClick.Invoke();
        }
    }
    
    public void RightWeaponSelect()
    {
        if (rightWeapponSelect.gameObject.activeInHierarchy)
        {
            rightWeapponSelect.onClick.Invoke();
        }
    }

    public void ValidWeapon()
    {
    }
}
