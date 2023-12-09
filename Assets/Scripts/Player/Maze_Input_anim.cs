using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Maze_Input_anim : MonoBehaviour
{
    public TextMeshProUGUI textmesh1;
    private Animator animator;
    [SerializeField] private InGameUiController ui1 ;
    private bool isPlayerInTrigger = false;
    public bool isOn = false;
    public delegate void LeverStateChanged(bool newState);
    public static event LeverStateChanged OnLeverStateChanged;

    private string inputText = ""; // Variable to store input text

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (!isOn)
            {
                
                ShowInputField();
            }
            ToggleLever();

            Debug.Log(isOn);
        }
    }

    private void ToggleLever()
    {
        isOn = !isOn;
        animator.SetBool("isOn", isOn);

        OnLeverStateChanged?.Invoke(isOn);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {   
            TipPopout.Create(transform.position,"E to input", 8, new Color(1,1,1), 1);
            isPlayerInTrigger = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Logic for exiting trigger
            // ...
            isPlayerInTrigger = false; 
        }
    }

    private void ShowInputField()
    {
        ui1.mazeinputscreen4();
        
    }

    public void ReceiveInputText(string text)
    {
        inputText = text;
        Debug.Log("Received Input: " + inputText);
        textmesh1.text = inputText;

        ui1.mazeinputscreenCLOSE4();
        

    }

    // Optionally, a method to get the saved input text
    public string GetInputText()
    {
        return inputText;
    }
}
