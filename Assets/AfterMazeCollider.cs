using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterMazeCollider : MonoBehaviour
{
    [SerializeField] ObjectivesController objectivesController;
     [SerializeField] GameObject teleporter;

    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            Debug.Log("tae");
            objectivesController.ChangeObjective();
            teleporter.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
