using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelareKontroller : MonoBehaviour
{
    public Animator animator;
    public float speedframmåt;
    public float speedbakåt;
    public float jump;
    float movevelocity;
    bool grounded = false;
    public bool SlowDown = false;
    private bool facingRight = true;
    public GameObject gameOver, stoppare, restartButton;
    SpriteRenderer sprite;
  
    // Use this for initialization
    void Start()
    {
        
        gameOver.SetActive(false);
        restartButton.SetActive(false);
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Att hoppa när man trycker space.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            animator.SetBool("isJumping", true);
            }

        }

        else
        {
            animator.SetBool("isJumping", false);
        }

        //kolla om gubben varit i kontakt med marken för att se om man kan hoppa igen
        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");

        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            movevelocity = speedframmåt; //röra sig Höger
            animator.SetFloat("Speed", 0.1f);
            jump = 25;
            if (sprite.flipX == false)
            {
                sprite.flipX = true;
            }
        }

        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            movevelocity = -speedbakåt; //röra sig vänster
            animator.SetFloat("Speed", 0.1f);
            jump = 25;
            if (sprite.flipX == true)
            {
                sprite.flipX = false;
            }
        }
        else
        {
            animator.SetFloat("Speed", 0f);
            movevelocity = 0;
            jump = 30;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(movevelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D()
    {
        grounded = true;

    }
    void OnTriggerExit2D()
    {
        grounded = false;
    }


    void OnCollisionEnter2D (Collision2D col)
    {

        if (col.gameObject.tag.Equals("Enemy"))
        {

            foreach(ContactPoint2D point in col.contacts)
            {
                if (point.normal.y >= 0.9f)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                }
                else
                {
                    gameOver.SetActive(true);
                    restartButton.SetActive(true);
                    gameObject.SetActive(false);

                }

            }

        }

        else if (col.gameObject.tag.Equals("DÖDSHYLLAN"))
        {
            gameOver.SetActive(true);
            restartButton.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}