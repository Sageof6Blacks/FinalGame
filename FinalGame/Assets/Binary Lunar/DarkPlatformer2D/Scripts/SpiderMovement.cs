using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float runSpeed = 10f;
    public float xAxis;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(xAxis, y);
        Run(direction);
    }
    public void Run(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * runSpeed, 0);//rb.velocity.y
    }
}