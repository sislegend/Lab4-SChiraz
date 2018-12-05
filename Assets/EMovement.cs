using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMovement : MonoBehaviour
{

    public float ESpeed = 1;
    //public GameObject WayPoint1; //Left Side
    //public GameObject WayPoint2; //Right Side
    public bool IsDED = false;

    private float Direction = 1;
    public LayerMask RaycastE;

    public Animator EAnn;

    public static int NbrUnits =0;

    // Use this for initialization
    void Start()
    {
        NbrUnits++;
        Debug.Log(NbrUnits);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDED)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, RaycastE);
            if (hit.collider == null)
            {
                Direction *= -1;
                transform.localScale = new Vector3(Direction, 1, 1);
            }
            transform.position += Direction * Vector3.left * ESpeed * Time.deltaTime;

            EAnn.SetBool("Pause", GameManager.Get().CurrentGState == GameManager.GameState.pause);
        }

    }

    public void HeDied(/*GameObject Enemy*/)
    {
        GetComponent<EMovement>().EAnn.SetBool("Dead", true);
        GetComponent<EMovement>().IsDED = true;
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * 3, ForceMode2D.Impulse);
        GetComponent<Collider2D>().enabled = false;
    }
}
