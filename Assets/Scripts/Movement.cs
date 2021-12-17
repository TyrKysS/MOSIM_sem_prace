using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform pub;
    public Transform grandma;
    ToggleGroup toggleGroup;
    private string direction = "";
    private float distance = 5;
    public static float speed = 0;
    
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    void Update()
    {
        agent.speed = speed;

        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(toggle.name+" _ "+toggle.GetComponentInChildren<Text>().text);
        direction = toggle.name;
        Debug.Log(direction);
       // Debug.Log(distance);

        if(direction == "Pub" && distance > 1.2)
        {
            agent.SetDestination(pub.position);
            distance = Vector3.Distance(agent.transform.position,pub.transform.position);
        }
        else if(direction == "Grandma" && distance > 1.2)
        {
            agent.SetDestination(grandma.position);
            distance = Vector3.Distance(agent.transform.position,grandma.transform.position);
        }
        else
        {
            agent.Stop();
            distance = 5;
        }

        
    }
}
