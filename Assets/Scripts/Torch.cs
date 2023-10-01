using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : ObjectPickup
{
    public override void Effect()
    {
        FindObjectOfType<PlayerControls>().GainTorch();
    }
}
