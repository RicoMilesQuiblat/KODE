using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattlePlayerDialogue : MonoBehaviour
{
    public Text text;
    private bool isClicked = false;
    int count = 0;
    public BattleCameraController battleCameraController;
    public ObjectivesController objectivesController;

    private int currentDialogue = 0;
    private List<string> dialogues;
    private List<string> dialogues1 = new List<string>(){
        "WHA-?! NO, I can't take this one. ITS SO BIG!",
    };


    private List<string> dialogues2 = new List<string>(){
        "HOW CAN YOU TALK?! B-but anyways, I just need to answer your questions and I can attack you, right?! ",
        "THEN TRY ME, YOU BIG FAT SLIMY BASTARD"
    };

    private List<string> dialogues3 = new List<string>();
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
