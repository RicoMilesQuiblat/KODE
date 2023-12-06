using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossCanvas : MonoBehaviour
{
   public Text text;
    private bool isClicked = false;
    int count = 0;
    public BattleCameraController battleCameraController;
    private int currentDialogue = 0;
    private List<string> dialogues;
    private List<string> dialogues1 = new List<string>(){
        "HOW DARE THEE, BASE VILLEIN! Hark! What audacity besets thee to lay low my kin? Stand forth and parley, or prepare to face the wrath of mine ire!",
    };


    private List<string> dialogues2 = new List<string>(){
        "I shall lay mine terms plain: Yield thee, or thou must parry my queries on the art of flowcharting.",
        "Shouldst thy answers prove true, I grant thee leave to strike upon me—if thine arm be strong enough, that is! MUHAHAHAHA! Fail, and thou shalt know mine fury!"
    };
    private void OnEnable(){
        if(currentDialogue == 0){
            dialogues = dialogues1;
        }else{
            dialogues = dialogues2;
        }
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
        battleCameraController.shouldUpdate = true;
        currentDialogue++;
       
    }
}
