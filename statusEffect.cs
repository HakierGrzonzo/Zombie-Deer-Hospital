using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusEffect 
{
    public int HpLossPerTick = 0;
    public int HpLoss = 0;

    public string Name;
    public int Length;
    private int LengthCounter;
    private static int TickTimer = 50; //How often should the effect be applied, 50 = 1 second, unless FixedDeltaTime() was changed
    private int Timer = 0;
    public static GameObject Player;
    public Mob AppliedTo;

    public float SpeedFactor = 1;
    private float OriginalSpeed;

    public float ToughnessFactor = 1; //if this does not work, then blame Eryk.
    private int OriginalToughness;

    //will add more later


        //default constructor
    public statusEffect(Mob AppliedTo, int HPlossPerTick, int HPloss, float SpeedFactor, float ToughnessFactor, string Name, int Length)
    {
        this.HpLossPerTick = HPlossPerTick;
        this.HpLoss = HPloss;
        this.Name = Name;
        this.Length = Length;
        this.AppliedTo = AppliedTo;
        this.SpeedFactor = SpeedFactor;
        this.ToughnessFactor = ToughnessFactor;
    }

    public statusEffect Poison = new statusEffect(Player.GetComponent<Mob>(), 1, 0, 1, 1, "Poison", 3);
    public statusEffect Slow   = new statusEffect(Player.GetComponent<Mob>(), 0, 0, 0.5f, 1, "Slow", 3);

    private void Start()
    {
        AppliedTo.HP -= HpLoss;

        OriginalSpeed = AppliedTo.speed;
        AppliedTo.speed *= SpeedFactor;

        OriginalToughness = AppliedTo.toughness;
        AppliedTo.toughness = (int) (ToughnessFactor * AppliedTo.toughness);
        
        if (TickTimer <= 0)
        {
            throw new System.InvalidOperationException("Ticktimer can not be less then or equal to 0");
        }
        if (Length <= 0)
        {
            throw new System.InvalidOperationException("Length can not be less then or equal to 0");
        }

    }
    private void FixedUpdate()
    {
        if (Timer >= TickTimer)
        {
            AppliedTo.HP += -HpLossPerTick;
            LengthCounter++;
            Timer = 0;
            Debug.Log("applied effect");
            //Debug.Log(AppliedTo.HP);
            
            
            // UI feedback for active buffs, debuffs
            if (Name == "Poison") { AppliedTo.Poison = true; Debug.Log("P Applied"); }
            if (Name == "Slow") { AppliedTo.Slow = true; Debug.Log("S Applied"); }
            if (Name == "Fear") { AppliedTo.Fear = true; Debug.Log("F Applied"); }
            if (Name == "Inspire") { AppliedTo.Inspire = true; Debug.Log("I Applied"); }
            if (Name == "Silence") { AppliedTo.Silence = true; Debug.Log("S Applied"); }





        }
        else { Timer++; }
        if (Length <= LengthCounter)
        {
            AppliedTo.speed = OriginalSpeed;
            AppliedTo.toughness = OriginalToughness;
            // UI feedback for active buffs, debuffs
            if (Name == "Poison") { AppliedTo.Poison = false; Debug.Log("P Removed"); }
            if (Name == "Slow") { AppliedTo.Slow = false; Debug.Log("S Removed"); }
            if (Name == "Fear") { AppliedTo.Fear = false; Debug.Log("F Removed"); }
            if (Name == "Inspire") { AppliedTo.Inspire = false; Debug.Log("I Removed"); }
            if (Name == "Silence") { AppliedTo.Silence = false; Debug.Log("S Removed"); }
            
            //Destroy(this);
        }
    }
    private void onDestroy()
    {
        
    }
}
