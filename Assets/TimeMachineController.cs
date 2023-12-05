using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachineController : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera mainCamera;
    public ObjectivesController objectivesController;
    private bool shouldUpdate = true;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider){
       
        if(collider.tag == "Player"){
            
                if(objectivesController.GetCurrentObjective() == 0 && shouldUpdate){
                    objectivesController.ChangeObjective();
                    shouldUpdate = false;

                }
        }
    }
}
