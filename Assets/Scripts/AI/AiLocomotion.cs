using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiLocomotion : MonoBehaviour
{
    NavMeshAgent agent;
    //[SerializeField] Animator animator;
    [SerializeField] Transform playerTransform;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = playerTransform.position;

        /*if (agent.hasPath)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }*/
    }
}