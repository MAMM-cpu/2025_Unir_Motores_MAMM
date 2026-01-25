using UnityEngine;

public class TrapTrigger : MonoBehaviour
{

    [SerializeField] public GameObject ground;

    bool lookTrigger;
    bool stepTrigger;
    Death dead;

    private void Awake()
    {
        dead = FindAnyObjectByType<Death>();
    }

    void Death()
    {
        if (dead.isDead) return;
        if (lookTrigger && stepTrigger)
        {
            dead.DeathCanvasOn();
            lookTrigger = false;
            stepTrigger = false;
        }
    }

    public void setLook(bool look)
    {
        lookTrigger = look;
        Death();
    }
    public void setStep(bool step)
    {
        stepTrigger = step;
        Death();
    }

    public void DesactiveGround()
    {
        ground.SetActive(false);
    }
}
