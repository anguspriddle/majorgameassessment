using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float enemySpeed;
    private bool faceRight;
    public GameObject Waypoint1;
    public GameObject Waypoint2;
    void Start()
    {
        faceRight = true;
        enemySpeed = 1.0f;
    }

    void Update()
    {
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
   