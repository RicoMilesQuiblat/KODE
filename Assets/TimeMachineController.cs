using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachineController : MonoBehaviour
{
    // Start is called before the first frame update
    public ObjectivesController objectivesController;
    public GameObject chapter2Start;
    public bool shouldUpdate = true;

    public ObjectivesController ObjectivesController
    {
        get => default;
        set
        {
        }
    }


    public GameObject atmosphere;
    public GameObject rain;
    public Chapter2StartDialogueController chapter2StartDialogueController;

    public GameObject player;
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider){
       
        if(collider.tag == "Player"){
            
                if(objectivesController.GetCurrentObjective() == 0 && shouldUpdate){
                    objectivesController.ChangeObjective();
                    shouldUpdate = false;

                }else if(objectivesController.GetCurrentObjective() == 5 && shouldUpdate){
                    chapter2Start.SetActive(true);
                    player.transform.position = new Vector2(-16.03f, 0.56f);
                    StartCoroutine(StartChapter2());
                }
        }


    }

    private IEnumerator StartChapter2(){
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        chapter2Start.SetActive(false);
        chapter2StartDialogueController.StartDialogues();
        atmosphere.SetActive(true);
        rain.SetActive(true);
    }
}
