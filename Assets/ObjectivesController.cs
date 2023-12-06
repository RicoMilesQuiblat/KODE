using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesController : MonoBehaviour
{

    public Animator animator;
    public GameObject slime;
    private List<string> objectives = new List<string>(){
        "Go and Check the time machine",
        "Defeat the Slime",
        "Collect Journals ",
        "Continue exploring the forest",
        "Enter the mysterious entrance",
        "Go back to the time machine",
    };
    public Text objectiveText;

    public Camera mainCamera;
    public Camera timeMachineCamera;
    public Camera playerMiniCamera;
    public GameObject playerMiniCameraCanvas;

    private bool shouldSwitchSlime = true;


    private int currentObjective = 0;

    public JournalController journalController;

    public GameObject timeMachineCanvas;

    public PlayerController playerController;

    public GameObject subQuest;
    public bool firstCompletion = false;
    private bool shouldUpdate = false;

    public void setShouldUpdate(bool should){
        shouldUpdate = should;
    }
    private void Awake(){
        objectiveText.text = objectives[currentObjective];
    }

    private void Update(){
        if(!slime && shouldSwitchSlime){
            StartCoroutine(PlayerMiniCamera());
            shouldSwitchSlime = false;
        }
    }


    public void ChangeObjective(){
        if(currentObjective == 0){
            StartCoroutine(SpawnFirstSlime());
        }else if(currentObjective == 2 && journalController.GetJournalCount() < 5){
            
            animator.SetTrigger("Change");
            currentObjective -= 1;
        }else if(currentObjective == 2 && journalController.GetJournalCount() == 5){
            animator.SetTrigger("Change");
        }
        
        
        animator.SetTrigger("Change");
        
        currentObjective += 1;
        

    }

    public void ChangeText(){
        string newText = objectives[currentObjective];
        if(currentObjective == 2){
            newText = newText + journalController.GetJournalCount() + "/5"; 
        }
        objectiveText.text = newText;
    }

    public int GetCurrentObjective(){
        return currentObjective;
    }

    IEnumerator SpawnFirstSlime(){
        playerController.SetCanAttack(false);
        Debug.Log(currentObjective);
        mainCamera.enabled = false;
        timeMachineCamera.enabled = true;
        timeMachineCanvas.SetActive(true);
        yield return new WaitUntil(() => shouldUpdate);
        yield return new WaitForSeconds(4f);
        slime.SetActive(true);
        StartCoroutine(TimeMachineCamera());
        shouldUpdate = false;
    }

    IEnumerator TimeMachineCamera(){
        yield return new WaitForSeconds(1f);
        timeMachineCanvas.SetActive(false);
        mainCamera.enabled = true;
        timeMachineCamera.enabled = false;
        playerController.SetCanAttack(true);
    }

    IEnumerator PlayerMiniCamera(){
        playerController.SetCanAttack(false);
        mainCamera.enabled = false;
        playerMiniCamera.enabled = true;
        playerMiniCameraCanvas.SetActive(true);
        yield return new WaitUntil(() => shouldUpdate);
        playerMiniCamera.enabled = false;
        mainCamera.enabled = true;
        playerMiniCameraCanvas.SetActive(false);
        playerController.SetCanAttack(true);
    }

    

}
