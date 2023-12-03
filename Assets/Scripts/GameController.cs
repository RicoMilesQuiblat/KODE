using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // public GameObject mainCamera;
    // public GameObject mainGrid;
    // public GameObject mainPlayer;
    // public GameObject mainMonsters;
    public Camera mainCamera;
    public Camera battleCamera;

  

    

    private void Awake(){
        // mainCamera.SetActive(true);
        // mainGrid.SetActive(true);
        // mainPlayer.SetActive(true);
        // mainMonsters.SetActive(true);
        mainCamera.enabled = true;
        battleCamera.enabled = false;
    }
    // public void BattleMode(){
    //     // mainCamera.SetActive(false);
    //     // mainGrid.SetActive(false);
    //     // mainPlayer.SetActive(false);
    //     // mainMonsters.SetActive(false);
    //     Debug.Log("BattleModeOn");
    //     mainGameObject.SetActive(false);
    //     battleGameObject.SetActive(true);
    // }

   

    public void FreeRoamMode(){
        mainCamera.enabled = true;
        battleCamera.enabled = false;
    }
    
}
