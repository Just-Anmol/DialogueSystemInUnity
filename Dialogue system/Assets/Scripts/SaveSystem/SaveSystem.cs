using System.IO;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame(Player player,int slot)
    {
        // Create an instance of SaveData and populate it with current game data
        SaveData data = new SaveData(player);
        data.playerPosition = new float[] { player.transform.position.x, player.transform.position.y, player.transform.position.z };
        data.playerScore = player.score;

        // Convert the save data to JSON format
        string json = JsonUtility.ToJson(data);

        // Define the path to save the file (persistent storage in Unity)
        string path = Application.persistentDataPath + "/saveSlot"+ slot +".json";

        // Write the JSON data to a file
        File.WriteAllText(path, json);
        

        Debug.Log("Game saved to: " + path);
    }
    public static SaveData LoadGame(int slot)
    {
        // Define the path to the saved JSON file
        string path = Application.persistentDataPath + "/saveSlot" + slot + ".json";

        if (File.Exists(path))
        {
            // Read the JSON file as a string
            string json = File.ReadAllText(path);

            // Convert the JSON string back into a SaveData object
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // Return the loaded data
            Debug.Log("Game loaded from: " + path);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    // Delete the save file for the specified slot
    public static void DeleteGame(int slot)
    {
        // Define the path to the save file
        string path = Application.persistentDataPath + "/saveSlot" + slot + ".json";

        // Check if the save file exists and delete it
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Deleted save file in slot " + slot);
        }
        else
        {
            Debug.LogError("No save file to delete in slot " + slot);
        }
    }

}
