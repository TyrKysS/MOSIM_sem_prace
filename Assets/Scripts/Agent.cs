using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public static string age;
    public static string speed;
    public static string fitness;
    
    void update()
    {
        Debug.Log("age "+age);
        Debug.Log("speed "+speed);
        Debug.Log("fitness "+fitness);
    }
}
