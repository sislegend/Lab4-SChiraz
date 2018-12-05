using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrAbility : Ability
{
    public override void OnCollect()
    {
        base.OnCollect();
        GetComponent<Rigidbody2D>().gravityScale = -1;
        GetComponent<CMovement>().transform.localScale = new Vector3(1, -1, 1);

    }

    public override void OnEnd()
    {
        base.OnEnd();
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<CMovement>().transform.localScale = new Vector3(1, 1, 1);
    }
}
