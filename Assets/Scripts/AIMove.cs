using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    public Transform[] markers;
    NavMeshAgent agent;
    public bool currentDestination;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.2)
        {
            Transform destination = markers[0];
            if (currentDestination) destination = markers[1];
            agent.destination = destination.position;
            currentDestination = !currentDestination;
        }
    }
}
