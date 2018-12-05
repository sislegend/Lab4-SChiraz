using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvAbility : Ability
{

    public override void OnCollect()
    {
        base.OnCollect();
        GetComponent<CMovement>().Inv = true;
    }

    public override void OnEnd()
    {
        base.OnEnd();
        GetComponent<CMovement>().Inv = false;
    }
}
