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
    public Sprite Qempty1;
    public Sprite Qempty2;

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
        if (Mathf.Floor(TimerCountdown) < 0) { FailQuest();}  //If quest timer reaches 0 player looses >Weight< MaxHP
        UpdateTextObject(); //updates quest textboxes
        PresentNewQuests(); //shows new quests
        if (QuestChosen == 1 || QuestChosen == 2) TimerCountdown -= Time.deltaTime; //countdown unless no current quest
    }
    public void ChooseQ1()
    {
        Table1.GetComponent<SpriteRenderer>().sprite = Qempty1;
        QuestChosen = 1;
        Table2.gameObject.SetActive(false);
        TimerCountdown = QuestContainer[0].timeLimit;      
    }                   //These are called when player chooses either quest by presing according button
    public void ChooseQ2()
    {
        QuestChosen = 2;
        Table2.GetComponent<SpriteRenderer>().sprite = Qempty2;
        Table1.gameObject.SetActive(false);
        TimerCountdown = QuestContainer[1].timeLimit;
    }

    Quest QuestGenerator(int TargetQuestSlot)
    {
        
        var EnemyContainer = new List<string> { "CommonInfected","Crazy", "ContagiousInfected", "Alcoholic", "Rescuer", "Druggy", "Wheelchair", "Soldier", "Doctor" };
                                                                                                                    //tier 2                                                //tier 3                                           //tier 4
        var WeaponContainer = new List<string> { "Pistol", "Uzi", "Revolver", "AK47", "M16", "Sniper Rifle", "Shotgun", "Rocket_Launcher", "Flame_Thrower", "Minigun" };
                                                                                                                     //tier 2                                              //Tier 3         
        int RandomizerA = Random.Range( 0, EnemyContainer.Count - 1);
        //
        if (RandomizerA < 5) { CurWeight = Mathf.FloorToInt(TotalWeight / 2); }
        else if (RandomizerA < 9 && RandomizerA >= 5) { CurWeight = Mathf.FloorToInt(TotalWeight / 4); }  //8?
        else if (RandomizerA < 13 && RandomizerA >= 9) { CurWeight = Mathf.FloorToInt(TotalWeight / 8); }
        else { CurWeight = Mathf.FloorToInt(TotalWeight / 10); }

        //CurWeight = TotalWeight / Mathf.FloorToInt(RandomizerA);
        int RandomizerB = Random.Range(0, WeaponContainer.Count - 1);
        CurWeight -= (5 - RandomizerB);
        int CountRandomizer = Random.Range(Camera.main.GetComponent<statKeeper>().getKillCount(EnemyContainer[RandomizerA])+2, Camera.main.GetComponent<statKeeper>().getKillCount(EnemyContainer[RandomizerA]) + CurWeight);
        //int CountRandomizer = Random.Range(QuestContainer[TargetQuestSlot].currentKills, QuestContainer[TargetQuestSlot].currentKills + CurWeight);
        CurWeight -= CountRandomizer;

        int TimeRandomizer;
        if (CurWeight < 2) { TimeRandomizer = Random.Range(18, 24) * 10; }
        else if (CurWeight < 6 && CurWeight >= 2) { TimeRandomizer = Random.Range(12, 18) * 10; }
        else if (CurWeight < 10 && CurWeight >= 6) { TimeRandomizer = Random.Range(6, 12) * 10; }
        else { TimeRandomizer = Random.Range(3, 6) * 10; }

        Q1_EnemyToKill.text = QuestContainer[0].enemyToKill;
        Q2_EnemyToKill.text = QuestContainer[1].enemyToKill;

        return new Quest(TimeRandomizer, (EnemyContainer[RandomizerA]), CountRandomizer, (WeaponContainer[RandomizerB]));
    }   //This generates quests for storage in QuestContainer[]

    public void UpdateTextObject()      //timer update failure- find out why the text is not updated.   QuestChosen ==1 error?
    {
        if (QuestChosen == 1)
        {
            Q1_Time.text = Mathf.FloorToInt(TimerCountdown).ToString();
            //Q1_EnemyCount.text = QuestContainer[0].targetKills.ToString();
            Q1_Time.text = Mathf.FloorToInt(TimerCountdown).ToString();
            QuestContainer[0].currentKills = Camera.main.GetComponent<statKeeper>().getKillCount(QuestContainer[0].enemyToKill);
            Q1_EnemyCount.text = (QuestContainer[0].targetKills - QuestContainer[0].currentKills).ToString();
            if (QuestContainer[0].targetKills - QuestContainer[0].currentKills <= 0) { WinQuest(); }
        }
        else if (QuestChosen == 2)
        {
            Q2_Time.text = Mathf.FloorToInt(TimerCountdown).ToString();
            //Q2_EnemyCount.text = QuestContainer[1].targetKills.ToString();
            Q2_Time.text = Mathf.FloorToInt(TimerCountdown).ToString();
            QuestContainer[1].currentKills = Camera.main.GetComponent<statKeeper>().getKillCount(QuestContainer[1].enemyToKill);
            Q2_EnemyCount.text = (QuestContainer[1].targetKills - QuestContainer[1].currentKills).ToString();
            if (QuestContainer[1].targetKills - QuestContainer[1].currentKills <= 0) { WinQuest(); }
        }
        else
        {
            Q1_EnemyToKill.text = QuestContainer[0].enemyToKill;
            Q2_EnemyToKill.text = QuestContainer[1].enemyToKill;
            Q1_Time.text = Mathf.FloorToInt(QuestContainer[0].timeLimit).ToString();
            Q2_Time.text = Mathf.FloorToInt(QuestContainer[1].timeLimit).ToString();
            QuestContainer[0].currentKills = Camera.main.GetComponent<statKeeper>().getKillCount(QuestContainer[0].enemyToKill);
            QuestContainer[1].currentKills = Camera.main.GetComponent<statKeeper>().getKillCount(QuestContainer[1].enemyToKill);
            Q1_EnemyCount.text = (QuestContainer[0].targetKills - QuestContainer[0].currentKills).ToString();
            Q2_EnemyCount.text = (QuestContainer[1].targetKills - QuestContainer[1].currentKills).ToString();
        }
    }

    public void GenerateQuests()
    {


            TimerCountdown = 0;
            Table1.gameObject.SetActive(true);
            Table2.gameObject.SetActive(true);;
            Table1.GetComponent<SpriteRenderer>().sprite = Q1;
            Table2.GetComponent<SpriteRenderer>().sprite = Q2;

        QuestContainer[0] = QuestGenerator(0);
        QuestContainer[1] = QuestGenerator(1);
        TotalWeight += 1;
        QuestChosen = 0;
    }

    public void PresentNewQuests()
    {
            if (Input.GetKeyDown(KeyCode.Alpha1) && QuestChosen == 0 ) { ChooseQ1(); }
            if (Input.GetKeyDown(KeyCode.Alpha2) && QuestChosen == 0 ) { ChooseQ2(); }
    }

    public void FailQuest()
    {
        gameObject.GetComponent<Mob>().MaxHP -= TotalWeight;
        GenerateQuests();
        PresentNewQuests();
    }
    public void WinQuest()
    {
        gameObject.GetComponent<Mob>().HP += TotalWeight*2;
        GenerateQuests();
        PresentNewQuests();
    }

}
