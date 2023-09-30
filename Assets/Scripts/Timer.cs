using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Timer : MonoBehaviour
{
    static  bool isCountingDown = false;
    static int timeRemaining = 5400;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown)
        {
            UnityEngine.Debug.Log(timeRemaining);
            timeRemaining--;
        }
    }

    public static void StartCountdown()
    {
        isCountingDown = true;
    }
}
