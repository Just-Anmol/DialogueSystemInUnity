using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private string Id;

    [ContextMenu("Generate Guid for Id")]
    private void GenerateGuid()
    {
        Id = System.Guid.NewGuid().ToString();
    }


    public TextMeshProUGUI scoreText;
    public static int coin;
    private bool collected = false;
    private SpriteRenderer visual;

    private void Awake()
    {
        visual = GetComponent<SpriteRenderer>();

    }
    // Creating scoring system
    public void addScore()
    {
        coin++;
        scoreText.text = coin.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        addScore();
        Destroy(gameObject);
        
    }
    private void Update()
    {
        scoreText.text = "" + coin;
    }

   
   
}
