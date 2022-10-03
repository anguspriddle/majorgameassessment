using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    void Start()
    {
        enemySpeed = 1.0f;
    }

    void Update()
    {
        transform.Translate(Vector3.right * enemySpeed * Time.deltaTime);
    }
}
   