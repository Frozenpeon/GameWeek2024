using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Movement _Movement;
    private PlayerInput _PlayerInput;

    private void Start()
    {
        _PlayerInput = GetComponent<PlayerInput>();
        Movement[] movers = FindObjectsOfType<Movement>();
        int index = _PlayerInput.playerIndex;
        _Movement = movers.FirstOrDefault(m => m.GetPlayerIndex() == index);

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


}
