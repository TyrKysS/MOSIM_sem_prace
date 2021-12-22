using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Linq;
using TMPro;



[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform treasure;
    public Transform relax;
    public static float sliderSpeed = 0;
    public static float sliderAge = 5f;
    public Camera cam;

    public TextMeshPro pathCost;
    public TextMeshPro forestCost;
    public TextMeshPro riverCost;
    public TextMeshPro riverCost2;
    public TextMeshPro bridgeCost;
    public TextMeshPro bridgesCost;
    
    ToggleGroup toggleGroup;

    private string direction = "";
    private float distance = 5;
    private float speedEnergy = 0.5f;
    private float age = 0;
    private bool isDirection = false;
    private float radius = 2f;
    private int m = 17;
    private int n = 7;
    
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }

    void Update()
    {
        int likeCamping = Skills.likeCamping ? 1 : 0;
        int likeMushroms = Skills.likeMushroms ? 1 : 0;
        int likeFishing = Skills.likeFishing ? 1 : 0;
        int likeSwimming = Skills.likeSwimming ? 1 : 0;

        int[,] a = new int[17,7]
        {//táboření  houbaření  plavání  rybaření  les  mosty  voda
            {1,         0,          0,      0,      2,      2,  5},
            {1,         1,          0,      0,      1,      2,  5},
            {1,         1,          1,      0,      1,      2,  1},
            {1,         1,          1,      1,      1,      1,  1},
            {1,         1,          0,      1,      1,      1,  5},
            {1,         0,          1,      0,      2,      2,  1},
            {1,         0,          1,      1,      2,      1,  1},
            {1,         0,          0,      1,      2,      1,  5},
            {0,         1,          0,      0,      1,      2,  20},
            {0,         1,          1,      0,      1,      2,  1},
            {0,         1,          1,      1,      1,      1,  1},
            {0,         1,          0,      1,      3,      1,  10},
            {0,         0,          1,      0,     10,      2,  1},
            {0,         0,          1,      1,     10,      1,  1},
            {0,         1,          0,      1,     1,       1,  10},
            {0,         0,          0,      1,     10,      1,  10},
            {0,         0,          0,      0,     10,      5,  20},
        };

        for(int i = 0; i < m; i++)
            for(int j = 0; j < n; j++)
                if(a[i,0] == likeCamping && a[i,1] == likeMushroms && a[i,2] == likeSwimming && a[i,3] == likeFishing)
                {
                    //Debug.Log(+a[i,4]+"______"+a[i,5]);
                    agent.SetAreaCost(3,a[i,4]);
                    agent.SetAreaCost(4,a[i,5]);
                    agent.SetAreaCost(5,a[i,6]);
                    forestCost.text = a[i,4].ToString();
                    bridgeCost.text = a[i,5].ToString();
                    bridgesCost.text = a[i,5].ToString();
                    riverCost.text = a[i,6].ToString();
                    riverCost2.text = a[i,6].ToString();

                }

        if(sliderAge < 20)
            age = 0.4f;
        if(sliderAge >= 20 && sliderAge < 40)
            age = 0.2f;
        if(sliderAge >= 40 && sliderAge < 60)
            age = 0.6f;
        if(sliderAge >= 60)
            age = 0.8f;
        speedEnergy = sliderSpeed*age;
        agent.speed = sliderSpeed*7;
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        direction = toggle.name;
        


        agent.isStopped = true;
        if(direction == "Treasure")
            agent.SetDestination(treasure.position);
        else if(direction == "Relax")
            agent.SetDestination(relax.position);
        else if(direction == "ByUser")
            DestionationByUser();


        if(Timer.timerActive == true)
        {
            if(agent.speed == 0 || StaminaBar.hasStamina == false)
            {
                agent.isStopped = true;
            }
            else if(direction == "Treasure" && distance >= 1.2 && StaminaBar.hasStamina == true)
            {
                agent.isStopped = false;
                //agent.SetDestination(treasure.position);
                distance = Vector3.Distance(agent.transform.position,treasure.transform.position);
                StaminaBar.instance.useStamina(speedEnergy);
            }
            else if(direction == "Relax" && distance >= 1.2 && StaminaBar.hasStamina == true)
            {
                agent.isStopped = false;
                //agent.SetDestination(relax.position);
                distance = Vector3.Distance(agent.transform.position,relax .transform.position);
                StaminaBar.instance.useStamina(speedEnergy);
            }
            else if(direction == "ByUser" && StaminaBar.hasStamina == true)
            {
                agent.isStopped = false;
                if(Input.GetMouseButtonDown(0))
                {
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if(Physics.Raycast(ray, out hit))
                    {
                        isDirection = true;
                        //agent.SetDestination(hit.point);
                    }
                }
                distance = Vector3.Distance(agent.transform.position, agent.destination);
                Debug.Log(distance);
                if(distance <= 1.2)
                {
                    isDirection = false;
                }
                    
                if(isDirection)
                    StaminaBar.instance.useStamina(speedEnergy);
            }
            else if(distance <= 1.3)
                Timer.timerActive = false;
        }
        else
            agent.isStopped = true;
        
    }
    private void DestionationByUser()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                isDirection = true;
                agent.SetDestination(hit.point);
            }
        }
    }
    
}
