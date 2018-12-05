using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMovement2 : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.layer == 9) || (collision.gameObject.layer == 8))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 3, ForceMode2D.Impulse);
        }
    }

    public void DestroyBlock(/*GameObject EnemyVariant2*/)
    {
        Destroy(gameObject);
    }
}
