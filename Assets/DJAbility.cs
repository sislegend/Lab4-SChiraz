using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJAbility : Ability
{
    public override void OnCollect()
    {
        base.OnCollect();
        GetComponent<CMovement>().MaxJump = 2;
    }

    public override void OnEnd()
    {
        base.OnEnd();
        GetComponent<CMovement>().MaxJump = 1;
    }
}
