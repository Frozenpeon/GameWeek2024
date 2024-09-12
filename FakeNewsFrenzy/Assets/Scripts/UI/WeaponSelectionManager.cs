using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSelectionManager : MonoBehaviour
{
    private bool[] _IsWeaponsValid = new bool[2] {false, false };

    public static WeaponType[] weapons = new WeaponType[2] { WeaponType.Pistol, WeaponType.Pistol};

    public void SetWeaponValidValue(int pIndex)
    {
        _IsWeaponsValid[pIndex] = !_IsWeaponsValid[pIndex];

        if (_IsWeaponsValid[0] && _IsWeaponsValid[1])
        {
            SceneManager.LoadScene(1);
        }
    }
}
