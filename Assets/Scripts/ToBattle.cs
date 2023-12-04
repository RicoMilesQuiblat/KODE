using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToBattle : MonoBehaviour
{
    public Camera mainCamera;
    public Camera battleCamera;

    public BatlleController batlleController;

    public void BattleMode(){
        mainCamera.enabled = false;
        Debug.Log(mainCamera.enabled);
        batlleController.Initialize();
        battleCamera.enabled = true;
        Debug.Log(battleCamera.enabled);
    }

    public void OverWorld(){
        battleCamera.enabled = false;
        mainCamera.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            Debug.Log("BattleModeOn");
            BattleMode();
        }
    }

}
