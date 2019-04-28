using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public Text text;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        text.text = slider.value.ToString() + "/100";
        slider.maxValue = GameObject.FindWithTag("Player").GetComponent<Mob>().MaxHP;
    }
    
}
