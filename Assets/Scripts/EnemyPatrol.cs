using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPatrol : MonoBehaviour
{
    private NavMeshAgent agent;
    public float x1;
    public float y1;
    public float z1;
    public float x2;
    public float y2;
    public float z2;

    private Vector3 position1;
    private Vector3 position2;
    private string target = "position1";
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        position1 = new Vector3(x1, y1, z1);
        position2 = new Vector3(x2, y2, z2);
    }

    void Update()
    {
        if (target == "position1")
        {
            agent.SetDestination(position1);
            agent.stoppingDistance = 0.1f;
            if (Vector3.Distance(transform.position, position1) < 1f) target = "position2";
        }
        else
        {
            agent.SetDestination(position2);
            agent.stoppingDistance = 0.1f;
            if (Vector3.Distance(transform.position, position2) < 1f) target = "position1";
        }

    }
}
