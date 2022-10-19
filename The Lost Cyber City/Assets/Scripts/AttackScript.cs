using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private float timeStamp = 0f;
    private float coolDownPeriodInSeconds = 0.5f;
    public bool cooldown;
    public GameObject AttackRight;
    public GameObject AttackLeft;
    public Animator attackLeft;
    public Animator attackRight;
    public GameObject player;
    private Player Player_Script;
    public float timeAnim;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        timeAnim = 0;
        cooldown = false;
        Player_Script = player.GetComponent<Player>();
        AttackRight.SetActive(false);
        AttackLeft.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        if (Input.GetKeyUp(KeyCode.V))
        {
            cooldown = true;
            if (Player_Script.Facing_Right == true)
            {
                AttackLeft.SetActive(true);
                attackLeft.Play("attackLeft", 0);
                timeStamp = 0;
                cooldown = true;
            }
            if (Player_Script.Facing_Left == true)
            {
                AttackRight.SetActive(true);
                attackRight.Play("attackRight", 0);
                timeStamp = 0;
                cooldown = true;
            }
        }
        if (cooldown == true)
        {
            timeStamp += Time.deltaTime;
            if (timeStamp >= coolDownPeriodInSeconds)
            {
                AttackLeft.SetActive(false);
                AttackRight.SetActive(false);
                cooldown = false;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Robot Enemy")
        {
            gameManager.lives += 1;
        }
    }

}
