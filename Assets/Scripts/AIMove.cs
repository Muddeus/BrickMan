using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class AIMove : MonoBehaviour
{
    public Transform[] markers;
    private int destPoint = 0;
    NavMeshAgent agent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;
    }

    void MoveToMarkers()
    {
        
    }
}
