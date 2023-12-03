using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class BatlleController : MonoBehaviour
{
    private Dictionary<string, int> questions;
    private List<string> answers;

    private List<string> choices;

    public DialogueBox dialogueBox;
    private int playerInitialHP;
    private int monsterInitialHP;
    private string chosenQuestion;
    private int answerCode;
    private bool isCorrect = false;

    public Slider playerHp;
    public Slider monsterHp;

    public GameController gameController;
     
     public PlayerController playerController;

     private bool shouldUpdate;





    private void Awake(){
        Initialize();
       
    }



    public void Update(){
        if(shouldUpdate){

            if (playerInitialHP <= 0 || monsterInitialHP <= 0){
                playerController.Removelife();
                gameController.FreeRoamMode();
                shouldUpdate = false;
            }
        }
    }

    private void NextQuestion(){
        SelectQuestion();
        Display();
    }

    public void Initialize()
    {
        shouldUpdate = true;
        playerInitialHP = 10;
        monsterInitialHP = 20;
        questions = new Dictionary<string, int>();
        answers = new List<string>();
        choices = new List<string>();
        playerHp.value = playerInitialHP;
        monsterHp.value = monsterInitialHP;

        questions.Add("What shape in a flowchart represents a process?", 1);
        answers.Add("a.Oval");
        answers.Add("b.Rectangle");
        answers.Add("c.Diamond");
        answers.Add("d.Arrow");
        questions.Add("Which symbol is used to depict a decision in a flowchart?", 6);
        answers.Add("a.Oval");
        answers.Add("b.Rectangle");
        answers.Add("c.Diamond");
        answers.Add("d.Arrow");
        questions.Add("What does the rectangle symbolize in a flowchart?", 10);
        answers.Add("a.Start/End");
        answers.Add("b.Process");
        answers.Add("c.Decision");
        answers.Add("d.Connector");
        questions.Add("What shape is used to indicate the start or end of a process in a flowchart?", 12);
        answers.Add("a.Oval");
        answers.Add("b.Rectangle");
        answers.Add("c.Diamond");
        answers.Add("d.Arrow");
        questions.Add("In a flowchart, what does an arrow represent?", 17);
        answers.Add("a.Data");
        answers.Add("b.Direction");
        answers.Add("c.Decision");
        answers.Add("d.Process");

        SelectQuestion();
        Display();
    }

    private void SelectQuestion(){
        string currentQuestion = chosenQuestion;

        while(currentQuestion == chosenQuestion){
            chosenQuestion = questions.Keys.ElementAt(Random.Range(0, questions.Count));
            answerCode = questions[chosenQuestion];
        }
    }
    private void Display()
    {
        choices.Clear();

        if (answerCode <= 3)
        {
            choices.Add(answers[0]);
            choices.Add(answers[1]);
            choices.Add(answers[2]);
            choices.Add(answers[3]);
        }
        else if (answerCode <= 7)
        {
            choices.Add(answers[4]);
            choices.Add(answers[5]);
            choices.Add(answers[6]);
            choices.Add(answers[7]);
        }
        else if (answerCode <= 11)
        {
            choices.Add(answers[8]);
            choices.Add(answers[9]);
            choices.Add(answers[10]);
            choices.Add(answers[11]);
        }
        else if (answerCode <= 15)
        {
            choices.Add(answers[12]);
            choices.Add(answers[13]);
            choices.Add(answers[14]);
            choices.Add(answers[15]);
        }
        else
        {
            choices.Add(answers[16]);
            choices.Add(answers[17]);
            choices.Add(answers[18]);
            choices.Add(answers[19]);
        }

        dialogueBox.ChangeQuestion(chosenQuestion);

        dialogueBox.ChangeChoices(choices);

    }

    public void Button1Click()
    {
        Debug.Log("button clicked");
        if(answerCode == 0 || answerCode == 4 || answerCode == 8 || answerCode == 12 || answerCode == 16){
            monsterInitialHP -= 2;
            monsterHp.value = monsterInitialHP;
            NextQuestion();
        }else{
            playerInitialHP -= 2;
            playerHp.value = playerInitialHP;
        }
    }
    public void Button2Click()
    {
        Debug.Log("button clicked");
        if(answerCode == 1 || answerCode == 5 || answerCode == 9 || answerCode == 13 || answerCode == 17){
            monsterInitialHP -= 2;
             monsterHp.value = monsterInitialHP;
             NextQuestion();
        }else{
            playerInitialHP -= 2;
            playerHp.value = playerInitialHP;
            
        }
        
    }

    public void Button3Click()
    {
        Debug.Log("button clicked");
        if(answerCode == 2 || answerCode == 6 || answerCode == 10 || answerCode == 14 || answerCode == 18){
            monsterInitialHP -= 2;
            monsterHp.value = monsterInitialHP;
            NextQuestion();
        }else{
            playerInitialHP -= 2;
            playerHp.value = playerInitialHP;
        }
        
    }

    public void Button4Click()
    {
        Debug.Log("button clicked");
        if(answerCode == 3 || answerCode == 7 || answerCode == 11 || answerCode == 15 || answerCode == 19){
            monsterInitialHP -= 2;
            monsterHp.value = monsterInitialHP;
            NextQuestion();
        }else{
            playerInitialHP -= 2;
            playerHp.value = playerInitialHP;
        }
        
    }



}

