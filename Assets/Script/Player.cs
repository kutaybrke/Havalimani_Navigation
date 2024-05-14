using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private NavMeshAgent agent;
    private LineRenderer line;
    private List<Vector3> point;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        line = GetComponent<LineRenderer>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                animator.SetBool("isWalking", true);
            }
        }
        else
            {
                animator.SetBool("isWalking",agent.velocity.magnitude>0);
            }
        DisplayLineDestination();
    }

    private void DisplayLineDestination()
    {
        if (agent.path.corners.Length < 2) return;

        int i = 1;
        while (i < agent.path.corners.Length)
        {
            line.positionCount = agent.path.corners.Length;
            point = agent.path.corners.ToList();
            for (int j = 0; j < point.Count; j++)
            {
                line.SetPosition(j, point[j]);
            }
            i++;
        }
    }
}
