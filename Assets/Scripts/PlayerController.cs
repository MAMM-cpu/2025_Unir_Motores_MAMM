using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float speedRotation = 180f;

    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference rotate;
    [SerializeField] Rigidbody rb;
    [SerializeField] Death dead;

    Vector2 rawMove = Vector2.zero;
    Vector2 rawRotation = Vector2.zero;

    InputAction interact;

    PlayerTrigger playerTrigger;


    private void Start()
    {
        playerTrigger = GetComponent<PlayerTrigger>();

        interact = new InputAction();
        interact = InputSystem.actions.FindAction("Interact");
        
    }

    private void OnEnable()
    {
        move.action.Enable();
        rotate.action.Enable();

        move.action.started += OnMove;
        move.action.performed+= OnMove;
        move.action.canceled += OnMove;

        rotate.action.started += OnRotate;
        rotate.action.performed+= OnRotate;
        rotate.action.canceled += OnRotate;
    }

    private void Update()
    {
        if (dead.isDead) return;
        Vector3 moveToApply = new Vector3(0f, 0f, rawMove.y) * speed * Time.deltaTime;
        transform.Translate(moveToApply);
        Vector3 rotateToApply = new Vector3(0f, rawRotation.x, 0f) * speedRotation * Time.deltaTime;
        transform.Rotate(rotateToApply);

        playerTrigger.pressed = interact.WasPressedThisFrame();
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
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        rawMove = context.ReadValue<Vector2>();
    }

    private void OnRotate(InputAction.CallbackContext context)
    {
        rawRotation = context.ReadValue<Vector2>();
    }

    public void OnDeath()
    {
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true;
    }

    public void OnRespawn()
    {
        rb.isKinematic = false;
    }
}
