using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{

    //these appear when player is presented with a choice between two quest and disappear when selection is made.
    //
    public GameObject Table1;
    public GameObject Table2;
    public Sprite Q1;
    public Sprite Q2;
    public Sprite Qempty;

    [Header("Text Objects for first quest")]
    public Text Q1_EnemyToKill;
    public Text Q1_EnemyCount;
    //public Text Q1_Weapon;
    public Text Q1_Time;
    [Header("Text Objects for second quest")]
    public Text Q2_EnemyToKill;
    public Text Q2_EnemyCount;
    //public Text Q2_Weapon;
    public Text Q2_Time;

    public float TimerCountdown;
    public int TotalWeight;
    public int CurWeight;
    public Quest[] QuestContainer = new Quest[3];
    public int QuestChosen;

    private void Start()
    {
        QuestContainer[0] = QuestGenerator(0);
        QuestContainer[1] = QuestGenerator(1);
        TimerCountdown = 1;
    }
    void Update()
    {
        if (Mathf.Floor(TimerCountdown) == 1)
        {
            if (TotalWeight != 40) { gameObject.GetComponent<Mob>().MaxHP -= TotalWeight; }
       
        }       //If quest timer reaches 0 player looses >Weight< MaxHP
        
        if (QuestContainer[0].timeLimit == 0 && QuestContainer[1]!=null)
        {
            QuestContainer[1].currentKills =Camera.main.GetComponent<statKeeper>().getKillCount(QuestContainer[1].enemyToKill);
            if (QuestContainer[1].currentKills == QuestContainer[1].targetKills) { gameObject.GetComponent<Mob>().HP += TotalWeight * 2; };
        }       //if player kills suffictient enemies Q1 is completed and rewards >Weight< HP
        if (QuestContainer[1].timeLimit == 0 && QuestContainer[0] != null)
        {
            QuestContainer[0].currentKills =Camera.main.GetComponent<statKeeper>().getKillCount(QuestContainer[0].enemyToKill);
            if (QuestContainer[0].currentKills == QuestContainer[0].targetKills) { gameObject.GetComponent<Mob>().HP += TotalWeight * 2; };
        }
        else { }



        if (Input.GetKeyDown(KeyCode.Alpha1)|| Input.GetKeyDown(KeyCode.O)) { ChooseQ1(); }
        if (Input.GetKeyDown(KeyCode.Alpha2)|| Input.GetKeyDown(KeyCode.P)) { ChooseQ2(); }

        if (QuestChosen == 1) { Q1_Time.text = TimerCountdown.ToString(); }
        else if (QuestChosen == 2) { Q2_Time.text = TimerCountdown.ToString(); }
        else { }
            if (QuestChosen == 1) { Q1_EnemyCount.text = (QuestContainer[0].targetKills - QuestContainer[0].currentKills).ToString(); }
            else if (QuestChosen == 2) { Q2_EnemyCount.text = (QuestContainer[1].targetKills - QuestContainer[1].currentKills).ToString(); }
            else { }




        if (Input.GetKeyDown(KeyCode.Space)|| Mathf.Floor(TimerCountdown) == 1)        //When this statement is fulfilled 2 new quests are generated
        {
            TimerCountdown =0;
            Table1.gameObject.SetActive(true);
            Table1.transform.position = new Vector3(-71.5f, 6, -440);
            Table2.gameObject.SetActive(true);
            Table2.transform.position = new Vector3(-61.5f, 6, -440);
            Table1.GetComponent<SpriteRenderer>().sprite = Q1;
            Table2.GetComponent<SpriteRenderer>().sprite = Q2;

            QuestContainer[0] = QuestGenerator(0);                                          //first time 2 quets are generated
            if (QuestContainer[2].timeLimit != 0) { QuestContainer[1] = QuestContainer[2]; }       
            else QuestContainer[1] = QuestGenerator(1);                                     //the rejected quest is introduced again as requested
            TotalWeight += 1;
            UpdateTextObject();
        }
        TimerCountdown -= Time.deltaTime;
    }
    public void ChooseQ1()
    {
        QuestContainer[2] = QuestContainer[1];
        QuestContainer[1] = null;
        //Table1.gameObject.transform.position.Set(1000, 100, -88.65f);// = new Vector3(-1700, -174, -88.65f)/250;
        Table1.transform.position = new Vector3(-60, 7, -450);
        Table1.GetComponent<SpriteRenderer>().sprite = Qempty;
        QuestChosen = 1;
        Table2.gameObject.SetActive(false);
        TimerCountdown = QuestContainer[0].timeLimit;
        UpdateTextObject();       
    }                   //These are called when player chooses either quest by presing according button
    public void ChooseQ2()
    {
        QuestContainer[2] = QuestContainer[0];
        QuestContainer[0] = null;
        //Table2.gameObject.transform.position = new Vector3(-1700, -174, -88.65f);
        Table2.transform.position = new Vector3(-60, 7, -450);
        QuestChosen = 2;
        Table2.GetComponent<SpriteRenderer>().sprite = Qempty;
        Table1.gameObject.SetActive(false);
        TimerCountdown = QuestContainer[1].timeLimit;
        UpdateTextObject();
    }

    Quest QuestGenerator(int TargetQuestSlot)
    {
        
        var EnemyContainer = new List<string> {"Patient", "Contagious Patient", "Alcoholic", "Rescuer", "Druggy", "Wheelchair Patient", "Injured Soldier", "Madman ", "Doctor" };
                                                                                                                    //tier 2                                                //tier 3                                           //tier 4
        var WeaponContainer = new List<string> { "Pistol", "Uzi", "Revolver", "AK47", "M16", "Sniper Rifle", "Shotgun", "Rocket_Launcher", "Flame_Thrower", "Minigun" };
                                                                                                                     //tier 2                                              //Tier 3         
        int RandomizerA = Random.Range(0, EnemyContainer.Count - 1);
        if (RandomizerA < 5) { CurWeight = Mathf.FloorToInt(TotalWeight / 2); }
        else if (RandomizerA < 9 && RandomizerA >= 5) { CurWeight = Mathf.FloorToInt(TotalWeight / 4); }  //8?
        else if (RandomizerA < 13 && RandomizerA >= 9) { CurWeight = Mathf.FloorToInt(TotalWeight / 8); }
        else { CurWeight = Mathf.FloorToInt(TotalWeight / 10); }

        //CurWeight = TotalWeight / Mathf.FloorToInt(RandomizerA);
        int RandomizerB = Random.Range(0, WeaponContainer.Count - 1);
        CurWeight -= (5 - RandomizerB);
        int CountRandomizer = Random.Range(1, CurWeight);
        CurWeight -= CountRandomizer;

        int TimeRandomizer;
        if (CurWeight < 2) { TimeRandomizer = Random.Range(18, 24) * 10; }
        else if (CurWeight < 6 && CurWeight >= 2) { TimeRandomizer = Random.Range(12, 18) * 10; }
        else if (CurWeight < 10 && CurWeight >= 6) { TimeRandomizer = Random.Range(6, 12) * 10; }
        else { TimeRandomizer = Random.Range(3, 6) * 10; }

        return new Quest(TimeRandomizer, (EnemyContainer[RandomizerA]), CountRandomizer, (WeaponContainer[RandomizerB]));

    }   //This generates quests for storage in QuestContainer[]
    public void UpdateTextObject()
    {
        Q1_EnemyToKill.text = QuestContainer[0].enemyToKill;
        Q1_EnemyCount.text = QuestContainer[0].targetKills.ToString();
        Q1_Time.text = QuestContainer[0].timeLimit.ToString();
        //Q1_Weapon.text = QuestContainer[0].weaponToKillWith;

        Q2_EnemyToKill.text = QuestContainer[1].enemyToKill;
        Q2_EnemyCount.text = QuestContainer[1].targetKills.ToString();
        Q2_Time.text = QuestContainer[1].timeLimit.ToString();
       // Q2_Weapon.text = QuestContainer[1].weaponToKillWith;

    }
}
