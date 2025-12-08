using System.Net.NetworkInformation;
using UnityEngine;
//using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 5f;
    public float rotateSpeed = 100f;

    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

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

    }
}
