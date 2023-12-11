using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public enum PickupType {
        scroll,
        add,
        minus,
        multiply,
        divide,
        modulo,
        greaterThan,
        lessThan,
        greaterThanOrEqual,
        lesserThanOrEqual,
        equal,
        notEqual,
        and,
        or,
        not
    }

    public PickupType pickupType;
    public JournalController journalController;
    public ObjectivesController objectivesController;

    public ObjectivesController ObjectivesController;

    public PlayerController playerController;
    public JournalController JournalController;
    public GameObject firstDialogue;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            if(pickupType == PickupType.scroll){
                if(journalController.GetJournalCount() == 0){
                    firstDialogue.SetActive(true);
                }
                Debug.Log("pickup");
                journalController.AddPage();
                objectivesController.ChangeObjective();
                Destroy(gameObject);
               
            }else{
                switch(pickupType){
                    case PickupType.greaterThan:
                        playerController.Debuffs(0);
                        break;
                    case PickupType.lessThan:
                        playerController.Debuffs(1);
                        break;
                }
                gameObject.SetActive(false);
            }
            }
        }
    }

