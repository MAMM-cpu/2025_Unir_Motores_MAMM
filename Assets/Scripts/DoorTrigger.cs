using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("DoorTrigger") /*&& Input.GetKeyDown(KeyCode.E)*/)
            {
                door.SetActive(false);
                Debug.Log("Puerta");
                //detectedCanvas.gameObject.SetActive(true); 
            }
        }

    }
}
