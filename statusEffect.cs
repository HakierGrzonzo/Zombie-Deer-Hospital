using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class statusEffect : MonoBehaviour
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
}*/
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
    //will add more later

    public statusEffect(Mob AppliedTo, int HPlossPerTick, int HPloss, string Name, int Length)
    {
        this.HpLossPerTick = HPlossPerTick;
        this.HpLoss = HPloss;
        this.Name = Name;
        this.Length = Length;
        this.AppliedTo = AppliedTo;
    }

    private void Start()
    {
        AppliedTo.HP -= HpLoss;
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
            Destroy(this);
        }
    }
}
