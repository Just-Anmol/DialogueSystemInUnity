using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    public Vector3 position;

    void Start()
    {
        // Load game state if available
        SaveData data = SaveSystem.LoadGame(1);

        if (data != null)
        {
            // Apply loaded player position and score
            position = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
            score = data.playerScore;

            // Apply the position to the player object
            transform.position = position;
        }
    }
}

