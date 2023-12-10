
using System.Data.Common;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Teleporter_Anim : MonoBehaviour
{
    private Animator animator;
    

    private Transform destination;
    private bool shouldExit = false;
    [SerializeField] private Transform destination1;
    [SerializeField] private Transform destination2;
    [SerializeField] private Transform destination3;
    [SerializeField] private Transform destination4;
    [SerializeField] private Transform exit;
    
    [SerializeField] private JournalController journalController;

    [SerializeField] private PlayerTeleport playerTeleport;
    
    
    [SerializeField] private bool trigger = false;
    [SerializeField] private bool instant = false;

    public Transform GetDestination(){
        if(trigger){
            return destination;
        }else{
            return null;
        }
        
    }
    private void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    // Called when another collider enters the trigger area
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(playerTeleport.CheckIfInside()){
            destination = exit;
        }else{

            if(journalController.GetJournalCount() == 1){
                destination = destination1;
            }else if(journalController.GetJournalCount() == 2){
                destination = destination2;
            }else if(journalController.GetJournalCount() == 3){
                destination = destination3;
            }else if(journalController.GetJournalCount() == 4){
                destination = destination4;
            }   
        }
        if (other.CompareTag("Player")) // You can use a tag or layer to identify your player
        {   
            if(trigger){
                TipPopout.Create(transform.position, "Teleport(E)",8f, new Color(1, 1, 1),1);
            }
            
            // Start the animation
            animator.SetBool("IsPlayerOnSprite", true);
        }
        else
        {
            
            animator.SetBool("IsPlayerOnSprite", false);
        }
    }

    // Called when another collider exits the trigger area
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop the animation
            animator.SetBool("IsPlayerOffSprite", true);
        }
        else
        {
            animator.SetBool("IsPlayerOffSprite", false);
        }
    }

}
