using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Jumpforce;
    public float speed;
    private Rigidbody2D body;
    bool isgrounded;
    public float groundRayLength;
    public LayerMask layers;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isgrounded = Physics2D.Raycast(transform.position, -transform.up, groundRayLength, layers);
        Debug.DrawRay(transform.position, -transform.up * groundRayLength);

        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //flips character when moving left and right
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(7,7,7);
        else if (horizontalInput < 0.01f)
            transform.localScale = new Vector3(-7,7,7);

        if (Input.GetButtonDown("Jump") && isgrounded)
            body.AddForce(Vector2.up * Jumpforce);

       
    }
}