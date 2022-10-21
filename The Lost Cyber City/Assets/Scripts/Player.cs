using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Variables
    public float PlayerSpeed = 1.0f;
    public float horizontalInput;
    public bool onGround = true;
    private float jumpForce = 4.0f;
    private float gravityModifier = 1f;
    public float jumpAmount = 0;
    private Rigidbody2D playerRb;
    public bool Facing_Left;
    public bool Facing_Right;
    public GameManager gameManager;
    private float timeStamp = 0f;
    private float coolDownPeriodInSeconds = 2.5f;
    public bool cooldown;
    public GameObject SpeedWarning;
    public int maxSpeed = 11;
    // Animations and Animation States
    Animator animator;
    string currentState;
    const string PLAYER_IDLELEFT = "idleLEFT";
    const string PLAYER_IDLERIGHT = "idleRIGHT";
    const string PLAYER_RUNLEFT = "runLEFT";
    const string PLAYER_RUNRIGHT = "runRIGHT";
    const string PLAYER_JUMPLEFT = "jumpLEFT";
    const string PLAYER_JUMPRIGHT = "jumpRIGHT";
    const string PLAYER_ATTACKRIGHT = "attackRIGHT";
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
        animator = gameObject.GetComponent<Animator>();
        ChangeAnimationState(PLAYER_IDLELEFT);
        cooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.lives == 0)
        {
            deathState();
        }
        if(PlayerSpeed == maxSpeed)
        {
            SpeedWarning.SetActive(true);
        }
        if(PlayerSpeed < 11)
        {
            SpeedWarning.SetActive(false);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * PlayerSpeed * Time.deltaTime);
        if (cooldown == true)
        {
            timeStamp += Time.deltaTime;
            if (timeStamp >= coolDownPeriodInSeconds){
                cooldown = false;
            }
        }
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

        if (horizontalInput > 0 && onGround == false)
        {
            ChangeAnimationState(PLAYER_JUMPRIGHT);
            Facing_Right = true;
            Facing_Left = false;
        }
        if (horizontalInput < 0 && onGround == false)
        {
            ChangeAnimationState(PLAYER_JUMPLEFT);
            Facing_Right = false;
            Facing_Left = true;
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
        if (Input.GetKeyDown(KeyCode.Space) && jumpAmount < 3 && Facing_Left == true) 
        {
            ChangeAnimationState(PLAYER_JUMPLEFT);
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpAmount += 1;
            onGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpAmount < 3 && Facing_Right == true)
        {
            ChangeAnimationState(PLAYER_JUMPRIGHT);
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpAmount += 1;
            onGround = false;
        }
            

    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Robot Enemy")
        {
            gameManager.lives -= 1;
        }
        if(collision.gameObject.name == "HeartContainer"){
                gameManager.lives += 1;
                Destroy(collision.gameObject);
        }
        if(collision.gameObject.name == "SpeedBoost")
        {
            if(PlayerSpeed < maxSpeed)
            {
                PlayerSpeed += 1;
                Destroy(collision.gameObject);
            }
            if(PlayerSpeed >= maxSpeed)
            {
                Destroy(collision.gameObject);
            }
            
        }
        if(collision.gameObject.name == "SpeedLower")
        {
            if(PlayerSpeed > 2)
            {
                PlayerSpeed -= 1;
                Destroy(collision.gameObject);
            }
            if(PlayerSpeed <= 1)
            {
                Destroy(collision.gameObject);
            }
            
        }
        if(collision.gameObject.name == "lever")
        {
            SceneManager.LoadScene("gameWIN");
        }
        if(collision.gameObject.name != "Robot Enemy" && collision.gameObject.name != "Coin" && collision.gameObject.name != "HeartContainer" && collision.gameObject.name !="SpeedBoost" && collision.gameObject.name != "SpeedLower")
        {
            jumpAmount = 0;
            onGround = true;
        }
          
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    void deathState()
    {
        SceneManager.LoadScene("deathScene"); 
    }
    
}
