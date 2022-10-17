using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public Text timeText;
    public Text healthText;
    public float TimeLeft;
    public float currentTime = 300;
    public bool TimerOn = false;
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {

            currentTime = currentTime - Time.deltaTime;

            float minutes = Mathf.FloorToInt((currentTime / 60));
            float seconds = Mathf.FloorToInt((currentTime % 60));
            timeText.text = string.Format("Time: {0:00} : {1:00}", minutes, seconds);
        }
    }

