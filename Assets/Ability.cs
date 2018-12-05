using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour {

    public string AbilityTag;
    public float Maxtime = 3.0f;

    public Sprite PActive;
    public Sprite Inactive;
    public GameObject ItemEquip;

    private float timer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OnUpdate();
    }

    public virtual void OnCollect()
    {
        enabled = true;
        ItemEquip.GetComponent<Image>().sprite = PActive;
    }

    public virtual void OnUpdate()
    {
        timer += Time.deltaTime;
        if(timer > Maxtime)
        {
            timer = 0;
            OnEnd();
        }
    }

    public virtual void OnEnd()
    {
        enabled = false;
        ItemEquip.GetComponent<Image>().sprite = Inactive;
    }
}
