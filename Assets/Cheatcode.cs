using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Cheatcode : MonoBehaviour
{
    public Camera mainCamera;
    public Camera battleCamera;

    public Camera minigameCamera;
    public GameObject battlemode;
    public GameObject minigame;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            ToBattle();
        }if(Input.GetKeyDown(KeyCode.B)){
            MinigameOut();
        }
        
    }
    
    private void ToBattle(){
        battlemode.SetActive(true);
        mainCamera.enabled = false;
        battleCamera.enabled = true;
    }

    private void MinigameOut(){
        minigameCamera.enabled = false;
        mainCamera.enabled = true;
        minigame.SetActive(false);
    }
}
