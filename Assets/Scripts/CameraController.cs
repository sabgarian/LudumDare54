using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera[] cameras;

    void Awake()
    {
        SetCamera(0);
    }

    public void SetCamera(int index)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == index)
            {
                cameras[i].Priority = 10;
            }
            else
            {
                cameras[i].Priority = 0;
            }
        }
    }

    public void PlayIdolCutscene()
    {
        StartCoroutine(IdolCutscene());
    }

    IEnumerator IdolCutscene()
    {
        CameraController controller = FindObjectOfType<CameraController>();
        PlayerControls player = FindObjectOfType<PlayerControls>();
        player.canMove = false;
        controller.SetCamera(1);
        yield return new WaitForSeconds(5);
        controller.SetCamera(0);
        yield return new WaitForSeconds(3);
        player.canMove = true;
        FindObjectOfType<Timer>().StartCountdown();
    }
}
