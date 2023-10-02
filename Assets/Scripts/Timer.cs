using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    static bool isCountingDown = false;
    static float timeRemaining = 300;
    public BestTimes timeArchive;

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown)
        {
            //Debug.Log(timeRemaining);
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                //Debug.Log("Game Over");
                isCountingDown = false;
                timeArchive.recordTime(timeRemaining);
            }
            //Also stop timer in the event of a win condition
        }
    }

    public static void StartCountdown()
    {
        isCountingDown = true;
    }
}
