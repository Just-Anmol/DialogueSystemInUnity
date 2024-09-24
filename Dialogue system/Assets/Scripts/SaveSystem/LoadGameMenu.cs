using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using System.IO;

public class LoadGameMenu : MonoBehaviour
{
    
    public Button slot1Button;
    public Button slot2Button;
    public Button slot3Button;
    public Button deleteSlot1Button;
    public Button deleteSlot2Button;
    public Button deleteSlot3Button;
    public Text slot1Text;
    public Text slot2Text;
    public Text slot3Text;

    void Start()
    {
        // Update the UI to reflect the saved game data in each slot
        UpdateSlotUI(1, slot1Text);
        UpdateSlotUI(2, slot2Text);
        UpdateSlotUI(3, slot3Text);

        // Add listeners to the load game buttons
        slot1Button.onClick.AddListener(() => LoadGame(1));
        slot2Button.onClick.AddListener(() => LoadGame(2));
        slot3Button.onClick.AddListener(() => LoadGame(3));

        // Add listeners to the delete game buttons
        deleteSlot1Button.onClick.AddListener(() => DeleteGame(1, slot1Text));
        deleteSlot2Button.onClick.AddListener(() => DeleteGame(2, slot2Text));
        deleteSlot3Button.onClick.AddListener(() => DeleteGame(3, slot3Text));
    }

    void LoadGame(int slot)
    {
        SaveData data = SaveSystem.LoadGame(slot);
        if (data != null)
        {
            // Load the game scene (or apply the loaded data)
            SceneManager.LoadScene("SampleScene");
            Debug.Log("Loaded save from slot " + slot);
        }
    }

    void DeleteGame(int slot, Text slotText)
    {
        SaveSystem.DeleteGame(slot);
        UpdateSlotUI(slot, slotText);  // Update the UI after deletion
    }

    void UpdateSlotUI(int slot, Text slotText)
    {
        string path = Application.persistentDataPath + "/saveSlot" + slot + ".json";
        if (File.Exists(path))
        {
            SaveData data = SaveSystem.LoadGame(slot);
            if (data != null)
            {
                slotText.text = "Saved: " + data.saveTime;  // Display save time if save exists
            }
        }
        else
        {
            slotText.text = "Empty Slot";  // Show "Empty Slot" if no save file exists
        }
    }
}
