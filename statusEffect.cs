﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusEffect : MonoBehaviour
{
    public string Title; //name e.g. "Bleeding"
    public int toughnessEffect; //during effect
    public int HPEffect; //per tick
    public int MaxHPEffect; //during effect
    public int tickLength;
    public int tickNum;
    private int tickCompleate;
    private float timepassed = 0;

    public int EffectDuration() => tickLength * (tickNum - tickCompleate);

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Mob>().MaxHP -= MaxHPEffect;
        gameObject.GetComponent<Mob>().toughness -= toughnessEffect;
    }

    public void statusMake(statusEffect status)
    {
        this.Title = status.Title;
        this.toughnessEffect = status.toughnessEffect;
        this.HPEffect = status.HPEffect;
        this.MaxHPEffect = status.MaxHPEffect;
        this.tickLength = status.tickLength;
        this.tickNum = status.tickNum;
    }

    // aplay status effect
    void Update()
    {
        timepassed = +Time.deltaTime;
        if (timepassed > tickLength)
        {
            gameObject.GetComponent<Mob>().HP -= HPEffect;
            timepassed = 0;
            tickCompleate++;
        }
        if (tickCompleate == tickNum)
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        gameObject.GetComponent<Mob>().MaxHP += MaxHPEffect;
        gameObject.GetComponent<Mob>().toughness += toughnessEffect;
    }
}
