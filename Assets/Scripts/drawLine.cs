using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(LineRenderer))]
public class drawLine : MonoBehaviour
{
    /**
        nepoužívá se, byly s polem
    */

    private LineRenderer lineRenderer;
    public NavMeshAgent agent;

    // vykreslení čáry
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.15f;
        lineRenderer.endWidth = 0.15f;
        lineRenderer.positionCount = 0;

    }
    // vytvoření bodů, pomoci kterých se vykresluje čára
    void Update()
    {
        lineRenderer.positionCount = agent.path.corners.Length;
        lineRenderer.SetPosition(0, transform.position);

        if(agent.path.corners.Length < 2)
        {
            return;
        }

        for(int i = 2; i < agent.path.corners.Length; i++)
        {
            Vector3 pointPosition = new Vector3(agent.path.corners[i].x, agent.path.corners[i].y, agent.path.corners[i].z);
            lineRenderer.SetPosition(i, pointPosition);
        }
    }
}
