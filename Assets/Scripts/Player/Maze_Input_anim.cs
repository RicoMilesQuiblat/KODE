using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class Maze_Input_anim : MonoBehaviour
{
    public TextMeshProUGUI textmesh1;
    private Animator animator;
    [SerializeField] private InGameUiController ui1 ;
    private bool isPlayerInTrigger = false;
    public bool isOn = false;
    public delegate void LeverStateChanged(bool newState);
    public static event LeverStateChanged OnLeverStateChanged;
    [SerializeField] private GameObject block1;
    [SerializeField] private GameObject cloud1,cloud3;
    [SerializeField] private GameObject block2;
    [SerializeField] private GameObject block3;

    [SerializeField] private GameObject cloud2;

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
        if(float.Parse(inputText)>32){
            if(cloud1 && block1){
                block1.SetActive(false);
                cloud1.SetActive(false);
            }
            
            if(cloud3 && block3){
                cloud3.SetActive(false);
                block3.SetActive(false);
            }
            if(cloud2 && block2){
                block2.SetActive(true);
                cloud2.SetActive(true);
            }
            
            
        }else{
            if(block1 && cloud1){
                block1.SetActive(false);
                cloud1.SetActive(false);
            }
            if(block2 && cloud2){
                block2.SetActive(false);
                cloud2.SetActive(false);
            }
            
            if(cloud3 && block3){
                cloud3.SetActive(true);
                block3.SetActive(true);
            }


        }
            

        
        ui1.mazeinputscreenCLOSE4();
        

    }

    // Optionally, a method to get the saved input text
    public string GetInputText()
    {
        return inputText;
    }

    
}
