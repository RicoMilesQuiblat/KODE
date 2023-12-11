using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterBoss : MonoBehaviour
{
    [SerializeField] private GameObject afterMazeCollider;

    public void StartAfterBoss(){
        StartCoroutine(spawnAfterMazeCollider());
    }
   private IEnumerator spawnAfterMazeCollider(){
        Debug.Log("kapoy");
        yield return new WaitForSeconds(2f);
         Debug.Log("kapoy");
        afterMazeCollider.SetActive(true);

    }
}
