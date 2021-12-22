using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [SerializeField] private Slider sliderTimer;
    [SerializeField] private Text sliderTextTimer;

    public static bool timerActive = false;
    public static bool resetSimulation = false;
    float currentTime;
    public float startMinutes;
    public Text currentTimeText;
    public float setTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        sliderTimer.onValueChanged.AddListener((v) => {
            startMinutes = float.Parse(v.ToString("0"));
            //Debug.Log(v.ToString("0"));
            currentTime = startMinutes * 0.5f;
            //Debug.Log(currentTime);
        });
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            if(currentTime <= 0)
            {
                timerActive = false;
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString()+":"+time.Seconds.ToString();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
