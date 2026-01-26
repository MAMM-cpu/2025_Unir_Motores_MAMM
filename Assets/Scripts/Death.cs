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
    [SerializeField] TMPro.TextMeshProUGUI endText;
    [SerializeField] Color deathColor = Color.red;
    [SerializeField] Color winColor = Color.green;

    [HideInInspector] public bool isDead = false;
    bool isVictory = false;

    private float cinematicTimer = 0f;

    private void Update()
    {
        if (!isDead) return;
        cinematicTimer -= Time.deltaTime;

        if (cinematicTimer <= 0f)
        {
            if (!isVictory)
            {
                ResetLevel();
                isDead = false;
            }
            deathCanvas.SetActive(false);
        }
    }

    
    public void DeathCanvasOn()
    {
        if (isDead) return;

        isVictory = false;
        isDead = true;
        player.GetComponent<PlayerController>().OnDeath();

        endText.text = "You Are Dead";
        endText.color = deathColor;

        deathCanvas.SetActive(true);
        cinematicTimer = cinematicDuration;
    }
    public void Victory()
    {
        if (isDead) return;

        isVictory = true;
        isDead = true;  
        player.GetComponent<PlayerController>().OnDeath();

        endText.text = "Victory";
        endText.color = winColor;

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
        roofScript.ResetWall();
    }
}
