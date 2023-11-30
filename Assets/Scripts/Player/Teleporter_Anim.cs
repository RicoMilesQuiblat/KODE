
using UnityEngine;

public class Teleporter_Anim : MonoBehaviour
{
    private Animator animator;
    

    [SerializeField] private Transform destination;

    public Transform GetDestination(){
        return destination;
    }
    private void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    // Called when another collider enters the trigger area
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // You can use a tag or layer to identify your player
        {   
            TipPopout.Create(transform.position, "Press 'E'");
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
