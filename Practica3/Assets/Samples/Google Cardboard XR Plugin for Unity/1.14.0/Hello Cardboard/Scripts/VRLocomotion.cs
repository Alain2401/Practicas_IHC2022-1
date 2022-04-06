using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLocomotion : GazeInteractable
{
    public Vector3 playerHeightOffset = new Vector3(0, 1.6f, 0);

    public override void OnPointerEnter()
    {
        base.OnPointerEnter();
    }

    public override void OnPointerExit()
    {
        base.OnPointerExit();
    }

    public override void OnPointerClick()
    {
        base.OnPointerClick();
        //Teletransportar jugador
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        player.position = transform.position + playerHeightOffset;
    }
}
