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
    private Keycode latestkey;
    
    // Animations and Animation States
    Animator animator;
    string currentState;
    const string PLAYER_IDLELEFT = "idleLEFT";
    const string PLAYER_IDLERIGHT = "idleRIGHT";
    const string PLAYER_RUNLEFT = "runLEFT";
    const string PLAYER_RUNRIGHT = "runRIGHT";
    const string PLAYER_JUMPLEFT = "jumpLEFT";
    const string PLAYER_JUMPRIGHT = "jumpRIGHT";
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpAmount < 2 && latestkey) 
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpAmount += 1;
            onGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpAmount < 2 && latestkey == KeyCode.A or latestkey == KeyCode.LeftArrow) 
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
