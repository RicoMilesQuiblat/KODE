using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordAttack : MonoBehaviour
{
   
   
    public Collider2D swordCollider;
    public float damage = 3f;
    public float knockbackForce = 500f;

    public Scene currentScene;
    private void Start(){
       currentScene = SceneManager.GetActiveScene();
    }

    
    public void AttackRight() {
        Debug.Log("Right");
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(0.49f , 0);
        // StartCoroutine(StopAttackAfterDuration());

    }
    public void AttackLeft() {
        Debug.Log("Left");
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(0.49f * -1 , 0);
        // StartCoroutine(StopAttackAfterDuration());
    }
    public void AttackUp() {
        Debug.Log("Up");
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(-0.02f , -0.56f * -1);
        // StartCoroutine(StopAttackAfterDuration());
    }
    public void AttackDown() {
        Debug.Log("Down");
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(-0.02f, -0.56f);
        // StartCoroutine(StopAttackAfterDuration());
    }

    public void StopAttack(){
        swordCollider.enabled = false;
    }

    // private IEnumerator StopAttackAfterDuration()
    // {
    //     yield return new WaitForSeconds(0.2f);
    //     StopAttack();
    // }

    // private void OnCollisionEnter2D(Collision2D col){
    //     if(col.collider.tag == "enemy"){
    //         Debug.Log("ouch");
    //          EnemyController enemy = col.collider.GetComponent<EnemyController>();

    //         if(enemy != null){
    //             Debug.Log("ouch");
    //              enemy.Health -= damage;
    //              Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
    //              Vector2 direction = (Vector2) (parentPosition - col.gameObject.transform.position).normalized;
    //              Vector2 knockback = direction * knockbackForce;
    //              enemy.GetHit(knockback);
    //          }
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other){
        if(currentScene.buildIndex == 0){
            damage = 3f;
        }else if(currentScene.buildIndex == 1){
            damage = 4f;
        }else if(currentScene.buildIndex == 2){
            damage = 5f;
        }
        if(other.tag == "enemy"){
            Debug.Log("ouch");
            EnemyController enemy = other.GetComponent<EnemyController>();

            if(enemy != null){
                Debug.Log("ouch");
                  enemy.Health -= damage;
                  Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
                  Vector2 direction = (Vector2) (parentPosition - other.gameObject.transform.position).normalized;
                  Vector2 knockback = direction * knockbackForce;
                  enemy.GetHit(knockback * -1);
              }
        }
    }
    
}
