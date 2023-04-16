using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed;
    public float jumpPower;
    public float fallMultiplyer = 2;
    public float lowjumpMultiplyer = 1;
    public int side;
    public bool facingRight;
    public Transform characterContainer;

    private Animator anim;
    private Rigidbody2D rb;
    private Collision collision;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<Collision>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y);
        Run(direction);
        if (Input.GetButtonDown("Jump"))
        {
            if (collision.onGround)
            {
                anim.SetTrigger("Jump");
                Jump(Vector2.up);
            }
        }

        anim.SetFloat("HorizontalAxis",direction.x);
        anim.SetBool("OnGround", collision.onGround);

        if (x > 0)
        {
            side = 1;
            Vector3 theScale = characterContainer.localScale;
            if (!facingRight)
            {
                theScale.x *= -1;
                characterContainer.localScale = theScale;
                facingRight = true;

            }

        }

        if (x < 0)
        {
            side = -1;
            Vector3 theScale = characterContainer.localScale;
            if (facingRight)
            {
                theScale.x *= -1;
                characterContainer.localScale = theScale;
                facingRight = false;

            }

        }

        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplyer * Time.deltaTime;
        if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.velocity += Vector2.up * Physics2D.gravity.y * lowjumpMultiplyer * Time.deltaTime;


    }


    public void Run(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * runSpeed, rb.velocity.y);
    }

    public void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpPower;
    }
}
