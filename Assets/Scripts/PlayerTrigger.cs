using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] float radio = 1.2f;
    [SerializeField] Death dead;

    [HideInInspector] public bool pressed = false;

    void Update()
    {
        if (dead.isDead) return;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("DoorTrigger") && pressed)
            {
                DoorTrigger doorTrigger = hit.collider.GetComponent<DoorTrigger>();
                doorTrigger.press = pressed;
            }
            if (hit.collider.CompareTag("TriggerShoot"))
            {
                TrapTrigger trap = hit.collider.GetComponentInParent<TrapTrigger>();
                trap.setLook(true);
            }
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, radio);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("TrapTriggerFloor"))
            {
                TrapTrigger trapTrigger = colliders[i].GetComponent<TrapTrigger>();
                trapTrigger.DesactiveGround();
            }

            if (colliders[i].CompareTag("TrapTriggerOnRoof"))
            {
                Roof roof = colliders[i].GetComponentInParent<Roof>();
                roof.move = true;
            }
            if (colliders[i].CompareTag("TrapTriggerOffRoof"))
            {
                Roof roof = colliders[i].GetComponentInParent<Roof>();
                roof.move = false;
            }
            if (colliders[i].CompareTag("TriggerDeath"))
            {
                dead.DeathCanvasOn();
            }
            if (colliders[i].CompareTag("TriggerShoot"))
            {
                TrapTrigger trap = colliders[i].GetComponentInParent<TrapTrigger>();
                trap.setStep(true);
            }

        }
    }

    public void setPressed(bool p)
    {
        pressed = p;
    }
}
