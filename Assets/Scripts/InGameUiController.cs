using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUiController : MonoBehaviour
{
    public GameObject tools;
    public GameObject journal;
    public GameObject deathScreen;

    public PlayerController playerController;


    public JournalController journalController;

    public void OpenJournal(){
        tools.SetActive(false);
        journal.SetActive(true);
        journalController.DisplayPage();
    }

    public void CloseJournal(){
        journal.SetActive(false);
        tools.SetActive(true);
    }

    public void DeathScreen(){
        deathScreen.SetActive(true);
    }

    public void Respawn(){
        deathScreen.SetActive(false);
        playerController.Respawn();
    }
}
