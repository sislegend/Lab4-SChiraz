using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetPlayer()
    {
        transform.parent.position = new Vector3(0, 1.183f, 0);
        GetComponent<Animator>().SetBool("Death", false);
        transform.parent.GetComponent<CMovement>().ResetLives();
        //Ann.SetBool("Death", false);
    }
}
