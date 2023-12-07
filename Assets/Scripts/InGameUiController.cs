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

    public GameObject gameOverScreen;
    public GameObject Maze_StartScreen;
    public GameObject Maze_InputScreen;
    public GameObject Maze_IfScreen;
    public GameObject Maze_ProcessScreen;
    public GameObject LowHPScreen;


    public PlayerController playerController;


    public JournalController journalController;

    public PlayerController PlayerController
    {
        get => default;
        set
        {
        }
    }

    public JournalController JournalController
    {
        get => default;
        set
        {
        }
    }

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
    public void mazestartscreen(){
        Maze_StartScreen.SetActive(true);
    }

    public void mazestartscreenCLOSE(){
        Maze_StartScreen.SetActive(false);
    }

    public void mazeifscreen(){
        Maze_IfScreen.SetActive(true);
    }

    public void mazeifscreenCLOSE(){
        Maze_IfScreen.SetActive(false);
    }

    public void mazeprocessscreen(){
        Maze_ProcessScreen.SetActive(true);
    }

    public void mazeprocessscreenCLOSE(){
        Maze_ProcessScreen.SetActive(false);
    }

    public void mazeinputscreen(){
        Maze_InputScreen.SetActive(true);
    }

    public void mazeinputscreenCLOSE(){
        Maze_InputScreen.SetActive(false);
    }

    public void lowhpscreen(){
        LowHPScreen.SetActive(true);
    }

    public void lowhpscreenCLOSE(){
        LowHPScreen.SetActive(false);
    }
    public void GameOverScreen(){
        gameOverScreen.SetActive(true);
    }
}
