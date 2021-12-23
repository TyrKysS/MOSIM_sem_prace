using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static bool timerActive = false;
    public static bool resetSimulation = false;
    float currentTime;
    public Text currentTimeText;
    
    // začíná se od nuly
    void Start()
    {   
        currentTime = 0;   
    }

    // stopky, pokud se stiskne tlačítko, začne se se odpočítavat, jinak stojí
    void Update()
    {
        if(timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
            
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }

    // tlačítka start, stop stopek
    public void StartTimer()
    {
        timerActive = true;
    }
    public void StopTimer()
    {
        timerActive = false;
    }

    // restart celé scény
    public void resetButton()
    {
        timerActive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
