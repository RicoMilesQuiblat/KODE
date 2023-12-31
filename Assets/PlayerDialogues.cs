using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class FirstSlimeDialogue : MonoBehaviour
{
   public Text text;
   
    public ObjectivesController objectivesController;

    public BeforeBossColliderController beforeBossColliderController;

    public BatlleController batlleController;
    private int currentDialogue = 0;

    public Chapter2StartDialogueController chapter2StartDialogueController;

    private List<string> dialogues;
    private List<string> dialogues1 = new List<string>(){
        "Well, that was... peculiar. Now, what is this? A piece of paper?",
        "NO! Its a torn piece of my journal notes particularly about Flowcharting!",
        "I REMEMBER NOW! My journal pages fell as the machine crashed.",
        "There’s a big chance that slimes ate a piece of these journals. I gotta find more slimes and kill it!"
    };


    private List<string> dialogues2 = new List<string>(){
        "What is that shiny thing over there?"
    };

    private List<string> dialogues3 = new List<string>(){
        "I know it's a bad idea but I wanna go there."
    };

    private List<string> dialogues4 = new List<string>(){
        "I should go back to the time machine and rest."
    };

    public BeforeBossColliderController BeforeBossColliderController
    {
        get => default;
        set
        {
        }
    }

    public ObjectivesController ObjectivesController
    {
        get => default;
        set
        {
        }
    }

    private List<string> dialogues5 = new List<string>(){
        "Ah, THIEVES! Wait… NO! GOBLINS! "
    };

    private List<string> dialogues6 = new List<string>(){
        "Now, let's head back to the time machine and try to put this again to its rightful place"
    };

    private void Start(){
        
    }

    private void OnEnable(){
        if(currentDialogue == 0){
            dialogues = dialogues1;
        }else if(currentDialogue == 1){
            dialogues = dialogues2;
        }else if(currentDialogue == 2){
            dialogues = dialogues3;
        }else if(currentDialogue == 3){
            dialogues = dialogues4;
        }else if(currentDialogue == 4){
            dialogues = dialogues5;
        }else if(currentDialogue == 5){
            dialogues = dialogues6;
        }
        StartCoroutine(ChangeText());
    }

    private IEnumerator ChangeText(){
        foreach(var dialogue in dialogues){
            text.text = "";
            float timePerLetter = 20 / dialogue.Length;
            foreach(var letter in dialogue){
                text.text += letter;
                yield return new WaitForSeconds(timePerLetter);
            }
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            
        }
        if(currentDialogue == 2 || currentDialogue == 1){
            beforeBossColliderController.SetShouldUpdate(true);
        }else if(currentDialogue == 4){
            chapter2StartDialogueController.shouldUpdate = true;
        }
       
        objectivesController.setShouldUpdate(true);
        
        currentDialogue++;
    }
}
