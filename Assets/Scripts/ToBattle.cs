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
    public GameObject playerHP;
    public GameObject monsterHP;

    public bool shouldUpdate = false;

    public BatlleController BatlleController
    {
        get => default;
        set
        {
        }
    }

    public BattleCameraController BattleCameraController
    {
        get => default;
        set
        {
        }
    }

    public void BattleMode(){
        if(atmosphere){
            atmosphere.SetActive(false);
        }
        mainCamera.enabled = false;
        Debug.Log("omsim ka");
        StartCoroutine(StartBattleDialogue());
        
    }

    public void Initialize(){
        Debug.Log(mainCamera.enabled);
        battleCamera.enabled = true;
        Debug.Log(battleCamera.enabled);
        playerHP.SetActive(true);
        monsterHP.SetActive(true);
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
