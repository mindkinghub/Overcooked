using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnOperateAction;
    private GameControl gameControl;

    private void Awake()
    {
        gameControl = new GameControl();
        gameControl.Player.Enable();
        gameControl.Player.Interact.performed += Interact_performed;
        gameControl.Player.Operate.performed += Operate_performed;
    }

    private void Operate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnOperateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 GetMovementDirectionNormalized()
    {
        Vector2 inputVector2= gameControl.Player.Move.ReadValue<Vector2>();
       
        Vector3 direction = new Vector3(inputVector2.x, 0, inputVector2.y);

        direction = direction.normalized;
        return direction;
    }
}
