using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToBattle : MonoBehaviour
{
    public Camera mainCamera;
    public Camera battleCamera;

    public BatlleController batlleController;
    public GameObject atmosphere;
    public BattleCameraController battleCameraController;

    public bool shouldUpdate = false;

    public void BattleMode(){
        if(atmosphere){
            atmosphere.SetActive(false);
        }
        mainCamera.enabled = false;
        Debug.Log("omsim ka");
        StartCoroutine(StartBattleDialogue());
        Debug.Log(mainCamera.enabled);
        batlleController.Initialize();
        battleCamera.enabled = true;
        Debug.Log(battleCamera.enabled);
    }

    IEnumerator StartBattleDialogue(){
        Debug.Log("Omsim chuy");
        battleCameraController.StartDialogue();
        yield return new WaitUntil(() => shouldUpdate);
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
