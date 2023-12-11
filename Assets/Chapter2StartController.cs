using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2StartController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject chapter2Start;
    [SerializeField] private GameObject goblins;
    [SerializeField] private GameObject cutscene4;
     [SerializeField] private ObjectivesController objectivesController;
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Player"){
            StartCoroutine(StartChapter2());
        }
    }

    private IEnumerator StartChapter2(){
        chapter2Start.SetActive(true);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        chapter2Start.SetActive(false);
        cutscene4.SetActive(true);
        goblins.SetActive(true);
        gameObject.SetActive(false);
    }
}
