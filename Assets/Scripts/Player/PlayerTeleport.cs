using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private bool insideMaze = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            if(currentTeleporter!=null && currentTeleporter.GetComponent<Teleporter_Anim>().GetDestination().position !=null){
                transform.position = currentTeleporter.GetComponent<Teleporter_Anim>().GetDestination().position;
                if(insideMaze == true){
                    insideMaze = false;
                }else if(insideMaze == false){
                    insideMaze = true;
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
    public bool CheckIfInside(){
        return insideMaze;
    }
}
