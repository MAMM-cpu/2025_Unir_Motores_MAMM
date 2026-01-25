using UnityEngine;

public class Roof : MonoBehaviour
{

    [SerializeField] GameObject wall;
    [SerializeField] public Transform roofMesh;
    [SerializeField] public Transform roofCollider;
    [SerializeField] Death dead;

    [HideInInspector] public Vector3 roofStart;
    
    Vector3 velocity = Vector3.down;

    public bool move = false;

    private void Awake()
    {
        roofStart = roofCollider.position;

    }

    void Update()
    {
        if (dead.isDead) return;

        Collider[] colider = Physics.OverlapBox(roofCollider.position, roofCollider.localScale / 2);
        if (move == true)
        {
            wall.SetActive(true);
            roofMesh.position += velocity * Time.deltaTime;
            roofCollider.position += velocity * Time.deltaTime;

            for (int i = 0; i < colider.Length; i++)
            {
                if (colider[i].CompareTag("Ground") || colider[i].CompareTag("Player"))
                {
                    move = false;
                }
            }
        }
    }
}
