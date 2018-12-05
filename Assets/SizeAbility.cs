using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeAbility : Ability
{
    public override void OnCollect()
    {
        base.OnCollect();
        GetComponent<CMovement>().transform.localScale = new Vector3(1.5f, 1.5f, 0);
    }

    public override void OnEnd()
    {
        base.OnEnd();
        GetComponent<CMovement>().transform.localScale = new Vector3(1, 1, 0);
    }
}
