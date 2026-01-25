using TMPro;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [HideInInspector] public bool press = false;

    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] float textDuration = 2f;

    private bool[] initialState;

    float textTimer;
    bool textActive = false;

    private void Awake()
    {
        initialState = new bool[doors.Length];
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i] != null)
                initialState[i] = doors[i].activeSelf;
        }
        infoText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (press)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                if (doors[i].activeSelf)
                {
                    doors[i].SetActive(false);
                    press = false;
                }
                else
                {
                    doors[i].SetActive(true); 
                    press = false;
                }
            }
            ShowText("Interruptor activado");
        }
        if (textActive)
        {
            textTimer -= Time.deltaTime;

            if (textTimer <= 0f)
            {
                infoText.gameObject.SetActive(false);
                textActive = false;
            }
        }
    }

    public void ResetDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i] != null)
                doors[i].SetActive(initialState[i]);
        }
    }

    void ShowText(string message)
    {
        if (infoText == null) return;

        infoText.text = message;
        infoText.gameObject.SetActive(true);
        textTimer = textDuration;
        textActive = true;
    }
}
