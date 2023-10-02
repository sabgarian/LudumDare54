using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Idol : ObjectPickup
{
    protected override void Start()
    {
        base.Start();
        floating = false;
    }

    public override void Effect()
    {
        CameraController controller = FindObjectOfType<CameraController>();
        controller.PlayIdolCutscene();
    }
}
