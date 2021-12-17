using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider _sliderAge;
    [SerializeField] private Text _sliderTextAge;

    [SerializeField] private Slider _sliderSpeed;
    [SerializeField] private Text _sliderTextSpeed;

    [SerializeField] private Slider _sliderFitness;
    [SerializeField] private Text _sliderTextFitness;
    // Start is called before the first frame update
    void Start()
    {
        _sliderAge.onValueChanged.AddListener((v)=> {
            _sliderTextAge.text = v.ToString("0");
        });

        _sliderSpeed.onValueChanged.AddListener((v)=> {
            _sliderTextSpeed.text = v.ToString("0.00");
            
            Movement.speed = float.Parse(v.ToString("0.00"));
        });

        _sliderFitness.onValueChanged.AddListener((v)=> {
            _sliderTextFitness.text = v.ToString("0.00");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
