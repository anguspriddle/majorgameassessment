using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public float PlayerSpeed = 5.0f;
    public float horizontalInput;
    public bool onGround = true;
    private float jumpForce = 4.0f;
    private float gravityModifier = 1f;
    public float jumpAmount = 0;
    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpAmount < 2) 
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpAmount += 1;
            onGround = false;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * PlayerSpeed * Time.deltaTime);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
            jumpAmount = 0;
            onGround = true;
    }
}
