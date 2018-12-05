using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    public string AbilityTag;

    //public GameObject PowerActive;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<CMovement>())
        {
            Ability[] abilities = collision.gameObject.GetComponents<Ability>();
            int cpt = 0;

            foreach(Ability a in abilities)
            {
                if(a.AbilityTag == AbilityTag)
                {
                    //PowerActive.GetComponent<SpriteRenderer>().sprite = Resources.Load("Assets/Coin", typeof(Sprite)) as Sprite;
                    a.OnCollect();
                }
                //else if(a.enabled) -> use only if you want to have 1 ability in use at a time.
                //{
                //    a.OnEnd();
                //}
                cpt++;
            }
            Destroy(gameObject);
        }
    }
}
