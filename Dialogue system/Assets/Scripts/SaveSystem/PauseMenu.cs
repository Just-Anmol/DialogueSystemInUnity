using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI
    public Player player;

    private bool isPaused = false; // Tracks if the game is paused
    
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
{
            Debug.Log("Working");
    if (isPaused)
    {
        Resume(); // If the game is already paused, resume it
    }
    else
    {
        Pause(); // If the game is not paused, pause it
    }
}
    }

    public void Resume()
    {
        Debug.Log("Resume called");   // Log for debugging
        pauseMenuUI.SetActive(false); // Hide pause menu
        Time.timeScale = 1f;          // Resume the game
        isPaused = false;
    }

    public void Pause()
    {
        Debug.Log("Pause called");    // Log for debugging
        pauseMenuUI.SetActive(true);  // Show pause menu
        Time.timeScale = 0f;          // Freeze the game
        isPaused = true;
    }

    public void SaveGame()
{
        // Call the SaveSystem's save method
        SaveSystem.SaveGame(player, 1);
        Debug.Log("Game Saved!");
}

public void QuitGame()
{
    // Option to quit the game
    Application.Quit();
    Debug.Log("Game Quit");
}
    
}
