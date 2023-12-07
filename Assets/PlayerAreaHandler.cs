using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAreaHandler : MonoBehaviour
{
    private int passCount = 0;
    public int passesRequired = 3; // Set this to the number of passes required.
    [SerializeField] GameObject objectToActivate;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player (you can add a tag or layer check here).
        if (collision.CompareTag("Player"))
        {
            passCount++;

            // Check if the required number of passes has been reached.
            if (passCount >= passesRequired)
            {
                

                // Activate the object if found.
                if (objectToActivate != null)
                {
                    objectToActivate.SetActive(true);
                }
            }
        }
    }
}
