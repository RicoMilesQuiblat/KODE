using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    [SerializeField] private GameObject teleporter;
    [SerializeField] private bool shouldRemove = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(currentTeleporter!=null && currentTeleporter.GetComponent<Teleporter_Anim>().GetDestination().position !=null){
                transform.position = currentTeleporter.GetComponent<Teleporter_Anim>().GetDestination().position;
                if(shouldRemove){
                    teleporter.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Teleporter")){
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Teleporter")){
            if(collision.gameObject == currentTeleporter){
                currentTeleporter = null;
            }
        }
    }

    public void setShouldRemove(bool set){
        shouldRemove = set;
    }
 
}
