using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter3StartController : MonoBehaviour
{
   
    [SerializeField] private GameObject chapter2Start;
   
    [SerializeField] private GameObject cutscene4;
     [SerializeField] private ObjectivesController objectivesController;
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            StartCoroutine(StartChapter2());
        }
    }

    private IEnumerator StartChapter2(){
        
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        
    }
}
