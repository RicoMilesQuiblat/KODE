using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BatlleController : MonoBehaviour
{

    private Questions questionSource;
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

     public SceneSwitcher sceneSwitcher;

    public List<int> temp;
    private Scene currentScene;



    private void Awake(){
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.buildIndex == 0){
            questionSource = new FlowChartQuestions();
        }else if(currentScene.buildIndex == 1){
            questionSource = new InputOutputQuestions();
        }else if(currentScene.buildIndex == 2){
            questionSource = new OperatorQuestions();
        }
        Initialize();
       
    }



    public void Update(){
        Debug.Log("gago " + shouldUpdate);
        Debug.Log("HP " + monsterInitialHP);
        if(shouldUpdate){

            if (playerInitialHP <= 0){
                playerController.Removelife();
                gameController.FreeRoamMode();
                shouldUpdate = false;
            }else if(monsterInitialHP <= 0){
                sceneSwitcher.SwitchScene();
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
        temp = new List<int>(){
        0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        playerHp.value = playerInitialHP;
        monsterHp.value = monsterInitialHP;
        Debug.Log(questionSource.questions);

        foreach(var question in questionSource.questions){
            questions.Add(question.Key, question.Value);
            Debug.Log(question);
            
        }

        foreach(var answer in questionSource.answers){
            answers.Add(answer);
            Debug.Log(answer);
        }

        SelectQuestion();
        Display();
    }

    private void SelectQuestion(){
        
        int randomNumber = temp[Random.Range(0 , temp.Count)];
        chosenQuestion = questions.Keys.ElementAt(randomNumber);

        temp.Remove(randomNumber);
            
        answerCode = questions[chosenQuestion];


        foreach(var number in temp){
                Debug.Log(number);
        
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
        }else if (answerCode <= 19)
        {
            choices.Add(answers[16]);
            choices.Add(answers[17]);
            choices.Add(answers[18]);
            choices.Add(answers[19]);
        }
        else if (answerCode <= 23)
        {
            choices.Add(answers[20]);
            choices.Add(answers[21]);
            choices.Add(answers[22]);
            choices.Add(answers[23]);
        }
        else if (answerCode <= 27)
        {
            choices.Add(answers[24]);
            choices.Add(answers[25]);
            choices.Add(answers[26]);
            choices.Add(answers[27]);
        }
        else if (answerCode <= 31)
        {
            choices.Add(answers[28]);
            choices.Add(answers[29]);
            choices.Add(answers[30]);
            choices.Add(answers[31]);
        }
        else if (answerCode <= 35)
        {
            choices.Add(answers[32]);
            choices.Add(answers[33]);
            choices.Add(answers[34]);
            choices.Add(answers[35]);
        }
        else
        {
            choices.Add(answers[36]);
            choices.Add(answers[37]);
            choices.Add(answers[38]);
            choices.Add(answers[39]);
        }

        dialogueBox.ChangeQuestion(chosenQuestion);

        dialogueBox.ChangeChoices(choices);

    }

    public void Button1Click()
    {
        Debug.Log("button clicked");
        if(answerCode == 0 || answerCode == 4 || answerCode == 8 || answerCode == 12 || answerCode == 16 || answerCode == 20 || answerCode == 24 || answerCode == 28 || answerCode == 32 || answerCode == 36){
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
        if(answerCode == 1 || answerCode == 5 || answerCode == 9 || answerCode == 13 || answerCode == 17 || answerCode == 21 || answerCode == 25 || answerCode == 29 || answerCode == 33 || answerCode == 37){
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
        if(answerCode == 2 || answerCode == 6 || answerCode == 10 || answerCode == 14 || answerCode == 18 || answerCode == 22 || answerCode == 26 || answerCode == 30 || answerCode == 34 || answerCode == 38 ){
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
        if(answerCode == 3 || answerCode == 7 || answerCode == 11 || answerCode == 15 || answerCode == 19 || answerCode == 23 || answerCode == 27 || answerCode == 31 || answerCode == 35 || answerCode == 39){
            monsterInitialHP -= 2;
            monsterHp.value = monsterInitialHP;
            NextQuestion();
        }else{
            playerInitialHP -= 2;
            playerHp.value = playerInitialHP;
        }
        
    }



}

