using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    private Mob playerMob;
    public Text text;

    private void Start()
    {
        playerMob = GameObject.FindWithTag("Player").GetComponent<Mob>();
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.maxValue = playerMob.MaxHP;
        slider.value = playerMob.HP;
        text.text = playerMob.HP.ToString() + "/" + playerMob.MaxHP.ToString();
    }
}
