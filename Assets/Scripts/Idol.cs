using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Idol : ObjectPickup
{
    public override void Effect()
    {
        Timer.StartCountdown();
    }
}