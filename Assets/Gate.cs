using System;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool unexploded;

    public GameObject gatePieces;
    private GameObject player;

    private Vector3 blastDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        unexploded = true;
    }

    void Explode()
    {
        unexploded = false;
        blastDirection = transform.position - player.transform.position;
        GameObject gate2 = Instantiate(gatePieces, transform.position, transform.rotation);
        Destroy(gameObject);
        foreach (Rigidbody rb in gate2.GetComponentsInChildren<Rigidbody>())
        {
            rb.AddForce(blastDirection * 10, ForceMode.Impulse);
        }
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (unexploded && other.CompareTag("Brick"))
        {
            player = other.gameObject;
            Explode();
        }
    }
}
