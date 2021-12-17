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
    public static float fitness = 0.5f;
    private float speedEnergy = 0.5f;
    public static float age = 5f;
    
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    void Update()
    {
        agent.speed = speed;
        speedEnergy = fitness;
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        //Debug.Log(toggle.name+" _ "+toggle.GetComponentInChildren<Text>().text);
        direction = toggle.name;
        //Debug.Log(direction);
       // Debug.Log(distance);
        Debug.Log(speedEnergy);
        
        if(speed == 0)
        {
            agent.isStopped = true;
        }
        else if(direction == "Pub" && distance > 1.2 && StaminaBar.hasStamina == true)
        {
            agent.isStopped = false;
            agent.SetDestination(pub.position);
            distance = Vector3.Distance(agent.transform.position,pub.transform.position);
            StaminaBar.instance.useStamina(speedEnergy);
            
        }
        else if(direction == "Grandma" && distance > 1.2 && StaminaBar.hasStamina == true)
        {
            agent.isStopped = false;
            agent.SetDestination(grandma.position);
            distance = Vector3.Distance(agent.transform.position,grandma.transform.position);
            StaminaBar.instance.useStamina(speedEnergy);
        }
        else if(StaminaBar.hasStamina == false)
        {
            agent.isStopped = true;
        }

        
    }
}
