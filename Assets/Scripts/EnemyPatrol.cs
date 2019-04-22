using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPatrol : MonoBehaviour
{
    public float minOnAxis=-10;
    public float maxOnAxis= 10;
    public float sufficientDistance=0.1f;

    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(IsCloseToDestination())
        {
            SetNewDestination();
        }

    }

    private void SetNewDestination()
    {
        var destination = GenerateNewDestination();
        agent.SetDestination(destination);
    }

    private Vector3 GenerateNewDestination()
    {
        var x = GenerateRandomFloat();
        var y = 1f;
        var z = GenerateRandomFloat();
        return new Vector3(x, y, z);
    }

    private float GenerateRandomFloat()
    {
        return Random.Range(minOnAxis, maxOnAxis);
    }

    private bool IsCloseToDestination()
    {
        return agent.remainingDistance < sufficientDistance;
    }
}
