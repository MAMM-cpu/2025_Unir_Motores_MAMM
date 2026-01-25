using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform startPoint;
    [SerializeField] GameObject[] doors;
    [SerializeField] GameObject[] traps;
    [SerializeField] GameObject roof;
    [SerializeField] GameObject deathCanvas;
    [SerializeField] float cinematicDuration = 3f;

    [HideInInspector] public bool isDead = false;

    private float cinematicTimer = 0f;

    private void Update()
    {
        if (!isDead) return;
        cinematicTimer -= Time.deltaTime;

        if (cinematicTimer <= 0f)
        {
            ResetLevel();
            isDead = false;
            deathCanvas.SetActive(false);
        }
    }

    
    public void DeathCanvasOn()
    {
        if (isDead) return;

        isDead = true;
        player.GetComponent<PlayerController>().OnDeath();
        deathCanvas.SetActive(true);
        cinematicTimer = cinematicDuration;
    }


    public void ResetLevel()
    {
        player.position = startPoint.position;

        player.GetComponent<PlayerController>().OnRespawn();

        foreach (var door in doors)
        {
            DoorTrigger doorScript = door.GetComponent<DoorTrigger>();
            doorScript.ResetDoors();
        }

        foreach (var trap in traps)
        {
            TrapTrigger trapScript = trap.GetComponent<TrapTrigger>();
            trapScript.ground.SetActive(true);
        }

        Roof roofScript = roof.GetComponent<Roof>();
        roofScript.move = false;
        roofScript.roofCollider.position = roofScript.roofStart;
        roofScript.roofMesh.position = roofScript.roofStart;
    }
}
