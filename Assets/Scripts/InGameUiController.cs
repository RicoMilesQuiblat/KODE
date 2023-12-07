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
    public GameObject Maze_EndScreen;

    //


    public GameObject Maze_StartScreen1;
    public GameObject Maze_InputScreen1;
    public GameObject Maze_IfScreen1;
    public GameObject Maze_ProcessScreen1;
    public GameObject Maze_EndScreen1;

    //


    public GameObject Maze_StartScreen2;
    public GameObject Maze_InputScreen2;
    public GameObject Maze_IfScreen2;
    public GameObject Maze_ProcessScreen2;
    public GameObject Maze_EndScreen2;

    //

    public GameObject Maze_StartScreen3;
    public GameObject Maze_InputScreen3;
    public GameObject Maze_IfScreen3;
    public GameObject Maze_ProcessScreen3;
    public GameObject Maze_EndScreen3;


    //

    public GameObject Maze_StartScreen4;
    public GameObject Maze_InputScreen4;
    public GameObject Maze_IfScreen4;
    public GameObject Maze_ProcessScreen4;
    public GameObject Maze_EndScreen4;


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
    public void lowhpscreen(){
        LowHPScreen.SetActive(true);
    }

    public void lowhpscreenCLOSE(){
        LowHPScreen.SetActive(false);
    }
    public void GameOverScreen(){
        gameOverScreen.SetActive(true);
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

    public void mazeendscreen(){
        Maze_EndScreen.SetActive(true);
    }

    public void mazeendscreenCLOSE(){
        Maze_EndScreen.SetActive(false);
    }


    //

    public void mazestartscreen1(){
        Maze_StartScreen1.SetActive(true);
    }

    public void mazestartscreenCLOSE1(){
        Maze_StartScreen1.SetActive(false);
    }

    public void mazeifscreen1(){
        Maze_IfScreen1.SetActive(true);
    }

    public void mazeifscreenCLOSE1(){
        Maze_IfScreen1.SetActive(false);
    }

    public void mazeprocessscreen1(){
        Maze_ProcessScreen1.SetActive(true);
    }

    public void mazeprocessscreenCLOSE1(){
        Maze_ProcessScreen1.SetActive(false);
    }

    public void mazeinputscreen1(){
        Maze_InputScreen1.SetActive(true);
    }

    public void mazeinputscreenCLOSE1(){
        Maze_InputScreen1.SetActive(false);
    }

    public void mazeendscreen1(){
        Maze_EndScreen1.SetActive(true);
    }

    public void mazeendscreenCLOSE1(){
        Maze_EndScreen1.SetActive(false);
    }

    //

    public void mazestartscreen2(){
        Maze_StartScreen2.SetActive(true);
    }

    public void mazestartscreenCLOSE2(){
        Maze_StartScreen2.SetActive(false);
    }

    public void mazeifscreen2(){
        Maze_IfScreen2.SetActive(true);
    }

    public void mazeifscreenCLOSE2(){
        Maze_IfScreen2.SetActive(false);
    }

    public void mazeprocessscreen2(){
        Maze_ProcessScreen2.SetActive(true);
    }

    public void mazeprocessscreenCLOSE2(){
        Maze_ProcessScreen2.SetActive(false);
    }

    public void mazeinputscreen2(){
        Maze_InputScreen2.SetActive(true);
    }

    public void mazeinputscreenCLOSE2(){
        Maze_InputScreen2.SetActive(false);
    }

    public void mazeendscreen2(){
        Maze_EndScreen2.SetActive(true);
    }

    public void mazeendscreenCLOSE2(){
        Maze_EndScreen2.SetActive(false);
    }

    //


    public void mazestartscreen3(){
        Maze_StartScreen3.SetActive(true);
    }

    public void mazestartscreenCLOSE3(){
        Maze_StartScreen3.SetActive(false);
    }

    public void mazeifscreen3(){
        Maze_IfScreen3.SetActive(true);
    }

    public void mazeifscreenCLOSE3(){
        Maze_IfScreen3.SetActive(false);
    }

    public void mazeprocessscreen3(){
        Maze_ProcessScreen3.SetActive(true);
    }

    public void mazeprocessscreenCLOSE3(){
        Maze_ProcessScreen3.SetActive(false);
    }

    public void mazeinputscreen3(){
        Maze_InputScreen3.SetActive(true);
    }

    public void mazeinputscreenCLOSE3(){
        Maze_InputScreen3.SetActive(false);
    }

    public void mazeendscreen3(){
        Maze_EndScreen3.SetActive(true);
    }

    public void mazeendscreenCLOSE3(){
        Maze_EndScreen3.SetActive(false);
    }

    //

    public void mazestartscreen4(){
        Maze_StartScreen4.SetActive(true);
    }

    public void mazestartscreenCLOSE4(){
        Maze_StartScreen4.SetActive(false);
    }

    public void mazeifscreen4(){
        Maze_IfScreen4.SetActive(true);
    }

    public void mazeifscreenCLOSE4(){
        Maze_IfScreen4.SetActive(false);
    }

    public void mazeprocessscreen4(){
        Maze_ProcessScreen4.SetActive(true);
    }

    public void mazeprocessscreenCLOSE4(){
        Maze_ProcessScreen4.SetActive(false);
    }

    public void mazeinputscreen4(){
        Maze_InputScreen4.SetActive(true);
    }

    public void mazeinputscreenCLOSE4(){
        Maze_InputScreen4.SetActive(false);
    }

    public void mazeendscreen4(){
        Maze_EndScreen4.SetActive(true);
    }

    public void mazeendscreenCLOSE4(){
        Maze_EndScreen4.SetActive(false);
    }

    //



    
}
