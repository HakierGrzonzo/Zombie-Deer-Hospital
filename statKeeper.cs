using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statKeeper : MonoBehaviour
{
    private Dictionary<string, int> KillCount = new Dictionary<string, int>();
    private int result;
    // Start is called before the first frame update

    public void addKill(string type)    //this adds a kill of a given name
    {
        if (KillCount.TryGetValue(type, out result))
        {
            result += 1;
            KillCount[type] = result;
        }
        else
        {
            KillCount[type] = result;
        }
    }

    private void Update()
    {
        Debug.Log(KillCount["Nurse"]);
    }

    public int getKillCount(string type)    
    {
        if (KillCount.TryGetValue(type, out result))
        {
            return KillCount[type];
        }
        else
        {
            return 0;
        }
    }
}
