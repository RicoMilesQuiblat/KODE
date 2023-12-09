using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    // Start is called before the first frame update

    private int remainingLives = 3;
    public List<GameObject> lives = new List<GameObject>();
    public void Start(){
        remainingLives = 3;
        for(int i = 0; i < lives.Count; i++){
            lives[i].SetActive(true);
        }
    }
   public void RemoveLives(){
        lives[remainingLives - 1].SetActive(false);
        remainingLives -= 1;
   }

}
