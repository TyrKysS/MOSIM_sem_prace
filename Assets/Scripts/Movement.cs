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
    public static float sliderSpeed = 0;
    private float speedEnergy = 0.5f;
    public static float sliderAge = 5f;
    private float age = 0;
    
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    void Update()
    {
        if(sliderAge < 20)
            age = 0.3f;
        if(sliderAge >= 20 && sliderAge < 40)
            age = 0.1f;
        if(sliderAge >= 40 && sliderAge < 60)
            age = 0.5f;
        if(sliderAge >= 60)
            age = 0.8f;
        speedEnergy = sliderSpeed*age;
        agent.speed = sliderSpeed*5;
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        direction = toggle.name;
        
        if(agent.speed == 0 || StaminaBar.hasStamina == false)
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
    }
}
