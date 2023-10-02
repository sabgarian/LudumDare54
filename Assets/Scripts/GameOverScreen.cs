using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public GameObject timeOutIcon;
    public GameObject healthOutIcon;

    GameObject player;

    void Start()
    {
        player = FindObjectOfType<PlayerControls>().gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void TriggerGameOver(bool timeOut)
    {
        if (timeOut)
        {
            timeOutIcon.SetActive(true);
            healthOutIcon.SetActive(false);
        }
        else
        {
            timeOutIcon.SetActive(false);
            healthOutIcon.SetActive(true);
        }
        Destroy(player);
    }
}
