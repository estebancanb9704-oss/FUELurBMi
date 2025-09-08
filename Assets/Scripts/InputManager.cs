using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour 
{
    private PlayerInput playerInpuit;
    public PlayerInput.OnFootActions OnFoot;

    private PlayerMotor motor;
    private PlayerLook look;

     private void Awake() {
        playerInpuit = new PlayerInput();
        OnFoot = playerInpuit.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        OnFoot.Jump.performed += ctx => motor.Jump(); 
    }

    private void FixedUpdate() {
       motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate() {
        look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable() {
        OnFoot.Enable();
    }

    private void OnDisable() {
        OnFoot.Disable();
    }
}
