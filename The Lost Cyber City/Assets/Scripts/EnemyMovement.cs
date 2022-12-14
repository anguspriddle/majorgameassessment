using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float enemySpeed;
    public GameObject Waypoint1;
    public GameObject Waypoint2;
    Animator animator;
    void Start()
    {
        enemySpeed = 1.0f;
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        animator.Play("enemyMove");
        transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
        if (transform.position.x >= Waypoint1.transform.position.x) 
        {
            transform.Rotate(0, 180, 0);
        }
        if (transform.position.x <= Waypoint2.transform.position.x) 
        {
            transform.Rotate(0, 180, 0);
        }

    }
}
   