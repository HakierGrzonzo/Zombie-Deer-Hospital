using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statKeeper : MonoBehaviour
{
    private Dictionary<string, int> KillCount = new Dictionary<string, int>();
    private int result;
    // Start is called before the first frame update

    public void addKill(string type)
    {
        if (KillCount.TryGetValue(type, out result))
        {
            KillCount.Add(type, result + 1);   
        }
        else
        {
            KillCount.Add(type, 1);
        }
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
