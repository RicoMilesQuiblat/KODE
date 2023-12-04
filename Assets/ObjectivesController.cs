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
        "Kill the boss",
    };
    public Text objectiveText;

    private int currentObjective = 0;

    public JournalController journalController;
    private void Awake(){
        objectiveText.text = objectives[currentObjective];
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
        yield return new WaitForSeconds(2f);
        slime.SetActive(true);
    }

}
