using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shoot;
    [SerializeField] InputActionReference jump;

    Vector2 rawMove = Vector2.zero;

    private void OnEnable()
    {
        move.action.Enable();
        shoot.action.Enable();
        jump.action.Enable();

        jump.action.started += __OnJump;

        move.action.started += __OnMove;
        move.action.performed+= __OnMove;
        move.action.canceled += __OnMove;
    }

    float verticalSpeed = 0f;
    private void Update()
    {

        if (mustJump)
        {
            mustJump = false;
            verticalSpeed = 10f;
        }

        Vector3 moveToApply = new Vector3(rawMove.x, 0f, rawMove.y) * speed * Time.deltaTime;
        transform.Translate(moveToApply);
    }

    private void OnDisable()
    {
        move.action.started += __OnMove;
        move.action.performed += __OnMove;
        move.action.canceled += __OnMove;

        jump.action.started += __OnJump;

        move.action.Disable();
        shoot.action.Disable();
        jump.action.Disable();

    }

    private void __OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.ReadValue<Vector2>();
        Debug.Log(context.control.device.name);
        Debug.Log(rawMove);
    }

    bool mustJump = false;
    private void __OnJump(InputAction.CallbackContext context) 
    {
        mustJump = context.ReadValueAsButton();
        Debug.Log(context.control.device.name);
    }

    /*void OnMove(InputValue value)
    {
        rawMove = value.Get<Vector2>();
        Debug.Log(rawMove);
    }

    void OnJump(InputValue value)
    {
        mustJump = true;
        Debug.Log("jump");
    }*/
}
