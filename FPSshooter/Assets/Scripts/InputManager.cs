using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot= playerInput.OnFoot;
        motor=GetComponent<PlayerMotor>();
        onFoot.jump.performed += ctx => motor.JumpFNC();
        look=GetComponent<PlayerLook>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.movement.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());

    }

    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
