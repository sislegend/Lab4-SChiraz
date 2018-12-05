using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    float InitialV = 10.0f;

	// Use this for initialization
	void Start () {

        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.gameObject.GetComponent<EMovement>()) // != null
        {
            collision.rigidbody.gameObject.GetComponent<EMovement>().HeDied();
        }
        //if(collision.rigidbody.gameObject.GetComponent<EMovement2>())
        //{
        //    collision.rigidbody.gameObject.GetComponent<EMovement2>().DestroyBlock();
        //}
        Destroy(gameObject);
    }

    public void GiveInitialV()
    {
        GetComponent<Rigidbody2D>().AddForce(-transform.right * InitialV, ForceMode2D.Impulse);
    }
}
