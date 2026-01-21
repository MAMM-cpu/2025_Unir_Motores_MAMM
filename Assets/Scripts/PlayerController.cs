using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float speedRotation = 360f;

    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference rotate;
    [SerializeField] InputActionReference interact;

    Vector2 rawMove = Vector2.zero;
    Vector2 rawRotation = Vector2.zero;

    private void OnEnable()
    {
        move.action.Enable();
        rotate.action.Enable();
        //interact.action.Enable();

        move.action.started += OnMove;
        move.action.performed+= OnMove;
        move.action.canceled += OnMove;

        rotate.action.started += OnRotate;
        rotate.action.performed+= OnRotate;
        rotate.action.canceled += OnRotate;
    }

    private void Update()
    {
        Vector3 moveToApply = new Vector3(0f, 0f, rawMove.y) * speed * Time.deltaTime;
        transform.Translate(moveToApply);
        Vector3 rotateToApply = new Vector3(0f, rawRotation.x, 0f) * speedRotation * Time.deltaTime;
        transform.Rotate(rotateToApply);

        //Vector3 moveToApply = new Vector3(rawMove.x, 0f, rawMove.y) * speed * Time.deltaTime;
        //transform.Translate(moveToApply);
        //Vector3 rotateToApply = new Vector3(rawRotation.x, 0f, rawRotation.y) * speedRotation * Time.deltaTime;
        //transform.Rotate(rotateToApply);
    }

    private void OnDisable()
    {
        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

        rotate.action.started += OnRotate;
        rotate.action.performed += OnRotate;
        rotate.action.canceled += OnRotate;


        move.action.Disable();
        rotate.action.Disable();
        //interact.action.Disable();

    }

    private void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.ReadValue<Vector2>();
        //Debug.Log(context.control.device.name);
        //Debug.Log(rawMove + " mover");
    }

    private void OnRotate(InputAction.CallbackContext context)
    {
        rawRotation = context.ReadValue<Vector2>();
        //Debug.Log(context.control.device.name);
        //Debug.Log(rawRotation + " rotar");
    }

   /* private void OnTriggerEnter(Collider other)
    {
        
    }*/
}
