using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{

    public float timeLimit;         //time to complete the quest
    public string enemyToKill;      //type of enemy to kill
    public int currentKills;       //number of kills neccessary
    public int targetKills;
    public string weaponToKillWith; //which weapon is te quest for
    

    void Update()
    {
        Camera.main.GetComponent<statKeeper>().getKillCount(enemyToKill);
    }
    public int QuestFailed()
    {
        return 50;
    }

    public int QuestSuccess()
    {
        return 100;
    }
    public Quest(float timelim, string enemytk, int NOK, string WTKW)                  //This gives new quest
    {
        this.timeLimit = timelim;
        this.enemyToKill = enemytk;
        this.targetKills = currentKills + NOK;
        this.weaponToKillWith = WTKW;

    }

 
}
