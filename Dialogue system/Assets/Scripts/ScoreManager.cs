using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int score;

    // Creating scoring system
    public void addScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        addScore();
        Destroy(gameObject);
        
    }
    private void Update()
    {
        scoreText.text = "" + score;
    }

}
