using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    public event EventHandler OnInteractAction;
    public event EventHandler OnOperateAction;
    public event EventHandler OnInteractAction2;
    public event EventHandler OnOperateAction2;
    public event EventHandler OnPauseAction;
    private GameControl gameControl;
    private bool isPlayer1 = true; // 默认玩家1

    private void Awake()
    {
        Instance = this;
        gameControl = new GameControl();
        gameControl.Player.Enable();
        gameControl.Player.Interact.performed += Interact_performed;
        gameControl.Player.Operate.performed += Operate_performed;
        gameControl.Player.Interact2.performed += Interact2_performed;
        gameControl.Player.Operate2.performed += Operate2_performed;
        gameControl.Player.Pause.performed += Pause_performed;
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void Operate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnOperateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    private void Operate2_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnOperateAction2?.Invoke(this, EventArgs.Empty);
    }

    private void Interact2_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction2?.Invoke(this, EventArgs.Empty);
    }

    // 设置当前控制的玩家（在Player脚本中调用）
    public void SetPlayer(bool isPlayerOne)
    {
        isPlayer1 = isPlayerOne;
    }
    public Vector3 GetMovementDirectionNormalized()
    {
        Vector2 inputVector;

        if (isPlayer1)
        {
            // 玩家1：WASD
            inputVector = gameControl.Player.Move.ReadValue<Vector2>();
        }
        else
        {
            // 玩家2：方向键
            inputVector = gameControl.Player.ArrowKeysMove.ReadValue<Vector2>();
        }

        return new Vector3(inputVector.x, 0, inputVector.y).normalized;
    }
}
