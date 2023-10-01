using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : ObjectPickup
{
    public override void Effect()
    {
        FindObjectOfType<PlayerControls>().GainPickaxe();
    }
}
