using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movespeed;
    public float jumpforce;
    float horizontalmove = 0;
    int extrajumps = 2;


    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        rb.velocity = new Vector2(horizontalmove * movespeed * Time.deltaTime, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            horizontalmove = -1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            horizontalmove = 1;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            horizontalmove = 0;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extrajumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extrajumps--;
        }

        if(rb.velocity.y == 0 && extrajumps < 2) 
        {
            extrajumps++;

        }
    }

}