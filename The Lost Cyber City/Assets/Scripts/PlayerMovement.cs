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
    private bool Facing_Left;
    private bool Facing_Right;
    
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
        animator = gameObject.GetComponent<Animator>();
        ChangeAnimationState(PLAYER_IDLELEFT);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * PlayerSpeed * Time.deltaTime);
        if (horizontalInput == 0 && onGround == true)
        {
            if (Facing_Left == true)
            {
                ChangeAnimationState(PLAYER_IDLERIGHT);
            }
            if (Facing_Right == true)
            {
                ChangeAnimationState(PLAYER_IDLELEFT);
            }
        }
        if (horizontalInput > 0 && onGround == true)
        {
            ChangeAnimationState(PLAYER_RUNRIGHT);
            Facing_Right = true;
            Facing_Left = false;
        }
        if (horizontalInput < 0 && onGround == true)
        {
            ChangeAnimationState(PLAYER_RUNLEFT);
            Facing_Right = false;
            Facing_Left = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpAmount < 2 && Facing_Left == true) 
        {
            ChangeAnimationState(PLAYER_JUMPLEFT);
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpAmount += 1;
            onGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpAmount < 2 && Facing_Right == true)
        {
            ChangeAnimationState(PLAYER_JUMPRIGHT);
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpAmount += 1;
            onGround = false;
        }
            

    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
            jumpAmount = 0;
            onGround = true;
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
}
