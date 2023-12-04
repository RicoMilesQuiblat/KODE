using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze_IF_Anim : MonoBehaviour
{
    private Animator animator;
    private bool isPlayerInTrigger = false; 

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
       
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
           
            bool isOn = animator.GetBool("isOn");
            animator.SetBool("isOn", !isOn); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {   
            TipPopout.Create(transform.position, "Toggle 'E'", 30f, new Color(1, 1, 1));
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
