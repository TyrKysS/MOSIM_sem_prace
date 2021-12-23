using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DrawLine2 : MonoBehaviour
{
    private Rigidbody rb;
    private NavMeshAgent agent;
    private LineRenderer line;
    private List<Vector3> point;
    // načtení komponent
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        line = GetComponent<LineRenderer>();
    }

    // vykreslení čárý ukazující směr kudyma agent jde
    void Update()
    {
        line.positionCount = agent.path.corners.Length;
        line.SetPositions(agent.path.corners);
    }
}
