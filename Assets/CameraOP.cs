using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOP : MonoBehaviour {

    public Transform ThePlayer;
    public float Lerpspeed = 10.0f;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        //transform.position = new Vector3(ThePlayer.position.x, ThePlayer.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, new Vector3(ThePlayer.position.x, ThePlayer.position.y, transform.position.z), Lerpspeed * Time.deltaTime);

    }
}
