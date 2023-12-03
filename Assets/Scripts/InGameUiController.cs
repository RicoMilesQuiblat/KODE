using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class InGameUiController : MonoBehaviour
{
    public GameObject tools;
    public GameObject journal;
    public GameObject deathScreen;
    public GameObject damageScreen;

    public GameObject dashScreen;



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

    public async void HitScreen(){
        damageScreen.SetActive(true);
        await Task.Delay(100);
        damageScreen.SetActive(false);
    }

    public async void DashScreen(){
        dashScreen.SetActive(true);
        await Task.Delay(100);
        dashScreen.SetActive(false);
    }

    public void Respawn(){
        deathScreen.SetActive(false);
        playerController.Respawn();
    }
}
