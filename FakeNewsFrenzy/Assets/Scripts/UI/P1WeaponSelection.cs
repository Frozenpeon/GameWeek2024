using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1WeaponSelection : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    [SerializeField] private Sprite[] weaponsSprites;
    [SerializeField] private Image weaponImg;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        leftButton.onClick.AddListener(DecrementArray);
        rightButton.onClick.AddListener(IncrementArray);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DecrementArray()
    {
        if (index == 0)
            index = weaponsSprites.Length - 1;
        else
            index--;

        UpdateImage();
    }
    private void UpdateImage()
    {
        weaponImg.sprite = weaponsSprites[index];
    }

    private void IncrementArray()
    {
        if (index == (weaponsSprites.Length - 1))
            index = 0;
        else
            index++;

        UpdateImage();
    }
}
