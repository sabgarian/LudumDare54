using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHUD : MonoBehaviour
{
    public Sprite filledIcon,
        emptyIcon;

    public void GainItem()
    {
        GetComponent<Image>().sprite = filledIcon;
    }

    public void LoseItem()
    {
        GetComponent<Image>().sprite = emptyIcon;
    }
}
