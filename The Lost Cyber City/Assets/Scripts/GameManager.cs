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
    public bool TimerOn = false;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
        TimeLeft = 420;
    }

    // Update is called once per frame
    void Update()
    {

            TimeLeft -= Time.deltaTime;

            float minutes = Mathf.FloorToInt((TimeLeft / 60));
            float seconds = Mathf.FloorToInt((TimeLeft % 60));
        // timeText.text = string.Format("Time: {0:00} : {1:00}", minutes, seconds);
                timeText.text = "Score: " + score;
        }
    }

