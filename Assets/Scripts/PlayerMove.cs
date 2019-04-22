using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent agent;
    private Camera cam;
    private GameObject followedObject;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
        animator = transform.Find("Douglas").gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (followedObject != null) followedObject = null;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Walkable")
                {
                    animator.SetBool("isWalking", true);
                    agent.SetDestination(hit.point);
                    agent.stoppingDistance = 0.1f;

                }

            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    animator.SetBool("isWalking", true);
                    followedObject = hit.collider.transform.parent.gameObject;
                }
                else if (hit.collider.gameObject.tag == "Walkable")
                {
                    animator.SetBool("isWalking", true);
                    if (followedObject != null) followedObject = null;
                    agent.SetDestination(hit.point);
                    agent.stoppingDistance = 0.1f;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger("isJumping");

        if (followedObject != null)
        {
            agent.SetDestination(followedObject.transform.position);
            agent.stoppingDistance = 0.1f;
        }

        if (Vector3.Distance(agent.destination, transform.position) < 0.5f)
        {
            animator.SetBool("isWalking", false);
        }
    }
}
