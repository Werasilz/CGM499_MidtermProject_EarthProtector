using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timer;
    public static int score;
    public static int health;

    public Text scoreText;
    public Text healthText;
    public Text timerText;

    void Start()
    {
        timer = 60;
        score = 0;
        health = 100;
    }

    void Update()
    {
        timerText.text = "Time : " + Mathf.Round(timer);
        healthText.text = "HP : " + health.ToString();
        scoreText.text = "Score : " + score.ToString();

        if(PlaceObjectOnPlane.isSetPos)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            SceneManager.LoadScene("Main");
            PlaceObjectOnPlane.isSetPos = false;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("ARGame");
        PlaceObjectOnPlane.isSetPos = false;
    }
}
