using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAreaHandler1 : MonoBehaviour
{
    
    [SerializeField] GameObject objectToActivate;
    [SerializeField] GameObject objectToActivate1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player (you can add a tag or layer check here).
        if (collision.CompareTag("Player"))
        {
             if (objectToActivate != null && objectToActivate1 != null)
                {
                    objectToActivate.SetActive(false);
                    objectToActivate1.SetActive(false);

                }
            
        }
    }
}
