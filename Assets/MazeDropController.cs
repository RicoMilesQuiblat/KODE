using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDropController : MonoBehaviour
{
    public GameObject mazeEntrance;
    
    // Update is called once per frame
    public void DropMaze(Vector2 dropPosition){
            if(!CheckIsActive()){
            mazeEntrance.SetActive(true);
            mazeEntrance.transform.position = dropPosition;
            }
            
        
    }

    public bool CheckIsActive(){
        return mazeEntrance.activeSelf;
    }
}
