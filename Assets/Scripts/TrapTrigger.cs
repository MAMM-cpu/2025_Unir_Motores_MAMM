using UnityEngine;

public class TrapTrigger : MonoBehaviour
{

    [SerializeField] float radio = 1.2f;
    [SerializeField] GameObject ground;
    public bool move = false;

    void Update()
    {
        // Trigger para activar trampas del suelo y del techo
        Collider[] colliders = Physics.OverlapSphere(transform.position, radio);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("TrapTriggerFloor"))
            {
                Debug.Log("trampa activada");
                ground.SetActive(false);
            }

            if (colliders[i].CompareTag("TrapTriggerOnRoof"))
            {
                Debug.Log("trampa activada");
                move = true;
            }
            if (colliders[i].CompareTag("TrapTriggerOffRoof"))
            {
                Debug.Log("trampa desactivada");
                move = false;
            }
        }

        ////Trigger para activar trampa que disparas
        //bool doorTriggered = false;
        //if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity))
        //{
        //    if (hit.collider.CompareTag("DoorTrigger"))
        //    {
        //        Debug.Log("Puerta");
        //        doorTriggered = true;
        //        //detectedCanvas.gameObject.SetActive(true); 
        //    }
        //}

    }
}
