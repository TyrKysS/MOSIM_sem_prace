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
    // nastavení hodnot pro slidery (věk a rychlost)
    void Start()
    {
        _sliderAge.onValueChanged.AddListener((v)=> {
            _sliderTextAge.text = v.ToString("0");
            // Hodnota se čte jako String, avšak pro další práci se převádí na Float
            Movement.sliderAge = float.Parse(v.ToString("0"));
        });

        _sliderSpeed.onValueChanged.AddListener((v)=> {
            _sliderTextSpeed.text = v.ToString("0.00");
            
            Movement.sliderSpeed = float.Parse(v.ToString("0.00"));
        });
    }
}
