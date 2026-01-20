using System;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        bool doorTriggered = false;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("DoorTrigger"))
            {
                Debug.Log("Puerta");
                doorTriggered = true;
                //detectedCanvas.gameObject.SetActive(true);
            }
        }

    }
}
