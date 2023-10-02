using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : ObjectPickup
{
    Collider2D pickupCollider;
    PlayerControls playerControls;

    public override void Effect()
    {
        playerControls.GainPickaxe();
    }

    protected override void Start()
    {
        base.Start();
        pickupCollider = GetComponent<Collider2D>();
        playerControls = FindObjectOfType<PlayerControls>();
    }

    protected override void Update()
    {
        base.Update();
        pickupCollider.enabled = !playerControls.hasPickaxe;
    }
}
