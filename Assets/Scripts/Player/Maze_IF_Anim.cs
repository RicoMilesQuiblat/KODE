using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Maze_IF_Anim : MonoBehaviour
{
    private Animator animator;
    private bool isPlayerInTrigger = false;
    public bool isOn = false;
    public delegate void LeverStateChanged(bool newState);
    public static event LeverStateChanged OnLeverStateChanged;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if(!isOn){
                TipPopout.Create(transform.position, "True (Press E for False)", 10f, new Color(0, 0, 1),1);
            }else{
                TipPopout.Create(transform.position, "False (Press E for True)", 10f, new Color(1, 0, 0),1);
            }
            ToggleLever();

            Debug.Log(isOn);
        }
    }

    private void ToggleLever()
    {
        isOn = !isOn;
        animator.SetBool("isOn", isOn);

        // Trigger the event to notify other scripts of the lever state change
        OnLeverStateChanged?.Invoke(isOn);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {   
            if(!isOn){
                TipPopout.Create(transform.position, "True (Press E for False)", 10f, new Color(1, 1, 1),1);
            }else{
                TipPopout.Create(transform.position, "False (Press E for True)", 10f, new Color(1, 1, 1),1);

            }
            
            isPlayerInTrigger = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false; 
        }
    }
}
