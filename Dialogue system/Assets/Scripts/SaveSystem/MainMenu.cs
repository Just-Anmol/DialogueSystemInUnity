using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LoadGameUI;
    public GameObject MainMenuUI;
    public void StartNewGame()
    {
        // Logic for starting a new game
        SceneManager.LoadScene("SampleScene"); // Load the main game scene
    }

    public void LoadGame()
    {

        LoadGameUI.SetActive(true); 
        MainMenuUI.SetActive(false);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Onback()
    {
        LoadGameUI.SetActive(false );
        MainMenuUI.SetActive(true);
    }
}
