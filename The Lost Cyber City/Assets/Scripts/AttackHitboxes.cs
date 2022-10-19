using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitboxes : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Robot Enemy")
        {
            gameManager.score += 1;
        }

    }
}
