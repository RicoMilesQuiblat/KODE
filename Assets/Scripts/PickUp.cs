using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public JournalController journalController;
    public ObjectivesController objectivesController;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Debug.Log("pickup");
            journalController.AddPage();
            objectivesController.ChangeObjective();
               
            }
            Destroy(gameObject);
        }
    }

