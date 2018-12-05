using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMovement : MonoBehaviour {

    public GameManager State;

    public float PSpeed;
    public float JForce;
    public float EJForce;
    public float EHeight;

    public int IsAir = 0;
    public int MaxJump = 1;

    private int NbrLives = 3;

    public List<GameObject> Hearts = new List<GameObject>();

    public bool Inv = false;

    public Animator Ann;
    public LayerMask RaycastLayer;

    public LayerMask WinCond;

    public static CMovement Instance;

    //private bool FaceLeft = true;

    //public float timeLeft = 2.0f;

    //private bool OnGround;

    // Use this for initialization
    void Start () {

        Instance = this;

    }
	
	// Update is called once per frame
	void Update ()
    {
        //-----
        //if (Ann.GetBool("Death"))
        //{
        //    timeLeft -= Time.deltaTime;
        //}
        //if(timeLeft < 0)
        //{
        //    timeLeft = 2.0f;
        //    transform.position = new Vector3(0, 1.183f, 0);
        //    Ann.SetBool("Death", false);
        //}
        //-----
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.Euler(0,0,0);
            transform.position += Vector3.left * PSpeed * Time.deltaTime;
            Ann.SetBool("Walk", true);
            //FaceLeft = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.localScale = new Vector3(-1, 1, 1);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position += Vector3.right * PSpeed * Time.deltaTime;
            Ann.SetBool("Walk", true);
            //FaceLeft = false;
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow)) && (IsAir < MaxJump))
        {
            Ann.SetBool("Walk", false);
            Ann.SetBool("Jump", true);
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * JForce, ForceMode2D.Impulse);
            IsAir++;
        }
        else
        {
            Ann.SetBool("Walk", false);
        }
        Debug.DrawRay(transform.position, Vector2.down);
        //--

        for (int cpt = 0; cpt < Hearts.Count; cpt++)
        {
            Hearts[cpt].SetActive(cpt < NbrLives);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            //OnGround = true;
            IsAir = 0;
            Ann.SetBool("Jump", false);
        }
        if (collision.gameObject.layer == 12)
        {
            IsAir = 0;
            Ann.SetBool("Jump", false);

            RaycastHit2D hit = Physics2D.BoxCast(transform.position, GetComponent<BoxCollider2D>().size * 0.9f, 0, Vector2.down, Mathf.Infinity, WinCond);
            if ((hit.collider != null) && (hit.collider.gameObject.layer == 12))
            {
                State.CurrentGState = GameManager.GameState.end;
            }
        }
        if (collision.gameObject.layer == 13)
        {
            IsAir = 0;
            Ann.SetBool("Jump", false);
            YouDied();
        }
        if (collision.gameObject.layer == 10)
        {
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, GetComponent<BoxCollider2D>().size * 0.9f, 0, Vector2.down, Mathf.Infinity, RaycastLayer);
            GameObject E = collision.rigidbody.gameObject;

            if (Inv == false)
            {
                if ((hit.collider != null) && (hit.collider.gameObject.layer == 10))
                {
                    E.GetComponent<EMovement>().HeDied();
                    //HeDied(collision.rigidbody.gameObject);
                }
                else
                {
                    DmgPlayer();
                }
            }
            else
            {
                E.GetComponent<EMovement>().HeDied();
            }
        }
        if (collision.gameObject.layer == 14)
        {
            DmgPlayer();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            //OnGround = false;
        }
    }

    public void YouDied()
    {
        Ann.SetBool("Death", true);
    }

    public void DmgPlayer()
    {

        NbrLives--;

        if (NbrLives <= 0)
        {
            YouDied();
        }

        //Destroy(Hearts[0]);
        //Hearts.RemoveAt(0);

        for (int cpt = 0; cpt < Hearts.Count; cpt++)
        {
            if (Hearts[cpt].active)
            {
                Hearts[cpt].SetActive(false);
                cpt = Hearts.Count;
            }
        }
    }

    public void ResetLives()
    {
        NbrLives = 3;
    }


}
