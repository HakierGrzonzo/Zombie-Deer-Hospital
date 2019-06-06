using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statusEffect : MonoBehaviour
{
    public int HpLossPerTick = 0;
    public int HpLoss = 0;

    public string Name;
    public int Length;
    private int LengthCounter;
    private static int TickTimer = 50; //How often should the effect be applied, 50 = 1 second, unless FixedDeltaTime() was changed
    private int Timer = 0;
    public Mob AppliedTo;

    public float SpeedFactor = 1;
    private float OriginalSpeed;

    public float ToughnessFactor = 1; //if this does not work, then blame Eryk.
    private int OriginalToughness;

    //will add more later

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
            //Debug.Log("applied effect");
            //Debug.Log(AppliedTo.HP);
        }
        else { Timer++; }
        if (Length <= LengthCounter)
        {
            AppliedTo.speed = OriginalSpeed;
            AppliedTo.toughness = OriginalToughness;
            Destroy(this);
        }
    }
    private void onDestroy()
    {
        
    }
}
