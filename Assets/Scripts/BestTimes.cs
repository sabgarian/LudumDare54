using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestTimes : MonoBehaviour
{
    const string recordKey = "record";

    public float goldMedalBenchmark;
    public float silverMedalBenchmark;
    public string medal;

    public void RecordTime(float remainingTime)
    {
        float record = PlayerPrefs.HasKey(recordKey)
            ? PlayerPrefs.GetFloat(recordKey)
            : float.MaxValue;
        if (remainingTime > record)
        {
            record = remainingTime;
            PlayerPrefs.SetFloat(recordKey, record);
        }

        if (remainingTime > goldMedalBenchmark)
        {
            medal = "Gold";
        }
        else if (remainingTime > silverMedalBenchmark)
        {
            medal = "Silver";
        }
        else if (remainingTime > 0)
        {
            medal = "Bronze";
        }
        else
        {
            medal = "Fail";
        }
    }
}
