using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueBox : MonoBehaviour
{
    public Text question;
    public Text choice1;
    public Text choice2;
    public Text chocie3;
    public Text choice4;

    

    
    public void ChangeQuestion(string newQuestion){
        question.text = newQuestion;
    }

    public void ChangeChoices(List<string> choices){
        choice1.text = choices[0];
        choice2.text = choices[1];
        chocie3.text = choices[2];
        choice4.text = choices[3];
    }


}
