using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<Text>();
    }
        
    
    // Update is called once per frame
    void Update()
    {
       Text.text = slider.value.ToString() + "/100";
    
        
    }
    
}
