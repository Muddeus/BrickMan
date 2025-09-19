using UnityEngine;
using UnityEngine.AI;

public class AIDeath : MonoBehaviour
{
    Rigidbody rb;
    public AIMove aIMove;
    public NavMeshAgent navMesh;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aIMove = GetComponent<AIMove>();
        navMesh = GetComponent<NavMeshAgent>();

    }

    private void OnCollisionEnter(Collision other)
    {
        print("hit");

        if (other.gameObject.CompareTag("Brick"))
        {
            Destroy(navMesh);
            rb.AddForce(Vector3.down * 0.5f, ForceMode.Impulse);
            print("brick hit");
        }
    }

}
