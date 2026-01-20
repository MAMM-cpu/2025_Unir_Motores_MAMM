using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float speedRotation = 360f;

    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference shoot;

    Vector2 rawMove = Vector2.zero;

    private void OnEnable()
    {
        move.action.Enable();
        shoot.action.Enable();

        move.action.started += OnMove;
        move.action.performed+= OnMove;
        move.action.canceled += OnMove;
    }

    private void Update()
    {
        Vector3 moveToApply = new Vector3(rawMove.x, 0f, rawMove.y) * speed * Time.deltaTime;
        transform.Translate(moveToApply);
    }

    private void OnDisable()
    {
        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;


        move.action.Disable();
        shoot.action.Disable();

    }

    private void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.ReadValue<Vector2>();
        Debug.Log(context.control.device.name);
        Debug.Log(rawMove);
    }

    /*void OnMove(InputValue value)
    {
        rawMove = value.Get<Vector2>();
        Debug.Log(rawMove);
    }*/
}
