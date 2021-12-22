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
    
    // Start is called before the first frame update
    void Start()
    {   
        currentTime = 0;   
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
            
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }

    public void StartTimer()
    {
        timerActive = true;
    }
    public void StopTimer()
    {
        timerActive = false;
    }
    public void resetButton()
    {
        timerActive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
