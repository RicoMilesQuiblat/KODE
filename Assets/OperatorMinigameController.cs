using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OperatorMinigameController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera miniGameCamera;
    public GameObject minigame;

    public GameObject minigameCanvas;

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            StartCoroutine(StartMinigame());
        }
    }

    public void goBack(){
        miniGameCamera.enabled = false;
        mainCamera.enabled = true;
    }

    private IEnumerator StartMinigame(){
        minigame.SetActive(true);
        mainCamera.enabled = false;
        miniGameCamera. enabled = true;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        minigameCanvas.SetActive(false);
    }

}
