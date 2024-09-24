using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float[] playerPosition;
    public int playerScore;
    public string saveTime;

    public SaveData(Player player)
    {
        playerScore = player.score;
        playerPosition = new float[3];
        playerPosition[0] = player.transform.position.x;
        playerPosition[1] = player.transform.position.y;
        playerPosition[2] = player.transform.position.z;
        saveTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}