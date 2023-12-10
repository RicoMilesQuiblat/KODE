using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesController : MonoBehaviour
{

    public Animator animator;
    public GameObject slime;

    [SerializeField] private GameObject slimeBoss;
    private List<string> objectives = new List<string>(){
        "",
        "Go and Check the time machine",
        "Defeat the Slime",
        "Collect Journals ",
        "Explore the surrounding area",
        "Defeat the Slime Boss",
        "Go back to the time machine",
        "Find the goblins",
        "Follow the footsteps",
        "Head back to the time machine"
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
    [SerializeField] private GameObject cutscene3;

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
        if(currentObjective == 1){
            StartCoroutine(SpawnFirstSlime());
        }else if(currentObjective == 3 && journalController.GetJournalCount() < 5){
            
            animator.SetTrigger("Change");
            currentObjective -= 1;
        }else if(currentObjective == 3 && journalController.GetJournalCount() == 5){
            animator.SetTrigger("Change");
            slimeBoss.SetActive(true);
            cutscene3.SetActive(true);
        }
        else if(currentObjective == 7 && journalController.GetJournalCount() >5 && journalController.GetJournalCount() < 8){
            animator.SetTrigger("Change");
            currentObjective -= 1;
        }else if(currentObjective == 7 && journalController.GetJournalCount() == 8 ){
            animator.SetTrigger("Change");
        }
        
        animator.SetTrigger("Change");
        
        currentObjective += 1;
        

    }

    public void PlayAnimation(){
        animator.SetTrigger("Change");
    }

    public void ChangeText(){
        string newText = objectives[currentObjective];
        if(currentObjective == 3){
            newText = newText + journalController.GetJournalCount() + "/5"; 
        }
        if(currentObjective == 7){
            newText = newText + (journalController.GetJournalCount() - 5) + "/3";
        }
        objectiveText.text = newText;
    }

    public int GetCurrentObjective(){
        return currentObjective;
    }

    IEnumerator SpawnFirstSlime(){
        slime.SetActive(true);
        shouldUpdate = false;
        yield return null;
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
