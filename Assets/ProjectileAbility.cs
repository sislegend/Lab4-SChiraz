using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbility : Ability {

    public GameObject Projectile;
    public Transform SpawnPoint;

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject SpawnP = Instantiate(Projectile, SpawnPoint.position, Quaternion.identity);
            SpawnP.transform.rotation = transform.rotation;
            SpawnP.GetComponent<Projectile>().GiveInitialV();

            //if(!FaceLeft)
            //{
            //    SpawnP.transform.rotation = Quaternion.Euler(0, 180, 0);
            //}
        }
    }
}
