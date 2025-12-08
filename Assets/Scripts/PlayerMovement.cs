using System.Net.NetworkInformation;
using UnityEngine;
//using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 15f;
    public float rotateSpeed = 100f;

    //transform.RotateAround(Vector3.zero, Vector3.up, gradosPorSegundo* Time.deltaTime)

    //private PlayerInput playerInput;
    //private bool isTriggered = false;

    private void Awake()
    {
        controller = this.GetComponent<CharacterController>();
        //playerInput = this.GetComponent<PlayerInput>(); 
    }

    void Start()
    {
        //playerInput.actions["WASD"].started += StartTriggering;
        //playerInput.actions["WASD"].canceled += StopTriggering;
    }

    /*public void StartTriggering(InputAction.CallbackContext context)
    {
        isTriggered = true;
    }
    public void StopTriggering(InputAction.CallbackContext context)
    {
        isTriggered = false;
    }*/
  
    void Update()
    {
        //Movimiento
        float vertical = Input.GetAxis("Vertical");

        //Transforma el movimiento
        Vector3 movement = transform.TransformDirection(Vector3.forward) * vertical;

        //Velocidad de movimiento
        controller.Move(movement * speed * Time.deltaTime);

        //Rotacion
        float horizontal = Input.GetAxis("Horizontal");
        
        //Velocidad de rotacion
        transform.Rotate(0f, horizontal * rotateSpeed * Time.deltaTime, 0f);



        /*if (isTriggered)
        {
            Vector2 vector = playerInput.actions["WASD"].ReadValue<Vector2>();
            Vector3 movement = new Vector3(vector.x * speed, 0, vector.y * speed);
            controller.SimpleMove(movement);
        }*/
    }
}
