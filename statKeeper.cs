using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statKeeper : MonoBehaviour
{
    public Dictionary<string, int> KillCount = new Dictionary<string, int>();
    private int result;
    // Start is called before the first frame update

    public void addKill(string type)    //this adds a kill of a given name
    {
        try
        {
            KillCount[type] = KillCount[type] + 1;
        }

        catch
        {
            KillCount[type] = 1;
        }
    }

    public int getKillCount(string type)    
    {
        try
        {
            return (KillCount[type]);
        }

        catch
        {
            KillCount[type] = 1;
            return (KillCount[type]);
        }
    }
}
