using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
   public void DieAndSpawn(GameObject enemy, Vector2 startPosition, bool willRespawn){
        enemy.SetActive(false);
        if(willRespawn){
            enemy.transform.position = startPosition;
            StartCoroutine(Respawn(enemy));
        }   
   }

    private IEnumerator Respawn(GameObject enemy){
        
        yield return new WaitForSeconds(10f);
        enemy.SetActive(true);
    }
}
