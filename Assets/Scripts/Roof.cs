using UnityEngine;

public class Roof : MonoBehaviour
{

    //[SerializeField] float startSpeed = 1f;

    Vector3 velocity = Vector3.down;

    [SerializeField] TrapTrigger tggr;
    [SerializeField] GameObject player;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject ground;


    void Update()
    {

        Collider[] colider = Physics.OverlapBox(transform.position, transform.localScale);
        if (tggr.move == true)
        {
            wall.SetActive(true);
            transform.position += velocity * Time.deltaTime;
        }

        for (int i = 0; i < colider.Length; i++)
        {
            if (colider[i].CompareTag("Ground") || colider[i].CompareTag("Player"))
            {
                tggr.move = false;
            }
        }
    }
}
