using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    static bool isCountingDown = false;
    static float timeRemaining = 540;
    public BestTimes timeArchive;
    public TMP_Text timerText;
    public TMP_Text bestTimeText;
    public GameOverScreen gameOverScreen;

    void Start()
    {
        timerText.text = "---s";
        if (PlayerPrefs.HasKey("record"))
        {
            bestTimeText.text = PlayerPrefs.GetFloat("record").ToString("F2");
        }
        else
        {
            bestTimeText.text = "---s";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = timeRemaining.ToString("F2");
            if (timeRemaining <= 0)
            {
                //Debug.Log("Game Over");
                isCountingDown = false;
                timeArchive.RecordTime(timeRemaining);
                gameOverScreen.gameObject.SetActive(true);
                gameOverScreen.TriggerGameOver(true);
            }
            //Also stop timer in the event of a win condition
        }
    }

    public void StartCountdown()
    {
        isCountingDown = true;
    }
}
