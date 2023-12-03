using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> lives = new List<GameObject>();
    private void Start(){
        for(int i = 0; i < lives.Count; i++){
            lives[i].SetActive(true);
        }
    }
   public void RemoveLives(){
        lives[lives.Count - 1].SetActive(false);
        lives.Remove(lives[lives.Count - 1]);
   }

}
