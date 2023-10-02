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

	private void Start()
	{
		pickupCollider = GetComponent<Collider2D>();
		playerControls = FindObjectOfType<PlayerControls>();

	}

	private void Update()
	{
		pickupCollider.enabled = playerControls.pickaxeCount == 0;
	}
}
