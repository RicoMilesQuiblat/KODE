using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OeprationGameController : MonoBehaviour
{
    [SerializeField]
    public TMP_InputField input;

    [SerializeField]
    public TMP_Text text;

    [SerializeField]
    private GameObject btn;
    private int num;
    private int ctr = 0;
    private Boolean isLess, isGreat, isEqual = false;
    void Awake() {
        num = UnityEngine.Random.Range(0, 100);
        text.text = "Guess a number between 0 and 100";
    }

    public void GetInput(string guess) {
        ctr++;

        int parsedInput; 

        if (int.TryParse(guess, out parsedInput))
        {
            CompareGuesses(parsedInput);
        }
        else
        {
            text.text = "Invalid input. Please enter a valid number.";
            text.alignment = TextAlignmentOptions.Center;
            parsedInput = 0;  
        }
        input.text = "";
    }


    void CompareGuesses(int guess) {
        text.alignment = TextAlignmentOptions.Left;
        if(guess == num) {
            text.text = "";
            if(ctr == 1 || isEqual) {
                isEqual = true;
                text.text = string.Format("if (guess == number) {{\n\tprintf(\"You guessed correctly, the number was {0}. \n\t\tIt took you {1} guess(es).\n\t\tDo you want to play again?\");\n}}", guess, ctr);
            } else {
                text.text = string.Format("else if (guess == number) {{\n\tprintf(\"You guessed correctly, the number was {0}. \n\t\tIt took you {1} guess(es).\n\t\tDo you want to play again?\");\n}}", guess, ctr);
            }
            btn.SetActive(true);
        } else if(guess < num) {
            text.text = "";
            if(ctr == 1 || isLess) {
                isLess = true;
                text.text = "if (guess < number) {\n\tprintf(\"Your guess is lesser than the number.\");\n}"; 
            } else {
                text.text = "else if (guess < number) {\n\tprintf(\"Your guess is lesser than the number.\");\n}"; 
            }
        } else if(guess > num) {
            text.text = "";
            if(ctr == 1 || isGreat) {
                isGreat = true;
                text.text = "if (guess > number) {\n\tprintf(\"Your guess is greater than the number.\");\n}"; 
            } else {
                text.text = "else if (guess > number) {\n\tprintf(\"Your guess is greater than the number.\");\n}"; 
            }
        } 
    }

    public void PlayAgain() {
    num = UnityEngine.Random.Range(0, 100);
        text.text = "Guess a number between 0 and 100";
        text.alignment = TextAlignmentOptions.Center;
        ctr = 0;
        btn.SetActive(false);
        isEqual = false;
        isLess = false;
        isGreat = false;
    }
}
