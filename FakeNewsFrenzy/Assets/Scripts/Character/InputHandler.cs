using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Movement _Movement;
    private UIControler _UIctrl;
    private PlayerInput _PlayerInput;

    [SerializeField] private InputActionReference _ShootAction;



    private bool ReviveKeyPress= false;

    private void Start()
    {
        _PlayerInput = GetComponent<PlayerInput>();
        if (_PlayerInput.currentActionMap.ToString().Contains("MainMenu"))
        {
            UIControler[] ctrls = FindObjectsOfType<UIControler>();
            int index = _PlayerInput.playerIndex;
            _UIctrl = ctrls.FirstOrDefault(m => m.GetControllerIndex() == index);
            GameInputManager.inputDevices[index] = _PlayerInput.devices[0];
        } else
        {
            Movement[] movers = FindObjectsOfType<Movement>();
            int index = _PlayerInput.playerIndex;
            _Movement = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);
            _Movement.GetComponent<PlayerLife>().myIH = this;
        }
    }

    private void Update()
    {
    }

    public void OnMove(InputAction.CallbackContext obj)
    {
        if (_Movement != null)
        {
            _Movement.SetDirVector(new Vector3(obj.ReadValue<Vector2>().x, 0, obj.ReadValue<Vector2>().y));
            _Movement.canMoveWithMouse = obj.control.ToString().Contains("Keyboard");
        }
    }
    
    public void OnRoll(InputAction.CallbackContext obj)
    {
        if(obj.canceled) return;
        if (_Movement != null) _Movement.SetRoll();
    }

    public void OnPush(InputAction.CallbackContext obj)
    {
        if (_Movement != null) _Movement.GetComponent<PushAttack>().OnAttack();
    }

    public void OnLook(InputAction.CallbackContext obj)
    {
        if(_Movement != null)
        {
            if (_Movement.canMoveWithMouse) return;
            _Movement.MakePlayerLookAt(obj.ReadValue<Vector2>());
        }
    }

    public void onShoot(InputAction.CallbackContext obj)
    {
        if (_Movement != null)
        {
            WeaponHandler wp = _Movement.GetComponentInChildren<WeaponHandler>();

            if (wp == null) return;

            _Movement.GetComponentInChildren<WeaponHandler>().isShooting = obj.ReadValue<float>() > 0;
        }
    }

    public void OnEquip(InputAction.CallbackContext obj)
    {
        if (_Movement != null)
        {
            _Movement.GetComponent<EquipWeapon>().EquipNewWeapon(_PlayerInput.playerIndex);
        }
    }

    public void OnRevive(InputAction.CallbackContext obj)
    {
        ReviveKeyPress = obj.performed;
    }

    public bool GetReviveKey()
    {
        return ReviveKeyPress;
    }

    public void OnSelectMenu(InputAction.CallbackContext obj)
    {
        if(_UIctrl != null)
        {
            _UIctrl.SelectMenu(obj.canceled);
        }
    }

    public void LeftSelectWeapon(InputAction.CallbackContext obj)
    {
        if (_UIctrl)
        {
            _UIctrl.LeftWeaponSelect();
        }
    }
    
    public void RightSelectWeapon(InputAction.CallbackContext obj)
    {
        if (!obj.started) return;
        if (_UIctrl)
        {
            _UIctrl.RightWeaponSelect();
        }
    }

    public void ValidWeapon(InputAction.CallbackContext obj)
    {
        if(!obj.started) return;
        if (_UIctrl)
        {
            _UIctrl.ValidWeapon();
        }
    }



}
