using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestTimes : MonoBehaviour
{
    public float record;
    public float goldMedalBenchmark;
    public float silverMedalBenchmark;
    public string medal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void recordTime(float remainingTime)
    {
        if(remainingTime > record)
        {
            record = remainingTime; 
        }

        if(remainingTime > goldMedalBenchmark)
        {
            medal = "Gold";
        }
        else if (remainingTime > silverMedalBenchmark)
        {
            medal = "Silver";
        }
        else if(remainingTime > 0)
        {
            medal = "Bronze";
        }
        else
        {
            medal = "Fail";
        }
    }
}
