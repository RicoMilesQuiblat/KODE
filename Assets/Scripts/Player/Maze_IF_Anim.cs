using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Maze_IF_Anim : MonoBehaviour
{
    private Animator animator;
    private bool isPlayerInTrigger = false; 
    public bool isOn = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
       
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if(isOn){
                TipPopout.Create(transform.position, "True (Press E for False)", 10f, new Color(135, 206, 235),2);
            }else{
                TipPopout.Create(transform.position, "False (Press E for True)", 10f, new Color(1, 0, 0),2);

            }
            isOn = animator.GetBool("isOn");
            animator.SetBool("isOn", !isOn); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {   
            if(!isOn){
                TipPopout.Create(transform.position, "True (Press E for False)", 10f, new Color(1, 1, 1),2);
            }else{
                TipPopout.Create(transform.position, "False (Press E for True)", 10f, new Color(1, 1, 1),2);

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
