using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeforeBossColliderController : MonoBehaviour
{

    public Camera mainCamera;
    public Camera bossEntranceCamera;
    public Camera playerMiniCamera;
    public PlayerController playerController;

    public GameObject playerCanvas;

    public ObjectivesController objectivesController;
    
    private bool shouldUpdate = false;
    private void OnTriggerEnter2D(Collider2D collider){
        FirstSwitch();
    }
    
    private void FirstSwitch(){
        playerController.SetCanAttack(false);
        mainCamera.enabled = false;
        playerMiniCamera.enabled = true;
        playerCanvas.SetActive(true);
        StartCoroutine(SecondSwitch());
    }
    public void SetShouldUpdate(bool setter){
        shouldUpdate = setter;
    }

    IEnumerator SecondSwitch(){
        yield return new WaitUntil(() => shouldUpdate);
        playerMiniCamera.enabled = false;
        bossEntranceCamera.enabled = true;
        playerCanvas.SetActive(false);
        shouldUpdate = false;
        yield return new WaitForSeconds(3f);
        bossEntranceCamera.enabled = false;
        playerMiniCamera.enabled = true;
        playerCanvas.SetActive(true);
        yield return new WaitUntil(() => shouldUpdate);
        playerMiniCamera.enabled = false;
        mainCamera.enabled = true;
        playerCanvas.SetActive(false);
         shouldUpdate = false;
         objectivesController.ChangeObjective();
        
        gameObject.SetActive(false);
    }

}
