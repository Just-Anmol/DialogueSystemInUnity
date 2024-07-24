using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeTrigger : MonoBehaviour
{
    [Header("Notification")]
    [SerializeField] private GameObject Notification;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        //setting it false so NCP Notification icon will not pop-up at starting the game
        playerInRange = false;
        Notification.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !DialougeManager.GetInstance().dialogueIsPlaying)
        { 
            Notification.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialougeManager.GetInstance().EnterDialougeMode(inkJSON);
            }
                
        }
        else
        {
            Notification.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInRange = true;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    
}
