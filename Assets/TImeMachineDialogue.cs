using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TImeMachineDialogue : MonoBehaviour
{

    public Text text;
    private bool isClicked = false;
    int count = 0;
    public ObjectivesController objectivesController;
    private List<string> dialogues = new List<string>(){
        "Oh, this is not good. Not good at all. What kind of temporal turbulence did I stumble upon?",
        "Blast it! I never anticipated a detour to the 14th century. The recalibration must have gone haywire. This wasn't part of the plan.",
        "Well, looks like I'll need to improvise a way out of this mess. Time to channel my inner Renaissance inventor and figure out how to fix this contraptions"
    };

    private void Start(){
        StartCoroutine(ChangeText());
    }

    private IEnumerator ChangeText(){
        foreach(var dialogue in dialogues){
            isClicked = false;
             text.text = "";
            float timePerLetter = 20 / dialogue.Length;
            foreach(var letter in dialogue){
                text.text += letter;
                yield return new WaitForSeconds(timePerLetter);
            }
            if(count < 2){

                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            }
            count++;
           
        }
        objectivesController.setShouldUpdate(true);
    }

}
