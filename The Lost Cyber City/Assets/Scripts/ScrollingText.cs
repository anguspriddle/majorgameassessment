using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour
{
    public int textSpeed;
    // Start is called before the first frame update
    void Start()
    {
        textSpeed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * textSpeed * Time.deltaTime);
    }
}
